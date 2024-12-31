using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            IEnumerable<About> model;
            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.AboutViewModelRepository.GetAll();
            }
            ViewBag.FirstCommentID = model.Select(a => a.CommentID).First();
            return View(model);
        }
    }
}