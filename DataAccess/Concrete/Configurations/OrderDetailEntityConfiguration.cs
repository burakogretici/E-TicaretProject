using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class OrderDetailEntityConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.ProductId });
            builder.Property(e => e.Amount).HasColumnName("Amount");
            builder.Property(e => e.SalePrice).HasColumnName("SalePrice");

            builder.HasOne(a => a.Order)
                .WithMany(a => a.OrderDetails)
                .HasForeignKey(a => a.OrderId);

            builder.HasOne(a => a.Product)
                .WithMany(a => a.OrderDetails)
                .HasForeignKey(a => a.ProductId);
        }
    }
}