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
    }
}