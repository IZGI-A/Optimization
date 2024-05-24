using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using optimization.Models;
using System.Net;
#nullable disable
namespace optimization.Pages.Account
{
    [ValidateAntiForgeryToken]
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public EmployeeModel Employee { get; set; }
        public string message;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (EmployeeProcessor.DoesExist(Employee.Email))
                { 
                    message = "This Email Already Exists!";
                }
                else
                {
                    EmployeeProcessor.CreateEmployee(Employee.Password, Employee.Email);

                    return RedirectToPage("/Account/Login");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Employee/Index");
        }
    }
}