using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.DTO.Order
{
    public class OrderDTOBase
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CustomerId { get; set; }
        public string? Title { get; set; }
        public decimal? Cost { get; set; }
    }
}
