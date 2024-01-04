using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Poco
{
    public class Supplier:BaseEntity
    {
        public Supplier()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public User User { get; set; }
        public Int64 UserId { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
