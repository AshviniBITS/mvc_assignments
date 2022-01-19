using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ResponseDemo()
        {
            Response.Write("hello from response example");
            Response.ContentType = "text/plain";
            return View();
        }
        public ActionResult RequestDemo()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath=Request.PhysicalApplicationPath;
            ViewBag.path=Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString=Request.QueryString["n"];
            ViewBag.HttpMethod=Request.HttpMethod;
            return View();
        }
    }
}