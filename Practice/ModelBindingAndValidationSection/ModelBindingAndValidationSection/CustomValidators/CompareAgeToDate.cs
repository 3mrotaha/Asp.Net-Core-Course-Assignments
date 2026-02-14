using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBindingAndValidationSection.CustomValidators
{
    public class CompareAgeToDate : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public string DefaultErrorMessage { get; set; } = "{0} isn't matching with the {1} = {2}";
        public CompareAgeToDate(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && value is int personAge)
            {
                // get the other property through reflection
                PropertyInfo? otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherPropertyName); // got the info
                if(otherPropertyInfo != null)
                {
                    DateTime dateOfBirth = Convert.ToDateTime(otherPropertyInfo.GetValue(validationContext.ObjectInstance)); // got the value
                    double years = Math.Abs(Math.Ceiling(dateOfBirth.Subtract(DateTime.Now).TotalDays / 365));
                    
                    if (years != personAge)
                    {
                        return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, validationContext.DisplayName, OtherPropertyName, dateOfBirth));
                    }


                    return ValidationResult.Success;
                }

                return null;
            }
            

            return null;
        }
    }
}
