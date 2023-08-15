using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class GeneralFilter : IPagingFilter
    {
        public GeneralFilter()
        {
            Page = 1;
            PropertyName = "Id";
        }
        public int Page { get; set; }
        public string PropertyName { get; set; }
        public bool Asc { get; set; }
    }
}
