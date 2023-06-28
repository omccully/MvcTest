namespace MvcTest.Library
{
    public static class ConfigurationHelper
    {

        public static string GetRequiredValue(this IConfiguration config, string key)
        {
            return config[key] ?? throw new Exception($"Value not found in config: {key}");
        }
    }
}
