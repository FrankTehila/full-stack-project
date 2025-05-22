using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Meeting
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public DateTime Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public decimal Duration { get; set; }

    public int LeaderId { get; set; }

    public virtual TeamLeader Leader { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
