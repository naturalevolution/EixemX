using System;
using EixemX.Controls.Buttons;
using EixemX.Controls.Navigations;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Authentication;
using EixemX.Pages.Base;
using EixemX.Services.Authentication;
using EixemX.ViewModels.Guest;
using Xamarin.Forms;

namespace EixemX.Pages.Guest
{
    public class WelcomePage : ModelBoundContentPage<WelcomeViewModel>
    {
        public WelcomePage()
        {
            BindingContext = new WelcomeViewModel
            {
                Navigation = this.Navigation
            };
            Content = CreateLayout();
        } 

        private Layout CreateLayout()
        {
            var linkToRegistration = buttonFactory.WhiteDefault(TextResources.Button_Registration); 
            linkToRegistration.Released += ViewModel.NavigateToRegistrationPage;
             
            var linkToSignIn = buttonFactory.TransparentDefault(TextResources.Button_SignIn);  
            linkToSignIn.Released += ViewModel.NavigateToSignInPage;

            var contentLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(30, 0, 30, 50),
                Spacing = 20,
                BackgroundColor = Color.Transparent,
                Children =
                {
                    imageFactory.WhiteLogo(),
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.End,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = new Thickness(50, 0, 50, 0),
                        Spacing = 20,
                        Children =
                        {
                            linkToSignIn,
                            linkToRegistration
                        }
                    }
                }
            };
            return layoutFactory.LayoutWithBackground(contentLayout);
        }

        protected override void OnAppearing()
        { 
            NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();
        }
    }
}