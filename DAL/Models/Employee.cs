using DAL.api;
using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Employee : IEmployee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? LeaderId { get; set; }

}
