using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface IUserService
    {
        User? GetUserByUsername(string username);
    }
}