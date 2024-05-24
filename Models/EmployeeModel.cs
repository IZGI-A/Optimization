using System.ComponentModel.DataAnnotations;
#nullable disable

namespace optimization.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID")]
        public int? ID { get; set; }

        [Display(Name = "Branch ID")]
        public int BranchID { get; set; }

        [Display(Name = "Employee Email")]
        [StringLength(64)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to provide a vaild email")]
        public string Email { get; set; }

        [StringLength(10)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You need to provide a vaild password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [StringLength(10)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You need to provide a vaild confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
