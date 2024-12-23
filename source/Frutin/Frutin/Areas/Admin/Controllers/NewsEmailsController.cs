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
    public class NewsEmailsController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/NewsEmails
        public ActionResult Index()
        {
            return View(db.NewsSubscribeEmailRepository.Get());
        }

        // GET: Admin/NewsEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsEmail newsEmail = db.NewsSubscribeEmailRepository.GetById(id.Value);
            if (newsEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsEmail);
        }

        // GET: Admin/NewsEmails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NewsEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsEmailID,Email")] NewsEmail newsEmail)
        {
            if (ModelState.IsValid)
            {
                db.NewsSubscribeEmailRepository.Insert(newsEmail);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            return View(newsEmail);
        }

        // GET: Admin/NewsEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsEmail newsEmail = db.NewsSubscribeEmailRepository.GetById(id.Value);
            if (newsEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsEmail);
        }

        // POST: Admin/NewsEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsEmailID,Email")] NewsEmail newsEmail)
        {
            if (ModelState.IsValid)
            {
                db.NewsSubscribeEmailRepository.Update(newsEmail);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            return View(newsEmail);
        }

        // GET: Admin/NewsEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsEmail newsEmail = db.NewsSubscribeEmailRepository.GetById(id.Value);
            if (newsEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsEmail);
        }

        // POST: Admin/NewsEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.NewsSubscribeEmailRepository.Delete(id);
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
