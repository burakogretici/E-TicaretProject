using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BasketDetail
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }

        public bool Status { get; set; } = true;
    }
}
