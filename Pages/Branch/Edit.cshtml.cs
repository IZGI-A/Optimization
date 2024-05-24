using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable

namespace optimization.Pages.Branch
{
    [ValidateAntiForgeryToken]
    public class EditModel : PageModel
    {
        [BindProperty]
        public BranchModel Branch { get; set; }
        public void OnGet(int id)
        {
            var branch = BranchProcessor.LoadBranch(id);

            Branch = new BranchModel
            {
                ID = branch.ID,
                Name = branch.Name,
                Address = branch.Address,
                PhoneNumber = branch.PhoneNumber,
            };

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                BranchProcessor.UpdateBranch(Branch.ID.Value, Branch.Name, Branch.Address, Branch.PhoneNumber);

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
