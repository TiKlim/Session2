using System;
using System.Collections.Generic;

namespace Session4.Models;

public partial class ProductSale
{
    public int Id { get; set; }

    public DateOnly? Dateofsale { get; set; }

    public TimeOnly? Timeofsale { get; set; }

    public int? Product { get; set; }

    public int? Countofproduct { get; set; }

    public virtual Product? ProductNavigation { get; set; }
}
