using Microsoft.AspNetCore.Mvc;
using RazorViewsSection.Models;

namespace RazorViewsSection.Controllers
{
    public class HomeController : Controller
    {
        private List<Person> poeple = new List<Person>()
        {
            new Person() {Name = "Amr", Email = "asdf@gmail.com", Dob = DateTime.Now.AddYears(-25), Gender = Gender.Male},
            new Person() {Name = "Linda", Email = "dsa@gmail.com", Dob = DateTime.Now.AddYears(-55), Gender = Gender.Female},
            new Person() {Name = "Mahmoud", Email = "dd@gmail.com", Dob = DateTime.Now.AddYears(-13), Gender = Gender.Male},
            new Person() {Name = "Sara", Email = "aaasdf@gmail.com", Dob = DateTime.Now.AddYears(-20), Gender = Gender.Female}

        };

        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.appTitle = "ASP.NET Core Application / Views section";
            /**
             * the view is stored in Views/Home/Index.cshtml by default
             * maps to Views/{Controller Name}/{Action}.cshtml
             * 
             * can be renamed View("abc") -> which maps to Views/Home/abc.cshtml
             */
            return View("Index", poeple);
        }

        [Route("/person-details/{name:maxlength(100):minlength(3)}")]
        public IActionResult Details([FromRoute] string name)
        {
            var person = poeple.Where(p => p.Name == name).FirstOrDefault();

            return View("Details", person);
        }
    }
}
