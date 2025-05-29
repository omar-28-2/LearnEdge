using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities
{
    public class Enrollment : BaseEntity
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        public EnrollmentStatus Status { get; set; }

        public DateTime? CompletionDate { get; set; }

        public decimal Progress { get; set; }

        public string? CertificateUrl { get; set; }

        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
