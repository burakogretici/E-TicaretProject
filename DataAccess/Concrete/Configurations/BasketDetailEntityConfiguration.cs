using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class BasketDetailEntityConfiguration : BaseEntityConfiguration<BasketDetail>
    {
        public override void Configure(EntityTypeBuilder<BasketDetail> builder)
        {
            builder.Property(a => a.BasketId).HasColumnName("BasketId").IsRequired();
            builder.Property(a => a.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(a => a.Amount).HasColumnName("Amount").IsRequired();
            builder.Property(a => a.Price).HasColumnName("Price").IsRequired();
            builder.Property(a => a.Total).HasColumnName("Total");

            builder.HasOne(a => a.Basket)
                .WithMany(a => a.BasketDetails)
                .HasForeignKey(a => a.BasketId);

            builder.HasOne(a => a.Product)
                .WithMany(a => a.BasketDetails)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);

        }
    }
}
