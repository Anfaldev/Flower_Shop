namespace Flower_Shop.Application.Dtos.RolesDtos
{
    public class CreateRoleDto
    {
        public string Name { get; set; } = "";
    }

    public class UpdateRoleDto : CreateRoleDto
    {
        public int Id { get; set; }
        public string UID { get; set; } = "";
    }

    public class RoleDto : UpdateRoleDto
    {
    }
}