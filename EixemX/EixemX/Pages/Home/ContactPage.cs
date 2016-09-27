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

             
            var label = new Label
            {
                Text = "ContactPage",
                TextColor = Color.White
            };

            Content = layoutFactory.ContentWithNavigation(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        } 
    }
}