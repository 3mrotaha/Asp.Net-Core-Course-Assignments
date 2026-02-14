using e_CommerceApp_Assignment_7.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace e_CommerceApp_Assignment_7.CustomValidators
{
    public class InvoiceMatchTotalCost : ValidationAttribute
    {
        public string Other { get; set; }
        public InvoiceMatchTotalCost(string other)
        {
            Other = other;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null && value is double invoicePrice)
            {
                PropertyInfo? other = validationContext.ObjectType.GetProperty(Other);
                if (other != null)
                {
                    List<Product> products = other.GetValue(validationContext.ObjectInstance) as List<Product> ?? new List<Product>();
                    var totalPrice = products.Sum(p => p.Price * p.Quantity);

                    if (totalPrice != invoicePrice)
                    {
                        return new ValidationResult("InvoicePrice doesn't match with the total cost of the specified products in the order.");
                    }


                    return ValidationResult.Success;
                }
            }

            return null;
        }
    }
}
