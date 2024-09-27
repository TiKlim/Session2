using System;
using System.Collections.Generic;

namespace Session4.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string? ActivityName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
