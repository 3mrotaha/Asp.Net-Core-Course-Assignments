using Controllers_Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers_Assignment_1.Controllers
{
    public class BankAccountController : Controller
    {
        
        private Account _GetAccountDetails()
        {
            return new Account() { AccountNumber = 1001, AccountHolderName = "Example Name", CurrentBalance = 5000 };
        }


        [HttpGet]
        [Route("/")]
        public IActionResult Welcome()
        {
            return Content("<h2>Welcome to the Best Bank</h2>", "text/html");
        }

        [HttpGet]
        [Route("/account-details")]
        public IActionResult GetAccountDetails()
        {
            return Json(_GetAccountDetails());
        }

        [HttpGet]
        [Route("/account-statement")]
        public IActionResult GetBankStatement()
        {
            return File("bank_statement.pdf", "application/pdf");
        }

        [HttpGet]
        [Route("/get-current-balance/{AccId:int?}")]
        public IActionResult GetAccountBalance()
        { 
            // get route values
            if (Request.RouteValues["AccId"] == null)
                return StatusCode(404, "Account Number should be supplied");

            int accNumber = Convert.ToInt32(Request.RouteValues["AccId"]);
            if(accNumber != 1001)
                return StatusCode(400, "Account Number should be 1001");
            
            return Content($"{_GetAccountDetails().CurrentBalance}", "text/plain");
        }
    }
}
