using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class TeacherDTO : BaseDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Bio { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Specialization { get; set; } = null!;

        public int YearsOfExperience { get; set; }

        public double Rating { get; set; }

        public int TotalCourses { get; set; }

        public int TotalStudents { get; set; }

        public bool IsVerified { get; set; }

        public string ProfilePictureUrl { get; set; } = null!;
    }
} 