using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        //public string InternalMessage { get; set; }
        public T? Data { get; set; }
        public IEnumerable<object> Errors { get; set; }

        public ApiResult(bool success, string message, T data, IEnumerable<object> errors)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }
        public ApiResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public ApiResult(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public ApiResult()
        {

        }
    }

    public class ApiReturn : ApiResult<object>
    {
        public ApiReturn(bool success, string message, object data, IEnumerable<object> errors) : base(success, message, data, errors)
        {
        }

        public ApiReturn(bool success, string message, object data) : base(success, message, data)
        {

        }

        public ApiReturn(bool success, string message) : base(success, message)
        {

        }
    }
}
