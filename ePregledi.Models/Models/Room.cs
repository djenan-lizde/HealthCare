using System.ComponentModel.DataAnnotations;

namespace ePregledi.Models.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
