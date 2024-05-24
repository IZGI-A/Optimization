using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using optimization.Models;
#nullable disable

namespace optimization.Pages.Product
{
    [ValidateAntiForgeryToken]
    public class EditModel : PageModel
    {
        [BindProperty]
        public ProductModel Product { get; set; }
        public List<SelectListItem> BranchIDs { get; set; }
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

            var ids = BranchProcessor.LoadIDs();
            BranchIDs = new List<SelectListItem>();

            foreach (var ID in ids)
            {
                BranchIDs.Add(new SelectListItem { Value = ID.ToString(), Text = ID.ToString() });
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                BranchProduct.UpdateProduct(Product.ID.Value, Product.BranchID.Value, Product.Name, Product.Price, Product.Amount.Value);

                return RedirectToPage("/Product/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Product/Index");
        }
    }
}
