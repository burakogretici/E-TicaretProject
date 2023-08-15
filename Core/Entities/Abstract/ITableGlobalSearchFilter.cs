using System.Collections.Generic;

namespace Core.Entities.Abstract
{
    public interface ITableGlobalSearchFilter
    {
        public int First { get; set; }
        public int Rows { get; set; }
        public string SortField { get; set; }
        public int SortOrder { get; set; }
        public List<Filter> Filters { get; set; }
    }

    public class Filter
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string SearchValue { get; set; }
    }

}
