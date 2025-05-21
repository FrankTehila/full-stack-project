using BL.api;
using DAL.models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class MeetingBL : IMeetingBL
    {
        Meeting TheMeeting;
        public MeetingBL()
        {

        }

        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public decimal Duration { get; set; }
        public int LeaderId { get; set; }
        public TeamLeader Leader { get; set; }
        public Room Room { get; set; }
    }
}
