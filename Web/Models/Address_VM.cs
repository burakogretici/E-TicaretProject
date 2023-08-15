using Entities.Concrete;
using System.ComponentModel.DataAnnotations;
using System;

namespace Web.Models
{
    public class Address_VM
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string FullName { get; set; }

        [Display(Name = "Ülke Adı")]
        public string CountryName { get; set; }

        [Display(Name = "Şehir Adı")]
        public string CityName { get; set; }
        
        [Display(Name = "Adres Detayı")]
        public string AddressDetail { get; set; }

        [Display(Name = "Posta Kodu")]
        public string PostalCode { get; set; }


        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}
