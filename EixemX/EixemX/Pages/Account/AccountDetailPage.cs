using EixemX.Constants;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Account;
using Xamarin.Forms;

namespace EixemX.Pages.Account
{
    public class AccountDetailPage : ModelBoundContentPage<AccountDetailViewModel>
    {
        public AccountDetailPage()
        {
            BindingContext = new AccountDetailViewModel(Navigation);

            Content = CreatePage();
        }

        private View CreatePage()
        {
            var titleLayout = ComponentFactories.Buttons.TitleLayout(TextResources.Account_ProfileTitle,
                ViewModel.BackButtonClicked);

            var userDetails = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Transparent,
                    Padding = new Thickness(20,0,20,0),
                    Spacing = 10,
                    Children =
                    {
                        GenerateContent()
                    }
            };

            var detailOverlay = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 0,
                Spacing = 0,  
                Children =
                {
                    titleLayout,
                    ComponentFactories.Layouts.FormBackground(userDetails)
                }
            };

            var result = ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, detailOverlay);

            return result;
        }

        private StackLayout GenerateContent()
        {

            var addressDetailButton = ComponentFactories.Buttons.TextCircleButton(">", ViewModel.AddressDetailClicked);
            var addressTitle = ComponentFactories.Buttons.TitleCirleButtons(TextResources.Account_Address_Title,
                addressDetailButton);

            var bankPlusButton = ComponentFactories.Buttons.TextCircleButton("+", ViewModel.BankPlusClicked);
            var bankDetailButton = ComponentFactories.Buttons.TextCircleButton(">", ViewModel.BankDetailClicked);
            var bankTitle = ComponentFactories.Buttons.TitleCirleButtons(TextResources.Account_BankCard_Title,
                bankPlusButton, bankDetailButton);

            var financeDetailButton = ComponentFactories.Buttons.TextCircleButton(">", ViewModel.FinanceDetailClicked);
            var financeTitle = ComponentFactories.Buttons.TitleCirleButtons(TextResources.Account_Finance_Title,
                financeDetailButton);

            var separator = ComponentFactories.Layouts.Separator();

            var result = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Padding = 20,
                Children =
                {
                    new CustomLabel
                    {
                        Text = ViewModel.UserAccountModel.User.DisplayFullname(),
                        TextColor = Palette.White,
                        FontSize = PaletteText.FontSizeL,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold
                    },
                    separator,
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.Start,
                        BackgroundColor = Color.Transparent,
                        Padding = 0,
                        Spacing = 5,
                        Children =
                        {
                            addressTitle
                            ,
                            new CustomLabel
                            {
                                Text = ViewModel.UserAccountModel.User.Address.Address,
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            },
                            new CustomLabel
                            {
                                Text = ViewModel.UserAccountModel.User.Address.DisplayCity(),
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            },
                            new CustomLabel
                            {
                                Text = ViewModel.UserAccountModel.User.Address.DisplayCountry(),
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            }
                        }
                    },
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.Start,
                        Padding = new Thickness(0, 10, 0, 10),
                        Spacing = 5,
                        Children =
                        {
                            bankTitle,
                            new CustomLabel
                            {
                                Text =
                                    string.Format("{0} : {1}", TextResources.Account_BankCard_FieldBank,
                                        ViewModel.UserAccountModel.User.Bank.BankCode),
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            },
                            new CustomLabel
                            {
                                Text =
                                    string.Format("{0} : {1}", TextResources.Account_BankCard_FieldCardNumber,
                                        ViewModel.UserAccountModel.User.Bank.CardNumber),
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            },
                            new CustomLabel
                            {
                                Text =
                                    string.Format("{0} : {1}", TextResources.Account_BankCard_FieldDateExpire,
                                        ViewModel.UserAccountModel.User.Bank.DisplayDateExpiration()),
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            },
                            new CustomLabel
                            {
                                Text = TextResources.Account_BankCard_IbanTitle,
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            },
                            new CustomLabel
                            {
                                Text =
                                    string.Format("{0} : {1}", TextResources.Account_BankCard_FieldIban,
                                        ViewModel.UserAccountModel.User.Bank.Iban),
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            }
                        }
                    },
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.Start,
                        Padding = 0,
                        Spacing = 0,
                        Children =
                        {
                            financeTitle,
                            new CustomLabel
                            {
                                Text =
                                    string.Format(TextResources.Field_PriceEuro,
                                        ViewModel.UserAccountModel.User.Finance.DisplayAmount()),
                                TextColor = Palette.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = PaletteText.FontSizeM
                            }
                        }
                    }

                }
            };
                return result;
        }
    }
}