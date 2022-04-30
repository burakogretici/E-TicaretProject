using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class BasketEntityConfiguration : BaseEntityConfiguration<Basket>
    {
        public override void Configure(EntityTypeBuilder<Basket> builder)
        {
         
            builder.Property(a => a.CustomerId).HasColumnName("CustomerId").IsRequired();

            builder.HasOne(a => a.Customer)
                .WithMany(a => a.Baskets)
                .HasForeignKey(a => a.CustomerId);

            builder.HasMany(a => a.BasketDetails)
                .WithOne(a => a.Basket)
                .HasForeignKey(a => a.BasketId);

            base.Configure(builder);
        }
    }
}