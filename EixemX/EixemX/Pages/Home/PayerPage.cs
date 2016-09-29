using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class PayerPage : ModelBoundContentPage<PayerViewModel>
    {
        public PayerPage()
        {
            BindingContext = new PayerViewModel(Navigation);
             
            var label = new CustomLabel
            {
                Text = "PayerPage",
                TextColor = Color.White
            };


            Content = ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        }
    }
}