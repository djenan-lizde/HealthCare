using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.Models.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
