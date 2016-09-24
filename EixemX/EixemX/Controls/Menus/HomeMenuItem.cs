using EixemX.Pages.Base;

namespace EixemX.Controls.Menus
{
    public class HomeMenuItem
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.Dashboard;
        }

        public string Icon { get; set; }

        public MenuType MenuType { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int Id { get; set; }
    }
}