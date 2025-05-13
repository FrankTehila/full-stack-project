using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.api
{
    public interface IRoomBL
    {
        public int Id { get; set; }

        public int NumOfSeats { get; set; }

        public int NumOfComputers { get; set; }

        public bool IsProjector { get; set; }

        public bool IsBoard { get; set; }

        public ICollection<Meeting> Meetings { get; set; } 
    }
}
