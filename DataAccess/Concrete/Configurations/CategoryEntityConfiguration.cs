using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class CategoryEntityConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
         
            builder.HasMany(a => a.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            base.Configure(builder);
        }
    }
}