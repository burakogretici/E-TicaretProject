using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }

    public class ApiReturn : ApiResult<object>
    {
    }
}
