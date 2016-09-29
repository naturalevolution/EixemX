using System;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Account
{
    public class AccountDetailViewModel : BaseViewModelNavigation
    {
        public AccountDetailViewModel(INavigation navigation) : base(navigation)
        { 
        }

        public  void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            App.GoToRoot();
        } 

        public void AddressDetailClicked(object sender, EventArgs e)
        {
            LogDebug("AddressDetailClicked");
        }

        public void BankPlusClicked(object sender, EventArgs e)
        {
            LogDebug("BankPlusClicked");
        }

        public void BankDetailClicked(object sender, EventArgs e)
        { 
            LogDebug("BankDetailClicked");
        }

        public void FinanceDetailClicked(object sender, EventArgs e)
        {
            LogDebug("FinanceDetailClicked");
        } 
    }
}