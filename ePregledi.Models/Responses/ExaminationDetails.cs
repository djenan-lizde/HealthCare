using ePregledi.Models.Models;
using System;

namespace ePregledi.Models.Responses
{
    public class ExaminationDetails
    {
        public int ExaminationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public Recipe Recipe { get; set; }
        public Referral Referral { get; set; }
    }
}
