using BL.api;
using DAL.api;
using DAL.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.api
{
    public interface IEmployeeServiceBL
    {
        public int IsItTeamLeader(int ID);
        //public string GetEmailByID(int ID);

        public bool AddWorker(IEmployeeBL worker);

        public bool AddWorker(ITeamLeaderBL worker);
        public bool RemoveWorker(int workerID);

        public IWorker GetWorkerByID(int workerID);
        
    }
}
