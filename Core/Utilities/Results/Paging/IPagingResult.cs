using System.Collections.Generic;

namespace Core.Utilities.Results.Paging
{
    public interface IPaginedResult<T> : IResult
    {
        List<T> Data { get; } 
        bool Success { get; }
        string Message { get; }
        int PageNumber { get; }
        int PageSize { get; }
        int TotalPages { get; }
        int TotalRecords { get; }
    }
}
