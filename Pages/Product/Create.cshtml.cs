using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using optimization.Models;
#nullable disable

namespace optimization.Pages.Product
{
    [ValidateAntiForgeryToken]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ProductModel Product { get; set; }
        public List<SelectListItem> BranchIDs { get; set; }
        public void OnGet()
        {
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
                BranchProduct.CreateProduct(Product.Name, Product.Price, Product.Amount.Value, Product.BranchID.Value);

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
