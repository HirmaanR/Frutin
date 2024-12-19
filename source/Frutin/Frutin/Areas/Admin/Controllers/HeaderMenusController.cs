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
    public class HeaderMenusController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/HeaderMenus
        public ActionResult Index()
        {
            return View(db.HeaderMenuRepository.Get());
        }

        // GET: Admin/HeaderMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderMenu headerMenu = db.HeaderMenuRepository.GetById(id.Value);
            if (headerMenu == null)
            {
                return HttpNotFound();
            }
            return View(headerMenu);
        }

        // GET: Admin/HeaderMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HeaderMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeaderMenuID,Title,IsMenuHasChild,Link")] HeaderMenu headerMenu)
        {
            if (ModelState.IsValid)
            {
                db.HeaderMenuRepository.Insert(headerMenu);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            return View(headerMenu);
        }

        // GET: Admin/HeaderMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderMenu headerMenu = db.HeaderMenuRepository.GetById(id.Value);
            if (headerMenu == null)
            {
                return HttpNotFound();
            }
            return View(headerMenu);
        }

        // POST: Admin/HeaderMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeaderMenuID,Title,IsMenuHasChild,Link")] HeaderMenu headerMenu)
        {
            if (ModelState.IsValid)
            {
                db.HeaderMenuRepository.Update(headerMenu);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            return View(headerMenu);
        }

        // GET: Admin/HeaderMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderMenu headerMenu = db.HeaderMenuRepository.GetById(id.Value);
            if (headerMenu == null)
            {
                return HttpNotFound();
            }
            return View(headerMenu);
        }

        // POST: Admin/HeaderMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.HeaderMenuRepository.Delete(id);
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
