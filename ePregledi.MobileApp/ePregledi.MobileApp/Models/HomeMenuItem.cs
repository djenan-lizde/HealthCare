namespace ePregledi.MobileApp.Models
{
    public enum MenuItemType
    {
        ReserveExamination,
        SearchExamination,
        AboutUs,
        EditUser
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
