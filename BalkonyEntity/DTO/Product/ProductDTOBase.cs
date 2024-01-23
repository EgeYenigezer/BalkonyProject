using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.DTO.Product
{
    public class ProductDTOBase
    {
        public long Id { get; set; }    
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
       

    }
}
