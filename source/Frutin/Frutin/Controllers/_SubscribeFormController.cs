using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityLayer;
using DataLayer;
using System.Threading.Tasks;

namespace Frutin.Controllers
{
    public class _SubscribeFormController : Controller
    {
        // GET: _SubscribeForm

        public ActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> SendMail(string userEmail)
        {
            EmailService email = new EmailService();


            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                NewsEmail sm = new NewsEmail()
                {
                    Email = userEmail
                };
                db.NewsSubscribeEmailRepository.Insert(sm);
                db.SaveChange();
            }

            string emailSubject = "عضویت در کانال خبررسانی";
            string emailBody = "<b>عضویت در کانال خبر رسانی با موفقیت انجام شد ، از اینکه مارا انتخاب کردید متشکریم</b>";


            bool emailResult = await email.SendEmailAsync("new User",userEmail,emailSubject,emailBody);

            return RedirectToAction("Index");
        }
    }
}