using EixemX.Constants;
using EixemX.Controls.Labels;
using EixemX.Factories;
using Xamarin.Forms;

[assembly: Dependency(typeof(LabelFactory))]

namespace EixemX.Factories
{
    public class LabelFactory : ILabelFactory
    {
        public CustomLabel LabelMessage()
        {
            return new CustomLabel
            {
                TextColor = Color.White,
                FontSize = PaletteText.FontSizeS,
                HorizontalTextAlignment = TextAlignment.Center
            };
        }

        public CustomLabel Title(string text)
        {
            var result = new CustomLabel
            {
                TextColor = Color.White, 
                FontSize = PaletteText.FontSizeM,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = text
            };
            return result;
        }

        public CustomLabel TitleSub(string text)
        {
            var result = Title(text);
            result.FontSize = PaletteText.FontSizeM;
            result.FontAttributes = FontAttributes.None;
            return result;
        }
    }

    public interface ILabelFactory
    {
        CustomLabel LabelMessage();
        CustomLabel Title(string text);
        CustomLabel TitleSub(string text);
    }
}