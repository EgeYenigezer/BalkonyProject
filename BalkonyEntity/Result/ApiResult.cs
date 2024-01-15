using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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
        public static ApiResult<T> SuccesNoDataFound(string message = "Sonuç bulunamadı!",int statusCode=(int)HttpStatusCode.NotFound)  
        { 
            return new ApiResult<T> (message,statusCode,ErrorInformation.NotFound());
        }
        public static ApiResult<T> FieldValdationError(List<string>? errorMessages=null,string message="Hata Oluştu",int statusCode=(int)HttpStatusCode.BadRequest)
        {
            return new ApiResult<T>(message,statusCode,ErrorInformation.FieldValidationError(errorMessages));
        }

        public static ApiResult<T> AuthenticationError(string message,int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ApiResult<T>(message,statusCode,ErrorInformation.AuthenticationError());
        }

        public static ApiResult<T> TokenValidationError()
        {
            return new ApiResult<T>("Hata Oluştu",(int)HttpStatusCode.Unauthorized,ErrorInformation.TokenValidationError());
        }

        public static ApiResult<T> TokenNotFound()
        {
            return new ApiResult<T>("Hata Oluştu",(int)HttpStatusCode.Unauthorized,ErrorInformation.TokenNotFoundError());
        }
        public static ApiResult<T> Error()
        {
            return new ApiResult<T>("Bir Hata Oluştu, Daha Sonra Tekrar Deneyiniz!!",(int)HttpStatusCode.InternalServerError,ErrorInformation.GlobalError());
        }
    }
}
