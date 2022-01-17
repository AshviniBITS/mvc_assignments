using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionResultAssignment1.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index(string arg)
        {
            if (arg == "sample")
                return File("~/Sample.pdf", "application/pdf");
            else if (arg == "gotoabout")
                return RedirectToAction("About");
            else if (arg == "login")
                return View("Login");
            else
                return Content("You entered:" + arg);
            
        }
        public ActionResult About()
        {
            return Content("about content here");

        }
    }
}