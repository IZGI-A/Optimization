using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using optimization.Models;
#nullable disable
namespace optimization.Pages.Employee
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public EmployeeModel Employee { get; set; }
        public string message;

        public void OnGet(int id)
        {
            var employee = EmployeeProcessor.LoadEmployee(id);

            Employee = new EmployeeModel
            {
                ID = employee.ID,
                BranchID = employee.BranchID,
                Email = employee.Email,
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if(Employee.Email == @User.Identity.Name)
            {
                this.message = "You cannot delete this employee. He is correctly working!";
                return Page();
            }
            else
            {
                EmployeeProcessor.DeleteEmployee(Employee.ID.Value);

                return RedirectToPage("/Employee/Index");
            }
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Employee/Index");
        }
    }
}
