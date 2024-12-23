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
    public class FooterContentsController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/FooterContents
        public ActionResult Index()
        {
            return View(db.FooterContentRepository.Get());
        }

        // GET: Admin/FooterContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterContent footerContent = db.FooterContentRepository.GetById(id.Value);
            if (footerContent == null)
            {
                return HttpNotFound();
            }
            return View(footerContent);
        }

        // GET: Admin/FooterContents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FooterContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FooterContentID,Description,Address,PhoneNumber,Email,IsAviable")] FooterContent footerContent)
        {
            if (ModelState.IsValid)
            {
                db.FooterContentRepository.Insert(footerContent);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            return View(footerContent);
        }

        // GET: Admin/FooterContents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterContent footerContent = db.FooterContentRepository.GetById(id.Value);
            if (footerContent == null)
            {
                return HttpNotFound();
            }
            return View(footerContent);
        }

        // POST: Admin/FooterContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FooterContentID,Description,Address,PhoneNumber,Email,IsAviable")] FooterContent footerContent)
        {
            if (ModelState.IsValid)
            {
                db.FooterContentRepository.Update(footerContent);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            return View(footerContent);
        }

        // GET: Admin/FooterContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterContent footerContent = db.FooterContentRepository.GetById(id.Value);
            if (footerContent == null)
            {
                return HttpNotFound();
            }
            return View(footerContent);
        }

        // POST: Admin/FooterContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.FooterContentRepository.Delete(id);
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
