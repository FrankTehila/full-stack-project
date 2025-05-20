// See https://aka.ms/new-console-template for more information
using BL.services;
using IdentityServer4.Models;

Console.WriteLine("Hello, World!");


//EmailService emailService = new EmailService();
//Random random = new Random();
//int randomCode = random.Next(100000, 999999);
//string recipientEmail = "tamar79009@gmail.com"; // כתובת המייל של הנמען
//string subject = "Your code to enter the system";
//string body = $"Your code is: {randomCode}"; // תוכן המייל שאת רוצה לשלוח

//emailService.SendRandomCodeEmail(recipientEmail, subject, body); // קריאה לפונקציה לשליחת המייל

//using System;
//using System.Net;
//using System.Net.Mail;
// סילשתי לצורך הרצה!!!!!

//    string to = "tamar79009@gmail.com"; // כתובת הנמען
//    string subject = "Subject of the Email"; // נושא המייל
//    string body = "This is the body of the email."; // תוכן המייל

//    SendEmail(to, subject, body);

//static void SendEmail(string to, string subject, string body)
//{
//    var fromAddress = new MailAddress("rg944262@gmail.com", "Meeting Room");
//    var toAddress = new MailAddress(to);
//    const string fromPassword = ",nrvufcrdr100"; // הסיסמה שלך

//    var smtp = new SmtpClient
//    {
//        Host = "smtp.gmail.com",
//        Port = 587,
//        EnableSsl = true,
//        DeliveryMethod = SmtpDeliveryMethod.Network,
//        UseDefaultCredentials = false,
//        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

//    };

//    using (var message = new MailMessage(fromAddress, toAddress)
//    {
//        Subject = subject,
//        Body = body
//    })
//    {
//        smtp.Send(message);
//    }
//}




