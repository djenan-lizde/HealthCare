namespace ePregledi.Models.Responses
{
    public class UserEditViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public byte[] Photo { get; set; }
        public string Email { get; set; }
    }
}
