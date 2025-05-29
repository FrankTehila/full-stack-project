using DAL.models;
using System;

namespace DAL.api
{
    public interface IMeeting
    {
        int Id { get; set; }
        int RoomId { get; set; }
        DateTime Date { get; set; }
        TimeOnly StartTime { get; set; }
        decimal Duration { get; set; }
        int LeaderId { get; set; }
        TeamLeader Leader { get; set; }
        Room Room { get; set; }
    }
}
