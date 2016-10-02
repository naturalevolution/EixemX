using System;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Controls.Labels;
using EixemX.Factories;
using EixemX.Localization;
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
                BackgroundColor = Color.White,
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
                Constraint.Constant(0),
                Constraint.RelativeToParent(parent => { return parent.Width - 40; }),
                Constraint.RelativeToParent(parent => { return parent.Height; }));
             
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
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    NavigationBarButtons(menuClicked, logoClicked, accountClicked)
                }
            };

            var contentScrollView = new StackLayout
            { 
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            foreach (var view in views)
                contentScrollView.Children.Add(view);

            result.Children.Add(new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand, 
                Content = contentScrollView
            });


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

        public Layout Separator(Thickness padding, Color color)
        {
            return new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Transparent,
                Padding = padding,
                Spacing = 10,
                Children =
                {
                    new BoxView
                    {
                        HeightRequest = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = color
                    }
                }
            };
        }

        public Layout Separator()
        {
            return Separator(new Thickness(0), Color.White);
        }
         
        public Layout GenerateBox(string titleText, string subTitleText, string amount, EventHandler detailEvent, Color backgroundColor)
        {

            var result = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(0, 10, 0, 0),
                Spacing = 5,
                BackgroundColor = Palette.Transparent
            };
            
            var title = new CustomLabel
            {
                FontSize = PaletteText.FontSizeM,
                TextColor = Palette.White,
                Text = titleText,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var detailButton = new CustomButton
            {
                Text = TextResources.Dashboard_Details,
                BackgroundColor = Palette.Transparent,
                BorderRadius = 25,
                TextColor = Palette.White,
                FontSize = PaletteText.FontSizeM,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            detailButton.Released += detailEvent;

            var detail = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = 0,
                Children =
                {
                    detailButton,
                    ComponentFactories.Buttons.ArrowRight(detailEvent)
                }
            };

            result.Children.Add(title);

            if (!string.IsNullOrEmpty(subTitleText))
            {
                var subTitle = new CustomLabel
                {
                    Text = subTitleText,
                    FontSize = PaletteText.FontSizeM,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Palette.White
                };
                result.Children.Add(subTitle);
            }

            if (!string.IsNullOrEmpty(amount))
            {
                var price = new CustomButton
                {
                    Text = string.Format(TextResources.Field_PriceEuro, amount),
                    BackgroundColor = Palette.White,
                    BorderRadius = 25,
                    TextColor = Palette.Green,
                    FontSize = PaletteText.FontSizeM,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                price.Released += detailEvent;
                result.Children.Add(price);
            }
            result.Children.Add(detail);
            /*
            if (backgroundColor != Color.Transparent)
            {
                var resultBackground = new AbsoluteLayout
                {
                    BackgroundColor = Palette.White,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                var boxBg = new BoxView
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = backgroundColor,
                    Opacity = 0.8
                };

                AbsoluteLayout.SetLayoutBounds(boxBg, new Rectangle(0, 0, 1, 1));
                AbsoluteLayout.SetLayoutFlags(boxBg, AbsoluteLayoutFlags.All);

                resultBackground.Children.Add(boxBg);

                AbsoluteLayout.SetLayoutBounds(result, new Rectangle(0, 0, 1, 1));
                AbsoluteLayout.SetLayoutFlags(result, AbsoluteLayoutFlags.All);

                resultBackground.Children.Add(result);

                return resultBackground;
            }*/

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

        Layout FormFields(params View[] views);
        Layout FormBackground(View view);
        Layout FormButtons(params View[] views);


        Layout NavigationBarMenuLogoAccount(EventHandler menuClicked, EventHandler logoClicked,
            EventHandler accountClicked,
            params View[] views);

        Layout TitleSubLayout(string text, string titleBar, EventHandler eventBackButton, EventHandler eventBarButton = null);
        Layout Separator();
        Layout GenerateBox(string title, string subTitle, string displayAmountAvailable, EventHandler eventClicked, Color backgroundColor);
        Layout Separator(Thickness padding, Color color);
    }
}