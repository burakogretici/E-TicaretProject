using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class IndividualEntityConfiguration : BaseEntityConfiguration<Individual>
    {
        public override void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder.Property(a => a.CustomerId).HasColumnName("CustomerId").IsRequired();
            builder.Property(a => a.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(a => a.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired();
            builder.Property(a => a.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired();
        

            builder.HasOne(a => a.Customer)
                .WithMany(a => a.Individuals).HasForeignKey(a => a.CustomerId);

            base.Configure(builder);
        }
    }
}
