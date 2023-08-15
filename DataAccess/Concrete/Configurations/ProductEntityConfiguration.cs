using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class ProductEntityConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.BrandId).HasColumnName("BrandId").IsRequired();
            builder.Property(a => a.CategoryId).HasColumnName("CategoryId").IsRequired();
            builder.Property(a => a.ColorId).HasColumnName("ColorId").IsRequired();

            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(a => a.Code).HasColumnName("Code").IsRequired();
            builder.Property(a => a.UnitPrice).HasColumnName("UnitPrice").HasColumnType("decimal(18,2)");
            builder.Property(a => a.UnitsInStock).HasColumnName("UnitsInStock");

            builder.HasIndex(x => x.Code).IsUnique();

            builder.HasOne(a => a.Brand)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.BrandId);

            builder.HasOne(a => a.Category)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.CategoryId);


            builder.HasOne(a => a.Color)
                .WithMany(a => a.Products).
                HasForeignKey(a => a.ColorId);

            builder.HasMany(a => a.BasketItems)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId);


            base.Configure(builder);
        }
    }
}