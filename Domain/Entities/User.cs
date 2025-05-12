namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string AuthProvider { get; set; } = null!;
        public string AuthProviderId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        
        public DateTime DateOfBirth { get; set; } 
        public string City { get; set; } = null!;
        public string Governorate { get; set; } = null!;

        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
        public void SetPassword(string password)
        {
            PasswordHash = HashPassword(password);
        }
        private string HashPassword(string password)
        {
            
            return password; 
        }
    }
}
