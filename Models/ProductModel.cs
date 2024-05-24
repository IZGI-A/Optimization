using System.ComponentModel.DataAnnotations;
#nullable disable

namespace optimization.Models
{
    public class ProductModel
    {
        [Display(Name = "Product ID")]
        public int? ID { get; set; }

        [Display(Name = "Branch ID")]
        public int? BranchID { get; set; }

        [Display(Name = "Product Name")]
        [StringLength(64)]
        [Required(ErrorMessage = "You need to provide a vaild name")]
        public string Name { get; set; }

        [Display(Name = "Product Price")]
        [Range(0, Double.MaxValue, ErrorMessage = "Please enter a postive value")]
        [Required(ErrorMessage = "You need to provide a vaild price")]
        public double Price { get; set; }

        [Display(Name = "Stock Amount")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a postive value")]
        public int? Amount { get; set; }
    }
}
