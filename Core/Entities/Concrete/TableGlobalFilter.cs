using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class TableGlobalFilter : ITableGlobalSearchFilter
    {
        public TableGlobalFilter()
        {
            //Default Settings
            First = 1;
            Rows = 5;
            SortField = "CreatedDate";
            Filters = new List<Filter>();
        }

        public int First { get; set; }
        public int Rows { get; set; }
        public string SortField { get; set; }
        public int SortOrder { get; set; }
        public List<Filter> Filters { get; set; }
      
    }
}


