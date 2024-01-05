using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class Stock:BaseEntity
{
    public long ProductId { get; set; }
    public long UserId { get; set; }
    public decimal? Quantity { get; set; }
    public string? QuantityUnit { get; set; }
    public virtual Product Product { get; set; } = null!;
    public virtual ICollection<StockDetail> StockDetails { get; set; } = new List<StockDetail>();
    public virtual User User { get; set; } = null!;
}
