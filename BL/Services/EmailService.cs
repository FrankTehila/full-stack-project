using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Abp.Net.Mail.EmailSettingNames;

namespace BL.services
{
    public class EmailService
    {
        public void SendRandomCodeEmail(string email, string subject, string body)
        {

            Console.WriteLine($"---------------------------++++++++++++++++++++++++++++++++++++++++++++++++++");
            var fromAddress = new MailAddress("rg944262@gmail.com", "The office");
            var toAddress = new MailAddress(email);
            const string fromPassword = ",nr vufcrdr100"; // סיסמת המייל שלך
            //const string subject = "Your Random Code";
            //string body = $"Your random code is: {randomCode}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // השרת SMTP שלך
                Port = 465, // או 465 עבור SSL
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
                try
                {
                    smtp.Send(message);
                }
                catch (SmtpException smtpEx)
                {
                    Console.WriteLine($"----------------------------SMTP Error: {smtpEx:Message}");
                    Console.WriteLine($"SMTP Error Code: {smtpEx:StatusCode}");
                    Console.WriteLine($"SMTP Error Details: {smtpEx:ToString()}");
                    smtp.Send(message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"-------------------------------------Error: {ex.Message}");
                }

            }
        }
    }
}
