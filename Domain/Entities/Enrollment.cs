namespace Domain.Entities
{
public class Enrollment : BaseEntity
{
    public bool IsPaid { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public QRCodeValidation? QRCodeValidation { get; set; }
    public Progress? Progress { get; set; }
}

}
