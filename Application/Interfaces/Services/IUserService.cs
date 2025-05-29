using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> CreateAsync(UserDTO userDto);
        Task UpdateAsync(Guid id, UserDTO userDto);
        Task DeleteAsync(Guid id);
        Task<UserDTO> GetByEmailAsync(string email);
        Task<bool> ValidateUserAsync(string email, string password);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber);
    }
} 