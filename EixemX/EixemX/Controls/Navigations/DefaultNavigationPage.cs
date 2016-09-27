using EixemX.Constants;
using EixemX.Factories;
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
            BarBackgroundColor = Palette.White;
            BarTextColor = Palette.Green;
            BackgroundColor = Color.Black;
            Icon = ComponentFactories.Images.NavigationIcon(); 
        }
    }
}