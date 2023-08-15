using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class BasketEntityConfiguration : BaseEntityConfiguration<Basket>
    {
        public override void Configure(EntityTypeBuilder<Basket> builder)
        {

            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();


            builder.HasOne(a => a.User)
                .WithMany(a => a.Baskets)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.BasketItems)
                .WithOne(a => a.Basket)
                .HasForeignKey(a => a.BasketId);

            builder.HasMany(a => a.Orders)
    .WithOne(a => a.Basket)
    .HasForeignKey(a => a.BasketId);

            base.Configure(builder);
        }
    }
}