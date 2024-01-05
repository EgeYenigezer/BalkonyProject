using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Poco
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

    }
}
