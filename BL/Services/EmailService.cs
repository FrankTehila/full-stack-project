using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class EmailService
    {
        public void SendRandomCodeEmail(string email, string subject, string body)
        {


            var fromAddress = new MailAddress("tamar79009@gmail.com", "The office");
            var toAddress = new MailAddress(email);
            const string fromPassword = "t327606497"; // סיסמת המייל שלך
            //const string subject = "Your Random Code";
            //string body = $"Your random code is: {randomCode}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // השרת SMTP שלך
                Port = 587, // או 465 עבור SSL
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
