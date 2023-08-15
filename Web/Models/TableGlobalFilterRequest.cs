using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;

namespace Web.Models
{
    public class TableGlobalFilterRequest
    {
        public int? First { get; set; }
        public int? Rows { get; set; }
        public string SortField { get; set; }
        public int? SortOrder { get; set; }
        public List<Filter> Filters { get; set; }

 
        public string ToQueryString()
        {
            var queryStringParams = new List<string>();

            if (First.HasValue)
                queryStringParams.Add($"first={First.Value}");

            if (Rows.HasValue)
                queryStringParams.Add($"rows={Rows.Value}");

            if (SortOrder.HasValue)
                queryStringParams.Add($"sortOrder={SortOrder.Value}");

            if (!string.IsNullOrEmpty(SortField))
                queryStringParams.Add($"sortField={SortField}");



            //todo burayı optimize et
            //if (Filters != null && Filters.Count > 0)
            //{
            //    var propertyFieldQuery = string.Join("&Filters=", Filters.Select(filter => filter));
            //    queryStringParams.Add("Filters=" + propertyFieldQuery);
            //}

            if (Filters != null && Filters.Count > 0)
            {
                for (int i = 0; i < Filters.Count; i++)
                {
                    var filter = Filters[i];
                    queryStringParams.Add($"Filters[{i}].Field={filter.Field}");
                    queryStringParams.Add($"Filters[{i}].Operator={filter.Operator}");
                    queryStringParams.Add($"Filters[{i}].SearchValue={filter.SearchValue}");
                }
            }
            var a= queryStringParams.Any() ? $"?{string.Join('&', queryStringParams)}" : string.Empty;

            return queryStringParams.Any() ? $"?{string.Join('&', queryStringParams)}" : string.Empty;
        }
    }
}

//if (!string.IsNullOrEmpty(SearchText))
//    queryStringParams.Add($"searchText={SearchText}");

//if (!string.IsNullOrEmpty(Operator))
//    queryStringParams.Add($"operator={Operator}");