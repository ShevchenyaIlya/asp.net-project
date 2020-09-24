﻿using asp.net_project.Models;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace asp.net_project.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var products = db.Products.ToList<Product>();
            ViewData["categories"] = db.Categories;
            return View(products);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Image()
        {
            ViewBag.image = db.Products.ToList()[0].Image;
            return View(db.Products.ToList());
        }

        [CustomAuthorize(Roles = "Saler")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Products()
        {
            var products = db.Products.ToList<Product>();
            return View(products);
        }
        public ActionResult Category()
        {
            var categories = db.Categories.ToList<Category>();
            return View(categories);
        }

        public ActionResult CategoryItems(int? id)
        {
            var products = db.Products.ToList<Product>();
            List<Product> categoryProducts = new List<Product>();
            foreach (var product in products)
            {
                if(product.CategoryId == id)
                {
                    categoryProducts.Add(product);
                }
            }

            ViewBag.categoryProducts = categoryProducts;

            return View(products);
        }

        public ActionResult FindProduct(string searching)
        {
            var products = from product in db.Products
                          select product;

            if (!String.IsNullOrEmpty(searching))
            {
                products = products.Where(product => product.ProductName.Contains(searching));
            }

            return View(products.ToList());
        }
    }
}