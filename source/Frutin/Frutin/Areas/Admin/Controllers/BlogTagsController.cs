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
    public class BlogTagsController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/BlogTags
        public ActionResult Index()
        {
            var blogTag = db.BlogTagRepository.Get(includes:"Blog,Tag");
            return View(blogTag);
        }

        // GET: Admin/BlogTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogTag blogTag = db.BlogTagRepository.GetById(id.Value);
            if (blogTag == null)
            {
                return HttpNotFound();
            }
            return View(blogTag);
        }

        // GET: Admin/BlogTags/Create
        public ActionResult Create()
        {
            ViewBag.BlogID = new SelectList(db.BlogRepository.Get(), "BlogID", "Tittle");
            ViewBag.TagID = new SelectList(db.TagRepository.Get(), "TagID", "Tittle");
            return View();
        }

        // POST: Admin/BlogTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogTagID,BlogID,TagID")] BlogTag blogTag)
        {
            if (ModelState.IsValid)
            {
                db.BlogTagRepository.Insert(blogTag);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            ViewBag.BlogID = new SelectList(db.BlogRepository.Get(), "BlogID", "Tittle", blogTag.BlogID);
            ViewBag.TagID = new SelectList(db.TagRepository.Get(), "TagID", "Tittle", blogTag.TagID);
            return View(blogTag);
        }

        // GET: Admin/BlogTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogTag blogTag = db.BlogTagRepository.GetById(id.Value);
            if (blogTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogID = new SelectList(db.BlogRepository.Get(), "BlogID", "Tittle", blogTag.BlogID);
            ViewBag.TagID = new SelectList(db.TagRepository.Get(), "TagID", "Tittle", blogTag.TagID);
            return View(blogTag);
        }

        // POST: Admin/BlogTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogTagID,BlogID,TagID")] BlogTag blogTag)
        {
            if (ModelState.IsValid)
            {
                db.BlogTagRepository.Update(blogTag);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            ViewBag.BlogID = new SelectList(db.BlogRepository.Get(), "BlogID", "Tittle", blogTag.BlogID);
            ViewBag.TagID = new SelectList(db.TagRepository.Get(), "TagID", "Tittle", blogTag.TagID);
            return View(blogTag);
        }

        // GET: Admin/BlogTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogTag blogTag = db.BlogTagRepository.GetById(id.Value);
            if (blogTag == null)
            {
                return HttpNotFound();
            }
            return View(blogTag);
        }

        // POST: Admin/BlogTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.BlogTagRepository.Delete(id);
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
