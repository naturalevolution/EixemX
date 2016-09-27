using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Authentication;
using EixemX.Pages.Base;
using EixemX.ViewModels.Authentication;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class DashboardPage : ModelBoundContentPage<DashboardViewModel>
    {
        public DashboardPage()
        {
            BindingContext = new DashboardViewModel(Navigation);

            // Catch the login success message from the MessagingCenter.
            // This is really only here for Android, which doesn't fire the OnAppearing() method in the same way that iOS does (every time the page appears on screen).
 
            /*Device.OnPlatform(Android:() =>
                    MessagingCenter.Subscribe<SignInViewModel>(this, MessagingServiceConstants.AUTHENTICATED, sender => Auth2())); 
*/
            Content = CreatePage(); 
        } 

        private Layout CreatePage()
        {
            var label = new Label
            {
                Text = "Dashborad page ",
                TextColor = Color.White
            };

            var result = ComponentFactories.Layouts.ContentWithNavigation(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);

            return result;
        }
    }
}