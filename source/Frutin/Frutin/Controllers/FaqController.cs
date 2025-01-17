using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class FaqController : Controller
    {
        // GET: Faq
        public ActionResult Index()
        {
            IEnumerable<Faq> model;
            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.FaqRepository.Get(where: f => f.IsAviable == true).ToList();
            }

            return View(model);
        }
    }
}