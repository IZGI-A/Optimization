using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable
namespace optimization.Pages.Order
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }
        public CustomerModel Customer { get; set; }

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

            var product = ProductProcessor.LoadProduct(id);

            Product = new ProductModel
            {
                Name = product.Name,
                Price = product.Price,
            };

            var customer = CustomerProcessor.LoadCustomer(id);

            Customer = new CustomerModel
            {
                Name = customer.Name,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
            };

        }
        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Order/Index");
        }
        public async Task<IActionResult> OnGetEdit(int id, int productID, int customerID)
        {
            return RedirectToPage("/Order/Edit", new { id = id, productID = productID, customerID = customerID });
        }
    }
}
