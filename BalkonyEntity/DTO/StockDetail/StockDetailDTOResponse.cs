using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.DTO.StockDetail
{
    public class StockDetailDTOResponse:StockDetailDTOBase
    {
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
    }
}
