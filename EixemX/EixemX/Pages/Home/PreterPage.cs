using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class PreterPage : ModelBoundContentPage<PreterViewModel>
    {
        public PreterPage()
        {
            BindingContext = new PreterViewModel(Navigation);

             
            var label = new Label
            {
                Text = "PreterPage",
                TextColor = Color.White
            };

            Content = layoutFactory.ContentWithNavigation(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        }
    }
}