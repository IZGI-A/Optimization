using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Authorization;

#nullable disable

namespace optimization.Pages.Branch
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public BranchModel Branch { get; set; }
        public List<BranchModel> Branches { get; set; }
        public void OnGet()
        {
            var list = BranchProcessor.LoadBranches();
            List<BranchModel> branches = new List<BranchModel>();

            foreach(var item in list)
            {
                branches.Add(new BranchModel
                {
                    ID = item.ID,
                    Name = item.Name,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                });
            }
            Branches = branches;
        }
        public async Task<IActionResult> OnGetCreate()
        {
            return RedirectToPage("/Branch/Create");
        }
        public async Task<IActionResult> OnGetEdit(int id)
        {
            return RedirectToPage("/Branch/Edit", new { id = id });
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            return RedirectToPage("/Branch/Delete", new { id = id });
        }
        public async Task<IActionResult> OnGetDetails(int id)
        {
            return RedirectToPage("/Branch/Details", new { id = id });
        }
    }
}
