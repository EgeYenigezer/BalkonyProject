using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class StockDetail:BaseEntity
{
    public long SupplierId { get; set; }
    public long StockId { get; set; }
    public long ProductId { get; set; }
    public string? Description { get; set; }
    public virtual Product Product { get; set; } = null!;
    public virtual Stock Stock { get; set; } = null!;
    public virtual Supplier Supplier { get; set; } = null!;
}
