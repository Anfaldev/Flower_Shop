namespace Flower_Shop.Dtos.PermissionsDtos
{
    public class CreatePermissionDto
    {
        public string Name { get; set; } = "";
    }

    public class UpdatePermissionDto : CreatePermissionDto
    {
        public int Id { get; set; }
        public string UID { get; set; } = "";
    }

    public class PermissionDto : UpdatePermissionDto
    {
    }
}