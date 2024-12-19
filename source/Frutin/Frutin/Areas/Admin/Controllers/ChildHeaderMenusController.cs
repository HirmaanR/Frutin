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
    public class ChildHeaderMenusController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/ChildHeaderMenus
        public ActionResult Index()
        {
            var childHeaderMenu = db.HeaderChildMenuRepository.Get(includes: "HeaderMenu");
            return View(childHeaderMenu);
        }

        // GET: Admin/ChildHeaderMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildHeaderMenu childHeaderMenu = db.HeaderChildMenuRepository.GetById(id.Value);
            if (childHeaderMenu == null)
            {
                return HttpNotFound();
            }
            return View(childHeaderMenu);
        }

        // GET: Admin/ChildHeaderMenus/Create
        public ActionResult Create()
        {
            ViewBag.HeaderMenuID = new SelectList(db.HeaderMenuRepository.Get(), "HeaderMenuID", "Title");
            return View();
        }

        // POST: Admin/ChildHeaderMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChildMenuID,HeaderMenuID,Title,Link")] ChildHeaderMenu childHeaderMenu)
        {
            if (ModelState.IsValid)
            {
                db.HeaderChildMenuRepository.Insert(childHeaderMenu);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            ViewBag.HeaderMenuID = new SelectList(db.HeaderMenuRepository.Get(), "HeaderMenuID", "Title", childHeaderMenu.HeaderMenuID);
            return View(childHeaderMenu);
        }

        // GET: Admin/ChildHeaderMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildHeaderMenu childHeaderMenu = db.HeaderChildMenuRepository.GetById(id.Value);
            if (childHeaderMenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.HeaderMenuID = new SelectList(db.HeaderMenuRepository.Get(), "HeaderMenuID", "Title", childHeaderMenu.HeaderMenuID);
            return View(childHeaderMenu);
        }

        // POST: Admin/ChildHeaderMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChildMenuID,HeaderMenuID,Title,Link")] ChildHeaderMenu childHeaderMenu)
        {
            if (ModelState.IsValid)
            {
                db.HeaderChildMenuRepository.Update(childHeaderMenu);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            ViewBag.HeaderMenuID = new SelectList(db.HeaderMenuRepository.Get(), "HeaderMenuID", "Title", childHeaderMenu.HeaderMenuID);
            return View(childHeaderMenu);
        }

        // GET: Admin/ChildHeaderMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildHeaderMenu childHeaderMenu = db.HeaderChildMenuRepository.GetById(id.Value);
            if (childHeaderMenu == null)
            {
                return HttpNotFound();
            }
            return View(childHeaderMenu);
        }

        // POST: Admin/ChildHeaderMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.HeaderChildMenuRepository.Delete(id);
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
