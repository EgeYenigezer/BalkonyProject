using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyHelper.CustomException
{
    public class TokenException:Exception
    {
        public TokenException(string message ="Token Hatası Oluştu"):base(message)
        {
            
        }
    }
}
