using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelDemoAssignment.Models;

namespace ModelDemoAssignment.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create([ModelBinder(typeof(CustomBinder))]Student stu)
        {
            return View();

        }
    }
}