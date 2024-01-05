using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Poco
{
    public class Stock:BaseEntity
    {

        public double Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public Product Product { get; set; }
        public Int64 ProductId { get; set; }
        public User User { get; set; }
        public Int64 UserId { get; set; }


    }
}
