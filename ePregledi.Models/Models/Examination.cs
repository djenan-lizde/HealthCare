using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePregledi.Models.Models
{
    public class Examination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ExaminationDate { get; set; }

        [Required]
        public TimeSpan ExaminationTime { get; set; }

        [Required]
        public bool IsFinished { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        [ForeignKey(nameof(User))]
        public int DoctorId { get; set; }
        public User Doctor { get; set; }

        [ForeignKey(nameof(User))]
        public int PatientId { get; set; }
        public User Patient { get; set; }

        [ForeignKey(nameof(Ambulance))]
        public int AmbulanceId { get; set; }
        public Ambulance Ambulance { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
