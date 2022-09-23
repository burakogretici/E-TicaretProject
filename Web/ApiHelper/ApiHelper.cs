using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Web.ApiHelper
{
    public class ApiHelper : IApiHelper
    {
        private readonly RestClient _client;
        private IHttpContextAccessor _httpContextAccessor;

        public ApiHelper(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;    
            _client = new RestClient(config.GetValue<string>("ApiSettings:Host"));
        }

        public async Task Delete<T>(string url)
        {
            var request = new RestRequest(url, Method.Delete) { RequestFormat = DataFormat.Json };
            await Response<T>(request);
        }


        public async Task<List<T>> Get<T>(string url)
        {
            var request = new RestRequest(url, Method.Get);

            var result = await Response<List<T>>(request);
            return result.Data;
        }

        public async Task<T> GetById<T>(string url)
        {
            var request = new RestRequest(url, Method.Get);

            var result = await Response<T>(request);
            return result.Data;
        }


        public async Task Post<T>(string url, object obj)
        {
            var request = new RestRequest(url, Method.Post);
            await Response<T>(request, obj);
        }


        public async Task Put<T>(string url, object obj)
        {
            var request = new RestRequest(url, Method.Put);
            await Response<T>(request, obj);
        }

        public async Task<IDataResult<T>> Response<T>(RestRequest request, object obj = null)
        {
            if (obj != null)
            {
                request.AddJsonBody(obj);
            }

            AddHeader(request);

            RestResponse<T> response = await _client.ExecuteAsync<T>(request);
            if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _httpContextAccessor.HttpContext.Response.Redirect("/Security/Logoff");
                }
                return new ErrorDataResult<T>(response.ErrorMessage);

            }
            return new SuccessDataResult<T>(response.Data);
        }

        private void AddHeader(RestRequest request)
        {
            request.RequestFormat = DataFormat.Json;
            request.OnBeforeDeserialization = resp => { resp.ContentType = ",/json"; };
            request.AddHeader("Accept-Language", "en-us");
            request.AddHeader("Content-Type", "application/json");
        }

    }
}

