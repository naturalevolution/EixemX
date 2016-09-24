using EixemX.Constants;
using EixemX.Controls.Entries;
using EixemX.Factories;
using Xamarin.Forms;

[assembly: Dependency(typeof(EntryFactory))]

namespace EixemX.Factories
{
    public class EntryFactory : IEntryFactory
    {
        public CustomEntry EntryDefaultText(string text, FontType fontType)
        {
            var result = new CustomEntry
            {
                Placeholder = text,
                PlaceholderColor = Palette.Green,
                Keyboard = Keyboard.Text,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = PaletteText.FontSizeEntry,
                MaxLength = 200,
                FontType = fontType,
                HeightRequest = 45
            }; 

            return result;
        }

        public CustomEntry EntryDefaultText(string text)
        {
            return EntryDefaultText(text, FontType.TextaNarrowRegular);
        }
    }

    public interface IEntryFactory
    {
        CustomEntry EntryDefaultText(string text, FontType fontType);
        CustomEntry EntryDefaultText(string text);
    }
}