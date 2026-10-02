using Flower_Shop.Infrastructure.Repositories;
using Flower_Shop.Models;


namespace Flower_Shop.Application.Services
{
    public class EmployeeFileService : IEmployeeFileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeFileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EmployeeFile> GetAllEmployeeFiles()
        {
            return _unitOfWork.EmployeeFileRepo.GetAll();
        }

        public EmployeeFile? GetEmployeeFileById(int id)
        {
            return _unitOfWork.EmployeeFileRepo.GetById(id);
        }

        public EmployeeFile? GetEmployeeFileByUid(string uid)
        {
            return _unitOfWork.EmployeeFileRepo.GetByUId(uid);
        }

        public IEnumerable<EmployeeFile> GetFilesByEmployeeId(int employeeId)
        {
            return _unitOfWork.EmployeeFileRepo
                .GetAll()
                .Where(f => f.EmployeeID == employeeId)
                .ToList();
        }

        public void AddEmployeeFile(EmployeeFile employeeFile)
        {
            _unitOfWork.EmployeeFileRepo.Add(employeeFile);
            _unitOfWork.Save();
        }

        public void UpdateEmployeeFile(EmployeeFile employeeFile)
        {
            var existingFile = _unitOfWork.EmployeeFileRepo
                .GetById(employeeFile.Id);

            if (existingFile == null)
            {
                return;
            }

            existingFile.Name = employeeFile.Name;
            existingFile.FileURL = employeeFile.FileURL;
            existingFile.EmployeeID = employeeFile.EmployeeID;

            _unitOfWork.EmployeeFileRepo.Update(existingFile);
            _unitOfWork.Save();
        }

        public void DeleteEmployeeFile(int id)
        {
            var employeeFile = _unitOfWork.EmployeeFileRepo
                .GetById(id);

            if (employeeFile == null)
            {
                return;
            }

            _unitOfWork.EmployeeFileRepo.Delete(employeeFile);
            _unitOfWork.Save();
        }
    }
}