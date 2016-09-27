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

    }

    public interface ILabelFactory
    {
        Label LabelMessage(); 
        Label Title(string text);  
    }
}