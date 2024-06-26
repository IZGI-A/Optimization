using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable
namespace optimization.Pages.Customer
{
    [AutoValidateAntiforgeryToken]
    public class EditModel : PageModel
    {
        [BindProperty]
        public CustomerModel Customer { get; set; }

        public void OnGet(int id)
        {
            var customer = CustomerProcessor.LoadCustomer(id);

            Customer = new CustomerModel
            {
                ID = customer.ID,
                Name = customer.Name,
                Surname = customer.Surname,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
            };

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                CustomerProcessor.UpdateCustomer(Customer.ID.Value, Customer.Name, Customer.Surname, Customer.Address, Customer.PhoneNumber);

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
