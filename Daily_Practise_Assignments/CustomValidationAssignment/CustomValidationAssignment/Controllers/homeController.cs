using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomValidationAssignment.Models;

namespace CustomValidationAssignment.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User u)
        {
            if(ModelState.IsValid)
            {
                return Content("Your form has submitted successfully");
            }
            else
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList().Select(error => error.ErrorMessage);  //convert list of error objects into a List<string>
                return Content(string.Join(". ", allErrors));
            }
            
        }
    }
}