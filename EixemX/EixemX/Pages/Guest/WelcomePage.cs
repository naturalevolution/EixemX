using System;
using EixemX.Controls.Buttons;
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
            BindingContext = new WelcomeViewModel(this.Navigation);
            Content = CreateLayout();
        } 

        private Layout CreateLayout()
        {
            var linkToRegistration = ComponentFactories.Buttons.WhiteRound(TextResources.Button_Registration, ViewModel.RegistrationPageClicked);

            var linkToSignIn = ComponentFactories.Buttons.TransparentRound(TextResources.Button_SignIn, ViewModel.SignInPageClicked);   

            var contentLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(30, 0, 30, 50),
                Spacing = 20,
                BackgroundColor = Color.Transparent,
                Children =
                {
                    ComponentFactories.Images.WhiteLogo(),
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
            return ComponentFactories.Layouts.LayoutWithBackground(contentLayout);
        }
         
    }
}