using BL.api;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    public class RoomBL : IRoomBL
    {
        public int Id { get; set; }

        public int? NumOfSeats { get; set; }

        public int? NumOfComputers { get; set; }

        public bool? IsProjector { get; set; }

        public bool? IsBoard { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}
