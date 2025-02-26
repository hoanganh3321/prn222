using System;
using System.Collections.Generic;

namespace DemoASP.NETCoreMVC.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Barcode { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Price { get; set; }

    public decimal? ManufacturingCost { get; set; }

    public decimal? StoneCost { get; set; }

    public string? Warranty { get; set; }

    public int? Quantity { get; set; }

    public bool? IsBuyback { get; set; }

    public int? CategoryId { get; set; }

    public int? StoreId { get; set; }

    public string? Image { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ProductReturn? ProductReturn { get; set; }

    public virtual Store? Store { get; set; }
}
