using System.ComponentModel.DataAnnotations;

namespace ePregledi.Models.Models
{
    public class Ambulance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
