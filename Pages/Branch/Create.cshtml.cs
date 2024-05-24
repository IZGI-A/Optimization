using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable

namespace optimization.Pages.Branch
{
    [ValidateAntiForgeryToken]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public BranchModel Branch { get; set; }

        public void OnGet()
        {


        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                BranchProcessor.CreateBranch(Branch.Address, Branch.Name, Branch.PhoneNumber);

                return RedirectToPage("/Branch/Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Branch/Index");
        }
    }
}
