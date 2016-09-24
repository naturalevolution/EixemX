using Android.Graphics;
using Xamarin.Forms;

namespace EixemX.Droid.Constants
{
    public static class Fonts
    {
        public static Typeface FontLight = Typeface.CreateFromAsset(Forms.Context.Assets,"Fonts/TextaNarrowAlt-Light.ttf");

        public static Typeface FontRegular = Typeface.CreateFromAsset(Forms.Context.Assets,"Fonts/TextaNarrowAlt-Regular.ttf");
    }
}