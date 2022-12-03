using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.ApiHelper
{
    public interface IApiHelper
    {
        Task Post<T>(string url, object obj);
        Task<List<T>> Get<T>(string url);
        Task Put<T>(string url, object obj);
        Task Delete<T>(string url); 
        Task<T> GetById<T>(string url);
    }
}

