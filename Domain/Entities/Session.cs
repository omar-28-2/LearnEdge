using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities
{
    public class Session : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public SessionStatus Status { get; set; }

        public string? RecordingUrl { get; set; }

        public int TotalAttendees { get; set; }

        [Required]
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
