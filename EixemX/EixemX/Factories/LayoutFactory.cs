using System;
using EixemX.Constants;
using EixemX.Factories;
using Xamarin.Forms;
using XLabs.Forms.Behaviors;
using XLabs.Forms.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(LayoutFactory))]
namespace EixemX.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        private const string ScreenBackgroud = "screen_bg.png";
        private const string BackgroundBarTitle = "bar_title.png";
        ILabelFactory LabelFactory;
        IButtonFactory ButtonFactory;
        IImageFactory ImageFactory;

        public LayoutFactory()
        {
            LabelFactory = DependencyService.Get<ILabelFactory>();
            ButtonFactory = DependencyService.Get<IButtonFactory>();
            ImageFactory = DependencyService.Get<IImageFactory>(); 
        }

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

        public Layout TitleLayout(Image image, ImageButton backButton)
        {
            var result = new AbsoluteLayout
            {
                BackgroundColor = Palette.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(backButton, new Rectangle(0.1, .5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(backButton, AbsoluteLayoutFlags.PositionProportional);

            result.Children.Add(backButton); 
            result.Children.Add(image);

            return result;
        }

        public Layout LayoutFields(params View[] views)
        {
            var result = new StackLayout
            {
                Padding = new Thickness(50,0,50,0),
                Spacing = 20, 
                VerticalOptions = LayoutOptions.Start,

            };

            foreach (var view in views)
            {
                result.Children.Add(view);
            }
            return result;
        }

        public Layout LayoutButtons(params View[] views)
        {
            var result = new StackLayout
            {
                Padding = new Thickness(50, 30, 50, 0),
                Spacing = 30, 
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            foreach (var view in views)
            {
                result.Children.Add(view);
            }
            return result;
        }

        public Layout TitleLayoutLower(string text, string titleBar, EventHandler eventBackButton,
            EventHandler eventBarButton = null)
        {
            var result = GenerateTitleLayout(text, titleBar, eventBackButton, eventBarButton, false);

            return result;
        }

        public Layout TitleLayout(string text, string titleBar, EventHandler eventBackButton, EventHandler eventBarButton = null)
        {
            var result = GenerateTitleLayout(text, titleBar, eventBackButton, eventBarButton, true);

            return result; 
        }

        private Layout GenerateTitleLayout(string text, string titleBar, EventHandler eventBackButton, EventHandler eventBarButton, bool isCenter)
        {
            var result = new AbsoluteLayout
            {
                BackgroundColor = Palette.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            Label labelTitle = LabelFactory.Title(text);
            AbsoluteLayout.SetLayoutBounds(labelTitle, new Rectangle(0.5, 0.8, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(labelTitle, AbsoluteLayoutFlags.PositionProportional);

            var buttonBackArrow = ButtonFactory.ArrowLeft(eventBackButton);
            AbsoluteLayout.SetLayoutBounds(buttonBackArrow, new Rectangle(0.1, 0.8, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(buttonBackArrow, AbsoluteLayoutFlags.PositionProportional); 

            var barTop = ButtonFactory.BarWithButtonTitle(titleBar, eventBarButton ?? eventBackButton);

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
        Layout LayoutFields(params View[] views);
        Layout LayoutButtons(params View[] views);
        Layout TitleLayoutLower(string text, string titleBar, EventHandler eventBackButton, EventHandler eventBarButton = null);
        //, EventHandler<EventArgs> backButtonClicked);
    }
}