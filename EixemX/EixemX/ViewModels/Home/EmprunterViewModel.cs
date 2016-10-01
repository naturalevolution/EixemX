using System;
using EixemX.Pages.Borrow;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Home
{
    public class EmprunterViewModel : BaseViewModelNavigation
    {
        public EmprunterViewModel(INavigation navigation) : base(navigation)
        {

        }

        public void BorrowDetailClicked(object sender, EventArgs e)
        {
            LogDebug("BorrowDetailClicked");
        }

        public void RemainingCapacityDetailClicked(object sender, EventArgs e)
        {
            LogDebug("RemainingCapacityDetailClicked");
        }

        public void NextRefoundDetailClicked(object sender, EventArgs e)
        {
            LogDebug("NextRefoundDetailClicked");
        }

        public async void StartBorrowClicked(object sender, EventArgs e)
        {
            LogDebug("StartBorrowClicked");
            await PushAsync(new CreateBorrowSelectAmountPage());
        }
    }
}