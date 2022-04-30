using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class CustomerEntityConfiguration : BaseEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired(); ;
            builder.Property(a => a.CustomerType).HasColumnName("CustomerType")/*.IsRequired()*/;

            builder.HasOne(a => a.User).WithMany(a => a.Customers).HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.Orders)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);
          
            builder.HasMany(a => a.Addresses)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);
           
            builder.HasMany(a => a.Baskets)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);
          
            builder.HasMany(a => a.Individuals)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);
           
            builder.HasMany(a => a.Suppliers)
                .WithOne(a => a.Customer).HasForeignKey(a => a.CustomerId);

            base.Configure(builder);
        }
    }
}