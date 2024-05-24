using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using DataLibrary.BusinessLogic;
using DataLibrary.DataAccess;
namespace optimization.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public string message;
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            bool isRegistered = EmployeeProcessor.isRegistered(Credential.Email, Credential.Password);

            // Verify the credential
            if (isRegistered)
            {
                // Creating the security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, Credential.Email),
                    new Claim(ClaimTypes.Name, Credential.Email),
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            this.message = "Email/Password is invaild!";
            try
            {
                SqlDataAccess.Excute(String.Format(
                    @"INSERT INTO dbo.LoginFailures
                      VALUES ('{0}', '{1}', '{2}');", Credential.Email, Credential.Password, DateTime.Now
                ));
            }
            catch{

            }
            return Page();
        }
    }
    public class Credential
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
