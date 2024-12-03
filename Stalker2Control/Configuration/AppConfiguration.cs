namespace Stalker2Control.Configuration
{
    /// <summary>
    /// Represents the configuration for the Stalker 2 Control application.
    /// Contains essential settings and constants related to the game and application behavior.
    /// </summary>
    public static class AppConfiguration
    {
        /// <summary>
        /// The name of the game process.
        /// </summary>
        public const string GAME_PROCESS_NAME = "Stalker2-Win64-Shipping";

        /// <summary>
        /// The English language layout identifier.
        /// </summary>
        public const string ENGLISH_LAYOUT = "00000409";

        /// <summary>
        /// Contains window flag constants used for window manipulation.
        /// </summary>
        public static class WindowFlags
        {
            /// <summary>
            /// The flag to restore a window.
            /// </summary>
            public const int SW_RESTORE = 9;
        }
    }
}
