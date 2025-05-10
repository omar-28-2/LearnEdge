using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class QRCodeValidationConfiguration : IEntityTypeConfiguration<QRCodeValidation>
{
    public void Configure(EntityTypeBuilder<QRCodeValidation> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.QRCode).IsRequired();
        builder.Property(q => q.IsValidated).IsRequired();

        builder.HasOne(q => q.Enrollment)
                .WithOne(e => e.QRCodeValidation)
                .HasForeignKey<QRCodeValidation>(q => q.EnrollmentId);
    }
}
