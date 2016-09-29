using System;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class DashboardPage : ModelBoundContentPage<DashboardViewModel>
    {
        public DashboardPage()
        {
            BindingContext = new DashboardViewModel(Navigation);

            // Catch the login success message from the MessagingCenter.
            // This is really only here for Android, which doesn't fire the OnAppearing() method in the same way that iOS does (every time the page appears on screen).

            /*Device.OnPlatform(Android:() =>
                    MessagingCenter.Subscribe<SignInViewModel>(this, MessagingServiceConstants.AUTHENTICATED, sender => Auth2())); 
*/
            Content = CreatePage();
        }

        private Layout CreatePage()
        {
            string subTitle = string.Format(TextResources.Dashboard_BorrowAvailableTo, ViewModel.UserAccountModel.Borrow.ToDateAvailable());

            var layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Padding = new Thickness(0, 0, 0, 0),
                Spacing = 0,
                Children =
                { 
                    GenerateBox(TextResources.Dashboard_BorrowAvailable, subTitle, ViewModel.UserAccountModel.Borrow.DisplayAmount(), ViewModel.BorrowDetailClicked),
                    GenerateSeparator(),
                    GenerateBox(TextResources.Dashboard_Loan, string.Empty, ViewModel.UserAccountModel.Loan.DisplayAmount(), ViewModel.LoanDetailClicked),
                    GenerateSeparator(),
                    GenerateBox(TextResources.Dashboard_Interest, string.Empty,  ViewModel.UserAccountModel.Interest.DisplayAmount(), ViewModel.InterestDetailClicked)
                }
            };

            var result = ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, layout);

            return result;
        }

        private BoxView GenerateSeparator()
        {
            return new BoxView
            {
                HeightRequest = 1,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Palette.White
            };
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

            var result= new StackLayout
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