namespace Stalker2Control.Configuration
{
    /// <summary>
    /// Represents configurable game settings.
    /// </summary>
    public class ControlSettings
    {
        // Constants for default settings
        private const int DefaultMoney = 10000;
        private const int DefaultClipSpeed = 1000;
        private const float DefaultKillNPCsRadius = 1000f;
        private const float DefaultKillNPCsminDistance = -100000f;
        private const float DefaultKillNPCsmaxDistance = 0f;
        private const int DefaultTimeSpeed = 10;
        private const bool DefaultIsALifeEnabled = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlSettings"/> class with default values.
        /// </summary>
        public ControlSettings()
        {
            Money = DefaultMoney;
            ClipSpeed = DefaultClipSpeed;
            SelectedWeather = WeatherTypes.Type.Weather0;
            WeatherTimeHours = 12;
            WeatherTimeMinutes = 30;
            KillNPCsRadius = DefaultKillNPCsRadius;
            KillNPCsminDistance = DefaultKillNPCsminDistance;
            KillNPCsmaxDistance = DefaultKillNPCsmaxDistance;
            TimeSpeed = DefaultTimeSpeed;
            IsGodModeEnabled = false;
            IsNoClipEnabled = false;
            IsTimeSpeedEnabled = false;
            IsALifeEnabled = DefaultIsALifeEnabled;
            SelectedLocation = string.Empty;
        }

        /// <summary>
        /// Amount of money available in the game.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Speed of the game clip.
        /// </summary>
        public int ClipSpeed { get; set; }

        /// <summary>
        /// Selected weather type.
        /// </summary>
        public WeatherTypes.Type SelectedWeather { get; set; }

        /// <summary>
        /// Weather time in hours.
        /// </summary>
        public int WeatherTimeHours { get; set; }

        /// <summary>
        /// Weather time in minutes.
        /// </summary>
        public int WeatherTimeMinutes { get; set; }

        /// <summary>
        /// Radius in which NPCs are killed.
        /// </summary>
        public float KillNPCsRadius { get; set; }

        /// <summary>
        /// Minimum distance from which NPCs can be killed.
        /// </summary>
        public float KillNPCsminDistance { get; set; }

        /// <summary>
        /// Maximum distance at which NPCs can be killed.
        /// </summary>
        public float KillNPCsmaxDistance { get; set; }

        /// <summary>
        /// Time speed multiplier for the game.
        /// </summary>
        public int TimeSpeed { get; set; }

        /// <summary>
        /// Flag to enable or disable God Mode.
        /// </summary>
        public bool IsGodModeEnabled { get; set; }

        /// <summary>
        /// Flag to enable or disable No Clip mode.
        /// </summary>
        public bool IsNoClipEnabled { get; set; }

        /// <summary>
        /// Flag to enable or disable time speed control.
        /// </summary>
        public bool IsTimeSpeedEnabled { get; set; }

        /// <summary>
        /// Flag to enable or disable "A Life" mode.
        /// </summary>
        public bool IsALifeEnabled { get; set; }

        /// <summary>
        /// Selected location for the game.
        /// </summary>
        public string SelectedLocation { get; set; }

        /// <summary>
        /// Defines available weather types.
        /// </summary>
        public static class WeatherTypes
        {
            public enum Type
            {
                Weather0,
                Weather1,
                Weather2,
                Weather3,
                Weather4,
                Weather5,
                Weather6,
                Weather7,
                Weather8
            }
        }

        /// <summary>
        /// Validates the settings to ensure that all values are within acceptable ranges.
        /// </summary>
        public void ValidateSettings()
        {
            if (Money < 0)
                throw new ArgumentOutOfRangeException(nameof(Money), "Money cannot be negative.");
            if (ClipSpeed < 0)
                throw new ArgumentOutOfRangeException(nameof(ClipSpeed), "Clip speed cannot be negative.");
            if (KillNPCsRadius < 0)
                throw new ArgumentOutOfRangeException(nameof(KillNPCsRadius), "Kill NPCs radius cannot be negative.");
            if (KillNPCsminDistance > KillNPCsmaxDistance)
                throw new ArgumentException("Minimum distance cannot be greater than maximum distance.");
            if (TimeSpeed < 1)
                throw new ArgumentOutOfRangeException(nameof(TimeSpeed), "Time speed must be at least 1.");
        }
    }
}