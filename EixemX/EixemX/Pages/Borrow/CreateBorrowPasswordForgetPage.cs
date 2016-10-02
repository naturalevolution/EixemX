using System;
using EixemX.Constants;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.Services.Account;
using EixemX.ViewModels.Borrow;
using Xamarin.Forms;

namespace EixemX.Pages.Borrow
{
    public class CreateBorrowPasswordForgetPage : ModelBoundContentPage<CreateBorrowPasswordForgetViewModel>
    {
        public CreateBorrowPasswordForgetPage()
        {
            BindingContext = new CreateBorrowPasswordForgetViewModel(Navigation);
             
            Content = CreatePage();
        } 

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Clear();
        }

        private View CreatePage()
        {
            var titleLayout = ComponentFactories.Buttons.TitleLayout(TextResources.PasswordForget_Title, ViewModel.BackButtonClicked);

            var emailEntry = ComponentFactories.Entries.EntryDefaultEmail(string.Empty, "Username");  
             
            var contentLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start, 
                Padding = new Thickness(20),
                Spacing = 5,
                Children =
                { 
                    new CustomLabel
                    {
                        Text = TextResources.PasswordForget_EnterEmail,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM, 
                    },
                    GetMessageLabel(),
                    emailEntry
                }
            };

            var buttonLayout = ComponentFactories.Buttons.TransparentRound(TextResources.Button_SendPassword , ViewModel.SendPasswordClicked, new Thickness(50, 20, 50, 20));
            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    titleLayout,
                    contentLayout,
                    buttonLayout
                }
            };

            return ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                 ViewModel.NavigationLogoClicked,
                 ViewModel.NavigationAccountClicked, result);
        }
    }
}