using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using optimization.Models;
#nullable disable
namespace optimization.Pages.Order
{
    [ValidateAntiForgeryToken]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public OrderModel Order { get; set; }

        public List<SelectListItem> ProductIDs { get; set; }

        public List<SelectListItem> CustomerIDs { get; set; }

        public void OnGet()
        {
            var productIDs = ProductProcessor.LoadIDs();
            ProductIDs = new List<SelectListItem>();

            foreach (var ID in productIDs)
            {
                ProductIDs.Add(new SelectListItem { Value = ID.ToString(), Text = ID.ToString() });
            }

            var customerIDs = CustomerProcessor.LoadIDs();
            CustomerIDs = new List<SelectListItem>();

            foreach (var ID in customerIDs)
            {
                CustomerIDs.Add(new SelectListItem { Value = ID.ToString(), Text = ID.ToString() });
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ProductOrder.CreateOrder(Order.NumberOfProducts, Order.ProductID, Order.CustomerID, Order.CourierCompany, Order.Date);

                return RedirectToPage("/Order/Index");

            }
            return Page();
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Order/Index");
        }
    }
}
