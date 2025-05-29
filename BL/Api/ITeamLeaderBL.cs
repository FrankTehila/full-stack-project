using DAL.api;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.api
{
    public interface ITeamLeaderBL:IWorker
    { 

        public int NumOfWorkers { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}
