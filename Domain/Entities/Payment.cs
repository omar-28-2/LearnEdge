﻿using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Money Amount { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = null!;

        [Required]
        public PaymentStatus Status { get; set; }

        [Required]
        [StringLength(100)]
        public string TransactionId { get; set; } = null!;

        public string? Notes { get; set; }

        public DateTime? PaidAt { get; set; }

        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}

