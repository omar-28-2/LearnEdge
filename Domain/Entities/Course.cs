namespace Domain.Entities
{
public class Course : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string Level { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;

    public ICollection<Session> Sessions { get; set; } = new List<Session>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

}