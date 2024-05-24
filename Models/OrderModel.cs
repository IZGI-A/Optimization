using System.ComponentModel.DataAnnotations;
#nullable disable

namespace optimization.Models
{
    public class OrderModel
    {
        [Display(Name = "Order ID")]
        public int? ID { get; set; }

        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Product Amount")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a postive value")]
        [Required(ErrorMessage = "You need to provide a vaild product amount")]
        public int NumberOfProducts { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Display(Name = "Courier Company")]
        [StringLength(64)]
        [Required(ErrorMessage = "You need to provide a vaild courier company")]
        public string CourierCompany { get; set; }

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "You need to provide a vaild order date")]
        public DateTime Date { get; set; }
    }
}
