using System;
using System.Linq;
using System.Text.Json;
using Business.Services;
using Entities.Concrete;
using Entities.Dtos.Users;
using Microsoft.AspNetCore.Http;

namespace WebAPI
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsLogined => User != null;

        public UserDto User { get => Get<UserDto>("CurrentUser"); set => Store("CurrentUser", value); }

        public string ClientIP
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null && httpContext.Connection != null)
                {
                    return httpContext.Connection.RemoteIpAddress?.ToString();
                }
                return null;
            }
        }

        public string RequestLink
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null && httpContext.Request != null)
                {
                    return httpContext.Request.Path.Value + httpContext.Request.QueryString.Value;
                }
                return null;
            }
        }

        public void Clear(string key = null)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null && httpContext.Session != null)
            {
                if (string.IsNullOrEmpty(key))
                {
                    httpContext.Session.Clear();
                }
                else if (httpContext.Session.Keys.Contains(key))
                {
                    httpContext.Session.Remove(key);
                }
            }
            else
            {
                throw new ArgumentNullException("HttpContext");
            }
        }

        public T Get<T>(string key)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null && httpContext.Session != null)
            {
                var value = httpContext.Session.GetString(key);
                return value == null ? default : JsonSerializer.Deserialize<T>(value);
            }
            else
            {
                throw new ArgumentNullException("HttpContext");
            }
        }

        public void Store<T>(string key, T data)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null && httpContext.Session != null)
            {
                httpContext.Session.SetString(key, JsonSerializer.Serialize(data));
            }
            else
            {
                throw new ArgumentNullException("HttpContext");
            }
        }
    }
}
