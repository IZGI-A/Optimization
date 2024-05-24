using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLibrary.BusinessLogic;
#nullable disable
namespace optimization.Pages.Account
{
    public class IndexModel : PageModel
    {
        [BindProperty]

        public Models.EmployeeModel Employee { get; set; }
        public List<SelectListItem> BranchIDs { get; set; }
        public List<LoginFailures> Data { get; set; }
        public string message;
        public void OnGet()
        {
            var employee = SqlDataAccess.LoadInstance<EmployeeModel>(String.Format(
                    @"SELECT *
                      FROM dbo.Employees
                      WHERE Email = '{0}'
                      ;", @User.Identity.Name
                ));
            Employee = new Models.EmployeeModel
            {
                ID = employee.ID,
                BranchID = employee.BranchID,
                Email = employee.Email,
            };

            Data = SqlDataAccess.LoadData<LoginFailures>(String.Format(
                   @"SELECT *
                      FROM dbo.LoginFailures
                      WHERE EmployeeEmail = '{0}'
                      ORDER BY Time DESC;", @User.Identity.Name
               ));

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
                if (EmployeeProcessor.DoesExist(Employee.Email))
                {
                    message = "This Email Already Exists!";
                }
                else
                {
                    EmployeeProcessor.UpdateEmployee(Employee.ID.Value, Employee.Password, Employee.Email, Employee.BranchID);

                    return RedirectToPage("/Account/Index");
                }
            }
            return RedirectToPage("/Account/Index");
        }
    }
}
