using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace EixemX.Pages.Home
{
    public class ProfessionalPage : ModelBoundContentPage<ProfessionalViewModel>
    {
        public ProfessionalPage()
        {
            BindingContext = new ProfessionalViewModel(Navigation); 
            var label = new CustomLabel
            {
                Text = "ProfessionalPage",
                TextColor = Color.White
            };

            Content = ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        }
    }
}