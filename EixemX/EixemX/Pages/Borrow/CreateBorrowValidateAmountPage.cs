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

            var passwordEntry = ComponentFactories.Entries.EntryPlainPassword(string.Empty, "Password"); 

            var borrowLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Padding =new Thickness(30,0,30,0),
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
                    ComponentFactories.Layouts.Separator(10, Color.Transparent),
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

            var buttonLayout = ComponentFactories.Buttons.TransparentRound(TextResources.Button_Validate,
                ViewModel.ValidateBorrowClicked, new Thickness(50, 20, 50, 20)); 

            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Clear();
        }
    }
}