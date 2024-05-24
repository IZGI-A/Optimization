using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using optimization.Models;
#nullable disable
namespace optimization.Pages.Employee
{
    [ValidateAntiForgeryToken]
    public class EditModel : PageModel
    {
        [BindProperty]
        public EmployeeModel Employee { get; set; }
        public List<SelectListItem> BranchIDs { get; set; }
        public void OnGet(int id)
        {
            var employee = EmployeeProcessor.LoadEmployee(id);

            Employee = new EmployeeModel
            {
                ID = employee.ID,
                BranchID = employee.BranchID,
                Email = employee.Email,
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
                EmployeeProcessor.UpdateEmployee(Employee.ID.Value, Employee.Password, Employee.Email, Employee.BranchID);

                return RedirectToPage("/Employee/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Employee/Index");
        }
    }
}
