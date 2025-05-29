using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class EnrollmentDTO : BaseDto
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = null!; // Active, Completed, Dropped, Suspended

        public DateTime? CompletionDate { get; set; }

        public decimal Progress { get; set; }

        public string? CertificateUrl { get; set; }

        public string StudentName { get; set; } = null!;
        public string CourseTitle { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
    }
} 