using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Web.Models;

namespace Web
{
    public static class Extensions
    {
        public static IActionResult ToJson<T>(this ApiResponse<T> result, string redirect = null)
        {
            return new JsonResult(new { Data = result, Redirect = redirect });
        }
        public static string GetErrorMessage(this ModelStateDictionary modelState)
        {
            var errorMessages = modelState.Values.Where(a => a.Errors.Count > 0).SelectMany(a => a.Errors.Select(b => WebUtility.HtmlEncode(b.ErrorMessage))).ToList();
            var message = errorMessages[0].ToString();
            return message;
        }
  
        public static IActionResult ToGridResult<T>(this ApiResponse<List<T>> result, TableGlobalFilterRequest request)
        {
            if (!result.Success)
            {
                return result.ToJson();
            }
            return new JsonResult(new
            {
                Success = true,
                Total = result.TotalRecords,
                TotalPage = result.TotalPages,
                CurrentPage = result.PageNumber,
                PageSize= result.PageSize,
                Data = result.Data
            });
        }
    }
}
