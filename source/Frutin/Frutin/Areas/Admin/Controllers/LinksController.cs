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
    public class LinksController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/Links
        public ActionResult Index()
        {
            var link = db.LinkRepository.Get(includes:"Shop");
            return View(link);
        }

        // GET: Admin/Links/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.LinkRepository.GetById(id.Value);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // GET: Admin/Links/Create
        public ActionResult Create()
        {
            ViewBag.ShopID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name");
            return View();
        }

        // POST: Admin/Links/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LinkID,ShopID,Tittle,URL")] Link link)
        {
            if (ModelState.IsValid)
            {
                db.LinkRepository.Insert(link);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            ViewBag.ShopID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", link.ShopID);
            return View(link);
        }

        // GET: Admin/Links/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.LinkRepository.GetById(id.Value);
            if (link == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShopID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", link.ShopID);
            return View(link);
        }

        // POST: Admin/Links/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LinkID,ShopID,Tittle,URL")] Link link)
        {
            if (ModelState.IsValid)
            {
                db.LinkRepository.Update(link);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            ViewBag.ShopID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", link.ShopID);
            return View(link);
        }

        // GET: Admin/Links/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.LinkRepository.GetById(id.Value);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: Admin/Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.LinkRepository.Delete(id);
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
