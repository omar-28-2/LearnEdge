﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Course : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
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

        public double AverageRating { get; set; }

        [Required]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}