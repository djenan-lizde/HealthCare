namespace ePregledi.Models.Responses
{
    public class DoctorViewModel
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public int NumberOfExaminations { get; set; }
        public double AverageRating { get; set; }
    }
}
