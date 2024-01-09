using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Result
{
    public class ErrorInformation
    {
        public object Error { get; set; }
        public string ErrorDescription { get; set; }


        public static ErrorInformation GlobalError(string errorDescription="Bir Hata Oluştu!!",object? error=null)
        {
            return new ErrorInformation { ErrorDescription = errorDescription,Error =error};
        }

        public static ErrorInformation FieldValidationError(string errorDescription="Zorunlu alanlarda eksiklikler var!!",object? error=null)
        {
            return new ErrorInformation {Error=error,ErrorDescription=errorDescription};
        }

    }
}
