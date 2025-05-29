using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.api
{
    public interface IEmployee:IWorker
    {
        public int LeaderId { get; set; }
    }
}
