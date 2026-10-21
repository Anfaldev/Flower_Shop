using Flower_Shop.Application.Dtos.UsersDtos;
using Flower_Shop.Domain.Models;

namespace Flower_Shop.Application.Services
{
    public interface IUserService
    {
        User? Login(LoginDto loginDto);

        User? Register(RegisterDto registerDto);

        User? GetUserByUsername(string username);
    }
}