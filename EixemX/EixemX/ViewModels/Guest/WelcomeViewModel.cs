using System;
using EixemX.Factories;
using EixemX.Pages.Authentication;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Guest
{
    public class WelcomeViewModel : BaseViewModel
    {
        public async void NavigateToSignInPage(object sender, EventArgs eventArgs)
        {
            System.Diagnostics.Debug.WriteLine("NavigateToSignInPage");
            await Navigation.PushAsync(new SignInPage());
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.Transparent);
        }

        public async void NavigateToRegistrationPage(object sender, EventArgs eventArgs)
        {
            System.Diagnostics.Debug.WriteLine("NavigateToRegistrationPage");
            await Navigation.PushAsync(new RegistrationPage());
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.White);
        }
    }
}