using System;
using System.Collections.Generic;

namespace Core.Utilities.Results.Paging
{
    public class PaginatedResult<T> : IPaginedResult<T>
    {
        public PaginatedResult(List<T> data, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber <= 0 ? 1 : pageNumber;
            PageSize = pageSize <= 0 ? 1 : pageSize;
            Data = data;
            Message = "Sayfa Listelendi";
            Success = true;
            TotalRecords = totalRecords;
            if (PageSize > 0)
            {
                TotalPages = (int)Math.Ceiling(1M * TotalRecords / PageSize);
            }
        }

        public bool Success { get; set; }
        public string Message { get; }
        public List<T> Data { get; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

    }
}
