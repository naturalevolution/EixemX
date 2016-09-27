using System;
using EixemX.Extensions;
using EixemX.Factories;
using EixemX.Pages.Authentication;
using EixemX.Services.Account;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Authentication
{
    public class RegistrationViewModel : BaseViewModel
    {
        public RegistrationModel Model
        {
            get { return _model ?? (_model = new RegistrationModel()); }
            set { _model = value;
                //SetProperty(ref _lastname, value, "Lastname");
            }
        }

        public RegistrationViewModel(INavigation navigation) : base(navigation)
        {
            
        } 

        private RegistrationModel _model;
         

        public async void NextClicked(object sender, EventArgs e)
        {
            LogDebug("NextClicked");
            if (Model.IsValidMandatory())
            { 
                await PushAsync(new RegistrationPasswordPage(Model));
            }
            else
            {
                DisplayMessage = Model.GetErrorMessage();
            }
            ComponentFactories.Buttons.SetToDefault(sender as Button, ButtonStyle.Transparent);
        }


        public async void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            await PopAsync();
        }

        public async void BackBarButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackBarButtonClicked");
            await PopAsync();
            ComponentFactories.Buttons.SetToDefault(sender as Button, ButtonStyle.White);
        }
    }
}