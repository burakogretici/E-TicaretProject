using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web
{
    public class SessionFilterAttribute : TypeFilterAttribute
    {
        public SessionFilterAttribute() : base(typeof(SessionFilter))
        {
        }

        private class SessionFilter : IAuthorizationFilter
        {
            private readonly IUserAccessor _userAccessor;

            public SessionFilter(IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
            }

            public void OnAuthorization(AuthorizationFilterContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException(nameof(filterContext));
                }

                var actionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
                var allowAnonymous = IsAllowAnonymous(actionDescriptor) || IsAllowAnonymousFilterApplied(filterContext.Filters);

                var actionUrl = GetActionUrl(actionDescriptor);

                if (!allowAnonymous)
                {
                    if (!_userAccessor.IsLogined)
                    {
                        var returnUrl = GetReturnUrl(filterContext.HttpContext.Request);
                        var loginUrl = "/Auth/Login" + returnUrl;

                        if (IsAjaxRequest(filterContext.HttpContext.Request))
                        {
                            filterContext.Result = new JsonResult(new
                            {
                                Success = false,
                                Redirect = loginUrl
                            });
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult(loginUrl);
                        }

                        return;
                    }

                    filterContext.HttpContext.Items["User"] = _userAccessor.User;
                }

                filterContext.HttpContext.Items["actionUrl"] = actionUrl;
            }

            private bool IsAllowAnonymous(ControllerActionDescriptor actionDescriptor)
            {
                return actionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).Any(a => a.GetType() == typeof(AllowAnonymousAttribute));
            }

            private bool IsAllowAnonymousFilterApplied(IEnumerable<IFilterMetadata> filters)
            {
                return filters.Any(a => a.GetType() == typeof(AllowAnonymousFilter));
            }

            private string GetActionUrl(ControllerActionDescriptor actionDescriptor)
            {
                return $"/{actionDescriptor.ControllerName}/{actionDescriptor.ActionName}";
            }

            private string GetReturnUrl(HttpRequest request)
            {
                var returnUrl = request.Path + request.QueryString;
                if (returnUrl != "/")
                {
                    returnUrl = "?returnUrl=" + HttpUtility.UrlEncode(returnUrl);
                }
                return returnUrl;
            }

            private static bool IsAjaxRequest(HttpRequest request)
            {
                return request != null && request.Headers != null && request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }
        }
    }
}

