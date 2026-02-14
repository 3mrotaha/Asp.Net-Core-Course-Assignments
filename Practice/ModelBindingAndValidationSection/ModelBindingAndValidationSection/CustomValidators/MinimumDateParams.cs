using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidationSection.CustomValidators
{
    public class MinimumDateParams : ValidationAttribute
    {
        public int MinimumYear { get; set; }
        public int MaximumYear { get; set; }
        private string DefaultErrorMessage { get; set; } = "{0} Year is out of boundaries [{1}, {2}]";
        public MinimumDateParams() { }
        /// <summary>
        /// Initializes a new instance of the MinimumDateParams class with the specified minimum and maximum year
        /// values.
        /// </summary>
        /// <remarks>If maxYear is not provided or is set to -1, it is automatically set to the current
        /// year to ensure a valid range.</remarks>
        /// <param name="minYear">The minimum year value. Must be greater than or equal to 1. The default is 2000.</param>
        /// <param name="maxYear">The maximum year value. If set to -1 or not specified, the current year is used. Must be greater than or
        /// equal to minYear.</param>
        public MinimumDateParams(int minYear = 2000, int maxYear = -1)
        {
            MinimumYear = minYear;
            MaximumYear = maxYear != -1 ? maxYear : DateTime.Today.Year;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value != null && value is DateTime date)
           {
                if (date.Year < MinimumYear || date.Year > MaximumYear)
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, validationContext.DisplayName, MinimumYear, MaximumYear));
                else
                    return ValidationResult.Success;
           }


           return null;
        }
    }
}
