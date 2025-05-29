using System;
using System.Collections.Generic;
using DAL.api;
using DAL.models;

namespace DAL.models;

public partial class TeamLeader:ITeamLeader
{
    public int Id { get; set; }

    public int NumOfWorkers { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}
