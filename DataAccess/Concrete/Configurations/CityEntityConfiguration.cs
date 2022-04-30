using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class CityEntityConfiguration : BaseEntityConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(a => a.CountryId).HasColumnName("CountryId").IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(25);


            builder.HasOne(a => a.Country)
                .WithMany(a => a.Cities)
                .HasForeignKey(a => a.CountryId);

            builder.HasMany(a => a.Addresses)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId);

            base.Configure(builder);
        }
    }
}