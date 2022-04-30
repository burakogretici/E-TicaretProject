using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            base.Configure(builder);
        }
    }
}