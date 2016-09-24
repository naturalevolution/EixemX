using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EixemX.Droid.Services.Config;
using EixemX.Services.Config;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConfigFetcher))]
namespace EixemX.Droid.Services.Config
{
    /// <summary>
    /// Fetches settings from embedded resources in the Android project.
    /// </summary>
    public class ConfigFetcher : IConfigFetcher
    {
        #region IConfigFetcher implementation

        public async Task<string> GetAsync(string configElementName, bool readFromSensitiveConfig = false)
        {
            var fileName = (readFromSensitiveConfig) ? "config-sensitive.xml" : "config.xml";

            var type = this.GetType();
            var resource = "EixemX.Droid.Config." + fileName;
            using (var stream = type.Assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                var doc = XDocument.Parse(await reader.ReadToEndAsync());
                return doc.Element("config").Element(configElementName)?.Value;
            }
        }

        #endregion
    }
}