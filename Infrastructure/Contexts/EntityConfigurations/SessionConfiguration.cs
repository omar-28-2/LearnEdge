using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.SessionName).IsRequired();
        builder.Property(s => s.Description).IsRequired();
        builder.Property(s => s.SessionType).IsRequired();
        builder.Property(s => s.ContentUrl).IsRequired();

        builder.HasOne(s => s.Course)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CourseId);
    }
}
