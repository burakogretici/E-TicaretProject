using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Business.Services;
using Core.Extensions;


namespace Web.ApiHelper
{
    public class HttpClient : IHttpClient
    {
        private static System.Net.Http.HttpClient _httpClient;
        private readonly IUserAccessor _userAccessor;
        private IHttpContextAccessor _httpContextAccessor;

        public HttpClient(IConfiguration configuration, IUserAccessor userAccessor, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = new System.Net.Http.HttpClient();
            _httpClient.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:Host"));
            _userAccessor = userAccessor;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            return await SendRequest<T>(HttpMethod.Get, endpoint);
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
        {
            return await SendRequest<T>(HttpMethod.Post, endpoint, data);
        }
        public async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
        {
            return await SendRequest<T>(HttpMethod.Put, endpoint, data);
        }

        public async Task<ApiResponse<T>> DeleteAsync<T>(string endpoint)
        {
            return await SendRequest<T>(HttpMethod.Delete, endpoint);
        }

        private async Task<ApiResponse<T>> SendRequest<T>(HttpMethod method, string endpoint, object data = null)
        {
            AddAuthorizationHeader();
            AddAcceptHeader();

            HttpResponseMessage response;
            string content = null;
            StringContent stringContent = null;

            if (data != null)
            {
                string json = JsonConvert.SerializeObject(data);
                stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            }

            switch (method)
            {
                case HttpMethod.Get:
                    response = await _httpClient.GetAsync(endpoint);
                    break;
                case HttpMethod.Post:
                    response = await _httpClient.PostAsync(endpoint, stringContent);
                    break;
                case HttpMethod.Put:
                    response = await _httpClient.PutAsync(endpoint, stringContent);
                    break;
                case HttpMethod.Delete:
                    response = await _httpClient.DeleteAsync(endpoint);
                    break;
                default:
                    throw new ArgumentException($"Unsupported HTTP method '{method}'");
            }

            string expiration = _userAccessor.Get<string>("Expiration");
            if (expiration != null)
            {
                var expirationTime = DateTime.Parse(expiration);
                var currentTime = DateTime.Now;

                if (expirationTime < currentTime)
                {
                    _httpContextAccessor.HttpContext.Response.Redirect("/Auth/Login");
                }
            }


            content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse<T>>(content);

            var apiResponse = new ApiResponse<T>()
            {
                Success = response.IsSuccessStatusCode,
                StatusCode = (int)response.StatusCode,
                Data = response.IsSuccessStatusCode ? result.Data : default(T),
                Message = result.Message,
                TotalRecords = result.TotalRecords,
                TotalPages = result.TotalPages,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };

            if (content.IndexOf("ValidationErrors") > 0)
            {
                var validationErrorDetails = JsonConvert.DeserializeObject<ValidationErrorDetails>(content);
                var errors = validationErrorDetails.ValidationErrors;
                apiResponse.Errors = !response.IsSuccessStatusCode ? errors : null;
            }

            return apiResponse;
        }

        private void AddAuthorizationHeader()
        {
            string token = _userAccessor.Get<string>("Token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        private void AddAcceptHeader()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
