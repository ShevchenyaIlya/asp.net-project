using asp.net_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace asp.net_project.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(bool? success)
        {
            var categories = db.Categories.ToList<Category>();
            if (success != null)
                ViewBag.Success = success;
            return View(categories);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            ViewBag.categoryId = id;

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Categories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,Description,IsActive,IsDelete,ImageUrl")] Category category, HttpPostedFileBase categoryImage)
        {
            if (ModelState.IsValid)
            {
                if (categoryImage != null)
                {
                    string extension = categoryImage.FileName.Split('.').Last();

                    if (extension == "png" || extension == "jpg" || extension == "bmp" || extension == "jpeg")
                    {
                        category.Image = new byte[categoryImage.ContentLength];
                        categoryImage.InputStream.Read(category.Image, 0, categoryImage.ContentLength);
                        category.ImageUrl = categoryImage.FileName;
                    }
                }
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index", new { success = true });
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.CategoryId);
            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.CategoryId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,Description,IsActive,IsDelete,ImageUrl")] Category category, HttpPostedFileBase categoryImage)
        {
            if (ModelState.IsValid)
            {
                if (categoryImage != null)
                {
                    string extension = categoryImage.FileName.Split('.').Last();

                    if (extension == "png" || extension == "jpg" || extension == "bmp" || extension == "jpeg")
                    {
                        category.Image = new byte[categoryImage.ContentLength];
                        categoryImage.InputStream.Read(category.Image, 0, categoryImage.ContentLength);
                        category.ImageUrl = categoryImage.FileName;
                    }
                }
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.CategoryId);
            return View(category);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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