using DAL.Api;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.api
{
    public interface ITeamLeader:IWorker
    { 

        public int NumOfWorkers { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}
