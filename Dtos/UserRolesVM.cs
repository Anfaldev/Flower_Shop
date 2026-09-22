namespace Flower_Shop.Dtos
{
    public class UserRolesVM
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = "";

        public List<RoleCheckVM> Roles { get; set; } = new List<RoleCheckVM>();
    }

    public class RoleCheckVM
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = "";

        public bool IsSelected { get; set; }
    }
}