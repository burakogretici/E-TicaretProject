using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class BrandEntityConfiguration : BaseEntityConfiguration<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            {
                builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);

                builder.HasMany(a => a.Products)
                    .WithOne(a => a.Brand)
                    .HasForeignKey(a => a.BrandId);

                base.Configure(builder);
            }
        }
    }
}