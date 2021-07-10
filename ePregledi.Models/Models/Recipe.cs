using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePregledi.Models.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Medicine))]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Required]
        public string Instruction { get; set; }

        [Required]
        public byte[] PdfDocument { get; set; }

        [ForeignKey(nameof(Diagnosis))]
        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}
