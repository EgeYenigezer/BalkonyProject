using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Poco.Base
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool IsActive { get; set; }  
    }
}
