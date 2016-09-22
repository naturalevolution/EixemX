using System.Collections.Generic;
using System.Linq;
using System.Text;
using EixemX.Controls.Buttons;
using Xamarin.Forms;
using XLabs.Enums;
using XLabs.Forms.Controls;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace EixemX
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
             
            var createAccountButton = new CustomButton
            {
                BackgroundColor = Color.White,
                BorderColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                BorderRadius = 25,
                BorderWidth = 1,
                Text = "S'inscrire",
                TextColor = Color.Green
            };
            createAccountButton.Pressed += (sender, args) =>
            { 
                System.Diagnostics.Debug.WriteLine("Pressed");
                var e = sender as Button;

                e.BackgroundColor = Color.Transparent;
                e.TextColor = Color.White;
            };
            createAccountButton.Released += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine("Released");
                var e = sender as Button;

                e.BackgroundColor = Color.White;
                e.TextColor = Color.Green;
            };


            var loginButton = new CustomButton
            {
                BackgroundColor = Color.Transparent,
                BorderColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                BorderRadius = 25,
                BorderWidth = 1,
                Text = "Se connecter",
                TextColor = Color.White
            };
            loginButton.Pressed += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine("Pressed");
                var e = sender as Button;

                e.BackgroundColor = Color.White;
                e.TextColor = Color.Green;
            };
            loginButton.Released += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine("Released");
                var e = sender as Button;

                e.BackgroundColor = Color.Transparent;
                e.TextColor = Color.White;
            };

            var screenBg = new Image {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = ImageSource.FromFile("screen_bg.png")
            };

            var contentLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(30, 0, 30, 30),
                Spacing = 0,
                BackgroundColor = Color.Transparent,
                Children =
                {
                    new Image
                    {
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Source = ImageSource.FromFile("logo_white.png")
                    },
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.End,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = new Thickness(50, 0, 50, 0),
                        Spacing = 20,
                        Children =
                        {
                            loginButton,
                            createAccountButton
                        }
                    }
                }
            };

            RelativeLayout layout = new RelativeLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Padding = 0
            };
            layout.Children.Add(screenBg,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; } ),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            layout.Children.Add(contentLayout,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));


            MainPage = new ContentPage {
                Content = layout
            };
        }
         
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
