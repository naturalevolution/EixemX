﻿using System;
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
            var linkToAuthentication = ComponentFactories.Buttons.TransparentRound(TextResources.Button_SignIn, ViewModel.SignInClicked); 

            var emailEntry = ComponentFactories.Entries.EntryDefaultText(TextResources.Account_Field_Email);
            emailEntry.SetBinding(Entry.TextProperty, "Username", BindingMode.TwoWay);
             
            var passwordEntry = ComponentFactories.Entries.EntryDefaultText(TextResources.Account_Field_Password); 
            passwordEntry.IsPassword = true;
            passwordEntry.SetBinding(Entry.TextProperty, "Password", BindingMode.TwoWay);
            
            var messageLabel = ComponentFactories.Labels.LabelMessage();
            messageLabel.SetBinding(Label.TextProperty, "DisplayMessage", BindingMode.TwoWay);

            var linkToPasswordForget = ComponentFactories.Buttons.Link(TextResources.Account_Link_PasswordForget, ViewModel.PasswordForgetClicked);
                
            var backArrowButton = ComponentFactories.Buttons.ArrowLeft(ViewModel.BackButtonClicked);

            var titleLayout = ComponentFactories.Layouts.TitleLayout(ComponentFactories.Images.WhiteLogoSmall(), backArrowButton);

            var fieldsLayout = ComponentFactories.Layouts.FormFields(messageLabel, emailEntry, passwordEntry);

            var buttonsLayout = ComponentFactories.Layouts.FormButtons(linkToPasswordForget, linkToAuthentication);


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
            return ComponentFactories.Layouts.LayoutWithBackground(content);
        }

        protected override async void OnAppearing()
        {
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