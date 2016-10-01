using System;
using System.Diagnostics;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Controls.Labels;
using EixemX.Factories;
using Xamarin.Forms;
using XLabs.Forms.Controls;

[assembly: Dependency(typeof(ButtonFactory))]

namespace EixemX.Factories
{
    public interface IButtonFactory
    {
        CustomButton WhiteRound(string text, EventHandler eventClicked);
        void SetToDefault(Button element, ButtonStyle buttonStyle);
        CustomButton WhiteDefaultBar(string text, EventHandler eventClicked);
        ImageButton ArrowLeft(EventHandler eventClicked);
        AbsoluteLayout BarWithButtonTitle(string titleBar, EventHandler eventBarBarButton);
        CustomButton TransparentRound(string text, EventHandler eventClicked);
        Image NavigationMenu(EventHandler eventClicked);
        Image NavigationAccount(EventHandler eventClicked);
        Image NavigationLogo(EventHandler eventClicked);
        CustomButton Link(string text, EventHandler eventClicked);
        ImageButton ArrowRight(EventHandler eventClicked);
        AbsoluteLayout TitleCirleButtons(string text, params CustomButton[] buttons);
        CustomButton TextCircleButton(string text, EventHandler evenClicked);
        Layout TitleLayout(string text, EventHandler backButton);
        Layout TitleLayout(Image image, ImageButton backButton);
    }

    public class ButtonFactory : IButtonFactory
    {
        public CustomButton TransparentRound(string text, EventHandler eventClicked)
        {
            var result = new CustomButton
            {
                BackgroundColor = Palette.Transparent,
                BorderColor = Palette.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BorderRadius = 25,
                BorderWidth = 1,
                Text = text,
                FontSize = PaletteText.FontSizeML,
                TextColor = Palette.White
            };

            result.Pressed += (sender, args) =>
            {
                Debug.WriteLine("TransparentRound OnPressed");
                var element = sender as Button;

                element.BackgroundColor = Palette.White;
                element.TextColor = Palette.Green;
            };
            result.Released += eventClicked;
            return result;
        }

        public void SetToDefault(Button element, ButtonStyle buttonStyle)
        {
            Debug.WriteLine("SetToDefault");
            switch (buttonStyle)
            {
                case ButtonStyle.Transparent:
                    element.BackgroundColor = Palette.Transparent;
                    element.TextColor = Palette.White;
                    break;
                case ButtonStyle.White:
                    element.BackgroundColor = Palette.White;
                    element.TextColor = Palette.Green;
                    break;
            }
        }


        public CustomButton WhiteRound(string text, EventHandler eventClicked)
        {
            var result = new CustomButton
            {
                BackgroundColor = Palette.White,
                BorderColor = Palette.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                BorderRadius = 25,
                BorderWidth = 1,
                Text = text,
                FontSize = PaletteText.FontSizeML,
                TextColor = Palette.Green,
                FontAttributes = FontAttributes.Bold
            };

            result.Pressed += (sender, args) =>
            {
                Debug.WriteLine("WhiteRound OnPressed");
                var element = sender as Button;

                element.BackgroundColor = Palette.Transparent;
                element.TextColor = Palette.White;
            };
            result.Released += eventClicked;
            return result;
        }

        public CustomButton WhiteDefaultBar(string text, EventHandler eventClicked)
        {
            var result = new CustomButton
            {
                BackgroundColor = Palette.White,
                BorderColor = Palette.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                BorderRadius = 25,
                BorderWidth = 1,
                Text = text,
                FontSize = PaletteText.FontSizeM,
                TextColor = Palette.Green
            };
            result.Released += eventClicked;
            return result;
        }


        public AbsoluteLayout BarWithButtonTitle(string text, EventHandler eventBarButton)
        {
            var result = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var backgroundLine = new BoxView
            {
                BackgroundColor = Palette.White,
                Opacity = 0.3
            };
            AbsoluteLayout.SetLayoutBounds(backgroundLine, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(backgroundLine, AbsoluteLayoutFlags.All);

            var backgroundBtnOverlay = new BoxView
            {
                BackgroundColor = Palette.White,
                Opacity = 1
            };
            AbsoluteLayout.SetLayoutBounds(backgroundBtnOverlay, new Rectangle(0, 0, AbsoluteLayout.AutoSize, 1));
            AbsoluteLayout.SetLayoutFlags(backgroundBtnOverlay,
                AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.HeightProportional);

            var buttonBack = new ImageButton
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = text,
                TextColor = Palette.Green,
                BackgroundColor = Palette.White,
                BorderRadius = 20,
                HeightRequest = 40,
                ImageTintColor = Palette.White
            };
            buttonBack.Clicked += eventBarButton;
            AbsoluteLayout.SetLayoutBounds(buttonBack,
                new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(buttonBack, AbsoluteLayoutFlags.PositionProportional);

            result.Children.Add(backgroundBtnOverlay);
            result.Children.Add(backgroundLine);
            result.Children.Add(buttonBack);

            AbsoluteLayout.SetLayoutBounds(result, new Rectangle(0, 0, 1, 40));
            AbsoluteLayout.SetLayoutFlags(result,
                AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

            return result;
        }

        public ImageButton ArrowLeft(EventHandler eventClicked)
        {
            var result = new ImageButton
            {
                BackgroundColor = Palette.Transparent,
                Source = ComponentFactories.Images.ArrowLeft(),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 50,
                WidthRequest = 50
            };
            result.Clicked += eventClicked;
            return result;
        }

        public ImageButton ArrowRight(EventHandler eventClicked)
        {
            var result = new ImageButton
            {
                BackgroundColor = Palette.Transparent,
                Source = ComponentFactories.Images.ArrowRight(),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End
            };
            result.Clicked += eventClicked;
            return result; 
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
        public Layout TitleLayout(string text, EventHandler backButton)
        { 
            var grid = new Grid
            { 
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 20
            };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.25, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.25, GridUnitType.Star) });

            var label = new CustomLabel
            {
                Text = text,
                TextColor = Palette.White,
                FontSize = PaletteText.FontSizeML,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(ArrowLeft(backButton), 0, 0);
            grid.Children.Add(label, 1, 0);

            return grid;
        }

        public AbsoluteLayout TitleCirleButtons(string text, params CustomButton[] buttons)
        {
            var result = new AbsoluteLayout
            {
                BackgroundColor = Palette.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var label = new CustomLabel
            {
                Text = text,
                TextColor = Palette.White,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = PaletteText.FontSizeM
            };

            AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.PositionProportional);
            result.Children.Add(label);

            var buttonStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand, 
                Spacing = 10,
                Padding = new Thickness(0, 0, 10,0)
            };

            foreach (var button in buttons)
            {
                var layoutButton = new AbsoluteLayout
                { 
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                var labelButton = new CustomLabel
                {
                    Text = button.Text,  
                    TextColor = Color.White,
                    FontSize = PaletteText.FontSizeL,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                double xLabel = 0.5;
                double yLabel = 0.4;

                AbsoluteLayout.SetLayoutBounds(labelButton,
                    new Rectangle(xLabel, yLabel, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutFlags(labelButton, AbsoluteLayoutFlags.PositionProportional);

                AbsoluteLayout.SetLayoutBounds(button, new Rectangle(0, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.PositionProportional);

                layoutButton.Children.Add(button);
                layoutButton.Children.Add(labelButton);


                buttonStack.Children.Add(layoutButton);
            }
            AbsoluteLayout.SetLayoutBounds(buttonStack, new Rectangle(1, .5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(buttonStack, AbsoluteLayoutFlags.PositionProportional);
            result.Children.Add(buttonStack);

            return result;
        }

        public CustomButton TextCircleButton(string text, EventHandler evenClicked)
        {
            var result = new CustomButton
            {
                BorderRadius = 90,
                BorderWidth = 1,
                BorderColor = Color.White,
                Text = text,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                FontSize = PaletteText.FontSizeXL,
                WidthRequest = 25,
                HeightRequest = 25,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                
            };
            result.Released += evenClicked;
            return result;
        }

        public Image NavigationMenu(EventHandler eventClicked)
        {
            var image = ComponentFactories.Images.NavigationMenu();
            image.Aspect = Aspect.AspectFit;
            image.HeightRequest = 30;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += eventClicked;
            image.GestureRecognizers.Add(tapGestureRecognizer);
            return image;
        }

        public Image NavigationAccount(EventHandler eventClicked)
        {
            var image = ComponentFactories.Images.NavigationAccount();
            image.Aspect = Aspect.AspectFit;
            image.HeightRequest = 40;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += eventClicked;
            image.GestureRecognizers.Add(tapGestureRecognizer);
            return image;
        }

        public Image NavigationLogo(EventHandler eventClicked)
        {
            var image = ComponentFactories.Images.NavigationLogo();
            image.Aspect = Aspect.AspectFit;
            image.HeightRequest = 20;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += eventClicked;
            image.GestureRecognizers.Add(tapGestureRecognizer);
            return image;
        }

        public CustomButton Link(string text, EventHandler eventClicked)
        {
            var result = new CustomButton
            {
                Text = text,
                FontSize = PaletteText.FontSizeS,
                TextColor = Palette.White,
                FontAttributes = FontAttributes.None,
                BackgroundColor = Palette.Transparent
            };
            result.Released += eventClicked;
            return result;
        }
    }

    public enum ButtonStyle
    {
        Transparent,
        White
    }
}