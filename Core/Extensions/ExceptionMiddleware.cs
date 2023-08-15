using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {

            var normalType = e.GetType();
            var innerExceptionType = e.InnerException?.GetType();

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors;
            if (normalType == typeof(ValidationException))
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    Title= "Validation Exceptiont",
                    StatusCode = 400,
                    Message = message,
                    ValidationErrors = errors
                }.ToString());

            }
            if (normalType == typeof(AuthorizationException)) {

                httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    Title = "Authorization Exception",
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Message = e.Message
                }.ToString());
            }
            
            if (normalType  == typeof(BusinessException) || innerExceptionType == typeof(BusinessException))
            {
                message = e.InnerException?.Message == null ? e.Message : e.InnerException.Message;
                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    Title = "Business Exception",
                    StatusCode = 400,
                    Message = message
                }.ToString());

            }
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                Title = "Internal exception",
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}