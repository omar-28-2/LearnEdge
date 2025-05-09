using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.AmountPaid).IsRequired().HasPrecision(18, 2);;
        builder.Property(p => p.PaymentStatus).IsRequired();
        builder.Property(p => p.PaymentMethod).IsRequired();
        builder.Property(p => p.PaymentReferenceId).IsRequired();
        builder.Property(p => p.PaymentDate).IsRequired();

        builder.HasOne(p => p.Student)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.StudentId);
    }
}
