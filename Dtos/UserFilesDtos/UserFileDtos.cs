namespace Flower_Shop.Dtos.UserFilesDtos
{
    public class CreateUserFileDto
    {
        public string Name { get; set; } = "";
        public string FileURL { get; set; } = "";
        public int UserID { get; set; }
    }

    public class UpdateUserFileDto : CreateUserFileDto
    {
        public int Id { get; set; }
        public string UID { get; set; } = "";
    }

    public class UserFileDto : UpdateUserFileDto
    {
        public string? UserName { get; set; }
    }
}