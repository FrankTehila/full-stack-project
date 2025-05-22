using DAL.api;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IdentityServer4.Models.IdentityResources;

namespace DAL.services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly dbClass _context;
        public EmployeeService(dbClass context)
        {
            _context = context;
        }
        public bool IsItTeamLeader(int ID)
        {
            int teamLeaderID = _context.TeamLeaders.FirstOrDefault(tl => tl.Id == ID).Id;
            if (teamLeaderID == null)
            {
                teamLeaderID = _context.Employees.FirstOrDefault(tl => tl.Id == ID).Id;
                if (teamLeaderID == null)
                {
                    throw new Exception("Employee does not exist");
                }
                return false;
            }


            return true;
        }

        public bool AddEmployee(IEmployee employee)
        {
            Employee employeeInDB = _context.Employees.FirstOrDefault(r => r.Id == employee.Id);
            if (employeeInDB != null)
            {
                throw new Exception("The employee already exists");
            }

            if (employee is Employee newEmployee)
            {
                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Invalid employee type");
            }
        }

        public bool RemoveEmployee(int employeeID)
        {
            Employee employeeInDB = _context.Employees.FirstOrDefault(r => r.Id == employeeID);
            if (employeeInDB == null)
            {
                throw new Exception("The employee does not exist");
            }
            _context.Employees.Remove(employeeInDB);
            _context.SaveChanges();
            return true;
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            Employee employeeInDB = _context.Employees.FirstOrDefault(r => r.Id == employeeID);
            if (employeeInDB == null)
            {
                throw new Exception("The employee does not exist");
            }
            return employeeInDB;

        }





        //namespace DAL.services
        //{
        //    public class EmployeeService : IEmployeeService
        //    {
        //        private readonly dbClass _context;
        //        public EmployeeService(dbClass context)
        //        {
        //            _context = context;
        //        }
        //        public bool IsItTeamLeader(int ID)
        //        {
        //            int teamLeaderID = _context.TeamLeaders.FirstOrDefault(tl => tl.Id == ID).Id;
        //            if (teamLeaderID == null)
        //            {
        //                teamLeaderID = _context.Employees.FirstOrDefault(tl => tl.Id == ID).Id;
        //                if (teamLeaderID == null)
        //                {
        //                    throw new Exception("Employee does not exist");
        //                }
        //                return false;
        //            }

        //            return true;
        //        }
        //        public string GetEmailByID(int ID)
        //        {
        //            string email;
        //            if (IsItTeamLeader(ID))
        //            {
        //                email = _context.TeamLeaders.FirstOrDefault(tm => tm.Id == ID).Email;
        //            }
        //            email = _context.Employees.FirstOrDefault(tm => tm.Id == ID).Email;
        //            if (email == null)
        //            {
        //                throw new Exception("Employee does not exist");
        //            }
        //            return email;
        //        }
    }
}
