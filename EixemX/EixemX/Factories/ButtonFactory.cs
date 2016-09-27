using System;
using System.Diagnostics;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Factories;
using Xamarin.Forms;
using XLabs.Forms.Controls;

[assembly: Dependency(typeof(ButtonFactory))]

namespace EixemX.Factories
{
    public interface IButtonFactory
    {
        CustomButton WhiteDefault(string text, EventHandler eventClicked);
        void SetToDefault(Button element, ButtonStyle buttonStyle);
        CustomButton WhiteDefaultBar(string text, EventHandler eventClicked);
        ImageButton ArrowLeft(EventHandler eventClicked);
        AbsoluteLayout BarWithButtonTitle(string titleBar, EventHandler eventBarBarButton);
        CustomButton TransparentDefault(string text, EventHandler eventClicked);
        Image NavigationMenu(EventHandler eventClicked);
        Image NavigationAccount(EventHandler eventClicked);
        Image NavigationLogo(EventHandler eventClicked);
        CustomButton Link(string text, EventHandler eventClicked);
    }

    public class ButtonFactory : IButtonFactory
    {
        private const string ArrowLeftPicture = "left_arrow.png"; 
         
        public CustomButton TransparentDefault(string text, EventHandler eventClicked)
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
                FontSize = PaletteText.FontSizeEntry,
                TextColor = Palette.White
            };

            result.Pressed += (sender, args) =>
            {
                Debug.WriteLine("TransparentDefault OnPressed");
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


        public CustomButton WhiteDefault(string text, EventHandler eventClicked)
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
                FontSize = PaletteText.FontSizeMediumButton,
                TextColor = Palette.Green
            };

            result.Pressed += (sender, args) =>
            {
                Debug.WriteLine("WhiteDefault OnPressed");
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
                FontSize = PaletteText.FontSizeMediumButton,
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
                Source = ImageSource.FromFile(ArrowLeftPicture),
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 50,
                WidthRequest = 50
            };
            result.Clicked += eventClicked;
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
                FontSize = PaletteText.FontSizeSmall,
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