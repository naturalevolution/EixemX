using System;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.Pages.Borrow
{
    public class BorrowDashboardPage : ModelBoundContentPage<BorrowDashboardViewModel>
    {
        public BorrowDashboardPage()
        {
            BindingContext = new BorrowDashboardViewModel(Navigation);
            
            Content = CreatePage();
        }

        public Layout CreatePage()
        { 
            var titleLayout = ComponentFactories.Labels.TitleHeader(TextResources.Borrow_Title);

            string subTitle = string.Format(TextResources.Dashboard_BorrowAvailableTo, ViewModel.UserAccountModel.Borrow.ToDateAvailable());

            var buttonLayout = ComponentFactories.Buttons.TransparentRound(TextResources.Emprunter_BorrowButton, ViewModel.StartBorrowClicked, new Thickness(50, 20, 50, 20));

            var borrowLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Padding = 0,
                Spacing =0,
                Children =
                {
                    ComponentFactories.Layouts.Separator(),
                    buttonLayout, 
                    ComponentFactories.Layouts.GenerateBox(TextResources.Dashboard_BorrowAvailable, subTitle, ViewModel.UserAccountModel.Borrow.DisplayAmountAvailable(), ViewModel.BorrowDetailClicked, Color.Fuchsia),
                    ComponentFactories.Layouts.Separator(),
                    ComponentFactories.Layouts.GenerateBox(TextResources.Borrow_RemainingCapacity, string.Empty, ViewModel.UserAccountModel.Borrow.DisplayAmountRemainingCapacity(), ViewModel.RemainingCapacityDetailClicked, Color.Blue),
                    ComponentFactories.Layouts.Separator(),
                    ComponentFactories.Layouts.GenerateBox(TextResources.Borrow_NextRefound, ViewModel.UserAccountModel.Borrow.ToDateNextRefound(), string.Empty, ViewModel.NextRefoundDetailClicked, Color.White),
                    ComponentFactories.Layouts.Separator() 
                   }
            };

            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                { 
                    titleLayout,
                    borrowLayout
                }
            };

           return ComponentFactories.Layouts.NavigationBarMenuLogoAccount(ViewModel.NavigationMenuClicked,
                ViewModel.NavigationLogoClicked,
                ViewModel.NavigationAccountClicked, result);
        }

    }
}