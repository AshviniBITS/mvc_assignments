using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorViewDemo.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public  ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Ash";
            ViewBag.marks = 70;
            ViewBag.NoOfSem = 8;
            ViewBag.Subject = new List<string>() { "maths", "chemistry", "physics" };
            return View();

        }
    }
}