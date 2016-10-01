using System;
using EixemX.Constants;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.Services.Borrow;
using EixemX.ViewModels.Borrow;
using Xamarin.Forms;

namespace EixemX.Pages.Borrow
{
    public class CreateBorrowValidateAmountPage : ModelBoundContentPage<CreateBorrowValidateAmountViewModel>
    {
        
        public CreateBorrowValidateAmountPage(CreateBorrowModel model)
        {
            BindingContext = new CreateBorrowValidateAmountViewModel(Navigation, model);
             
            Content = CreatePage(); 
        }

        private View CreatePage()
        {
            var titleLayout = ComponentFactories.Buttons.TitleLayout(TextResources.Borrow_Title, ViewModel.BackButtonClicked);

            var passwordEntry = ComponentFactories.Entries.EntryPlainPassword(string.Empty);
            passwordEntry.SetBinding(Entry.TextProperty, "Password", BindingMode.TwoWay);

            var borrowLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Blue,
                Padding = 0,
                Spacing = 5,
                Children =
                {
                     new CustomLabel
                    {
                        Text = TextResources.BorrowCreateValidateAmount,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    new CustomLabel
                    {
                        Text = string.Format(TextResources.BorrowCreateValidateAmountRequested, ViewModel.DisplaySelectedAmount()),
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    new CustomLabel
                    {
                        Text = TextResources.BorrowCreateValidatePasswordEnterCode,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    GetMessageLabel(),
                    passwordEntry,
                    ComponentFactories.Buttons.Link(TextResources.BorrowCreateValidatePasswordTitle, ViewModel.PasswordForgetClicked)
                }
            };

            var buttonLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 20,
                BackgroundColor = Color.Red,
                Children =
                {
                    ComponentFactories.Buttons.TransparentRound(TextResources.Button_Validate, ViewModel.ValidateBorrowClicked)
                }
            };
            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    titleLayout,
                    borrowLayout,
                    buttonLayout
                }
            };

            return ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                 ViewModel.NavigationLogoClicked,
                 ViewModel.NavigationAccountClicked, result);
        }
    }
}