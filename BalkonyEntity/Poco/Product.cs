using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Poco
{
    public class Product:BaseEntity
    {
        public Product()
        {
            Stocks = new List<Stock>();
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Supplier Supplier { get; set; }
        public Int64 SupplierId { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }
        


    }
}
