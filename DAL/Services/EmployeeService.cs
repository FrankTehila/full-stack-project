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
            var teamLeader = _context.TeamLeaders.FirstOrDefault(tl => tl.Id == ID);
            if (teamLeader != null)
            {
                return true;
            }

            Employee employee = _context.Employees.FirstOrDefault(tl => tl.Id == ID);
            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }
            return false;
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

        public string GetEmailByID(int ID)
        {
            string email;
            if (IsItTeamLeader(ID))
            {
                email = _context.TeamLeaders.FirstOrDefault(tm => tm.Id == ID).Email;
            }
            else
            {
                email = _context.Employees.FirstOrDefault(tm => tm.Id == ID).Email;
            }
            if (email == null)
            {
                throw new Exception("Employee does not exist");
            }
            return email;
        }
        public List<Employee> GetEmployeesByLeaderId(int leaderId)
        {
            var employees = _context.Employees.Where(e => e.LeaderId == leaderId).ToList();
            if (employees == null || !employees.Any())
            {
                throw new Exception("No employees found for the given leader ID");
            }
            return employees;
        }
    }
}
