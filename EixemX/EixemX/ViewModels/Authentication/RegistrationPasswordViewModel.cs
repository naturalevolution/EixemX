using System;
using EixemX.Extensions;
using EixemX.Factories;
using EixemX.Pages.Authentication;
using EixemX.Services.Account;
using EixemX.ViewModels.Base;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace EixemX.ViewModels.Authentication
{
    public class RegistrationPasswordViewModel : BaseViewModel
    {
        public RegistrationModel Model { get; set; }

        public RegistrationPasswordViewModel(RegistrationModel model, INavigation navigation) :base(navigation)
        {
            Model = model;
        } 

        public async void NextClicked(object sender, EventArgs e)
        { 
            LogDebug("NextClicked");
            if (Model.IsValidPassword())
            {
                await PushAsync(new RegistrationPasswordConfirmPage(Model));
            }
            else
            {
                DisplayMessage = Model.GetErrorMessage();
            }
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.Transparent);
        } 

        public async void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            await PopAsync();
        } 
    }
}