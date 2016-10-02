using EixemX.Constants;
using EixemX.Controls.Entries;
using EixemX.Factories;
using Xamarin.Forms;

[assembly: Dependency(typeof(EntryFactory))]

namespace EixemX.Factories
{
    public class EntryFactory : IEntryFactory
    { 

        public CustomEntry EntryDefaultEmail(string text, string fieldName)
        {
            return GenerateEntryDefault(text, fieldName, FontType.TextaNarrowRegular, Keyboard.Email);
        }

        public CustomEntry EntryPlainPassword(string text, string fieldName)
        {
            var result = GenerateEntryDefault(text, fieldName, FontType.TextaNarrowRegular, Keyboard.Default);
            result.IsPassword = true;
            return result;
        }

        public CustomEntry EntryDefaultAmount(string text, string fieldName)
        {
            return GenerateEntryDefault(text, fieldName, FontType.TextaNarrowRegular, Keyboard.Numeric);
        }

        public CustomEntry EntryDefaultText(string text, string fieldName)
        { 
            return GenerateEntryDefault(text, fieldName, FontType.TextaNarrowRegular, Keyboard.Text);
        }

        private CustomEntry GenerateEntryDefault(string placeHolder, string fieldName, FontType fontType, Keyboard keyboard)
        {
            var result = new CustomEntry
            {
                Placeholder = placeHolder,
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
            result.SetBinding(Entry.TextProperty, fieldName, BindingMode.TwoWay);

            return result;
        }
    }

    public interface IEntryFactory
    { 
        CustomEntry EntryDefaultText(string text, string fieldName);
        CustomEntry EntryDefaultEmail(string text, string fieldName);
        CustomEntry EntryPlainPassword(string text, string fieldName);
        CustomEntry EntryDefaultAmount(string text, string fieldName);
    }
}