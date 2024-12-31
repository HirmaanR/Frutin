using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class _BlogsPartialController : Controller
    {
        // GET: _BlogsPartial
        public ActionResult Index()
        {

            IEnumerable<Blog> model;
            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.BlogRepository.Get(where:b=>b.IsAvailable==true,includes:"Shop").ToList();
            }
           
            return View(model);
        }
    }
}