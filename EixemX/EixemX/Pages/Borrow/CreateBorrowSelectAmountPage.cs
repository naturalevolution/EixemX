using EixemX.Constants;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Borrow;
using Xamarin.Forms;

namespace EixemX.Pages.Borrow
{
    public class CreateBorrowSelectAmountPage : ModelBoundContentPage<CreateBorrowSelectAmountViewModel>
    {
        public CreateBorrowSelectAmountPage()
        {
            BindingContext = new CreateBorrowSelectAmountViewModel(Navigation);
             
            Content = CreatePage(); 
        } 

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Clear();
        }

        private View CreatePage()
        {
            var titleLayout = ComponentFactories.Buttons.TitleLayout(TextResources.Borrow_Title, ViewModel.BackButtonClicked);

            var amountEntry = ComponentFactories.Entries.EntryDefaultAmount(string.Empty, "Amount");

            var borrowLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start, 
                Padding = 0,
                Spacing = 10,
                Children =
                {
                    new CustomLabel
                    {
                        Text = TextResources.BorrowCreateEnterAmoutTitle,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    GetMessageLabel(),
                    new StackLayout
                    { 
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Padding = new Thickness(60,0,60,0),
                        Children =
                        {
                            amountEntry
                        }
                    },
                    new CustomLabel
                    {
                        Text = TextResources.BorrowCreateEnterAmout,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    new CustomLabel
                    {
                        Text = string.Format(TextResources.BorrowCreateEnterAmoutEuro, ViewModel.UserAccountModel.Borrow.DisplayAmountRemainingCapacity()),
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    new CustomLabel
                    {
                        Text = TextResources.BorrowCreateNoCentimes,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeS
                    }
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
    }
}