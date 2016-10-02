using System;
using System.Threading.Tasks;
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
    public class CreateBorrowFinalPage : ModelBoundContentPage<CreateBorrowFinalViewModel>
    { 
        public CreateBorrowFinalPage(CreateBorrowModel model)
        {
            BindingContext = new CreateBorrowFinalViewModel(Navigation, model); 

            Content = CreatePage();
        }

        private View CreatePage()
        {
            var messageLayout = new CustomLabel
            {
                Text = TextResources.BorrowCreateFinalMessage,
                TextColor = Color.White,
                FontSize = PaletteText.FontSizeS,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var label = new CustomLabel
            {
                TextColor = Color.White,
                Text =
                    string.Format("{0} le transfert de {1} € sur votre compte Eixem est en cours ...",
                        ViewModel.Model.User.DisplayFullname(), ViewModel.Model.Amount)
            };

             
            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(50),
                Spacing = 30,
                Children =
                {
                    messageLayout ,
                    label,
                    GetMessageLabel()
                }
            };

            return ComponentFactories.Layouts.LayoutWithBackground(result);
        }

        private Layout GenerateBorrowValidatedPage()
        {
            var titleLayout = ComponentFactories.Buttons.TitleLayout(TextResources.Borrow_Title, ViewModel.BackButtonClicked);
            
            var buttonLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = 0,
                Spacing = 10,
                Children =
                {
                    ComponentFactories.Buttons.TransparentRound(TextResources.Button_SendPassword, ViewModel.NavigationRoot, new Thickness(50, 20, 50, 20)),
                    ComponentFactories.Buttons.TransparentRound(TextResources.Button_SendPassword, ViewModel.NavigationPartners, new Thickness(50, 20, 50, 20))
                }
            };
            var contentLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Padding = 0,
                Spacing = 10,
                Children =
                {
                    new CustomLabel
                    {
                        Text = TextResources.BorrowCreateConfirmTitle,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },  
                    new CustomLabel
                    {
                        Text = string.Format(TextResources.BorrowCreateConfirmAmount, ViewModel.Model.Amount),
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    new CustomLabel
                    {
                        Text = TextResources.BorrowCreateConfirmInfoText1,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    },
                    new CustomLabel
                    {
                        Text = string.Format(TextResources.BorrowCreateConfirmInfoText2, ViewModel.UserAccountModel.Borrow.DisplayDayNextRefund()),
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = PaletteText.FontSizeM
                    }
                }
            };

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.ExecuteIfConnectedToInternet(async () =>
            {
                await Task.Delay(5000);

                ViewModel.DisplayMessage = "Le transfert est terminé!";

                await Task.Delay(2000);

                Content = GenerateBorrowValidatedPage();

                //TODO Remove phhysical back button
            });
        }
    }
}