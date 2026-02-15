namespace RazorViewsSection.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public Gender Gender { get; set; }
    }


    public enum Gender
    {
        Male, Female
    }
}
