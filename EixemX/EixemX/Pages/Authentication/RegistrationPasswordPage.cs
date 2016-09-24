using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Authentication;
using Xamarin.Forms;

namespace EixemX.Pages.Authentication
{
    public class RegistrationPasswordPage : ModelBoundContentPage<RegistrationPasswordViewModel>
    {
        public RegistrationPasswordPage()
        {
            BindingContext=new RegistrationPasswordViewModel(Navigation);

            Content = CreatePage();
        }

        public Layout CreatePage()
        {
            AbsoluteLayout titleLayout = layoutFactory.TitleLayoutLower(TextResources.Registration_PasswordTitle,
                TextResources.Registration_Secret, ViewModel.BackButtonClicked);

            var passwordEntry = entryFactory.EntryPlainPassword(string.Empty);
            passwordEntry.SetBinding(Entry.TextProperty, "Password", BindingMode.TwoWay);

            StackLayout fieldsLayout = layoutFactory.LayoutFields(passwordEntry);

            var linkToNext = buttonFactory.TransparentDefault(TextResources.Button_Next, ViewModel.NextClicked);

            StackLayout buttonsLayout = layoutFactory.LayoutButtons(linkToNext);

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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}