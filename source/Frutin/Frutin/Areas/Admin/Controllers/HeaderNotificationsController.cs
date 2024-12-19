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
    public class HeaderNotificationsController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/HeaderNotifications
        public ActionResult Index()
        {
            return View(db.HeaderNotificationRepository.Get());
        }

        // GET: Admin/HeaderNotifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderNotification headerNotification = db.HeaderNotificationRepository.GetById(id.Value);
            if (headerNotification == null)
            {
                return HttpNotFound();
            }
            return View(headerNotification);
        }

        // GET: Admin/HeaderNotifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HeaderNotifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeaderNotofocationID,Text,IsAviable")] HeaderNotification headerNotification)
        {
            if (ModelState.IsValid)
            {
                db.HeaderNotificationRepository.Insert(headerNotification);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            return View(headerNotification);
        }

        // GET: Admin/HeaderNotifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderNotification headerNotification = db.HeaderNotificationRepository.GetById(id.Value);
            if (headerNotification == null)
            {
                return HttpNotFound();
            }
            return View(headerNotification);
        }

        // POST: Admin/HeaderNotifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeaderNotofocationID,Text,IsAviable")] HeaderNotification headerNotification)
        {
            if (ModelState.IsValid)
            {
                db.HeaderNotificationRepository.Update(headerNotification);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            return View(headerNotification);
        }

        // GET: Admin/HeaderNotifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderNotification headerNotification = db.HeaderNotificationRepository.GetById(id.Value);
            if (headerNotification == null)
            {
                return HttpNotFound();
            }
            return View(headerNotification);
        }

        // POST: Admin/HeaderNotifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.HeaderNotificationRepository.Delete(id);
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
