using System;
using EixemX.Controls.Menus;
using EixemX.Pages.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Base
{
    public abstract class BaseViewModelNavigation : BaseViewModel
    {
        protected BaseViewModelNavigation(INavigation navigation) : base(navigation)
        {

        }
        protected RootPage GetRootPage()
        {
            return App.CurrentApp.MainPage as RootPage;
        }

        public virtual void NavigationMenuClicked(object sender, EventArgs e)
        {
            LogDebug("NavigationMenuClicked");
            var root = GetRootPage();
            if (root != null)
            {
                root.IsPresented = true;
            }
        }

        public virtual async void NavigationAccountClicked(object sender, EventArgs e)
        {
            LogDebug("NavigationAccountClicked");
            var root = GetRootPage();
            if (root != null)
            {
                await root.DisplayAlert("Alert", "Account", "OK");
            }
        }

        public virtual async void NavigationLogoClicked(object sender, EventArgs e)
        {
            LogDebug("NavigationLogoClicked");
            var root = GetRootPage();
            if (root != null)
            {
                await root.NavigateAsync(MenuType.Dashboard);
            }
        }
    }
}