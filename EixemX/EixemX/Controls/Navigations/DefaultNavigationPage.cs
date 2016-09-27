using EixemX.Constants;
using EixemX.Factories;
using Microsoft.Data.OData;
using Xamarin.Forms;

namespace EixemX.Controls.Navigations
{
    public class DefaultNavigationPage : NavigationPage
    {
        private Page _root;
        public DefaultNavigationPage(Page root)
            : base(root)
        {
            Init(root);
        }

        public DefaultNavigationPage()
        {
            Init(null);
        }

        void Init(Page root)
        {
            _root = root;
            var imageFactory = DependencyService.Get<IImageFactory>();

            BarBackgroundColor = Palette.White;
            BarTextColor = Palette.Green;
            BackgroundColor = Color.Black;
            Icon = imageFactory.NavigationIcon();
            if (_root != null)
            {
                SetHasNavigationBar(_root, false);
                SetHasNavigationBar(this, false);
            }
        }
    }
}