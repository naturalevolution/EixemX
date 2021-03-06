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
    public class SignInViewModel : BaseViewModelNavigation
    {
        private string _password;

        private string _username;

        public SignInViewModel(INavigation navigation)
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
                 SetProperty(ref _password, value, "Password");  
            }
        }

        public async void PasswordForgetClicked(object sender, EventArgs e)
        {
            await App.ExecuteIfConnectedToInternet(async () =>
            {
                if (!string.IsNullOrWhiteSpace(Username))
                {
                    DisplayMessage = TextResources.Alert_Authentication_PasswordEmailInProgress;

                    if (await authenticationService.PasswordForgetAsync(Username))
                    {
                        await
                            App.Current.MainPage.DisplayAlert(TextResources.Alert_Authentication_PasswordEmailSendTitle,
                                TextResources.Alert_Authentication_PasswordEmailSendMessage, TextResources.Button_OK);

                        DisplayMessage = TextResources.Alert_Authentication_PasswordEmailDone;
                    }
                    else
                    {
                        DisplayMessage = TextResources.Alert_Authentication_PasswordForgetEmailNotExist;
                    }
                }
                else
                {
                    DisplayMessage = TextResources.Alert_Authentication_PasswordForgetEmail;
                }
            });
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

            ComponentFactories.Buttons.SetToDefault(sender as Button, ButtonStyle.Transparent);
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
    }
}