using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Areas.Admin.Controllers
{
    public class BlogsController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/Blogs
        public ActionResult Index()
        {
            var blog = db.BlogRepository.Get(includes: "Category,Shop");
            //var blog = db.Blog.Include(b => b.Category).Include(b => b.Shop);
            return View(blog);
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.BlogRepository.GetById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CategoryRepository.Get(), "CategoryID", "Tittle");
            ViewBag.ShopID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogID,ShopID,CategoryID,Tittle,ShortDes,Text,CoverImage,DesImage,CreateDate,IsAvailable")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.BlogRepository.Insert(blog);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CategoryRepository.Get(), "CategoryID", "Tittle", blog.CategoryID);
            ViewBag.ShopID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", blog.ShopID);
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.BlogRepository.GetById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CategoryRepository.Get(), "CategoryID", "Tittle", blog.CategoryID);
            ViewBag.ShopID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", blog.ShopID);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogID,ShopID,CategoryID,Tittle,ShortDes,Text,CoverImage,DesImage,CreateDate,IsAvailable")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.BlogRepository.Update(blog);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CategoryRepository.Get(), "CategoryID", "Tittle", blog.CategoryID);
            ViewBag.ShopID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", blog.ShopID);
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.BlogRepository.GetById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.BlogRepository.Delete(id);
            db.SaveChange();
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
