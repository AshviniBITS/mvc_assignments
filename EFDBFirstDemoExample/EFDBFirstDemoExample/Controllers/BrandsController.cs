﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstDemoExample.Models;

namespace EFDBFirstDemoExample.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Brand>brands =db.Brands.ToList();
            return View(brands);
        }
    }
}