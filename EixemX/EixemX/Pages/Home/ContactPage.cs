using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Base;
using EixemX.Pages.Menus;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class ContactPage : ModelBoundContentPage<ContactViewModel>
    {
        public ContactPage()
        {
            BindingContext = new ContactViewModel(Navigation);

             
            var label = new CustomLabel
            {
                Text = "ContactPage",
                TextColor = Color.White
            };

            Content = ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        } 
    }
}