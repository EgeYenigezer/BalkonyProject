using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyHelper.CustomException
{
    public class TokenNotFoundException:Exception
    {
        public TokenNotFoundException(string message)
        {
            this.Data["TokenNotFoundMessage"] = message;
        }
    }
}
