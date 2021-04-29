using System;

namespace ePregledi.Models.Responses
{
    public class ExaminationViewModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string ExaminationDate { get; set; }
        public string ExaminationTime { get; set; }
    }
}
