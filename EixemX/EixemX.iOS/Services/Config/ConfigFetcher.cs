using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EixemX.iOS.Services.Config;
using EixemX.Services.Config;
using Xamarin.Forms;
using System.Xml.Linq;

[assembly: Dependency(typeof(ConfigFetcher))]
namespace EixemX.iOS.Services.Config
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
            var resource = "EixemX.iOS.Config." + fileName;
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
