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

        private View CreatePage()
        {
            var titleLayout = ComponentFactories.Buttons.TitleLayout(TextResources.Borrow_Title, ViewModel.BackButtonClicked);

            var amountEntry = ComponentFactories.Entries.EntryDefaultAmount(string.Empty);
            amountEntry.SetBinding(Entry.TextProperty, "Amount", BindingMode.TwoWay);

            var borrowLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Blue,
                Padding = 30,
                Spacing = 20,
                Children =
                {
                    new CustomLabel
                    {
                        Text = TextResources.BorrowCreateEnterAmoutTitle,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    amountEntry,
                    new CustomLabel
                    {
                        Text = string.Format(TextResources.BorrowCreateEnterAmout, ViewModel.UserAccountModel.Borrow.DisplayAmountRemainingCapacity()),
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


            var buttonLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
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