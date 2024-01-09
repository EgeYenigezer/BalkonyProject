using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.DTO.Customer
{
    public class CustomerDTORequest:CustomerDTOBase
    {
        public long UserId { get; set; }
        public long Id { get; set; }
    }
}
