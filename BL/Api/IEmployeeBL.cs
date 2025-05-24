using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.api
{
    public interface IEmployeeBL:IWorkerBL
    {
        public int LeaderId { get; set; }
    }
}
