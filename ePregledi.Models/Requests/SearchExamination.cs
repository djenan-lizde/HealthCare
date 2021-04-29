using System;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.Models.Requests
{
    public class SearchExamination
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string PatientFullName { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
