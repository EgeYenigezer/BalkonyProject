using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.DTO.StockDetail
{
    public class StockDetailDTOBase
    {
        public long Id { get; set; }
        public long SupplierId { get; set; }
        public long StockId { get; set; }
        public long ProductId { get; set; }
        public string? Description { get; set; }
    }
}
