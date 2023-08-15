using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class AddressEntityConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(a => a.CountryId).HasColumnName("CountryId").IsRequired();
            builder.Property(a => a.CityId).HasColumnName("CityId").IsRequired();
            builder.Property(a => a.AddressDetail).HasColumnName("AddressDetail").HasMaxLength(500);
            builder.Property(a => a.PostalCode).HasColumnName("PostalCode");

            builder.HasOne(a => a.User)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Country)
                .WithMany(a => a.Addresses)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(a => a.City)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.CityId);

            builder.HasMany(a => a.Orders)
                .WithOne(a => a.Address)
                .HasForeignKey(a => a.AddressId);

            base.Configure(builder);
        }
    }
}