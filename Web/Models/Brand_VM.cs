using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Brand_VM
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Marka Adı")]
        public string Name { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

    }
}
