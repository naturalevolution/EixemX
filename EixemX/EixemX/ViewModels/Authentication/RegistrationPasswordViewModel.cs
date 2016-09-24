using System;
using EixemX.Factories;
using EixemX.Pages.Authentication;
using EixemX.ViewModels.Base;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace EixemX.ViewModels.Authentication
{
    public class RegistrationPasswordViewModel : BaseViewModel
    {
        public RegistrationPasswordViewModel(INavigation navigation) :base(navigation)
        {
            
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                SetProperty(ref _password, value, "Password");
            }
        }

        public async void NextClicked(object sender, EventArgs e)
        { 
            LogDebug("NextClicked");
            await PushAsync(new RegistrationPasswordConfirmPage());
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.Transparent);
        } 

        public async void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            await PopAsync();
        } 
    }
}