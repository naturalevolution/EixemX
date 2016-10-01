using System;
using EixemX.Pages.Borrow;
using EixemX.Services.Borrow;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Borrow
{
    public class CreateBorrowSelectAmountViewModel : BaseViewModelNavigation
    {
        public CreateBorrowSelectAmountViewModel(INavigation navigation) : base(navigation)
        {

        }
        private string _amount;

        public string Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value, "Amount"); }
        }

        public override async void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            await PopAsync();
        }

        public async void ValidateBorrowClicked(object sender, EventArgs e)
        {
            LogDebug("ValidateBorrowClicked");
            await PushAsync(new CreateBorrowValidateAmountPage(new CreateBorrowModel(Amount, UserAccountModel.User)));
        }
    }
}