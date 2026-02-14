using ControllersSection.Models;
using Microsoft.AspNetCore.Mvc;
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
                FirstName = "Test",
                LastName = "Test",
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

    }
}
