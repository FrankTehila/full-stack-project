using System;
using System.Net;
using System.Net.Mail;

namespace BL.services
{
    public class EmailService
    {
        public void SendRandomCodeEmail(string email, string subject, string body)
        {
            Console.WriteLine($"--------------------------- שליחת מייל ---------------------------");

            // כתובת השולח
            var fromAddress = new MailAddress("rg944262@gmail.com", "The Office");
            var toAddress = new MailAddress(email);

            // קריאת הסיסמה מתוך משתנה סביבה (מאובטח יותר)
            string fromPassword = "uydq whtp jexr gnkf";


            if (string.IsNullOrEmpty(fromPassword))
            {
                Console.WriteLine("שגיאה: סיסמת SMTP לא נמצאה. ודא שהיא מוגדרת במערכת.");
                return;
            }

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // שרת SMTP של Gmail
                Port = 587, // פורט TLS (או 465 עבור SSL)
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true // אפשר להפוך את גוף ההודעה ל-HTML אם רוצים
            })
            {
                try
                {
                    smtp.Send(message);
                    Console.WriteLine(" מייל נשלח בהצלחה!");
                }
                catch (SmtpException smtpEx)
                {
                    Console.WriteLine($" שגיאת SMTP: {smtpEx.Message}");
                    Console.WriteLine($"קוד שגיאה: {smtpEx.StatusCode}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" שגיאה כללית: {ex.Message}");
                }
            }
        }
    }
}