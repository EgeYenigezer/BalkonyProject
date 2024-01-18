using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class Unit:BaseEntity
{
    public string? UnitName { get; set; }

    public virtual ICollection<ProductUnit> ProductUnits { get; set; } = new List<ProductUnit>();
}
