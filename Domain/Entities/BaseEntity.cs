using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class BaseEntity
{
    public Guid Id { get; set; }
}

}
