using Domain.Interfaces.Repositories;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICourseRepository Courses { get; }
        Task<int> CompleteAsync();
    }
} 