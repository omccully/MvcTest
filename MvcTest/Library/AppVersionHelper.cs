using System.Reflection;

namespace MvcTest.Library
{
    public static class AppVersionHelper
    {
        public static string GetVersion()
        {
            return Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
                ?? "Unknown";
        }
    }
}
