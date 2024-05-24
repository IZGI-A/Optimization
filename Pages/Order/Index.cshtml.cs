using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Authorization;

#nullable disable
namespace optimization.Pages.Order
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public OrderModel Order { get; set; }
        public List<OrderModel> Orders { get; set; }
        public void OnGet()
        {
            var list = ProductOrder.LoadOrders();
            List<OrderModel> orders = new List<OrderModel>();

            foreach (var item in list)
            {
                orders.Add(new OrderModel
                {
                    ID = item.ID,
                    ProductID = item.ProductID,
                    NumberOfProducts = item.NumberOfProducts,
                    CustomerID = item.CustomerID,
                    CourierCompany = item.CourierCompany,
                    Date=item.Date,
                });
            }
            Orders = orders;
        }
        public async Task<IActionResult> OnGetCreate()
        {
            return RedirectToPage("/Order/Create");
        }
        public async Task<IActionResult> OnGetEdit(int id, int productID, int customerID)
        {
            return RedirectToPage("/Order/Edit", new { id = id, productID = productID, customerID = customerID});
        }

        public async Task<IActionResult> OnGetDelete(int id, int productID, int customerID)
        {
            return RedirectToPage("/Order/Delete", new { id = id, productID = productID, customerID = customerID });
        }
        public async Task<IActionResult> OnGetDetails(int id, int productID, int customerID)
        {
            return RedirectToPage("/Order/Details", new { id = id, productID = productID, customerID = customerID });
        }
    }
}
