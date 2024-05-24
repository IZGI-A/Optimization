using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable

namespace optimization.Pages.Product
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public ProductModel Product { get; set; }
        public BranchModel Branch { get; set; }

        public void OnGet(int id, int branchID)
        {
            var product = BranchProduct.LoadProduct(id, branchID);
            Product = new ProductModel
            {
                ID = id,
                BranchID = branchID,
                Name = product.Name,
                Amount = product.Amount,
                Price = product.Price,
            };

            var branch = BranchProcessor.LoadBranch(branchID);
            Branch = new BranchModel
            {
                Name = branch.Name,
                PhoneNumber = branch.PhoneNumber,
                Address = branch.Address,
            };

        }
        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Product/Index");
        }
        public async Task<IActionResult> OnGetEdit(int id, int branchID)
        {
            return RedirectToPage("/Product/Edit", new { id = id, branchID = branchID });
        }
    }
}
