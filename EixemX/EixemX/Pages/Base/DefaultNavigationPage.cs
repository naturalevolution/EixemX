using EixemX.Constants;
using EixemX.Factories;
using Xamarin.Forms;

namespace EixemX.Pages.Base
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
            BarBackgroundColor = Palette.White;
            BarTextColor = Palette.Green;
            BackgroundColor = Color.Black;
            Icon = ComponentFactories.Images.NavigationIcon(); 
        }
    }
}