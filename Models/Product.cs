using System;
using System.Collections.Generic;

namespace Session4.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }

    public int? Activity { get; set; }

    public int? Manufacturer { get; set; }

    public virtual Activity? ActivityNavigation { get; set; }

    public virtual Manufacturer? ManufacturerNavigation { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
