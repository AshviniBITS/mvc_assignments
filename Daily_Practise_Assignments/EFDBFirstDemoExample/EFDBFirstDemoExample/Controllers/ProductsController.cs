using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstDemoExample.Models;

namespace EFDBFirstDemoExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search="")
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.search = search;
           // List<Product>products=db.Products.Where(temp=>temp.CategoryId==1 && temp.Price>=30000).ToList();
            List<Product> products = db.Products.Where(temp =>temp.ProductName.Contains(search)).ToList();
            return View(products);
        }
        public ActionResult Details(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product p = db.Products.Where(temp => temp.ProductId == id).FirstOrDefault();
            return View(p);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            db.Products.Add(p);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index");


        }
    }
}