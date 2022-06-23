using Definitions.Utils;

namespace Definitions.Configuration
{
    public static class TestConfig
    {
        public static string Url { get; private set; } = ConfigurationReader.GetConfigFile(nameof(TestConfig)).GetValue<string>(nameof(Url).ToLower());
        public static string Image { get; private set; } = ConfigurationReader.GetConfigFile(nameof(TestConfig)).GetValue<string>(nameof(Image).ToLower());
    }
}
