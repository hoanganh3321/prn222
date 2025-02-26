using System;
using System.Collections.Generic;

namespace DemoASP.NETCoreMVC.Models;

public partial class LoyaltyPoint
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int Points { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
