using System.ComponentModel.DataAnnotations;

namespace optimization.Models
{
    public class ShipmentModel
    {
        [Display(Name = "Cargo ID")]
        public int CargoID { get; set; }

        [Display(Name = "Courier Company")]
        [StringLength(64)]
        [Required(ErrorMessage = "You need to provide a vaild courier company")]
        public string CourierCompany { get; set; }
    }
}
