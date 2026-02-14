using ModelBindingAndValidationSection.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ControllersSection.Models
{
    public class Person //: IValidatableObject
    {
        public Guid ID { get; set; } = Guid.NewGuid();


        //[Required(ErrorMessage = "{0} Property Can't be null or Empty")]
        //[StringLength(20, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1}")]
        //[RegularExpression("^[A-Za-z .]*$", ErrorMessage ="{0} should contain only alphapets, spaces and dots (.)")]
        //[Display(Name = "Person First Name")]
        //public string? FirstName { get; set; }

        //[Required(ErrorMessage = "{0} Property Can't be null or Empty")]
        //[StringLength(20, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1}")]
        //[RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphapets, spaces and dots (.)")]
        //[Display(Name = "Person Last Name")]
        //public string? LastName { get; set; }

        [Required(ErrorMessage = "{0} Property Can't be null or Empty")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1}")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphapets, spaces and dots (.)")]
        [Display(Name = "Person Last Name")]
        public string? Name { get; set; }

        [MinimumDateParams(1905, -1, ErrorMessage = "{0} year should be between [{1}, {2}]")]
        [Display(Name = "Person's Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        
        [Required(ErrorMessage = "{0} Should be submitted")]
        [Range(1, 120, ErrorMessage = "{0} Age should be between {1} and {2}")]
        [CompareAgeToDate("DateOfBirth", ErrorMessage = "{0} isn't the matching with the year chosed in {1} = {2}")]
        [Display(Name = "Person Age")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "{0} Property Can't be null or Empty")]
        [EmailAddress(ErrorMessage = "{0} isn't correct format of Email Address")]
        public string? Email {  get; set; }

        [Required(ErrorMessage = "{0} Property Can't be null or Empty")]
        [Phone(ErrorMessage = "{0} isn't correct format of phone number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be null or empty")]
        [Range(1000, 9999.99, ErrorMessage = "{0} is too big or too small number")]
        [Display(Name = "Employee Salary")]
        public double? Salary { get; set; }
        
        [Required(ErrorMessage = "{0} Property Can't be null or Empty")]
        [MinLength(8, ErrorMessage = "{0} should be at least {1} characters")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} Property Can't be null or Empty")]
        [Compare("Password", ErrorMessage = "{0} and {1} don't match")]
        [Display(Name = "Password re-match")]
        public string? ConfirmPassword { get; set; }

        public override string ToString()
        {
            return $"id {ID}, Name: {Name}, Age: {Age}";
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    // validation code here ...

        //    // return validation result
        //    yield return new ValidationResult("");


        //    // other validation code here ...

        //    // return validation result
        //}
    }
}
