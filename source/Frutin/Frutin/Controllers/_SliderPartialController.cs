using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frutin.Controllers
{
    public class _SliderPartialController : Controller
    {
        // GET: _SliderPartial
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}