using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Contexts.EntityConfigurations
{
    public class QRCodeValidationConfiguration : IEntityTypeConfiguration<QRCodeValidation>
    {
        public void Configure(EntityTypeBuilder<QRCodeValidation> builder)
        {
            builder.Property(q => q.QRCode).IsRequired().HasMaxLength(100);
            builder.Property(q => q.IsValidated).IsRequired();

            // Configure relationships
            builder.HasOne(q => q.Enrollment)
                .WithMany()
                .HasForeignKey(q => q.EnrollmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure soft delete
            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}
