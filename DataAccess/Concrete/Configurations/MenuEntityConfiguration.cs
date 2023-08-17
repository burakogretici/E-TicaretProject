using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class MenuEntityConfiguration : IEntityTypeConfiguration<Menu> 
    {

        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedNever();

            builder.Property(m => m.Name).HasColumnName("Name").IsRequired().HasMaxLength(30);
            builder.Property(m => m.Url).HasColumnName("Url");
            builder.Property(m => m.Icon).HasColumnName("Icon");
            builder.Property(m => m.Hidden).HasColumnName("Hidden");
            builder.Property(m => m.IsAdmin).HasColumnName("IsAdmin");
            builder.Property(m => m.DisplayOrder).HasColumnName("DisplayOrder").HasDefaultValue("0");
            builder.Property(m => m.ParentMenuId).IsRequired(false).HasDefaultValue(null);

            builder.HasOne(a => a.ParentMenu)
           .WithMany(a => a.Childeren)
           .HasForeignKey(a => a.ParentMenuId);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasData(
                    new Menu { Id = 1, Name = "Ürün ", DisplayOrder = 0 },
                    new Menu { Id = 2, ParentMenuId = 1, Name = "Ürün Listesi", DisplayOrder = 0 ,Url= "/product/index" },
                    new Menu { Id = 3, ParentMenuId = 1, Name = "Markalar", DisplayOrder = 1, Url = "/brand/index" },
                    new Menu { Id = 4, ParentMenuId = 1, Name = "Kategoriler", DisplayOrder = 2, Url = "/category/index" },
                    new Menu { Id = 5, ParentMenuId = 1, Name = "Renkler", DisplayOrder = 3, Url = "/color/index" },

                    new Menu { Id = 6, Name = "Sipariş", DisplayOrder = 1 },
                    new Menu { Id = 7, ParentMenuId = 6, Name = "Sipariş Listesi", DisplayOrder = 0, Url = "/order/index" },
                    new Menu { Id = 17, ParentMenuId = 6, Name = "Sepet Listesi", DisplayOrder = 0, Url = "/basket/index" },


                    new Menu { Id = 8, Name = "Adres", DisplayOrder = 2 },
                    new Menu { Id = 9, ParentMenuId = 8, Name = "Adres Listesi", DisplayOrder = 0, Url = "/adress/index" },
                    new Menu { Id = 10, ParentMenuId = 8, Name = "Ülke Listesi", DisplayOrder = 1, Url = "/country/index" },
                    new Menu { Id = 11, ParentMenuId = 8, Name = "Şehir Listesi", DisplayOrder = 2, Url = "/city/index" },

                    new Menu { Id = 13, Name = "Kullanıcı İşlemleri", DisplayOrder = 0, IsAdmin = true },
                    new Menu { Id = 14, ParentMenuId = 13, Name = "Kullanıcı Listesi", DisplayOrder = 0, IsAdmin = true, Url = "/user/index" },
                    new Menu { Id = 15, ParentMenuId = 13, Name = "Roller", DisplayOrder = 1, IsAdmin = true, Url = "/operationclaim/index" },
                    new Menu { Id = 16, ParentMenuId = 13, Name = "Kullanıcı Rolleri", DisplayOrder = 2, IsAdmin = true, Url = "/useroperationclaim/index" }
                );
        }
    }
}
