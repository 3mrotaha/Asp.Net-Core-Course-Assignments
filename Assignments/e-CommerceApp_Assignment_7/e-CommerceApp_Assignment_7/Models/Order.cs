using System.ComponentModel.DataAnnotations;
using e_CommerceApp_Assignment_7.CustomValidators;
namespace e_CommerceApp_Assignment_7.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [DateLimit(minYear:2000, minMonth:1, minDay:1)]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "{0} Can't be null or empty, add at least 1 product")]
        [MinLength(1)]
        public ICollection<Product>? Products { get; set; } = new List<Product>();

        [Required(ErrorMessage = "{0} can't be blank")]
        [InvoiceMatchTotalCost("Products")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be a number between {1} and {2}")]
        public double? InvoicePrice { get; set; }
    }
}
