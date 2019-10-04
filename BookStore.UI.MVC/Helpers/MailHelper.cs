using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BookStore.UI.MVC.Helpers
{
    public class MailHelper
    {
        public static bool SendMail(string name, string mailAddress, Guid code)
        {
            MailAddress from = new MailAddress("bookstorecomsales@gmail.com");
            MailAddress to = new MailAddress(mailAddress);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = from;
            mailMessage.To.Add(to);
            mailMessage.Subject = "BookStore Üyelik Aktivasyon";
            mailMessage.Body = string.Format("Merhaba {0},<br/>" +
                "Hesabını aşağıdaki linkten aktifleştirerek, seni bekleyen yüzlerce kitap ile alışverişe  devam edebilirsin <br/><a href='http://localhost:53948/Account/Activate?code={1}'>Aktivasyon için tıklayınız</a>", name, code);
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(from.Address, "bookstore14789");
            smtpClient.EnableSsl = true;

            bool result = false;
            try
            {
                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;

        }
    }
}