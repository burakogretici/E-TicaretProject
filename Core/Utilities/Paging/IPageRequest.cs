using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Paging
{
    public interface IPageRequest
    {
         int PageNumber { get; set; }
         int PageSize { get; set; }
    }
}
