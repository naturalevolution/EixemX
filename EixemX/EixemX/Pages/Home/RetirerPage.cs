using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class RetirerPage : ModelBoundContentPage<RetirerViewModel>
    {
        public RetirerPage()
        {
            BindingContext = new RetirerViewModel(Navigation);
             
            var label = new Label
            {
                Text = "RetirerPage",
                TextColor = Color.White
            };

            Content = ComponentFactories.Layouts.ContentWithNavigation(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        }
    }
}