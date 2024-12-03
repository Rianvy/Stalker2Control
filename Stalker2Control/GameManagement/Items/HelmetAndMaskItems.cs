namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Represents a collection of helmets and masks items and their descriptions.
    /// </summary>
    public class HelmetAndMaskItems
    {
        /// <summary>
        /// Gets the dictionary containing helmets and masks descriptions.
        /// </summary>
        public Dictionary<string, string> HelmetsAndMasksDescriptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelmetAndMaskItems"/> class.
        /// </summary>
        public HelmetAndMaskItems()
        {
            HelmetsAndMasksDescriptions = InitializeHelmetsAndMasksDescriptions();
        }

        private Dictionary<string, string> InitializeHelmetsAndMasksDescriptions() =>
            new()
            {
                { "Light_Duty_Helmet", "Gas mask Aurora" },
                { "Heavy_Duty_Helmet", "Helmet Sphere-M20" },
                { "Heavy_Svoboda_Helmet", "Helmet Mask-1" },
                { "Heavy_Varta_Helmet", "Gas mask AeroProtection" },
                { "Heavy_Military_Helmet", "Tactical helmet" },
                { "Light_Mercenaries_Helmet", "Gas mask PA-7" },
                { "Light_Military_Helmet", "Gas mask PA-10" },
                { "Battle_Military_Helmet", "Ballistic helmet" },
                { "Light_Bandit_Helmet", "Gas mask PG-4 Vices" },
                { "Light_Neutral_Helmet", "Gas mask Optic" }
            };
    }
}