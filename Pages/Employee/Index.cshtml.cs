using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
using DataLibrary.BusinessLogic;
#nullable disable

namespace optimization.Pages.Employee
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public EmployeeModel Employee { get; set; }
        public List<EmployeeModel> Employees { get; set; }

        

        public void OnGet()
        {
            var list = EmployeeProcessor.LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var item in list)
            {
                employees.Add(new EmployeeModel
                {
                    ID = item.ID,
                    BranchID = item.BranchID,
                    Email = item.Email,
                    Password = item.Password,
                });
            }
            Employees = employees;
        }

        public async Task<IActionResult> OnGetCreate()
        {
            return RedirectToPage("/Employee/Create");
        }

        public async Task<IActionResult> OnGetEdit(int id)
        {
            return RedirectToPage("/Employee/Edit", new { id = id });
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            return RedirectToPage("/Employee/Delete", new { id = id });
        }

        public async Task<IActionResult> OnGetDetails(int id, int branchID)
        {
            return RedirectToPage("/Employee/Details", new { id = id, branchID = branchID });
        }
    }
}
