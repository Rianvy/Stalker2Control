using System.Reflection;

namespace Stalker2Control.Configuration
{
    /// <summary>
    /// Provides information about the current assembly.
    /// </summary>
    public static class AssemblyInfo
    {
        /// <summary>
        /// Gets the version of the current assembly.
        /// </summary>
        /// <returns>The version of the current assembly.</returns>
        public static string GetVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return version != null ? version.ToString() : "Unknown version";
        }

        /// <summary>
        /// Gets the name of the current assembly.
        /// </summary>
        /// <returns>The name of the current assembly.</returns>
        public static string GetName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name ?? "Unknown name";
        }

        /// <summary>
        /// Gets the full name of the current assembly.
        /// </summary>
        /// <returns>The full name of the current assembly.</returns>
        public static string GetFullName()
        {
            return Assembly.GetExecutingAssembly().GetName().FullName;
        }

        /// <summary>
        /// Gets the location of the current assembly.
        /// </summary>
        /// <returns>The location of the current assembly.</returns>
        public static string GetLocation()
        {
            return Assembly.GetExecutingAssembly().Location;
        }

        /// <summary>
        /// Gets the informational version of the current assembly.
        /// </summary>
        /// <returns>The informational version of the current assembly.</returns>
        public static string GetInformationalVersion()
        {
            var attribute = Attribute.GetCustomAttribute(
                Assembly.GetExecutingAssembly(),
                typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;

            return attribute?.InformationalVersion ?? "Unknown informational version";
        }
    }
}
