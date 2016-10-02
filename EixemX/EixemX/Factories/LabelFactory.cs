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
            return new CustomLabel
            {
                Text = text,
                TextColor = Palette.White,
                FontSize = PaletteText.FontSizeML,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            }; 
        }

        public Grid TitleHeader(string text)
        { 
            var grid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 20
            };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });  
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); 

            var label = new CustomLabel
            {
                Text = text,
                TextColor = Palette.White,
                FontSize = PaletteText.FontSizeML,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(label, 0, 0);
            return grid;
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
        Grid TitleHeader(string text);
        CustomLabel TitleSub(string text);
    }
}