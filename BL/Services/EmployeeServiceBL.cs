using BL.api;
using DAL.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.services
{
    public class EmployeeServiceBL : IEmployeeServiceBL
    {
        EmployeeService employeeService;
        EmailService emailService;
        public EmployeeServiceBL(EmployeeService employeeService, EmailService emailService)
        {
            this.employeeService = employeeService;
            this.emailService = emailService;
        }
        public bool IsItTeamLeader(int ID)
        {
            if (employeeService.IsItTeamLeader(ID))
            {
                /// יצירת מספר רנדומלי בן 6 ספרות
                Random random = new Random();
                int randomCode = random.Next(100000, 999999);
                string recipientEmail = GetEmailByID(ID); // כתובת המייל של הנמען
                string subject = "Your code to enter the system";
                string body = $"Your code is: {randomCode}"; // תוכן המייל שאת רוצה לשלוח

                emailService.SendRandomCodeEmail(recipientEmail, subject, body); // קריאה לפונקציה לשליחת המייל
                return true;
            }
            return false;
        }
        public string GetEmailByID(int ID)
        {
            return employeeService.GetEmailByID(ID);
        }
    }
}
