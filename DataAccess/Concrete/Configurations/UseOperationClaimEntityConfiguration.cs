using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class UseOperationClaimEntityConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(x => new { x.UserId, x.OperationClaimId });

            builder.HasOne(a => a.User)
                .WithMany(a => a.UserOperationClaims)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(a => a.OperationClaim)
                .WithMany(a => a.UserOperationClaims)
                .HasForeignKey(a => a.OperationClaimId);
        }
    }
}