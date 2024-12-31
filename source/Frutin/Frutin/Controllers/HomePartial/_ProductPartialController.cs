using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class _ProductPartialController : Controller
    {
        // GET: _ProductPartial
        public ActionResult Index()
        {
            IEnumerable<Product> model;
            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.ProductRepository.Get(where: p => p.IsAvailable == true, includes: "Category").ToList();
            }

            return View(model);
        }
    }
}