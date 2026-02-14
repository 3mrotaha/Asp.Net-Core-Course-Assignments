using ControllersSection.Models;
using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidationSection.CustomModelBinders;
using System.Security.Cryptography;

namespace ControllersSection.Controllers
{
    public class MyFirstController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
         
        [Route("/hello")]
        public IActionResult MyFirstMethod()
        {
            //return new ContentResult()
            //{
            //    Content = "<div>Hello from myFirstMethod</div>",
            //    ContentType = "text/html"
            //};

            return Content("<div>Hello from myFirstMethod</div>", "text/html");
        }

        [Route("Person")]
        public IActionResult MySecondMethod()
        {
            Person person = new Person()
            {
                ID = Guid.NewGuid(),
                Name = "Test Test",
                Age = 24
            };

            //return new JsonResult(person);
            return Json(person);
        }

        [Route("my-resume")]
        public IActionResult DownloadResume()
        {
            //return new VirtualFileResult("/Resume.pdf", "application/pdf");
            return File("/Resume.pdf", "application/pdf");
        }

        [Route("/phy/my-resume")]
        public IActionResult DownloadResume(int x)
        {
            //return new PhysicalFileResult(@"C:\Users\3mrotaha\Downloads\Resume (2).pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\3mrotaha\Downloads\Resume (2).pdf", "application/pdf");
        }
        
        [Route("image-download")]
        public IActionResult FileDownload()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\3mrotaha\Downloads\Resume (2).pdf");

            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }

        [HttpGet]        
        [Route("bookstore/{bookid:int?}/{isloggedin:bool?}")]
        public IActionResult downloadBook([FromRoute] int? bookId, [FromRoute] bool? isLoggedIn, Person? person)
        {
            string loggedinString = isLoggedIn == true ? "" : "not ";
            return Content($"bookid is {bookId}, and user is {loggedinString}logged in, person: {person}");
        }

        [HttpPost]
        [Route("/person-details")]
        public IActionResult PersonDetails(Person? person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join("\n", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList()));
            }

            return Content($"{person}");
        }
    }
}
