using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.Configurations
{
    public class CategoryEntityConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
         
            builder.HasMany(a => a.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            builder.HasData(
   new Category { Id = Guid.NewGuid(), Name = "Telefon" },
   new Category { Id = Guid.NewGuid(), Name = "Elektronik" },
   new Category { Id = Guid.NewGuid(), Name = "Bilgisayar" },
   new Category { Id = Guid.NewGuid(), Name = "Beyaz Eşya" },
   new Category { Id = Guid.NewGuid(), Name = "Giyim" },
   new Category { Id = Guid.NewGuid(), Name = "Mobilya" });
            base.Configure(builder);
        }
    }
}