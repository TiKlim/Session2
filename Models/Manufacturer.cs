using System;
using System.Collections.Generic;

namespace Session4.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string? Manufacturersname { get; set; }

    public DateOnly? Startupdate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
