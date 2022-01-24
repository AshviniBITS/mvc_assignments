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

            // List<Product>products=db.Products.Where(temp=>temp.CategoryId==1 && temp.Price>=30000).ToList();
            /*List<Product> products = db.Products.Where(temp =>temp.ProductName.Contains(search)).ToList();
            ViewBag.search = search;
            return View(products);*/
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            ViewBag.search = search;
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
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

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
        public ActionResult edit(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingProduct = db.Products.Where(temp => temp.ProductId == id).FirstOrDefault();
            ViewBag.categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(existingProduct);
        }
        [HttpPost]
        public ActionResult edit(Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingProduct = db.Products.Where(temp => temp.ProductId == p.ProductId).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.CategoryId = p.CategoryId;
            existingProduct.BrandId = p.BrandId;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            db.SaveChanges();

            return RedirectToAction("Index","Products");
        }
        public ActionResult delete(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingProduct = db.Products.Where(temp => temp.ProductId ==id).FirstOrDefault();
            return View(existingProduct);

        }
        [HttpPost]
        public ActionResult delete(long id,Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingProduct = db.Products.Where(temp => temp.ProductId == id).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
           
            return RedirectToAction("Index", "Products");

        }

    }
}