using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Progress : BaseEntity
    {
        [Required]
        [Range(0, 100)]
        public decimal CompletionPercentage { get; set; }

        [Required]
        public DateTime LastAccessed { get; set; }

        public string? Notes { get; set; }

        [Required]
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = null!;

        [Required]
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public ICollection<Session> CompletedSessions { get; set; } = new List<Session>();
    }
}
