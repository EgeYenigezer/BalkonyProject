using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class Customer:BaseEntity
{

    public long UserId { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual User User { get; set; } = null!;
}
