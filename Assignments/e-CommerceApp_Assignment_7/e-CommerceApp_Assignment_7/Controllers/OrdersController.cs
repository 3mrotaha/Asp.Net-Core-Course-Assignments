using e_CommerceApp_Assignment_7.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceApp_Assignment_7.Controllers
{
    public class OrdersController : Controller
    {
        [HttpPost]
        [Route("/order")]
        public IActionResult Index([FromForm] Order? orderDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join("\n", ModelState.Values.SelectMany(m => m.Errors)
                                                .Select(e => e.ErrorMessage)
                                                .ToList()));

            }

            Random rnd = new Random(DateTime.Now.Millisecond);
            orderDetails.OrderNo = rnd.Next(1, 99_999);

            return Json(orderDetails);
        }
    }
}
