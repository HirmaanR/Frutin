using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using UtilityLayer;

namespace Frutin.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {

            FooterContent model;

            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                model = db.FooterContentRepository.Get(where: f => f.IsAviable == true).First();
            }

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> GetContactMessage(string userName, string userEmail, string userPhone, string subject, string message)
        {

            Contact newContact = new Contact()
            {
                UserName = userName,
                UserEmail = userEmail,
                PhoneNumber = userPhone,
                MessageText = message,
                Subject = subject,
                CreateDate = DateTime.Now,
            };

            using (UnitGenericRepository db = new UnitGenericRepository())
            {
                try
                {
                    db.ContactRepository.Insert(newContact);
                    db.SaveChange();

                    EmailService email = new EmailService();

                    // email subject :
                    string emailSubject = "تماس با ما";
                    // email body:
                    string emailBody = "<b>کاربر گرامی ، ما با موفقیت پیام شمارا دریافت کردیم، از اینکه به ما در بهتر شدن کمک می کنید سپاسگزاریم</b>";

                    bool emailResult = await email.SendEmailAsync(userName,userEmail,emailSubject,emailBody);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }

        }
    }
}