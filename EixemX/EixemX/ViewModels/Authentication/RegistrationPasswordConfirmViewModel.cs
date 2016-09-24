using System;
using System.Threading.Tasks;
using EixemX.Extensions;
using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Localization;
using EixemX.ViewModels.Base;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace EixemX.ViewModels.Authentication
{
    public class RegistrationPasswordConfirmViewModel : BaseViewModel
    {
        public RegistrationPasswordConfirmViewModel(INavigation navigation) :base(navigation)
        {
            
        }
        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                SetProperty(ref _confirmPassword, value, "ConfirmPassword");
            }
        }

        public async void NextClicked(object sender, EventArgs e)
        { 
            LogDebug("NextClicked");
            await App.ExecuteIfConnectedToInternet(async () =>
            {
                // ViewModel.ShowSpinner = true;

                if (await Authenticate())
                {
                    App.GoToRoot();

                    MessagingCenter.Send(this, MessagingServiceConstants.REGISTERED);
                }
                else
                {
                    DisplayMessage = TextResources.Alert_Registration_Retry;
                }
            });
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.Transparent);
        }

        private async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                DisplayMessage = TextResources.Alert_Authentication_InProgress;

                success = await authenticationService.AuthenticateAsync(ConfirmPassword, ConfirmPassword);
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