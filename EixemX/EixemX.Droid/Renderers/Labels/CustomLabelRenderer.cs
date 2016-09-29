using EixemX.Controls.Labels;
using EixemX.Droid.Constants;
using EixemX.Droid.Renderers.Labels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]

namespace EixemX.Droid.Renderers.Labels
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var customLabel = e.NewElement as CustomLabel;

            Control.Typeface = customLabel.FontAttributes == FontAttributes.Bold ? Fonts.FontRegular : Fonts.FontLight;
        }
    }
}