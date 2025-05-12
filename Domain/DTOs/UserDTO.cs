namespace Domain.DTOs
{
    public class UserDTO
    {
        
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public string City { get; set; }
        public string Governorate { get; set; }

        public string? TeacherSpecialization { get; set; }
        public ICollection<string>? TeacherCourses { get; set; } = new List<string>();

        
        public string? StudentLevel { get; set; }
        public string? StudentSpecialization { get; set; }
        public ICollection<string>? StudentEnrollments { get; set; } = new List<string>();
        public ICollection<decimal>? StudentPayments { get; set; } = new List<decimal>();
        public int? StudentAge { get; set; }
    }
}
