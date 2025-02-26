using System;
using System.Collections.Generic;

namespace DemoASP.NETCoreMVC.Models;

public partial class DashboardStatistic
{
    public int StatisticId { get; set; }

    public string StatisticName { get; set; } = null!;

    public decimal StatisticValue { get; set; }

    public DateOnly StatisticDate { get; set; }
}
