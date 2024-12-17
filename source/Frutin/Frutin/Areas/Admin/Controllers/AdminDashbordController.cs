using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frutin.Areas.Admin.Controllers
{
    public class AdminDashbordController : Controller
    {
        // GET: Admin/AdminDashbord
        public ActionResult Index()
        {
            return View();
        }
    }
}