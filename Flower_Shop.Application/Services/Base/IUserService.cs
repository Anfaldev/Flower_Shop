using Flower_Shop.Application.Dtos.UsersDtos;
using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface IUserService
    {
        User? GetUserByUsername(string username);
        bool Login(LoginDto loginDto);
        bool Register(RegisterDto registerDto);
    }
}