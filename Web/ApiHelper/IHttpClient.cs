using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Web.ApiHelper
{
    public interface IHttpClient
    {
        Task<ApiResponse<T>> GetAsync<T>(string endpoint);
        Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data);
        Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data);
        Task<ApiResponse<T>> DeleteAsync<T>(string endpoint);
    
    }
}
