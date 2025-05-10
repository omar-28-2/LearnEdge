
namespace Domain.Entities
{
public class Progress : BaseEntity
{
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }

    public Guid EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; } = null!;
}

}
