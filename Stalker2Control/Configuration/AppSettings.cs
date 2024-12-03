using System.Configuration;

namespace Stalker2Control.Configuration
{
    /// <summary>
    /// Represents application-wide settings.
    /// </summary>
    public class AppSettings
    {
        private readonly string _repositoryUrl;
        private readonly string _version;
        private readonly string _nameApp;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        public AppSettings()
        {
            // Load settings from a configuration file or environment variables.
            _repositoryUrl = ConfigurationManager.AppSettings["RepositoryUrl"] ?? "https://github.com/Rianvy/Stalker2Control";
            _version = AssemblyInfo.GetVersion();
            _nameApp = AssemblyInfo.GetName();

            ValidateSettings();
        }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        public string Version => _version;

        /// <summary>
        /// Gets the application name.
        /// </summary>
        public string NameApp => _nameApp;

        /// <summary>
        /// Gets the GitHub repository URL.
        /// </summary>
        public string RepositoryUrl => _repositoryUrl;

        /// <summary>
        /// Validates the settings to ensure they are correct.
        /// </summary>
        private void ValidateSettings()
        {
            if (string.IsNullOrWhiteSpace(_repositoryUrl))
            {
                throw new ArgumentException("Repository URL cannot be null or whitespace.", nameof(RepositoryUrl));
            }

            if (string.IsNullOrWhiteSpace(_version))
            {
                throw new ArgumentException("Version cannot be null or whitespace.", nameof(Version));
            }

            if (string.IsNullOrWhiteSpace(_nameApp))
            {
                throw new ArgumentException("Application name cannot be null or whitespace.", nameof(NameApp));
            }
        }
    }
}