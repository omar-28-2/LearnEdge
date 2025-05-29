using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class SessionDTO : BaseDto
    {
        [Required]
        public Guid CourseId { get; set; }

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
        [StringLength(50)]
        public string Status { get; set; } = null!; // Scheduled, In Progress, Completed, Cancelled

        public string? MeetingLink { get; set; }

        public string? RecordingUrl { get; set; }

        public int TotalAttendees { get; set; }

        public string CourseTitle { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
    }
} 