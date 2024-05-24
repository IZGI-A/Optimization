using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable
namespace optimization.Pages.Customer
{
    [ValidateAntiForgeryToken]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CustomerModel Customer { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                CustomerProcessor.CreateCustomer(Customer.Name, Customer.Surname, Customer.Address, Customer.PhoneNumber);

                return RedirectToPage("/Customer/Index");

            }
            return Page();
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Customer/Index");
        }
    }
}
