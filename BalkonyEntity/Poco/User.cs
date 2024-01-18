using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;

namespace BalkonyEntity.Poco;

public partial class User:BaseEntity
{
    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
