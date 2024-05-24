using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable

namespace optimization.Pages.Branch
{
    public class DeleteModel : PageModel
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
            BranchProcessor.DeleteBranch(Branch.ID.Value);

            return RedirectToPage("/Branch/Index");
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Branch/Index");
        }
    }
}
