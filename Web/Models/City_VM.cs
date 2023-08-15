using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Entities.Concrete;

namespace Web.Models
{
    public class City_VM
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Ülke")]
        public string CountryName { get; set; }

        [Display(Name = "Şehir")]
        public string Name { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        public Country Country { get; set; }
    }
}
