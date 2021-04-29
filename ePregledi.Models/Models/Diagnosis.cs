using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePregledi.Models.Models
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DiagnosisName { get; set; }

        [Required]
        public string Description { get; set; }



        [ForeignKey(nameof(Examination))]
        public int ExaminationId { get; set; }
        public Examination Examination { get; set; }
    }
}
