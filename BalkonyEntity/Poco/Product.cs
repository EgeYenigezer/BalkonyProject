using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class Product:BaseEntity
{
    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProductUnit> ProductUnits { get; set; } = new List<ProductUnit>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
