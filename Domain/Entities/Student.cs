namespace Domain.Entities
{
public class Student : BaseEntity
{
    public string Level { get; set; } = null!;
    public string Specialization { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}


}
