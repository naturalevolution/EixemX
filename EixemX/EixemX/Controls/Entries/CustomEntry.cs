using Xamarin.Forms;

namespace EixemX.Controls.Entries
{
    public class CustomEntry : Xamarin.Forms.Entry
    {
        public static readonly BindableProperty MaxLengthProperty =
             BindableProperty.Create("MaxLength", typeof(float), typeof(CustomEntry), 0F);
         
        public float MaxLength
        {
            get { return (float)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public static readonly BindableProperty FontTypeProperty =
             BindableProperty.Create("FontType", typeof(FontType), typeof(CustomEntry), FontType.TextaNarrowRegular);

        public FontType FontType
        {
            get { return (FontType)GetValue(FontTypeProperty); }
            set { SetValue(FontTypeProperty, value); }
        }
    }

    public enum FontType
    {
        TextaNarrowLight,
        TextaNarrowRegular,
    }


}
