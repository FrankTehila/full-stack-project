using BL.api;
using DAL.api;
using DAL.models;
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
        TeamLeaderService teamLeaderService;
        public EmployeeServiceBL(EmployeeService employeeService, EmailService emailService, TeamLeaderService teamLeaderService)
        {
            this.employeeService = employeeService;
            this.emailService = emailService;
            this.teamLeaderService = teamLeaderService;
        }



        public int IsItTeamLeader(int ID)
        {
            try
            {
                if (employeeService.IsItTeamLeader(ID))
                {
                    /// יצירת מספר רנדומלי בן 6 ספרות
                    Random random = new Random();
                    int randomCode = random.Next(100000, 999999);
                    string recipientEmail = GetEmailByID(ID);
                    string subject = "Your code to enter the system";
                    string body = $"Your code is: {randomCode}";

                    emailService.SendRandomCodeEmail(recipientEmail, subject, body);
                    return randomCode;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddWorker(IEmployeeBL worker)
        {

            IEmployee employee = new Employee
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Email = worker.Email,
                LeaderId = worker.LeaderId
            };

            return employeeService.AddEmployee(employee);
        }
        public bool AddWorker(ITeamLeaderBL worker)
        {

            ITeamLeader teamLeader = new TeamLeader
            {
                Id = worker.Id,
                NumOfWorkers = worker.NumOfWorkers,
                Email = worker.Email,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Meetings = worker.Meetings
            };

            return teamLeaderService.AddTeamLeader(teamLeader);
        }

        public bool RemoveWorker(int workerID)
        {
            if (employeeService.IsItTeamLeader(workerID))
            {

                return teamLeaderService.RemoveTeamLeader(workerID);
            }
            return employeeService.RemoveEmployee(workerID);
        }
        public IWorker GetWorkerByID(int workerID)
        {
            if (employeeService.IsItTeamLeader(workerID))
            {

                return teamLeaderService.GetTeamLeaderByID(workerID);
            }
            return employeeService.GetEmployeeByID(workerID);
        }
        public string GetEmailByID(int ID)
        {
            return employeeService.GetEmailByID(ID);
        }
    }
}
