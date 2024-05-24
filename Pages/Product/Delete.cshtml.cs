using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable

namespace optimization.Pages.Product
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public ProductModel Product { get; set; }
        public void OnGet(int id, int branchID)
        {

            var product = BranchProduct.LoadProduct(id, branchID);
            Product = new ProductModel
            {
                ID = product.ID,
                BranchID = product.BranchID,
                Name = product.Name,
                Amount = product.Amount,
                Price = product.Price,
            };
        }

        public async Task<IActionResult> OnPost()
        {
            BranchProduct.DeleteProduct(Product.ID.Value, Product.BranchID.Value);

            return RedirectToPage("/Product/Index");
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Product/Index");
        }
    }
}
