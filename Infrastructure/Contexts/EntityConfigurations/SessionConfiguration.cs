using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Contexts.EntityConfigurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(s => s.Title).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Description).IsRequired().HasMaxLength(500);
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.RecordingUrl).HasMaxLength(500);

            // Configure relationships
            builder.HasOne(s => s.Course)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure soft delete
            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
