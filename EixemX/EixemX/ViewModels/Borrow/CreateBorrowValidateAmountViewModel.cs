using System;
using System.Threading.Tasks;
using EixemX.Localization;
using EixemX.Pages.Borrow;
using EixemX.Services.Borrow;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Borrow
{
    public class CreateBorrowValidateAmountViewModel : BaseViewModelNavigation
    {
        public CreateBorrowModel Model { get; set; }

        public CreateBorrowValidateAmountViewModel(INavigation navigation, CreateBorrowModel model) : base(navigation)
        {
            Model = model;
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value, "Password"); }
        }
        public async void PasswordForgetClicked(object sender, EventArgs e)
        {
            LogDebug("PasswordForgetClicked");
            await PushAsync(new CreateBorrowPasswordForgetPage());
        }

        public string DisplaySelectedAmount()
        {
            return DisplayDouble(Model.Amount);
        }

        public async void ValidateBorrowClicked(object sender, EventArgs e)
        {
            LogDebug("ValidateBorrowClicked");
            await App.ExecuteIfConnectedToInternet(async () =>
            {
                if (!string.IsNullOrWhiteSpace(Password))
                {
                    DisplayMessage = TextResources.Alert_Authentication_InProgress;

                    if (await authenticationService.AuthenticateAsync(UserAccountModel.User.Email, Password))
                    {
                        await PushAsync(new CreateBorrowFinalPage(Model)); 
                    }
                    else
                    {
                        DisplayMessage = TextResources.Alert_Borrow_UnableToAuthenticate;
                    }
                }
                else
                {
                    DisplayMessage = TextResources.Alert_Borrow_MandatoryPassword;
                }
            });
        }
    }
}