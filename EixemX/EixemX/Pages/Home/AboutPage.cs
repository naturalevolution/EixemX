﻿using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Home
{
    public class AboutPage : ModelBoundContentPage<AboutViewModel>
    {
        public AboutPage()
        {
            BindingContext = new AboutViewModel(Navigation);
             
            var label = new CustomLabel
            {
                Text = "AboutPage",
                TextColor = Color.White 
            };

            Content = ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, label);
        }
    }
}