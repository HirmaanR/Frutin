using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace UtilityLayer
{
    public class EmailService // 
    {
        /* 
        -> parameters :
            email : frutinstore@gmail.com 
            pass : ojnb qjka euqr ahnf 
            smpt  : smtp.gmail.com 
            port : 587
         */


        public bool SendEmail(string recevierName, string recevierEmail,string emailSubject,string emailBody)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Frutin", "frutinstore@gmail.com"));
            email.To.Add(new MailboxAddress(recevierName, recevierEmail));

            email.Subject = emailSubject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailBody
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("frutinstore@gmail.com", "ojnb qjka euqr ahnf");

                try
                {
                    smtp.Send(email);
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {

                    smtp.Disconnect(true);
                }
            }
        }

        public async Task<bool> SendEmailAsync(string receiverName, string receiverEmail,string emailSubject,string emailBody)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Frutin", "frutinstore@gmail.com"));
            email.To.Add(new MailboxAddress(receiverName, receiverEmail));

            email.Subject = emailSubject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailBody
            };

            using (var smtp = new SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    await smtp.AuthenticateAsync("frutinstore@gmail.com", "ojnb qjka euqr ahnf");

                    await smtp.SendAsync(email);

                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    await smtp.DisconnectAsync(true);
                }
            }
        }

    }
}

