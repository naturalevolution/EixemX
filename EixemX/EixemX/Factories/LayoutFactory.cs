using System;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Controls.Labels;
using EixemX.Factories;
using Xamarin.Forms;
using XLabs.Forms.Controls;

[assembly: Dependency(typeof(LayoutFactory))]

namespace EixemX.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        private const string ScreenBackgroud = "screen_bg.png";
        private const string FormBackgroud = "form_bg.png";
        
        public Layout LayoutWithBackground(View view)
        {
            var layout = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Padding = 0
            };
            var screenBg = new Image
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = ImageSource.FromFile(ScreenBackgroud),
                Aspect = Aspect.Fill
            };
            layout.Children.Add(screenBg,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent(parent => { return parent.Width; }),
                Constraint.RelativeToParent(parent => { return parent.Height; }));

            layout.Children.Add(view,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent(parent => { return parent.Width; }),
                Constraint.RelativeToParent(parent => { return parent.Height; }));

            return layout;
        }


        public Layout TitleLayout(Image image, ImageButton backButton)
        {
            var result = new AbsoluteLayout
            {
                BackgroundColor = Palette.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            AbsoluteLayout.SetLayoutBounds(image,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(backButton,
                new Rectangle(0.1, .5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(backButton, AbsoluteLayoutFlags.PositionProportional);

            result.Children.Add(backButton);
            result.Children.Add(image);

            return result;
        }

        public Layout FormFields(params View[] views)
        {
            var result = new StackLayout
            {
                Padding = new Thickness(50, 0, 50, 0),
                Spacing = 20,
                VerticalOptions = LayoutOptions.Start
            };

            foreach (var view in views)
                result.Children.Add(view);
            return result;
        }

        public Layout FormBackground(View view)
        {
            var layout = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent
            };
            var screenBg = new Image
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = ImageSource.FromFile(FormBackgroud),
                Aspect = Aspect.Fill
            };
            layout.Children.Add(screenBg,
                Constraint.Constant(20),
                Constraint.Constant(20),
                Constraint.RelativeToParent(parent => { return parent.Width - 40; }),
                Constraint.RelativeToParent(parent => { return parent.Height - 40; }));
             
                layout.Children.Add(view,
                    Constraint.Constant(0),
                    Constraint.Constant(0),
                    Constraint.RelativeToParent(parent => { return parent.Width; }),
                    Constraint.RelativeToParent(parent => { return parent.Height; })); 

            return layout;
        }

        public Layout FormButtons(params View[] views)
        {
            var result = new StackLayout
            {
                Padding = new Thickness(50, 30, 50, 0),
                Spacing = 30,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            foreach (var view in views)
                result.Children.Add(view);
            return result;
        }


        public Layout NavigationBarMenuLogoAccount(EventHandler menuClicked, EventHandler logoClicked,
            EventHandler accountClicked, params View[] views)
        {
            var result = new StackLayout
            {
                Children =
                {
                    NavigationBarButtons(menuClicked, logoClicked, accountClicked)
                }
            };
            foreach (var view in views)
                result.Children.Add(view);

            return LayoutWithBackground(result);
        } 

        public Layout TitleLayout(string text, string titleBar, EventHandler eventBackButton,
            EventHandler eventBarButton = null)
        {
            var labelTitle = ComponentFactories.Labels.Title(text);
            var result = GenerateTitleLayout(labelTitle, titleBar, eventBackButton, eventBarButton);

            return result;
        }
        public Layout TitleSubLayout(string text, string titleBar, EventHandler eventBackButton,
            EventHandler eventBarButton = null)
        {
            var labelTitle = ComponentFactories.Labels.TitleSub(text);
            var result = GenerateTitleLayout(labelTitle, titleBar, eventBackButton, eventBarButton);

            return result;
        }

        

        private Layout NavigationBarButtons(EventHandler menuClicked, EventHandler logoClicked,
            EventHandler accountClicked)
        {
            var grid = new Grid
            {
                BackgroundColor = Palette.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(70, GridUnitType.Absolute)});
            grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(100, GridUnitType.Absolute)});
            grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)});
            grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(100, GridUnitType.Absolute)});

            var menuButton = ComponentFactories.Buttons.NavigationMenu(menuClicked);
            var logoButton = ComponentFactories.Buttons.NavigationLogo(logoClicked);
            var accountButton = ComponentFactories.Buttons.NavigationAccount(accountClicked);

            grid.Children.Add(menuButton, 0, 0);
            grid.Children.Add(logoButton, 1, 0);
            grid.Children.Add(accountButton, 2, 0);

            return grid;
        }

        private Layout GenerateTitleLayout(CustomLabel labelTitle, string titleBar, EventHandler eventBackButton,
            EventHandler eventBarButton)
        {
            var result = new AbsoluteLayout
            {
                BackgroundColor = Palette.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
             
            AbsoluteLayout.SetLayoutBounds(labelTitle,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(labelTitle, AbsoluteLayoutFlags.PositionProportional);

            var buttonBackArrow = ComponentFactories.Buttons.ArrowLeft(eventBackButton);
            AbsoluteLayout.SetLayoutBounds(buttonBackArrow,
                new Rectangle(0.1, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(buttonBackArrow, AbsoluteLayoutFlags.PositionProportional);

            var barTop = ComponentFactories.Buttons.BarWithButtonTitle(titleBar, eventBarButton ?? eventBackButton);

            result.Children.Add(buttonBackArrow);
            result.Children.Add(barTop);
            result.Children.Add(labelTitle);

            var layout = new StackLayout
            {
                BackgroundColor = Palette.Transparent,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 160,
                Children = {result}
            };

            return layout;
        }
    }

    public interface ILayoutFactory
    {
        Layout LayoutWithBackground(View view);

        Layout TitleLayout(string text, string titleBar, EventHandler eventBackButton, EventHandler eventBarButton = null);


        Layout TitleLayout(Image image, ImageButton backButton);
        Layout FormFields(params View[] views);
        Layout FormBackground(View view);
        Layout FormButtons(params View[] views);


        Layout NavigationBarMenuLogoAccount(EventHandler menuClicked, EventHandler logoClicked,
            EventHandler accountClicked,
            params View[] views);

        Layout TitleSubLayout(string text, string titleBar, EventHandler eventBackButton, EventHandler eventBarButton = null); 
    }
}