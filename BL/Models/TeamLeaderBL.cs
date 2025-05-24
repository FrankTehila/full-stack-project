using BL.api;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class TeamLeaderBL:ITeamLeaderBL
    {
        public int Id { get; set; }

        public int NumOfWorkers { get; set; }

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}
