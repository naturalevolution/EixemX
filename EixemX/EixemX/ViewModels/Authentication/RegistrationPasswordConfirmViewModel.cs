using System;
using System.Threading.Tasks;
using EixemX.Extensions;
using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Localization;
using EixemX.Services.Account;
using EixemX.ViewModels.Base;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace EixemX.ViewModels.Authentication
{
    public class RegistrationPasswordConfirmViewModel : BaseViewModel
    { 

        public RegistrationPasswordConfirmViewModel(RegistrationModel model, INavigation navigation) : base(navigation)
        {
            Model = model; 
        }
         
        public RegistrationModel Model { get; set; }
         

        public async void NextClicked(object sender, EventArgs e)
        { 
            LogDebug("NextClicked");
            await App.ExecuteIfConnectedToInternet(async () =>
            {
                // ViewModel.ShowSpinner = true;

                if (Model.IsValid())
                {
                    if (await RegisterAndAuthenticate())
                    {
                        App.GoToRoot();

                        MessagingCenter.Send(this, MessagingServiceConstants.REGISTERED);
                    }
                    else
                    {
                        DisplayMessage = TextResources.Alert_Registration_Retry;
                    }
                }
                else
                {
                    DisplayMessage = Model.GetErrorMessage();
                }
            });
            ComponentFactories.Buttons.SetToDefault(sender as Button, ButtonStyle.Transparent);
        }

        private async Task<bool> RegisterAndAuthenticate()
        {
            var success = false;
            try
            { 
                DisplayMessage = TextResources.Alert_Registration_InProgress;

                if (await authenticationService.RegisterAsync(Model))
                { 
                    success = await authenticationService.AuthenticateAsync(Model.Email, Model.Password);
                } 
            }
            catch (Exception ex)
            {
                if (ex is AdalException && ((ex as AdalException).ErrorCode == "authentication_canceled"))
                    ex.WriteFormattedMessageToDebugConsole(this);
            }
            finally
            {
                //ViewModel.ShowSpinner = false;
            }
            return success;
        }

        public async void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            await PopAsync();
        } 
    }
}