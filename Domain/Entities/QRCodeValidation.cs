namespace Domain.Entities
{
    public class QRCodeValidation : BaseEntity
    {
        public string QRCode { get; set; } = null!;
        public bool IsValidated { get; set; }
        public DateTime? ValidatedAt { get; set; }
        public Guid EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; } = null!;
    }
}
