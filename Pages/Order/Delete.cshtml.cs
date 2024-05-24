using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable
namespace optimization.Pages.Order
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public OrderModel Order { get; set; }

        public void OnGet(int id, int productID, int customerID)
        {
            var order = ProductOrder.LoadOrder(id, productID, customerID);

            Order = new OrderModel
            {
                ID = id,
                CustomerID = customerID,
                ProductID = productID,
                CourierCompany = order.CourierCompany,
                Date = order.Date,
                NumberOfProducts = order.NumberOfProducts,
            };
        }

        public async Task<IActionResult> OnPost()
        {
            ProductOrder.DeleteOrder(Order.ID.Value);

            return RedirectToPage("/Order/Index");
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Order/Index");
        }
    }
}
