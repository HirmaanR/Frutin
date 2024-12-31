using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class _FooterPartialController : Controller
    {
        // GET: _FooterPartial
        public ActionResult Index()
        {
            FooterContent model;
            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.FooterContentRepository.Get(where:f=>f.IsAviable==true).FirstOrDefault();
            }
                return PartialView(model);
        }
    }
}