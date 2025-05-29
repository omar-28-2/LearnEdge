using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class CourseDTO : BaseDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Duration { get; set; } // in hours

        [Required]
        [StringLength(50)]
        public string Level { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = null!;

        public bool IsActive { get; set; }

        public int TotalEnrollments { get; set; }

        public double AverageRating { get; set; }

        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; } = null!;
    }
} 