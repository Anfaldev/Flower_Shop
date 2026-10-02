using System.ComponentModel.DataAnnotations.Schema;
using Flower_Shop.Models;

namespace Flower_Shop.Domain.Models
{
    public class RoleUser
    {
        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        public Role Roles { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public User Users { get; set; }
    }
}
