using System;
using EixemX.Constants;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
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

        private View CreatePage()
        {
            var titleLayout = ComponentFactories.Labels.Title(TextResources.PasswordForget_Title);

            var emailEntry = ComponentFactories.Entries.EntryDefaultEmail(string.Empty);
            emailEntry.SetBinding(Entry.TextProperty, "Username", BindingMode.TwoWay);
             
            var contenLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Blue,
                Padding = 0,
                Spacing = 5,
                Children =
                {
                    titleLayout,
                    GetMessageLabel(),
                    new CustomLabel
                    {
                        Text = TextResources.PasswordForget_EnterEmail,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    emailEntry
                }
            };

            var buttonLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 20, 
                Children =
                {
                    ComponentFactories.Buttons.TransparentRound(TextResources.Button_SendPassword , ViewModel.SendPasswordClicked)
                }
            };
            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    titleLayout,
                    contenLayout,
                    buttonLayout
                }
            };

            return ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                 ViewModel.NavigationLogoClicked,
                 ViewModel.NavigationAccountClicked, result);
        }
    }
}