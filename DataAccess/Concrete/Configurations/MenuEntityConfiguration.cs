using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class MenuEntityConfiguration : BaseEntityConfiguration<Menu>
    {
        public override void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(m => m.Name).HasColumnName("Name").IsRequired().HasMaxLength(30);
            builder.Property(m => m.Url).HasColumnName("Url");
            builder.Property(m => m.Icon).HasColumnName("Icon");
            builder.Property(m => m.Hidden).HasColumnName("Hidden");
            builder.Property(m => m.DisplayOrder).HasColumnName("DisplayOrder").HasDefaultValue("0");
            builder.Property(m => m.ParentMenuId).IsRequired(false).HasDefaultValue(null);
            if (builder.HasMany(m => m.Childeren)
                    .WithOne(m => m.ParentMenu)
                    .HasForeignKey(m => m.ParentMenuId) == null)
            {
                
            }

            base.Configure(builder);
        }
    }
}
