using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionResultDemo.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetEmpName(int Empid)
        {
            var employees = new[]
            {
                new{Empid=1,EmpName="Ash",salary=30000 },
                 new
                 {
                     Empid = 2,
                     EmpName = "Ashvini",
                     salary = 40000 
                 },


                 
                 new { Empid = 3, EmpName = "Abhi",salary = 20000 }
                 
            };
            string matchEmpname = null;
            foreach (var emp in employees)
            {
                if (emp.Empid==Empid)
                {
                    matchEmpname = emp.EmpName;
                }
            }
            return Content(matchEmpname, "text/plain");


        }
        public ActionResult EmpFacebookLogin(int Empid)
        {
            string fburl = "https//www.facebook.com/emp" + Empid;
            return Redirect(fburl);
        }
    }
}