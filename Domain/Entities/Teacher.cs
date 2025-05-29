using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Teacher : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Specialization { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Bio { get; set; } = null!;

        public int YearsOfExperience { get; set; }

        public double Rating { get; set; }

        public bool IsVerified { get; set; }

        public string ProfilePictureUrl { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
