﻿using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EixemX.Extensions;
using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Localization;
using EixemX.Pages.Guest;
using EixemX.ViewModels.Base;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

namespace EixemX.ViewModels.Authentication
{
    public class SignInViewModel : BaseViewModel
    {
        private string _password;

        private string _username;

        public SignInViewModel(INavigation navigation = null)
            : base(navigation)
        {
        }
         
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value, "Username"); }
        }
         
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
         
        public async void SignInClicked(object sender, EventArgs e)
        {
            await App.ExecuteIfConnectedToInternet(async () =>
            {
                // ViewModel.ShowSpinner = true;

                if (await Authenticate())
                {
                    App.GoToRoot();

                    MessagingCenter.Send(this, MessagingServiceConstants.AUTHENTICATED);
                }
                else
                {
                    DisplayMessage = TextResources.Alert_Authentication_Credential;
                }
            });
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.Transparent);
        } 

        public async Task LoadDemoCredentials()
        {
            Username = await configFetcher.GetAsync("azureActiveDirectoryUsername", true);
            Password = await configFetcher.GetAsync("azureActiveDirectoryPassword", true);
        }

        private async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                DisplayMessage = TextResources.Alert_Authentication_InProgress;

                success = await authenticationService.AuthenticateAsync(Username, Password);
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

        public async void BackClicked(object sender, EventArgs e)
        {
            await PopAsync();
        }
    }
}