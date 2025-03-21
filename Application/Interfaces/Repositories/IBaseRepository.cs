using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        // GET 
        Task<T> GetbyId(int id);

        // Create 
        Task<T> Create(T entity);

        // Update
        Task<T> Update(T entity);

        // Delete
        Task<T> Delete(int id);
    }
}
