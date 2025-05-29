using Application.Interfaces.Services;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> CreateAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateAsync(Guid id, UserDTO userDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found");

            _mapper.Map(userDto, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found");

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDTO> GetByEmailAsync(string email)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email);
            if (user == null)
                return false;

            // TODO: Implement proper password hashing and validation
            return user.PasswordHash == password;
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await _unitOfWork.Users.IsEmailUniqueAsync(email);
        }

        public async Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber)
        {
            return await _unitOfWork.Users.IsPhoneNumberUniqueAsync(phoneNumber);
        }
    }
} 