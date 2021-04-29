using System;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.Models.Responses
{
    public class UserRegistrationResult
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public byte[] Photo { get; set; }
        public Role Role { get; set; }
    }
}
