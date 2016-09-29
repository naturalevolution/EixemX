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
            await PushAsync(new SignInPage());
            ComponentFactories.Buttons.SetToDefault(sender as Button, ButtonStyle.Transparent);
        }

        public async void RegistrationPageClicked(object sender, EventArgs eventArgs)
        {
            LogDebug("RegistrationPageClicked"); 
            await PushAsync(new RegistrationPage());
            ComponentFactories.Buttons.SetToDefault(sender as Button, ButtonStyle.White);
        }
    }
}