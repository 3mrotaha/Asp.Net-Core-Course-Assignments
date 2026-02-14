using System.ComponentModel.DataAnnotations;

namespace e_CommerceApp_Assignment_7.CustomValidators
{
    public class DateLimit : ValidationAttribute
    {
        public string minDate {  get; set; }
        private readonly DateTime _minDate;

        public DateLimit() {
            if (string.IsNullOrEmpty(minDate))
                throw new NullReferenceException("minDate string can't be null or empty");

            _minDate = Convert.ToDateTime(minDate);
        }

        public DateLimit(int minYear, int minMonth, int minDay)
        {
            minDate = $"{minYear}-{minMonth}-{minDay}";
            _minDate = Convert.ToDateTime(minDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null && value is DateTime date)
            {
                if(_minDate >= date)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? "{0} must be greater than {1}", validationContext.DisplayName,
                        minDate));
                }

                return ValidationResult.Success;
            }

            return null;
        }
    }
}
