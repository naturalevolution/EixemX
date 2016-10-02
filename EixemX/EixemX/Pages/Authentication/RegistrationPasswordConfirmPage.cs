using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.Services.Account;
using EixemX.ViewModels.Authentication;
using Xamarin.Forms;

namespace EixemX.Pages.Authentication
{
    public class RegistrationPasswordConfirmPage : ModelBoundContentPage<RegistrationPasswordConfirmViewModel>
    {
        public RegistrationModel Model { get; set; }

        public RegistrationPasswordConfirmPage(RegistrationModel model)
        {
            BindingContext=new RegistrationPasswordConfirmViewModel(model, Navigation);
            Model = model;

            Content = CreatePage();

        }

        public Layout CreatePage()
        {
            var titleLayout = ComponentFactories.Layouts.TitleSubLayout(TextResources.Registration_ConfirmSecret,
                TextResources.Registration_Secret, ViewModel.BackButtonClicked);

            var passwordEntry = ComponentFactories.Entries.EntryPlainPassword(string.Empty, "Model.PasswordConfirmation"); 

            var fieldsLayout = ComponentFactories.Layouts.FormFields(GetMessageLabel(), passwordEntry);

            var linkToNext = ComponentFactories.Buttons.TransparentRound(TextResources.Button_Next, ViewModel.NextClicked);

            var buttonsLayout = ComponentFactories.Layouts.FormButtons(linkToNext);
             

            var content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(0, 0, 0, 30),
                Spacing = 0,
                Children = {
                    titleLayout,
                    fieldsLayout,
                    buttonsLayout
                }
            };
            return ComponentFactories.Layouts.LayoutWithBackground(content);
        } 
    }
}