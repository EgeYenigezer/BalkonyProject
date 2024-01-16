using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.DTO.Stock
{
    public class StockDTOBase
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public string StockTitle { get; set; }
        public decimal? Quantity { get; set; }
        public string? QuantityUnit { get; set; }
    }
}
