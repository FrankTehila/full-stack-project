using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.api
{
    public interface IEmployeeServiceBL
    {
        public bool IsItTeamLeader(int ID);
        public string GetEmailByID(int ID);
    }
}
