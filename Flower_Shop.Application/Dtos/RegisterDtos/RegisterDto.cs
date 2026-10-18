using System;
namespace Flower_Shop.Application.Dtos.UsersDtos
{
    public class RegisterDto
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}