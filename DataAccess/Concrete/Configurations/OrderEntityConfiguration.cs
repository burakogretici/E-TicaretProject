using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class OrderEntityConfiguration : BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(a => a.AddressId).HasColumnName("AddressId").IsRequired();
            builder.Property(a => a.ShipperId).HasColumnName("ShipperId").IsRequired();
            builder.Property(a => a.BasketId).HasColumnName("BasketId").IsRequired();
            //builder.Property(a => a.Amount).HasColumnName("Amount");
            builder.Property(a => a.OrderStatus).HasColumnName("OrderStatus").IsRequired();


            builder.HasOne(a => a.Basket)
                .WithMany(a => a.Orders).HasForeignKey(a => a.BasketId);

            builder.HasOne(a => a.User)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(a => a.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.AddressId);

            builder.HasOne(a => a.Shipper)
                .WithMany(a => a.Orders).HasForeignKey(a => a.ShipperId);


            base.Configure(builder);
        }
    }
}