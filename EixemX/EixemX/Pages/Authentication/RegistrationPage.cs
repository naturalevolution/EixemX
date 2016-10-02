using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Authentication;
using Xamarin.Forms;

namespace EixemX.Pages.Authentication
{
    public class RegistrationPage : ModelBoundContentPage<RegistrationViewModel>
    {
        public RegistrationPage()
        {
            BindingContext = new RegistrationViewModel(Navigation);

            Content = CreatePage();
        }

        public Layout CreatePage()
        {
            var titleLayout = ComponentFactories.Layouts.TitleLayout(TextResources.Registration_Title,
                TextResources.Registration_TitleBar, ViewModel.BackButtonClicked, ViewModel.BackBarButtonClicked);

            var lastnameEntry = ComponentFactories.Entries.EntryDefaultText(TextResources.Account_Field_Lastname, "Model.Lastname"); 

            var firstnameEntry = ComponentFactories.Entries.EntryDefaultText(TextResources.Account_Field_Firstname, "Model.Firstname"); 

            var birthdayEntry = ComponentFactories.Entries.EntryDefaultText(TextResources.Account_Field_Birthday, "Model.Birthday"); 

            var emailEntry = ComponentFactories.Entries.EntryDefaultEmail(TextResources.Account_Field_Email, "Model.Email"); 

            var fieldsLayout = ComponentFactories.Layouts.FormFields(GetMessageLabel(),lastnameEntry, firstnameEntry, birthdayEntry, emailEntry);

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