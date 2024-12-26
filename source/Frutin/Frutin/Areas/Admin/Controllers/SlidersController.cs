using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Areas.Admin.Controllers
{
    public class SlidersController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(db.SliderRepository.Get());
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.SliderRepository.GetById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderID,Label,Caption,IsAviable,ImageName,Link,IsActive")] Slider slider, HttpPostedFileBase imgUp)
        {


            if (imgUp != null)
            {
                slider.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                imgUp.SaveAs(Server.MapPath("/Content/Images/Slider/" + slider.ImageName));
            }
            db.SliderRepository.Insert(slider);
            db.SaveChange();
            return RedirectToAction("Index");



        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.SliderRepository.GetById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderID,Label,Caption,IsAviable,ImageName,Link,IsActive")] Slider slider,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if(imgUp != null)
                {
                    if(slider.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Content/Images/Slider/" + slider.ImageName));
                    }
                    slider.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/Images/Slider/" + slider.ImageName));
                }

                db.SliderRepository.Update(slider);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.SliderRepository.GetById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider Dslider = db.SliderRepository.GetById(id);
            if (Dslider.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Content/Images/Slider/" + Dslider.ImageName));
            }
            db.SliderRepository.Delete(id);
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
