using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            IEnumerable<Blog> model;

            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.BlogRepository.Get(where: b => b.IsAvailable == true, includes: "Shop,Comments,BlogTags,Category", orderby: b => b.OrderBy(i => i.CreateDate)).ToList();
            }

            return View(model);
        }
        
        
        public ActionResult BlogDetail(int blogid)
        {

            ViewBag.blogID = blogid;

            IEnumerable<Blog> model;

            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.BlogRepository.Get(where: b => b.IsAvailable == true, includes: "Shop,Comments,BlogTags,Category", orderby: b => b.OrderBy(i => i.CreateDate)).ToList();
            }
            
            return View(model);
        }
    }
}