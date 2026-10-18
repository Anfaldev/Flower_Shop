using Flower_Shop.Application.Dtos.UsersDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;


namespace Flower_Shop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User? GetUserByUsername(string username)
        {
            return _unitOfWork.UserRepo
                .GetAll()
                .FirstOrDefault(u => u.Username == username);
        }


        public bool Login(LoginDto loginDto)
        {
            var user = _unitOfWork.UserRepo
                .GetByUsername(loginDto.Username);

            if (user == null ||
                string.IsNullOrEmpty(user.PasswordHash))
            {
                return false;
            }

            bool userFound = BCrypt.Net.BCrypt.Verify(
                loginDto.Password,
                user.PasswordHash
            );

            return userFound;
        }


        public bool Register(RegisterDto registerDto)
        {
            var existingUsername = _unitOfWork.UserRepo
                 .GetByUsername(registerDto.Username);

            var existingEmail = _unitOfWork.UserRepo
                .GetByEmail(registerDto.Email);

            if (existingUsername != null || existingEmail != null)
            {
                return false;
            }

            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Username = registerDto.Username,
                Password = registerDto.Password,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(
                    registerDto.Password
                )
            };

            _unitOfWork.UserRepo.Add(user);

            _unitOfWork.Save();

            return true;
        }
    }
}