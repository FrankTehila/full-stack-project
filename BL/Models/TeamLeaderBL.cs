using BL.api;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BL.models
{
    public class TeamLeaderBL : ITeamLeaderBL
    {
        public int Id { get; set; }

        public int NumOfWorkers { get; set; }

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }


    namespace BL.models
    {
        public class TeamLeaderDTO
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("numOfWorkers")]
            public int NumOfWorkers { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; }

            [JsonPropertyName("firstName")]
            public string FirstName { get; set; }

            [JsonPropertyName("lastName")]
            public string LastName { get; set; }
        }
    }
}
