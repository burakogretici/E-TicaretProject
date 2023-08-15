using Core.Extensions;
using System;
using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<object> Errors { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
 
}
