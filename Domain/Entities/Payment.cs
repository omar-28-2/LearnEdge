namespace Domain.Entities
{
public class Payment : BaseEntity
{
    public decimal AmountPaid { get; set; }
    public string PaymentStatus { get; set; } = null!;
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = null!;
    public string PaymentReferenceId { get; set; } = null!;

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;
}


}

