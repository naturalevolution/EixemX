﻿using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.Services.Account;
using EixemX.ViewModels.Authentication;
using Xamarin.Forms;

namespace EixemX.Pages.Authentication
{
    public class RegistrationPasswordPage : ModelBoundContentPage<RegistrationPasswordViewModel>
    {
        public RegistrationModel Model { get; set; }

        public RegistrationPasswordPage(RegistrationModel model)
        {
            BindingContext = new RegistrationPasswordViewModel(model, Navigation);
            Model = model;
            Content = CreatePage();
        }

        public Layout CreatePage()
        {
            var titleLayout = layoutFactory.TitleLayoutLower(TextResources.Registration_PasswordTitle,
                TextResources.Registration_Secret, ViewModel.BackButtonClicked);

            var passwordEntry = entryFactory.EntryPlainPassword(string.Empty);
            passwordEntry.SetBinding(Entry.TextProperty, "Model.Password", BindingMode.TwoWay);

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