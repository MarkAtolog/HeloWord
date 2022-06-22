using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Definitions.Utils
{
    class ConfigurationReader
    {
        private static readonly string PathConfig = "../../../../Definitions/Resources";

        public static ISettingsFile GetConfigFile(string fileName) => 
            new JsonSettingsFile(Path.Combine(Directory.GetCurrentDirectory(), PathConfig, $"{fileName}.json"));
    }
}
