﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Web.Models
{
    public class Color_VM
    {

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Renk Adı")]
        public string Name { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
    }
}
