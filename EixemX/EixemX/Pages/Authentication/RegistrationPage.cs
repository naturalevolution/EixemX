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
            AbsoluteLayout titleLayout = layoutFactory.TitleLayout(TextResources.Registration_Title,
                TextResources.Registration_TitleBar, ViewModel.BackButtonClicked, ViewModel.BackBarButtonClicked);

            var lastnameEntry = entryFactory.EntryDefaultText(TextResources.Account_Field_Lastname);
            lastnameEntry.SetBinding(Entry.TextProperty, "Lastname", BindingMode.TwoWay); 

            var firstnameEntry = entryFactory.EntryDefaultText(TextResources.Account_Field_Firstname);
            firstnameEntry.SetBinding(Entry.TextProperty, "Firstname", BindingMode.TwoWay); 

            var birthdayEntry = entryFactory.EntryDefaultText(TextResources.Account_Field_Birthday);
            birthdayEntry.SetBinding(Entry.TextProperty, "Birthday", BindingMode.TwoWay); 

            var emailEntry = entryFactory.EntryDefaultEmail(TextResources.Account_Field_Email);
            emailEntry.SetBinding(Entry.TextProperty, "Email", BindingMode.TwoWay); 

            StackLayout fieldsLayout = layoutFactory.LayoutFields(lastnameEntry, firstnameEntry, birthdayEntry, emailEntry);

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