using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Infrastructure.Repositories;
using Flower_Shop.Infrastructure.Data;
using Flower_Shop.Application.Dtos.UsersDtos;
using Flower_Shop.Application.Dtos.UserFilesDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Application.Dtos;

namespace Flower_Shop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFileRepository _userFileRepository;
        private readonly AppDbContext _db;

        public UsersController(
            IUserRepository userRepository,
            IUserFileRepository userFileRepository,
            AppDbContext db)
        {
            _userRepository = userRepository;
            _userFileRepository = userFileRepository;
            _db = db;
        }

        public IActionResult Index()
        {
            var users = _userRepository
                .GetAll()
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UID = u.UID,
                    Name = u.Name,
                    Email = u.Email,
                    Username = u.Username
                })
                .ToList();

            return View(users);
        }

        [HttpPost]
        public IActionResult Create(CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Username = dto.Username,
                    Password = dto.Password,
                    PasswordHash =
                        BCrypt.Net.BCrypt.HashPassword(dto.Password)
                };

                _userRepository.Add(user);
                _userRepository.Save();
            }

            return RedirectToAction(nameof(Index));
        }

       
        [HttpPost]
        public IActionResult Edit(UpdateUserDto dto)
        {
            var oldUser = _userRepository.GetById(dto.Id);

            if (oldUser == null)
            {
                return NotFound();
            }

            oldUser.Name = dto.Name;
            oldUser.Email = dto.Email;
            oldUser.Username = dto.Username;

            if (!string.IsNullOrEmpty(dto.Password))
            {
                oldUser.Password = dto.Password;
                oldUser.PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(dto.Password);
            }

            _userRepository.Update(oldUser);
            _userRepository.Save();

            return RedirectToAction(nameof(Index));
        }

     
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _userRepository.GetById(id);

            if (user != null)
            {
                _userRepository.Delete(user);
                _userRepository.Save();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ManageRoles(string uid)
        {
            var user = _userRepository.GetByUId(uid);

            if (user == null)
            {
                return NotFound();
            }

            var roles = _db.Roles.ToList();

            var userRoleIds = _db.RoleUsers
                .Where(x => x.UserId == user.Id)
                .Select(x => x.RoleId)
                .ToList();

            var model = new UserRolesVM
            {
                UserId = user.Id,
                UserName = user.Name,

                Roles = roles.Select(role => new RoleCheckVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected =
                        userRoleIds.Contains(role.Id)
                }).ToList()
            };

            return View(model);
        }

     
        [HttpPost]
        public IActionResult ManageRoles(UserRolesVM model)
        {
            var user = _userRepository.GetById(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var oldRoles = _db.RoleUsers
                .Where(x => x.UserId == model.UserId)
                .ToList();

            _db.RoleUsers.RemoveRange(oldRoles);

            foreach (var role in model.Roles)
            {
                if (role.IsSelected)
                {
                    RoleUser roleUser = new RoleUser
                    {
                        UserId = model.UserId,
                        RoleId = role.RoleId
                    };

                    _db.RoleUsers.Add(roleUser);
                }
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

 
        private string UploadFiles(IFormFile file, string name)
        {
            string fileName =
                name + "_" + Guid.NewGuid().ToString()
                + Path.GetExtension(file.FileName);

            string folderPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "Files",
                "Users"
            );

            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(
                folderPath,
                fileName
            );

            using (var stream = new FileStream(
                filePath,
                FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/Files/Users/" + fileName;
        }

     
        [HttpGet]
        public IActionResult ManageFiles(string uid)
        {
            var user = _userRepository.GetByUId(uid);

            if (user == null)
            {
                return NotFound();
            }

            var files = _userFileRepository
                .GetAll()
                .Where(e => e.UserID == user.Id)
                .Select(e => new UserFileDto
                {
                    Id = e.Id,
                    UID = e.UID,
                    Name = e.Name,
                    FileURL = e.FileURL,
                    UserID = e.UserID
                })
                .ToList();

            ViewBag.UserName = user.Username;
            ViewBag.Files = files;

            CreateUserFileDto userFile =
                new CreateUserFileDto
                {
                    UserID = user.Id
                };

            return View(userFile);
        }

       
        [HttpPost]
        public IActionResult ManageFiles(
            CreateUserFileDto dto,
            IFormFile fileUser)
        {
            UserFile userFile = new UserFile
            {
                Name = dto.Name,
                UserID = dto.UserID
            };

            if (fileUser != null)
            {
                userFile.FileURL =
                    UploadFiles(fileUser, dto.Name);
            }

            _userFileRepository.Add(userFile);
            _userFileRepository.Save();

            var user = _userRepository.GetById(dto.UserID);

            return RedirectToAction(
                nameof(ManageFiles),
                new
                {
                    uid = user?.UID
                }
            );
        }

       
        [HttpPost]
        public IActionResult DeleteFile(string uid)
        {
            var file = _userFileRepository.GetByUId(uid);

            if (file == null)
            {
                return NotFound();
            }

            int userId = file.UserID;

            if (!string.IsNullOrEmpty(file.FileURL))
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    file.FileURL.TrimStart('/')
                );

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _userFileRepository.Delete(file);
            _userFileRepository.Save();

            var user = _userRepository.GetById(userId);

            return RedirectToAction(
                nameof(ManageFiles),
                new
                {
                    uid = user?.UID
                }
            );
        }
    }
}