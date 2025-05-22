using BL.api;
using DAL.api;

using DAL.models;
using DAL.Models;
using DAL.services;
using DAL.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.services
{
    public class EmployeeServiceBL : IEmployeeServiceBL
    {

        IEmployeeService employeeService;
        //EmailService emailService;
        ITeamLeaderService teamLeaderService;
        public EmployeeServiceBL(IEmployeeService employeeService,ITeamLeaderService teamLeaderService)
        {
            this.employeeService = employeeService;
            //this.emailService = emailService;
            this.teamLeaderService = teamLeaderService;
        }

      

        public int IsItTeamLeader(int ID)
        {
            if (employeeService.IsItTeamLeader(ID))
            {
                /// יצירת מספר רנדומלי בן 6 ספרות
                Random random = new Random();
                int randomCode = random.Next(100000, 999999);
                //string recipientEmail = GetEmailByID(ID);
                //string subject = "Your code to enter the system";
                //string body = $"Your code is: {randomCode}"; 


                return randomCode;
            }
            return 0;
        }

        public bool AddWorker(IWorkerBL worker)
        {
            if(worker is IEmployee)
            {
               IEmployee e = (IEmployee)worker;
                return employeeService.AddEmployee(e);
                 
            }
            if (worker is ITeamLeader)
            {
                ITeamLeader e = (ITeamLeader)worker;
                return teamLeaderService.AddTeamLeader(e);
                 
            }
            return false;

        }
        public bool RemoveWorker(int workerID)
        {
            if(employeeService.IsItTeamLeader(workerID)) 
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


        //public string GetEmailByID(int ID)
        //{
        //    return employeeService.GetEmailByID(ID);
        //}
    }
}
