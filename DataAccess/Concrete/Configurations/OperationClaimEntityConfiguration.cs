using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.Configurations
{
    public class OperationClaimEntityConfiguration : BaseEntityConfiguration<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.Property(o => o.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(a => a.UserOperationClaims)
                .WithOne(a => a.OperationClaim)
                .HasForeignKey(a => a.OperationClaimId);
           
                builder.HasData(
         new OperationClaim { Id = Guid.NewGuid(), Name = "Admin" },
            #region Category Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "Category.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Category.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Category.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Category.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Category.Get" },
            #endregion
            #region Product Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "Product.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Product.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Product.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Product.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Product.Get" },
            #endregion
            #region Color Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "Color.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Color.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Color.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Color.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Color.Get" },
            #endregion
            #region Brand Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "Brand.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Brand.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Brand.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Brand.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Brand.Get" },
            #endregion
            #region Address Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "Address.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Address.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Address.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Address.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Address.Get" },
            #endregion
            #region Menu Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "Menu.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Menu.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Menu.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Menu.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "Menu.Get" },
            #endregion
            #region User Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "User.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "User.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "User.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "User.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "User.Get" },
            #endregion
            #region OperationClaim Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "OperationClaim.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "OperationClaim.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "OperationClaim.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "OperationClaim.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "OperationClaim.Get" },
            #endregion
            #region UserOperationClaim Claim
               new OperationClaim { Id = Guid.NewGuid(), Name = "UserOperationClaim.Add" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "UserOperationClaim.List" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "UserOperationClaim.Delete" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "UserOperationClaim.Update" },
               new OperationClaim { Id = Guid.NewGuid(), Name = "UserOperationClaim.Get" });
            #endregion

            base.Configure(builder);
        }
    }
}