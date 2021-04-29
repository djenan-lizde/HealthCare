using System;
using System.ComponentModel.DataAnnotations;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.Models.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required]
        public byte[] Photo { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
