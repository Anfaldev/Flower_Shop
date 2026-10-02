using Flower_Shop.Application.Dtos.UserFilesDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;

namespace Flower_Shop.Application.Services
{
    public class UserFileService : IUserFileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserFileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserFileDto> GetFilesByUserId(int userId)
        {
            return _unitOfWork.UserFileRepo
                .GetAll()
                .Where(f => f.UserID == userId)
                .Select(f => new UserFileDto
                {
                    Id = f.Id,
                    UID = f.UID,
                    Name = f.Name,
                    FileURL = f.FileURL,
                    UserID = f.UserID
                })
                .ToList();
        }

        public UserFile? GetUserFileById(int id)
        {
            return _unitOfWork.UserFileRepo.GetById(id);
        }

        public UserFile? GetUserFileByUid(string uid)
        {
            return _unitOfWork.UserFileRepo.GetByUId(uid);
        }

        public void AddUserFile(
            CreateUserFileDto dto,
            string fileUrl)
        {
            var userFile = new UserFile
            {
                Name = dto.Name,
                FileURL = fileUrl,
                UserID = dto.UserID
            };

            _unitOfWork.UserFileRepo.Add(userFile);
            _unitOfWork.Save();
        }

        public void DeleteUserFile(int id)
        {
            var userFile =
                _unitOfWork.UserFileRepo.GetById(id);

            if (userFile == null)
            {
                return;
            }

            _unitOfWork.UserFileRepo.Delete(userFile);
            _unitOfWork.Save();
        }
    }
}