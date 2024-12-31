using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Category> model;
            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.CategoryRepository.Get(includes: "Products").ToList();
            }
            return View(model);
        }
    }
}