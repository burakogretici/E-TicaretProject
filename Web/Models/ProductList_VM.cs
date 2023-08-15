using Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ProductList_VM
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Marka Adı")]
        public string BrandName { get; set; }

        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }

        [Display(Name = "Renk Adı")]
        public string ColorName { get; set; }

        [Display(Name = "Tedarikçi Adı")]
        public string SupplierName { get; set; }

        [Display(Name = "Ürün Kodu")]
        public string Code { get; set; }

        [Display(Name = "Stok Miktarı")]
        public short UnitsInStock { get; set; }

        [Display(Name = "Fiyat")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }

        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public Category Category { get; set; }



    }
}
