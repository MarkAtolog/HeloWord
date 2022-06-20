using Aquality.Selenium.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utils
{
    public class ConfigManager
    {
        private static readonly string SettingsFile = "settings.json";
        private static JsonSettingsFile Reader = new(SettingsFile);

        public static string GetValue(string path)
        {
            return Reader.GetValue<string>(path);
        }
    }
}
