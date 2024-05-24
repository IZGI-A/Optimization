using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using optimization.Models;
#nullable disable
namespace optimization.Pages.Employee
{
    [ValidateAntiForgeryToken]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public EmployeeModel Employee { get; set; }
        public List<SelectListItem> BranchIDs { get; set; }

        public string message;
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
                if (EmployeeProcessor.DoesExist(Employee.Email))
                {
                    message = "This Email Already Exists!";
                }
                else
                {
                    EmployeeProcessor.CreateEmployee(Employee.Password, Employee.Email, Employee.BranchID);

                    return RedirectToPage("/Employee/Index");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnGetIndex()
        {
            return RedirectToPage("/Employee/Index");
        }
    }
}
