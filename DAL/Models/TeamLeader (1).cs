using System;
using System.Collections.Generic;
using DAL.Api;
using DAL.models;

namespace DAL.Models;

public partial class TeamLeader:IWorker
{
    public int Id { get; set; }

    public int NumOfWorkers { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}
