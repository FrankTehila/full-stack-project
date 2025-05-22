using DAL.api;
using DAL.models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.api
{
    public interface ITeamLeaderService
    {


        public bool IsItTeamLeader(int ID);




        public bool AddTeamLeader(ITeamLeader teamLeader);


        public bool RemoveTeamLeader(int teamLeaderID);



        public TeamLeader GetTeamLeaderByID(int teamLeaderID);
        
}
}
