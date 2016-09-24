using System;
using System.Threading.Tasks;
using EixemX.Constants;
using EixemX.Controls.Entries;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Authentication;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace EixemX.Pages.Authentication
{
    public class SignInPage : ModelBoundContentPage<SignInViewModel>
    {
        public SignInPage()
        {
            BindingContext = new SignInViewModel(Navigation);

            Content = CreatePage();
        }

        private Layout CreatePage()
        {
            var linkToAuthentication = buttonFactory.TransparentDefault(TextResources.Button_SignIn, ViewModel.SignInClicked); 

            var emailEntry = entryFactory.EntryDefaultText(TextResources.Account_Field_Email);
            emailEntry.SetBinding(Entry.TextProperty, "Username", BindingMode.TwoWay);
             
            var passwordEntry = entryFactory.EntryDefaultText(TextResources.Account_Field_Password); 
            passwordEntry.IsPassword = true;
            passwordEntry.SetBinding(Entry.TextProperty, "Password", BindingMode.TwoWay);
            
            var messageLabel = labelFactory.LabelMessage();
            messageLabel.SetBinding(Label.TextProperty, "DisplayMessage", BindingMode.TwoWay);

            var linkToPasswordForget = labelFactory.HyperLinkLabel();

            var backArrowButton = buttonFactory.ArrowLeft(ViewModel.BackButtonClicked);

            var titleLayout = layoutFactory.TitleLayout(imageFactory.WhiteLogoSmall(), backArrowButton);

            var fieldsLayout = layoutFactory.LayoutFields(messageLabel, emailEntry, passwordEntry);

            var buttonsLayout = layoutFactory.LayoutButtons(linkToPasswordForget, linkToAuthentication);


            var content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(0, 0, 0, 30),
                Spacing = 0,
                Children = {
                    titleLayout, 
                    fieldsLayout,
                    buttonsLayout
                }
            }; 
            return layoutFactory.LayoutWithBackground(content);
        }

        protected override async void OnAppearing()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();

            // fetch the demo credentials
            await ViewModel.LoadDemoCredentials();

            // pause for a moment before animations
            //await Task.Delay(250);
             
             //await SignInButton.ScaleTo(1, (uint)250, Easing.SinIn);
            //await SkipSignInButton.ScaleTo(1, (uint)250, Easing.BounceIn);
        }
    }
}