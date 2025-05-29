using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class PaymentDTO : BaseDto
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = null!; // Pending, Completed, Failed, Refunded

        [Required]
        [StringLength(100)]
        public string TransactionId { get; set; } = null!;

        public string? Notes { get; set; }

        public DateTime? PaidAt { get; set; }

        public string StudentName { get; set; } = null!;
        public string CourseTitle { get; set; } = null!;
    }
} 