using System.ComponentModel.DataAnnotations;

namespace e_CommerceApp_Assignment_7.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, uint.MaxValue, ErrorMessage = "{0} should be a number between {1} and {2}")]
        public int? ProductCode { get; set; }
        
        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be a number between {1} and {2}")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, uint.MaxValue, ErrorMessage = "{0} should be a number between {1} and {2}")]
        public int? Quantity { get; set; }
    }
}
