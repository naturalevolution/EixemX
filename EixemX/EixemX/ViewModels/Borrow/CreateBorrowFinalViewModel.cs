using System;
using EixemX.Pages.Borrow;
using EixemX.Services.Borrow;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Borrow
{
    public class CreateBorrowFinalViewModel : BaseViewModelNavigation
    {
        public CreateBorrowModel Model { get; set; }
        public CreateBorrowFinalViewModel(INavigation navigation, CreateBorrowModel model) : base(navigation)
        {
            Model = model;
        }

        public override async void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            await PushAsync(new BorrowDashboardPage());
        }

        public void NavigationRoot(object sender, EventArgs e)
        {
            LogDebug("NavigationRoot");
            App.GoToRoot();
        }

        public async void NavigationPartners(object sender, EventArgs e)
        {
            LogDebug("NavigationPartners");
            await PushAsync(new BorrowDashboardPage());
        }
    }
}