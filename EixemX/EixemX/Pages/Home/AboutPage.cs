using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class AboutPage : ModelBoundContentPage<AboutViewModel>
    {
        public AboutPage()
        {
            BindingContext = new AboutViewModel(Navigation);
             
            var label = new Label
            {
                Text = "AboutPage",
                TextColor = Color.Black,
                BackgroundColor = Color.White
            };

            Content = layoutFactory.ContentWithNavigation(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        }
    }
}