namespace Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string Specialization { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
