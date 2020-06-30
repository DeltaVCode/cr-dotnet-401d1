namespace xam.Models
{
    public enum MenuItemType
    {
        Browse,
        Test,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
