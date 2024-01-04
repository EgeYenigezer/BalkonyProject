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
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Stock Stock { get; set; }
        public Int64 StockId { get; set; }
        public Supplier Supplier { get; set; }
        public Int64 SupplierId { get; set; }


    }
}
