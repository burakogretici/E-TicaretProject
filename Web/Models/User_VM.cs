using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class User_VM
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

    }
}
