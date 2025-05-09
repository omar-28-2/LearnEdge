using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
{
    public void Configure(EntityTypeBuilder<Progress> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.IsCompleted).IsRequired();

        builder.HasOne(p => p.Enrollment)
                .WithOne(e => e.Progress)
                .HasForeignKey<Progress>(p => p.EnrollmentId);
    }
}
