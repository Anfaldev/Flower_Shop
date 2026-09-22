using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_Shop.Models
{
    public class UserFile
    {
        public int Id { get; set; }

        public string UID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = "";

        public string FileURL { get; set; } = "";

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public User? User { get; set; }
    }
}