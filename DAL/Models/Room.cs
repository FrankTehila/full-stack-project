using DAL.api;
using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Room : IRoom
{
    public int Id { get; set; }

    public int? NumOfSeats { get; set; }

    public int? NumOfComputers { get; set; }

    public bool? IsProjector { get; set; }

    public bool? IsBoard { get; set; }

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}
