using System.ComponentModel.DataAnnotations;
#nullable disable

namespace optimization.Models
{
    public class CustomerModel
    {
        [Display(Name = "Customer ID")]
        public int? ID { get; set; }

        [Display(Name = "Customer Name")]
        [StringLength(64)]
        [Required(ErrorMessage = "You need to provide a vaild name")]
        public string Name { get; set; }

        [Display(Name = "Customer Surname")]
        [StringLength(64)]
        [Required(ErrorMessage = "You need to provide a vaild surname")]
        public string Surname { get; set; }

        [Display(Name = "Customer Address")]
        [StringLength(256)]
        [Required(ErrorMessage = "You need to provide a vaild address")]
        public string Address { get; set; }

        [Display(Name = "Customer Phone Number")]
        [StringLength(11)]
        [MinLength(11, ErrorMessage = "Please provide an 11 digit phone number")]
        [Required(ErrorMessage = "You need to provide a vaild phone number")]
        public string PhoneNumber { get; set; }
    }
}
