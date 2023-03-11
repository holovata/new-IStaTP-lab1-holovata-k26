using System;
using System.Collections.Generic;

namespace NewHolovataLab1WebApplication.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
