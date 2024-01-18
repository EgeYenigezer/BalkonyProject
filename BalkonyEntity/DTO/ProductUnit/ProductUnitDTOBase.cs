using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.DTO.ProductUnit
{
    public class ProductUnitDTOBase
    {
        public Int64 Id { get; set; }
        public long ProductId { get; set; }

        public long UnitId { get; set; }
    }
}
