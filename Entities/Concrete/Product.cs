﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Code { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public bool Status { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
