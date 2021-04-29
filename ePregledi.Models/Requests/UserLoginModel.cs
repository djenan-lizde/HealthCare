using System.ComponentModel.DataAnnotations;

namespace ePregledi.Models.Requests
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
