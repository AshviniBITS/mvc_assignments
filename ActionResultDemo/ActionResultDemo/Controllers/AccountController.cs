using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionResultDemo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string username,string password)
        {
            if(username=="admin" && password=="pass@123" )
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return RedirectToAction("InvalidLogin");
            }
            
        }
        public ActionResult InvalidLogin()
        {
            return View();
        }
        
    }
}