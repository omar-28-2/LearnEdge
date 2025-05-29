using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string MName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = null!;

        [Required]
        public Address Address { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string AuthProvider { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string AuthProviderId { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }

        public void SetPassword(string password)
        {
            PasswordHash = HashPassword(password);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
