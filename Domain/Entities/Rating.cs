using System;

namespace Domain.Entities
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public double Score { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Course Course { get; set; }
        public User User { get; set; }
    }
} 