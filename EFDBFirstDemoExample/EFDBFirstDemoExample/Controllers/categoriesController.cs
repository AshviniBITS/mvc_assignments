using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstDemoExample.Models;

namespace EFDBFirstDemoExample.Controllers
{
    public class categoriesController : Controller
    {
        // GET: categories
        public ActionResult Index()
        {
            CompanyDBContext db =new CompanyDBContext();
            List<Category> categories=db.Categories.ToList();

            return View(categories);
        }
    }
}