namespace Domain.Entities
{
public class Session : BaseEntity
{
    public string SessionName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string SessionType { get; set; } = null!;
    public string ContentUrl { get; set; } = null!;

    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;
}

}
