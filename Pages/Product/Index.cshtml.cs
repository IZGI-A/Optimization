using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Authorization;

#nullable disable


namespace optimization.Pages.Product
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public ProductModel Product { get; set; }
        public List<ProductModel> Products { get; set; }
        public void OnGet()
        {
            var list = BranchProduct.LoadProducts();
            List<ProductModel> products = new List<ProductModel>();

            foreach (var item in list)
            {
                products.Add(new ProductModel
                {
                    ID = item.ID, 
                    BranchID = item.BranchID,
                    Name = item.Name,
                    Price = item.Price,
                    Amount = item.Amount,
                });
            }
            Products = products;
        }
        public async Task<IActionResult> OnGetCreate()
        {
            return RedirectToPage("/Product/Create");
        }
        public async Task<IActionResult> OnGetEdit(int id, int branchID)
        {
            return RedirectToPage("/Product/Edit", new { id = id, branchID = branchID });
        }

        public async Task<IActionResult> OnGetDelete(int id, int branchID)
        {
            return RedirectToPage("/Product/Delete", new { id = id, branchID = branchID });
        }
        public async Task<IActionResult> OnGetDetails(int id, int branchID)
        {
            return RedirectToPage("/Product/Details", new { id = id, branchID = branchID });
        }
    }
}
