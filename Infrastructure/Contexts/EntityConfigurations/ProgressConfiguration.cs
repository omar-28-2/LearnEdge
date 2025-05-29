using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Contexts.EntityConfigurations
{
    public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
    {
        public void Configure(EntityTypeBuilder<Progress> builder)
        {
            builder.Property(p => p.CompletionPercentage).IsRequired().HasPrecision(5, 2);
            builder.Property(p => p.LastAccessed).IsRequired();
            builder.Property(p => p.Notes).HasMaxLength(500);

            // Configure relationships
            builder.HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Course)
                .WithMany()
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.CompletedSessions)
                .WithMany()
                .UsingEntity(j => j.ToTable("ProgressCompletedSessions"));

            // Configure soft delete
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
