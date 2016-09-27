using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class EmprunterPage : ModelBoundContentPage<EmprunterViewModel>
    {
        public EmprunterPage()
        {
            BindingContext = new EmprunterViewModel(Navigation);
             
            var label = new Label
            {
                Text = "EmprunterPage",
                TextColor = Color.White
            };

            Content = ComponentFactories.Layouts.ContentWithNavigation(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        }
    }
}