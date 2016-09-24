using EixemX.Constants;
using Microsoft.Data.OData;
using Xamarin.Forms;

namespace EixemX.Controls.Navigations
{
    public class DefaultNavigationPage : NavigationPage
    {
        public DefaultNavigationPage(Page root)
            : base(root)
        {
            Init();
        }

        public DefaultNavigationPage()
        {
            Init();
        }

        void Init()
        { 
            BarBackgroundColor = Palette.Transparent;
            BarTextColor = Palette.White;
            BackgroundColor = Palette.Transparent; 
        }
    }
}