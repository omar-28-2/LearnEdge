using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;  

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.IsPaid).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();

        builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.QRCodeValidation)
                .WithOne(q => q.Enrollment)
                .HasForeignKey<QRCodeValidation>(q => q.EnrollmentId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Progress)
                .WithOne(p => p.Enrollment)
                .HasForeignKey<Progress>(p => p.EnrollmentId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
