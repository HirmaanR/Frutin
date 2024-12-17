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
    public class ShopsController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/Shops
        public ActionResult Index()
        {
            var shop = db.ShopRepository.Get(includes:"User");
            return View(shop);
        }

        // GET: Admin/Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.ShopRepository.GetById(id.Value);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Admin/Shops/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.RoleRepository.Get(), "RoleID", "Tittle");
            ViewBag.ShopID = new SelectList(db.UserRepository.Get(), "UserID", "FirstName");
            return View();
        }

        // POST: Admin/Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopID,UserID,RoleID,Name,ShortDes,Description,Phone,Site,Address")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.ShopRepository.Insert(shop);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.RoleRepository.Get(), "RoleID", "Tittle", shop.RoleID);
            ViewBag.ShopID = new SelectList(db.UserRepository.Get(), "UserID", "FirstName", shop.ShopID);
            return View(shop);
        }

        // GET: Admin/Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.ShopRepository.GetById(id.Value);
            if (shop == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.RoleRepository.Get(), "RoleID", "Tittle", shop.RoleID);
            ViewBag.ShopID = new SelectList(db.UserRepository.Get(), "UserID", "FirstName", shop.ShopID);
            return View(shop);
        }

        // POST: Admin/Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopID,UserID,RoleID,Name,ShortDes,Description,Phone,Site,Address")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.ShopRepository.Update(shop);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.RoleRepository.Get(), "RoleID", "Tittle", shop.RoleID);
            ViewBag.ShopID = new SelectList(db.UserRepository.Get(), "UserID", "FirstName", shop.ShopID);
            return View(shop);
        }

        // GET: Admin/Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.ShopRepository.GetById(id.Value);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Admin/Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.ShopRepository.Delete(id);
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
