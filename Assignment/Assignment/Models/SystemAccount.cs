using System;
using System.Collections.Generic;
namespace Assignment.Models;

public partial class SystemAccount
{

    public enum UserRole
    {
        Admin = 1,
        Editor = 2,
        User = 3
    }
    public short AccountId { get; set; }

    public string? AccountName { get; set; }

    public string? AccountEmail { get; set; }

    public UserRole? AccountRole { get; set; }

    public string? AccountPassword { get; set; }

    public virtual ICollection<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
}
