using EixemX.Helpers.Constants;
using EixemX.Pages.Authentication;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            SetBinding(TitleProperty, new Binding {Source = "Dashboard Root"});

            Content = new Label {Text = "Welcome !!!"};

            // Catch the login success message from the MessagingCenter.
            // This is really only here for Android, which doesn't fire the OnAppearing() method in the same way that iOS does (every time the page appears on screen).
            //Device.OnPlatform(Android: () => MessagingCenter.Subscribe<SignInPage>(this, MessagingServiceConstants.AUTHENTICATED, sender => OnAppearing()));
            //Device.OnPlatform(Android: () => MessagingCenter.Subscribe<RegistrationPasswordConfirmPage>(this, MessagingServiceConstants.REGISTERED, sender => OnAppearing()));
             
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
             
        }
    }
}