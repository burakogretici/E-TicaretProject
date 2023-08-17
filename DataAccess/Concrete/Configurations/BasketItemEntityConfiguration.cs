using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class BasketItemEntityConfiguration : BaseEntityConfiguration<BasketItem>
    {
        public override void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(a => a.BasketId).HasColumnName("BasketId").IsRequired();
            builder.Property(a => a.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(a => a.Amount).HasColumnName("Amount").IsRequired();
            builder.Property(a => a.Price).HasColumnName("Price").IsRequired().HasColumnType("decimal(18, 2)");
            ;

            builder.HasOne(a => a.Basket)
                .WithMany(a => a.BasketItems)
                .HasForeignKey(a => a.BasketId);

            builder.HasOne(a => a.Product)
                .WithMany(a => a.BasketItems)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);

        }
    }
}
