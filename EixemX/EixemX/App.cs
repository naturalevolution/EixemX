using System;
using System.Threading.Tasks;
using EixemX.Constants;
using EixemX.Controls.Navigations;
using EixemX.Factories;
using EixemX.Helpers;
using EixemX.Localization;
using EixemX.Pages.Authentication;
using EixemX.Pages.Base;
using EixemX.Pages.Guest;
using EixemX.Services;
using EixemX.Services.Authentication;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace EixemX
{
    public class App : Application
    {
        private static Application app;
        public static Application CurrentApp
        {
            get { return app; }
        }

        readonly IAuthenticationService _AuthenticationService;

        public App()
        {
            app = this;

            RegisterDependencies();

            /* if we were targeting Windows Phone, we'd want to include the next line. */
            // if (Device.OS != TargetPlatform.WinPhone) 
            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            _AuthenticationService = DependencyService.Get<IAuthenticationService>();

            // If the App.IsAuthenticated property is false, modally present the SplashPage.
            if (!_AuthenticationService.IsAuthenticated)
            {
                MainPage = new DefaultNavigationPage(new WelcomePage());
            }
            else
            {
                GoToRoot(); 
            }
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void RegisterDependencies()
        {
            DependencyService.Register<AuthenticationDemoService>();
        }

        public static void GoToRoot()
        {
                CurrentApp.MainPage = new RootPage();
        } 

        public static async Task ExecuteIfConnectedToInternet(Func<Task> actionToExecuteIfConnected)
        {
            if (IsConnected)
            {
                await actionToExecuteIfConnected();
            }
            else
            {
                await ShowNetworkConnectionAlert();
            }
        }

        static async Task ShowNetworkConnectionAlert()
        {
            await CurrentApp.MainPage.DisplayAlert(
                string.Empty,
                TextResources.Alert_Authentication_Network,
                TextResources.Button_OK);
        }

        public static bool IsConnected
        {
            get { return true; } //CrossConnectivity.Current.IsConnected; }
            }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}