using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePregledi.Models.Models
{
    public class Referral
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public string Info { get; set; }

        [ForeignKey(nameof(Examination))]
        public int ExaminationId { get; set; }
        public Examination Examination { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
