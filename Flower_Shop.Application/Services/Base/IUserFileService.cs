using Flower_Shop.Application.Dtos.UserFilesDtos;
using Flower_Shop.Domain.Models;

namespace Flower_Shop.Application.Services
{
    public interface IUserFileService
    {
        IEnumerable<UserFileDto> GetFilesByUserId(int userId);

        UserFile? GetUserFileById(int id);

        UserFile? GetUserFileByUid(string uid);

        void AddUserFile(CreateUserFileDto dto, string fileUrl);

        void DeleteUserFile(int id);
    }
}