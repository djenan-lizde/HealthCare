using System;

namespace ePregledi.Models.Requests
{
    public class ExaminationAvailability
    {
        public DateTime ExaminationDate { get; set; }
        public TimeSpan ExaminationTime { get; set; }
        public int DoctorId { get; set; }
    }
}
