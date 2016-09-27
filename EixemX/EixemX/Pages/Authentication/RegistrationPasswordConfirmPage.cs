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
            var titleLayout = layoutFactory.TitleLayoutLower(TextResources.Registration_ConfirmSecret,
                TextResources.Registration_Secret, ViewModel.BackButtonClicked);

            var passwordEntry = entryFactory.EntryPlainPassword(string.Empty);
            passwordEntry.SetBinding(Entry.TextProperty, "Model.PasswordConfirmation", BindingMode.TwoWay);

            var fieldsLayout = layoutFactory.LayoutFields(GetMessageLabel(), passwordEntry);

            var linkToNext = buttonFactory.TransparentDefault(TextResources.Button_Next, ViewModel.NextClicked);

            var buttonsLayout = layoutFactory.LayoutButtons(linkToNext);
             

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
            return layoutFactory.LayoutWithBackground(content);
        } 
    }
}