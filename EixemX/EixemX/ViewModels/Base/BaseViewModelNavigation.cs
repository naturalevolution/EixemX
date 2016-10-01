using System;
using EixemX.Controls.Menus;
using EixemX.Pages.Account;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
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

        protected string DisplayDouble(double value)
        {
            return string.Format("{0:0.##}", value);
        }

        public virtual void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            App.GoToRoot();
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
                await PushAsync(new AccountDetailPage());
            }
        }

        public virtual async void NavigationLogoClicked(object sender, EventArgs e)
        {
            LogDebug("NavigationLogoClicked");
            App.GoToRoot();/*
            var root = GetRootPage();
            if (root != null)
            {
                await root.NavigateAsync(MenuType.Dashboard);
            }*/
        }
    }
}