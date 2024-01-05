using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Poco
{
    public class Order:BaseEntity
    {
        public string Title { get; set; }
        public double Cost { get; set; }
        public User User { get; set; }
        public Int64 UserId { get; set; }
        public Customer Customer { get; set; }
        public Int64 CustomerId { get; set; }
        
    }
}
