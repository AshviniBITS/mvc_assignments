using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurrencyAssignment2.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index(int ?amount)
        {
            ViewBag.amount = amount;
            return View();
        }
    }
}