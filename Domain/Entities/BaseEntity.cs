using System.ComponentModel.DataAnnotations;

namespace StudentVoiceNU.Domain.Entities
{
    public abstract class BaseEntity
    {

        // all features we will implement we should use id , created at , updated at to service on
        public int Id { get; set; }
        public DateTime createdAt { get; set; } 
        public DateTime updatedAt { get; set; }
    }
}
