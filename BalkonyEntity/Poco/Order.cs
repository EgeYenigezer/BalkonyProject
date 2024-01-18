using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class Order:BaseEntity
{
    public long UserId { get; set; }

    public long CustomerId { get; set; }

    public string? Title { get; set; }

    public decimal? Cost { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
