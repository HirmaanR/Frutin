using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class _SliderPartialController : Controller
    {
        // GET: _SliderPartial
        public ActionResult Index()
        {
            UnitGenericRepository db = new UnitGenericRepository();
            IEnumerable<Slider> model = db.SliderRepository.Get(where:s=>s.IsAviable==true).ToList();
            db.Dispose();
            return PartialView(model);
        }
    }
}