using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.api
{
    public interface IEmployeeService
    {
        public bool IsItTeamLeader(int ID);
        //public string GetEmailByID(int ID);



        public bool AddEmployee(IEmployee employee);


        public bool RemoveEmployee(int employeeID);

        public Employee GetEmployeeByID(int employeeID);
    }
}
