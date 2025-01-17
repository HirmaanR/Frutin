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
    public class AdminFaqsController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/AdminFaqs
        public ActionResult Index()
        {
            return View(db.FaqRepository.Get().ToList());
        }

        // GET: Admin/AdminFaqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faq faq = db.FaqRepository.GetById(id.Value);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return View(faq);
        }

        // GET: Admin/AdminFaqs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminFaqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaqID,Question,Answer,IsAviable")] Faq faq)
        {
            if (ModelState.IsValid)
            {
                db.FaqRepository.Insert(faq);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            return View(faq);
        }

        // GET: Admin/AdminFaqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faq faq = db.FaqRepository.GetById(id.Value);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return View(faq);
        }

        // POST: Admin/AdminFaqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaqID,Question,Answer,IsAviable")] Faq faq)
        {
            if (ModelState.IsValid)
            {
                db.FaqRepository.Update(faq);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            return View(faq);
        }

        // GET: Admin/AdminFaqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faq faq = db.FaqRepository.GetById(id.Value);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return View(faq);
        }

        // POST: Admin/AdminFaqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.FaqRepository.Delete(id);
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
