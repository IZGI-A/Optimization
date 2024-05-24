using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable

namespace optimization.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public EmployeeModel Employee { get; set; }
        public BranchModel Branch { get; set; }

        public void OnGet(int id, int branchID)
        {
            var employee = EmployeeProcessor.LoadEmployee(id);

            Employee = new EmployeeModel
            {
                ID = employee.ID,
                BranchID = employee.BranchID,
                Email = employee.Email,
            };

            var branch = BranchProcessor.LoadBranch(branchID);

            Branch = new BranchModel
            {
                ID = branch.ID,
                Name = branch.Name,
                Address = branch.Address,
                PhoneNumber = branch.PhoneNumber,
            };

        }
        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Employee/Index");
        }
        public async Task<IActionResult> OnGetEdit(int id)
        {
            return RedirectToPage("/Employee/Edit", new { id = id });
        }
    }
}
