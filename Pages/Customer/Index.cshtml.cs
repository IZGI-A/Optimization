using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Authorization;

#nullable disable

namespace optimization.Pages.Customer
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CustomerModel Customer { get; set; }
        public List<CustomerModel> Customers { get; set; }
        public void OnGet()
        {
            var list = CustomerProcessor.LoadCustomers();
            List<CustomerModel> customers = new List<CustomerModel>();

            foreach (var item in list)
            {
                customers.Add(new CustomerModel
                {
                    ID = item.ID,
                    Name = item.Name,
                    Surname = item.Surname,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                });
            }
            Customers = customers;
        }
        public async Task<IActionResult> OnGetCreate()
        {
            return RedirectToPage("/Customer/Create");
        }
        public async Task<IActionResult> OnGetEdit(int id)
        {
            return RedirectToPage("/Customer/Edit", new { id = id });
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            return RedirectToPage("/Customer/Delete", new { id = id });
        }
        public async Task<IActionResult> OnGetDetails(int id)
        {
            return RedirectToPage("/Customer/Details", new { id = id });
        }
    }
}
