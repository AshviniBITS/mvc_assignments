using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelDemoAssignment.Models;

namespace ModelDemoAssignment.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Products> product = new List<Products>()
            {
                new Products{ProductId=1,ProductName="Laptop",rate=60000},
                 new Products{ProductId=2,ProductName="BMW",rate=90000},
                  new Products{ProductId=3,ProductName="Bike",rate=70000}

            };
            ViewBag.product = product;
            return View();
        }
        public ActionResult Details(int id)
        {
            List<Products> product = new List<Products>()
            {
                new Products{ProductId=1,ProductName="Laptop",rate=60000},
                 new Products{ProductId=2,ProductName="BMW",rate=90000},
                  new Products{ProductId=3,ProductName="Bike",rate=70000}

            };
            Products matchingProduct = null;
            foreach(var item in product)
            {
                if(item.ProductId==id)
                    matchingProduct = item;
            }
            ViewBag.matchingProduct=matchingProduct;

           ViewBag.product = product;
            return View();
            //return View(matchingProduct);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create([Bind(Include ="ProductId,ProductName")]Products d)
        {
            return View();
        }
    }
}