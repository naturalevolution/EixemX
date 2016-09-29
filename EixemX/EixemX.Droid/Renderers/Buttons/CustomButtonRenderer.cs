using Android.Graphics;
using Android.Views;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Droid.Constants;
using EixemX.Droid.Renderers.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]

namespace EixemX.Droid.Renderers.Buttons
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            var customButton = e.NewElement as CustomButton;

            var thisButton = Control;

            thisButton.Typeface = customButton.FontAttributes == FontAttributes.Bold ? Fonts.FontRegular : Fonts.FontLight;

            /* if (customButton.BackgroundColor == Palette.White)
             {
                 thisButton.Typeface = Fonts.FontRegular;
             }
             else
             {
                 thisButton.Typeface = Fonts.FontLight;
             }*/

            thisButton.Touch += (sender, args) =>
            {
                var btn = sender as Android.Widget.Button;
                //btn.Typeface = btn.Typeface == Fonts.FontRegular ? Fonts.FontLight : Fonts.FontRegular;
                if (args.Event.Action == MotionEventActions.Down)
                {
                    customButton.OnPressed(); 
                }
                else if (args.Event.Action == MotionEventActions.Up)
                {
                    customButton.OnReleased();
                }
            };
        }
    }
}