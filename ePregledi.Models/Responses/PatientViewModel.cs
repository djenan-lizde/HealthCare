using System;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.Models.Responses
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public byte[] Photo { get; set; }
    }
}
