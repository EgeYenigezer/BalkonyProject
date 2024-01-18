using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class ProductUnit:BaseEntity
{
    public long ProductId { get; set; }

    public long UnitId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
