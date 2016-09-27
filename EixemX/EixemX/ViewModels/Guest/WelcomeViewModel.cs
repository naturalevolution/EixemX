using System;
using EixemX.Factories;
using EixemX.Pages.Authentication;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Guest
{
    public class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel(INavigation navigation = null) : base(navigation)
        {
            
        }

        public async void SignInPageClicked(object sender, EventArgs eventArgs)
        {
            LogDebug("SignInPageClicked");
           // await Navigation.PushAsync(new SignInPage());
            await PushAsync(new SignInPage());
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.Transparent);
        }

        public async void RegistrationPageClicked(object sender, EventArgs eventArgs)
        {
            LogDebug("RegistrationPageClicked");
            // await Navigation.PushAsync(new RegistrationPage());
            await PushAsync(new RegistrationPage());
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.White);
        }
    }
}