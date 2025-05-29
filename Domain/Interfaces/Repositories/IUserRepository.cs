using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber);
    }
} 