using System;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Borrow
{
    public class EmprunterPage : ModelBoundContentPage<EmprunterViewModel>
    {
        public EmprunterPage()
        {
            BindingContext = new EmprunterViewModel(Navigation);
            
            Content = CreatePage();
        }

        public Layout CreatePage()
        { 
            var titleLayout = ComponentFactories.Buttons.TitleLayout(TextResources.Borrow_Title, ViewModel.BackButtonClicked);

            string subTitle = string.Format(TextResources.Dashboard_BorrowAvailableTo, ViewModel.UserAccountModel.Borrow.ToDateAvailable());

            var borrowLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Blue,
                Padding = 0,
                Spacing = 5,
                Children =
                {
                    ComponentFactories.Layouts.Separator(),
                    GenerateBox(TextResources.Dashboard_BorrowAvailable, subTitle, ViewModel.UserAccountModel.Borrow.DisplayAmountAvailable(), ViewModel.BorrowDetailClicked),
                    ComponentFactories.Layouts.Separator(),
                    GenerateBox(TextResources.Borrow_RemainingCapacity, string.Empty, ViewModel.UserAccountModel.Borrow.DisplayAmountRemainingCapacity(), ViewModel.RemainingCapacityDetailClicked),
                    ComponentFactories.Layouts.Separator(),
                    GenerateBox(TextResources.Borrow_NextRefound, ViewModel.UserAccountModel.Borrow.ToDateNextRefound(), string.Empty, ViewModel.NextRefoundDetailClicked),
                    ComponentFactories.Layouts.Separator() 
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
                    ComponentFactories.Buttons.TransparentRound(TextResources.Emprunter_BorrowButton, ViewModel.StartBorrowClicked)
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

        private Layout GenerateBox(string titleText, string subTitleText, string amount, EventHandler detailEvent)
        {
            var title = new CustomLabel
            {
                FontSize = PaletteText.FontSizeM,
                TextColor = Palette.White,
                Text = titleText,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var price = new CustomButton
            {
                Text = string.Format(TextResources.Field_PriceEuro, amount),
                BackgroundColor = Palette.White,
                BorderRadius = 25,
                TextColor = Palette.Green,
                FontSize = PaletteText.FontSizeML,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            price.Released += detailEvent;

            var detailButton = new CustomButton
            {
                Text = TextResources.Dashboard_Details,
                BackgroundColor = Palette.Transparent,
                BorderRadius = 25,
                TextColor = Palette.White,
                FontSize = PaletteText.FontSizeM,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            detailButton.Released += detailEvent;

            var detail = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
                Padding = new Thickness(0, 0, 0, 10),
                Children =
                {
                    detailButton,
                    ComponentFactories.Buttons.ArrowRight(detailEvent)
                }
            };

            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(0, 15, 0, 0),
                Spacing = 10,
                BackgroundColor = Palette.Transparent
            };

            result.Children.Add(title);

            if (!string.IsNullOrEmpty(subTitleText))
            {
                var subTitle = new CustomLabel
                {
                    Text = subTitleText,
                    FontSize = PaletteText.FontSizeM,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Palette.White
                };
                result.Children.Add(subTitle);
            }

            result.Children.Add(price);
            result.Children.Add(detail);

            return result;
        }
    }
}