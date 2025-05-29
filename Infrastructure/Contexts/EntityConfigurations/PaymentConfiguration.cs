using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Contexts.EntityConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PaymentMethod).IsRequired().HasMaxLength(50);
            builder.Property(p => p.TransactionId).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Notes).HasMaxLength(500);
            builder.Property(p => p.Status).IsRequired();

            // Configure Money value object
            builder.OwnsOne(p => p.Amount, m =>
            {
                m.Property(money => money.Amount).IsRequired().HasPrecision(18, 2);
                m.Property(money => money.Currency).IsRequired().HasMaxLength(3);
            });

            // Configure relationships
            builder.HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Course)
                .WithMany()
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure soft delete
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
