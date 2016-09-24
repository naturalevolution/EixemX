using System.Globalization;
using EixemX.Droid.Localization;
using EixemX.Localization;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]

namespace EixemX.Droid.Localization
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns pt_BR into pt-BR
            return new CultureInfo(netLanguage);
        }
    }
}