using EixemX.Constants;
using EixemX.Controls.Entries;
using EixemX.Factories;
using Xamarin.Forms;

[assembly: Dependency(typeof(EntryFactory))]

namespace EixemX.Factories
{
    public class EntryFactory : IEntryFactory
    { 

        public CustomEntry EntryDefaultEmail(string text)
        {
            return GenerateEntryDefault(text, FontType.TextaNarrowRegular, Keyboard.Email);
        }

        public CustomEntry EntryPlainPassword(string text)
        {
            return GenerateEntryDefault(text, FontType.TextaNarrowRegular, Keyboard.Default);
        }

        public CustomEntry EntryDefaultAmount(string text)
        {
            return GenerateEntryDefault(text, FontType.TextaNarrowRegular, Keyboard.Numeric);
        }

        public CustomEntry EntryDefaultText(string text)
        { 
            return GenerateEntryDefault(text, FontType.TextaNarrowRegular, Keyboard.Text);
        }

        private CustomEntry GenerateEntryDefault(string text, FontType fontType, Keyboard keyboard)
        {
            var result = new CustomEntry
            {
                Placeholder = text,
                PlaceholderColor = Palette.Green,
                Keyboard = keyboard,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = PaletteText.FontSizeM,
                MaxLength = 200,
                FontType = fontType,
                HeightRequest = 45
            };

            return result;
        }
    }

    public interface IEntryFactory
    { 
        CustomEntry EntryDefaultText(string text);
        CustomEntry EntryDefaultEmail(string text);
        CustomEntry EntryPlainPassword(string text);
        CustomEntry EntryDefaultAmount(string text);
    }
}