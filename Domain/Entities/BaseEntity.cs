using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }

    public abstract class BaseEntity : IEntity, IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
