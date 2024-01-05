using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class Supplier:BaseEntity
{
    public long UserId { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public virtual ICollection<StockDetail> StockDetails { get; set; } = new List<StockDetail>();
    public virtual User User { get; set; } = null!;
}
