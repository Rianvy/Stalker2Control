namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Represents a collection of armor items and their descriptions.
    /// </summary>
    public class ArmorItems
    {
        /// <summary>
        /// Gets the dictionary containing armor descriptions.
        /// </summary>
        public Dictionary<string, string> ArmorDescriptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorItems"/> class.
        /// </summary>
        public ArmorItems()
        {
            ArmorDescriptions = InitializeArmorDescriptions();
        }

        private Dictionary<string, string> InitializeArmorDescriptions() =>
            new()
            {
                { "TemplateArmor", "Beginner's Suit" },
                { "Jemmy_Neutral_Armor", "Beginner's Suit" },
                { "Newbee_Neutral_Armor", "Debut Suit" },
                { "Nasos_Neutral_Armor", "OZK Researcher" },
                { "Zorya_Neutral_Armor", "ZORYA" },
                { "SEVA_Neutral_Armor", "SEVA Suit" },
                { "Exoskeleton_Neutral_Armor", "EXOSKELETON" },
                { "SkinJacket_Bandit_Armor", "Bandit's Jacket" },
                { "Jacket_Bandit_Armor", "Bandit Leather Jacket" },
                { "Middle_Bandit_Armor", "Marauder Suit (Bandit)" },
                { "Light_Mercenaries_Armor", "Mercenary Suit" },
                { "Exoskeleton_Mercenaries_Armor", "Exoskeleton Brumbar (Mercenary)" },
                { "Heavy_Mercenaries_Armor", "PSZ-9N Wolfhound (Mercenary)" },
                { "Default_Military_Armor", "PSZ-7 Bulletproof Vest (Military)" },
                { "Heavy2_Military_Armor", "Beryll-5M Bulletproof Vest (Military)" },
                { "Anomaly_Scientific_Armor", "SSP-99 Ecologist (Scientists/Red)" },
                { "Anomaly_Scientific_Armor_PSY_preinstalled", "SSP-99 Ecologist (Air Filter Modification)" },
                { "HeavyAnomaly_Scientific_Armor", "SSP-100 Discovery (Scientists/White)" },
                { "Rook_Svoboda_Armor", "Svoboda Wind of Freedom Suit" },
                { "Battle_Svoboda_Armor", "PSZ-5V Svoboda Experience Suit" },
                { "SEVA_Svoboda_Armor", "Svoboda SEVA-V Suit" },
                { "Heavy_Svoboda_Armor", "PSZ-12V Bulat (Svoboda)" },
                { "HeavyExoskeleton_Svoboda_Armor", "Exoskeleton Stronghold (Svoboda)" },
                { "Exoskeleton_Svoboda_Armor", "Exoskeleton Will (Svoboda)" },
                { "Rook_Dolg_Armor", "Dolg Recruit Suit" },
                { "Battle_Dolg_Armor", "PSZ-5D Universal Protection (Dolg)" },
                { "SEVA_Dolg_Armor", "Dolg SEVA-D Suit" },
                { "Heavy_Dolg_Armor", "PSZ-9D Dolg Armor" },
                { "HeavyExoskeleton_Dolg_Armor", "Exoskeleton Shield of Dolg" },
                { "Exoskeleton_Dolg_Armor", "Exoskeleton Carapace (Dolg)" },
                { "Battle_Monolith_Armor", "Zircon Suit (Monolith)" },
                { "HeavyAnomaly_Monolith_Armor", "Corund Suit (Monolith)" },
                { "HeavyExoskeleton_Monolith_Armor", "Exoskeleton Ruby (Monolith)" },
                { "Exoskeleton_Monolith_Armor", "Exoskeleton Diamond (Monolith)" },
                { "Battle_Varta_Armor", "PSZ-20W — Convoy (Varta)" },
                { "BattleExoskeleton_Varta_Armor", "Exoskeleton Operator (Varta)" },
                { "Battle_Spark_Armor", "PSZ-5I Hawk (Spark)" },
                { "HeavyAnomaly_Spark_Armor", "SSP-100I Search (Spark)" },
                { "SEVA_Spark_Armor", "SEVA-I Suit (Spark)" },
                { "HeavyBattle_Spark_Armor", "PSZ-9I Falcon (Spark)" },
                { "Battle_Dolg_End_Armor", "X7 Suit" }
            };
    }
}
