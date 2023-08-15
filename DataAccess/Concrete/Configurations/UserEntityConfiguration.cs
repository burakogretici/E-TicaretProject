using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(s => s.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired();
            builder.Property(s => s.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired();
            builder.Property(s => s.FullName).HasColumnName("FullName").HasMaxLength(200).IsRequired();
            builder.Property(s => s.Email).HasColumnName("Email").HasMaxLength(50).IsRequired();
            builder.Property(s => s.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(s => s.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(s => s.Phone).HasColumnName("Phone").HasMaxLength(30);
            builder.Property(s => s.IsActive).HasColumnName("IsActive");


            builder.HasMany(a => a.UserOperationClaims)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.Orders)
              .WithOne(a => a.User)
              .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.HasMany(a => a.Baskets)
              .WithOne(a => a.User)
              .HasForeignKey(a => a.UserId);

            base.Configure(builder);
        }
    }
}