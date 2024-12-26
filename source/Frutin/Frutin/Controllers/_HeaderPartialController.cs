using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Controllers
{
    public class _HeaderPartialController : Controller
    {
        // GET: _HeaderPartial 
        public ActionResult Index()
        {
            IEnumerable<HeaderMenu> menu;

            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                ViewBag.notificationText = db.HeaderNotificationRepository.Get(where: n => n.IsAviable == true).Select(n => n.Text).First();
                menu = db.HeaderMenuRepository.Get(includes: "ChildHeaderMenus").ToList();
            }
            return PartialView(menu);
        }
    }
}