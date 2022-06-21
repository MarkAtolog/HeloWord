using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Definitions.Utils
{
    class ConfigurationReader
    {
        private static readonly string BasePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
        private static readonly string PathConfig = "Definitions/Resources";

        public static string GetBaseDirectoryPath() => BasePath;

        public static Dictionary<string, object> GetValueDictionary(string configurationKey) => GetConfigFile(configurationKey).GetValueDictionary<object>("").ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        public static string GetConfigValue(string configurationKey, string valueName) => GetConfigFile(configurationKey).GetValue<string>(valueName);

        public static ISettingsFile GetConfigFile(string fileName, string partFilePath = null) => new JsonSettingsFile(Path.Combine(BasePath, partFilePath ?? PathConfig, $"{fileName}.json"));
    }
}
