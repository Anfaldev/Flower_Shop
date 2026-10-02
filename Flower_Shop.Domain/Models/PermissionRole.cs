using System.ComponentModel.DataAnnotations.Schema;
using Flower_Shop.Domain.Models;
using Flower_Shop.Models;

namespace Flower_Shop.Domain.Models
{
    public class PermissionRole
    {
        [ForeignKey(nameof(Permission))]
        public int PermissionId { get; set; }

        public Permission Permission { get; set; } = null!;

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;
    }
}