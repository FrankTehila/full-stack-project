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
            if (teamLeader == null)
            {
                var employee = _context.Employees.FirstOrDefault(emp => emp.Id == ID);
                if (employee == null)
                {
                    throw new Exception("Employee does not exist");
                }
                return false;
            }
            return true;
        }
        //public string GetEmailByID(int ID)
        //{
        //    string email;
        //    if (IsItTeamLeader(ID))
        //    {
        //        email = _context.TeamLeaders.FirstOrDefault(tm => tm.Id == ID).Email;
        //    }
        //    email = _context.Employees.FirstOrDefault(tm => tm.Id == ID).Email;
        //    if (email == null)
        //    {
        //        throw new Exception("Employee does not exist");
        //    }
        //    return email;
        //}
    }
}
