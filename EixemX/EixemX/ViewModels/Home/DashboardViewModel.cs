using System;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Home
{
    public class DashboardViewModel : BaseViewModelNavigation
    {
        public DashboardViewModel(INavigation navigation) : base(navigation)
        { 
        }
         
        public void BorrowDetailClicked(object sender, EventArgs e)
        {
            LogDebug("BorrowDetailClicked");
        }
        public void InterestDetailClicked(object sender, EventArgs e)
        {
            LogDebug("InterestDetailClicked");
        }
        public void LoanDetailClicked(object sender, EventArgs e)
        {
            LogDebug("LoanDetailClicked");
        }
    }
}