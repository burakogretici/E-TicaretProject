using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class OrderEntityConfiguration :BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(a => a.CustomerId).HasColumnName("CustomerId").IsRequired();
            builder.Property(a => a.AddressId).HasColumnName("AddressId").IsRequired();
            builder.Property(a => a.ShipperId).HasColumnName("ShipperId").IsRequired();
            builder.Property(a => a.Amount).HasColumnName("Amount");
            builder.Property(a => a.OrderStatus).HasColumnName("OrderStatus").IsRequired();

            builder.HasOne(a => a.Customer)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.CustomerId);
           
            builder.HasOne(a => a.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.AddressId);
           
            builder.HasOne(a => a.Shipper)
                .WithMany(a => a.Orders).HasForeignKey(a => a.ShipperId);

            builder.HasMany(a => a.OrderDetails)
                .WithOne(a => a.Order).HasForeignKey(a => a.OrderId);

            base.Configure(builder);
        }
    }
}