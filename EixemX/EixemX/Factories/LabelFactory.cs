using EixemX.Constants;
using EixemX.Factories;
using EixemX.Localization;
using Xamarin.Forms;
using XLabs.Forms.Controls;

[assembly: Dependency(typeof(LabelFactory))]

namespace EixemX.Factories
{
    public class LabelFactory : ILabelFactory
    {
        public Label LabelMessage()
        {
            return new Label
                    {
                        TextColor = Color.White,
                        FontSize = PaletteText.FontSizeXS,
                        HorizontalTextAlignment = TextAlignment.Center
                    };
        }

        public Label Title(string text)
        { 
            var result = new Label
            {
                TextColor = Color.White,
                FontSize = PaletteText.FontSizeM, 
                HorizontalTextAlignment = TextAlignment.Center,
                Text = text
            };
            return result;
        }

        public HyperLinkLabel HyperLinkLabel()
        {
            return new HyperLinkLabel
            {
                Text = TextResources.Account_Link_PasswordForget,
                FontSize = PaletteText.FontSizeSmall,
                TextColor = Palette.White,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.None
            };
        }
    }

    public interface ILabelFactory
    {
        Label LabelMessage(); 
        Label Title(string text);
        HyperLinkLabel HyperLinkLabel();
    }
}