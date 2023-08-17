using System.ComponentModel.DataAnnotations;
using System;
using Entities.Concrete;

namespace Web.Models
{
    public class BasketItem_VM
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string CustomerName { get; set; }

        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Display(Name = "Miktar")]
        public string Amount { get; set; }

        [Display(Name = "Fiyat")]
        public string Price { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }

        public Basket Basket { get; set; }
        public Product Product { get; set; }
      

    }
}
