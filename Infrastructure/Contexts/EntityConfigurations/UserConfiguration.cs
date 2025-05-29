using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Contexts.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.MName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Gender).IsRequired().HasMaxLength(10);
            builder.Property(u => u.Role).IsRequired().HasMaxLength(20);
            builder.Property(u => u.AuthProvider).IsRequired().HasMaxLength(50);
            builder.Property(u => u.AuthProviderId).IsRequired().HasMaxLength(100);

            // Configure Address value object
            builder.OwnsOne(u => u.Address, a =>
            {
                a.Property(addr => addr.Street).IsRequired().HasMaxLength(200);
                a.Property(addr => addr.City).IsRequired().HasMaxLength(100);
                a.Property(addr => addr.State).IsRequired().HasMaxLength(100);
                a.Property(addr => addr.Country).IsRequired().HasMaxLength(100);
                a.Property(addr => addr.PostalCode).IsRequired().HasMaxLength(20);
            });

            // Configure relationships
            builder.HasOne(u => u.Teacher)
                .WithOne(t => t.User)
                .HasForeignKey<Teacher>(t => t.UserId);

            builder.HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId);

            // Configure soft delete
            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
