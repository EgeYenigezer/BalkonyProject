using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Result
{
    public class ApiResult<T>
    {
        public ApiResult(T _data,string _message,int _statusCode,ErrorInformation _errorInformation)
        {
            this.Data = _data;
            this.Message = _message;
            this.StatusCode = _statusCode;
            this.ErrorInformation = _errorInformation;
        }
        public ApiResult(T _data, string _message, int _statusCode)
        {
            this.Data = _data;
            this.Message = _message;
            this.StatusCode = _statusCode;
            
        }
        public ApiResult(string _message, int _statusCode)
        {
            
            this.Message = _message;
            this.StatusCode = _statusCode;
            
        }
        public ApiResult( string _message, int _statusCode, ErrorInformation _errorInformation)
        {
            
            this.Message = _message;
            this.StatusCode = _statusCode;
            this.ErrorInformation = _errorInformation;
        }



        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ErrorInformation? ErrorInformation { get; set; }  

        public static ApiResult<T> SuccesWithData(T data, string message="İşlem Başarılı",int statusCode=(int)HttpStatusCode.OK)
        {
            return new ApiResult<T>(data,message,statusCode);
        }
        public static ApiResult<T> SuccesWithOutData(string message="İşlem Başarılı",int statusCode=(int)HttpStatusCode.OK)
        {
            return new ApiResult<T>(message, statusCode);
        }
        public static ApiResult<T> FieldValdationError(List<string>? errorMessages=null,string message="Hata Oluştu",int statusCode=(int)HttpStatusCode.BadRequest)
        {
            return new ApiResult<T>(message,statusCode,ErrorInformation.FieldValidationError());
        }

    }
}
