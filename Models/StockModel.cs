using System.ComponentModel.DataAnnotations;

namespace optimization.Models
{
    public class StockModel
    {
        [Display(Name = "Stock ID")]
        public int StockID { get; set; }

        [Display(Name = "Stock Amount")]
        [Required(ErrorMessage = "You need to provide a vaild amount")]
        public int Amount { get; set; }
    }
}
