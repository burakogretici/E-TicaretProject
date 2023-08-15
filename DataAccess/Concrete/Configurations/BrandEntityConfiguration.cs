using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.Configurations
{
    public class BrandEntityConfiguration : BaseEntityConfiguration<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            {
                builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);

                builder.HasMany(a => a.Products)
                    .WithOne(a => a.Brand)
                    .HasForeignKey(a => a.BrandId);

                builder.HasData(
        new Brand { Id = Guid.NewGuid(), Name = "İphone" },
        new Brand { Id = Guid.NewGuid(), Name = "Samsung" },
        new Brand { Id = Guid.NewGuid(), Name = "Vestel" },
        new Brand { Id = Guid.NewGuid(), Name = "Asus" },
        new Brand { Id = Guid.NewGuid(), Name = "Philips" },
        new Brand { Id = Guid.NewGuid(), Name = "Hp" });

                base.Configure(builder);
            }
        }
    }
}