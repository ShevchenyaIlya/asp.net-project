using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asp.net_project.Models;

namespace asp.net_project.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index(bool? success)
        {
            var products = db.Products.Include(p => p.Category);
            if (success != null)
                ViewBag.Success = success;
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            Category category = db.Categories.Find(product.CategoryId);
            ViewBag.categoryName = category.CategoryName;
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Description,IsActive,IsDelete,Price,CreatedDate,InStock,CategoryId,Quantity,Image")] Product product, HttpPostedFileBase productImage)
        {
            product.ImageUrl = productImage.FileName;
           // ModelState.SetModelValue("ImageUrl", productImage.FileName);
            if (ModelState.IsValid)
            {
                if (productImage != null)
                {
                    string extension = productImage.FileName.Split('.').Last();

                    if (extension == "png" || extension == "jpg" || extension == "bmp" || extension == "jpeg")
                    {
                        product.Image = new byte[productImage.ContentLength];
                        productImage.InputStream.Read(product.Image, 0, productImage.ContentLength);
                        product.ImageUrl = productImage.FileName;
                    }
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index", new { success = true });
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Description,IsActive,IsDelete,Price,CreatedDate,ImageUrl,InStock,CategoryId,Quantity,Image")] Product product, HttpPostedFileBase productImage)
        {   
            if (ModelState.IsValid)
            {
                if (productImage != null)
                {
                    string extension = productImage.FileName.Split('.').Last();

                    if (extension == "png" || extension == "jpg" || extension == "bmp" || extension == "jpeg")
                    {
                        product.Image = new byte[productImage.ContentLength];
                        productImage.InputStream.Read(product.Image, 0, productImage.ContentLength);
                        product.ImageUrl = productImage.FileName;
                    }
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            Category category = db.Categories.Find(product.CategoryId);
            ViewBag.categoryName = category.CategoryName;

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
