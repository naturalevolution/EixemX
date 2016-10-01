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
        private CreateBorrowModel Model;

        public CreateBorrowFinalPage()
        {
        }

        public CreateBorrowFinalPage(CreateBorrowModel model)
        {
            BindingContext = new CreateBorrowFinalViewModel(Navigation);
            Model = model;

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
             
            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    messageLayout 
                }
            };

            return ComponentFactories.Layouts.LayoutWithBackground(result);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //TODO Cinematique de transfert redirect ver root
            /* App.ExecuteIfConnectedToInternet(async () =>
            {
               if (!string.IsNullOrWhiteSpace(Username))
                {
                    DisplayMessage = TextResources.Alert_Authentication_PasswordEmailInProgress;

                    if (await authenticationService.PasswordForgetAsync(Username))
                    {
                        await
                            App.Current.MainPage.DisplayAlert(TextResources.Alert_Authentication_PasswordEmailSendTitle,
                                TextResources.Alert_Authentication_PasswordEmailSendMessage, TextResources.Button_OK);

                        DisplayMessage = TextResources.Alert_Authentication_PasswordEmailDone;
                    }
                    else
                    {
                        DisplayMessage = TextResources.Alert_Authentication_PasswordForgetEmailNotExist;
                    }
                }
                else
                {
                    DisplayMessage = TextResources.Alert_Authentication_PasswordForgetEmail;
                }
        });*/
        }
    }
}