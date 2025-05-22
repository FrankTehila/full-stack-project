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
    }
}
