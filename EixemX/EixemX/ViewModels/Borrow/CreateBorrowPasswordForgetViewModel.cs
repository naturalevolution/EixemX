using System;
using EixemX.Localization;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Borrow
{
    public class CreateBorrowPasswordForgetViewModel : BaseViewModelNavigation
    {
        public string Email { get; set; }

        public CreateBorrowPasswordForgetViewModel(INavigation navigation) : base(navigation)
        { 
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value, "Username"); }
        }

        public async void SendPasswordClicked(object sender, EventArgs e)
        {
             LogDebug("SendPasswordClicked");
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
    }
}