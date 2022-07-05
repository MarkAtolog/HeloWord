using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace Definitions.Utils
{
    public class ConfigurationReader
    {
        private static readonly string PathConfig = "../../../../Definitions/Resources";

        public static ISettingsFile GetConfigFile(string fileName) => 
            new JsonSettingsFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), PathConfig, $"{fileName}.json"));
    }
}
