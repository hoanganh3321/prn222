using System;
using System.Collections.Generic;

namespace DemoASP.NETCoreMVC.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? OrderId { get; set; }

    public int? PromotionId { get; set; }

    public string? PromotionName { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? StaffId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Promotion? Promotion { get; set; }

    public virtual Staff? Staff { get; set; }
}
