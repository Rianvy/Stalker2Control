namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Represents a collection of blueprints items and their descriptions.
    /// </summary>
    public class BlueprintItems
    {
        /// <summary>
        /// Gets the dictionary containing blueprints descriptions.
        /// </summary>
        public Dictionary<string, string> BlueprintsDescriptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueprintItems"/> class.
        /// </summary>
        public BlueprintItems()
        {
            BlueprintsDescriptions = InitializeBlueprintsDescriptions();
        }

        private Dictionary<string, string> InitializeBlueprintsDescriptions() =>
            new()
            {
                { "Blueprint_M10_Upgrade_1 0 1 1", "Rubberized layer" },
                { "Blueprint_Rhino_Upgrade_1 0 1 1", "Conversion for buckshot" },
                { "Blueprint_APB_Upgrade_1 0 1 1", "Balancer installation" },
                { "Blueprint_APB_Upgrade_2 0 1 1", "Individual fitting" },
                { "Blueprint_Integral_Upgrade_1 0 1 1", "Return sleeve seal" },
                { "Blueprint_Zubr_Upgrade_1 0 1 1", "Additional rifling in the barrel" },
                { "Blueprint_Zubr_Upgrade_2 0 1 1", "Anatomical fitting" },
                { "Blueprint_Gvintar_Upgrade_1 0 1 1", "Return sleeve seal" },
                { "Blueprint_Grim_Upgrade_1 0 1 1", "Rubberized buttpad" },
                { "Blueprint_Gvintar_Upgrade_2 0 1 1", "Combat stop fitting" },
                { "Blueprint_Lavina_Upgrade_1 0 1 1", "Combat stop fitting" },
                { "Blueprint_Lavina_Upgrade_2 0 1 1", "Rubberized layer" },
                { "Blueprint_Kharod_Upgrade_1 0 1 1", "Balancer installation" },
                { "Blueprint_Kharod_Upgrade_2 0 1 1", "Rubberized coating" },
                { "Blueprint_Dnipro_Upgrade_1 0 1 1", "Additional rifling in the barrel" },
                { "Blueprint_Dnipro_Upgrade_2 0 1 1", "Conversion for caliber" },
                { "Blueprint_M701_Upgrade_1 0 1 1", "Return sleeve seal" },
                { "Blueprint_M701_Upgrade_2 0 1 1", "Polymer grip" },
                { "Blueprint_SVU_Upgrade_1 0 1 1", "Individual fitting" },
                { "Blueprint_SVU_Upgrade_2 0 1 1", "Rubberized layer" },
                { "Blueprint_M860_Upgrade_1 0 1 1", "Magazine feed" },
                { "Blueprint_D12_Upgrade_1 0 1 1", "Choke" },
                { "Blueprint_D12_Upgrade_2 0 1 1", "Buttstock rebalancing" },
                { "Blueprint_Ram2_Upgrade_1 0 1 1", "Return sleeve seal" },
                { "Blueprint_Ram2_Upgrade_2 0 1 1", "Automatic two-position" },
                { "Blueprint_MG_Upgrade_1 0 1 1", "Rubberized coating" },
                { "Blueprint_MG_Upgrade_2 0 1 1", "Rubberized buttpad" },
                { "Blueprint_FaustPsyResist_Quest_1_1 0 1 1", "Suppressor blueprint" },
                { "Blueprint_Heavy2_Military_Armor_Upgrade_1 0 1 1", "Camelback drinking system" },
                { "Blueprint_Heavy2_Military_Armor_Upgrade_2 0 1 1", "Lead container" },
                { "Blueprint_HeavyAnomaly_Scientific_Armor_Upgrade_1 0 1 1", "Lead container" },
                { "Blueprint_HeavyAnomaly_Scientific_Armor_Upgrade_2 0 1 1", "Aramid lining" },
                { "Blueprint_Heavy_Svoboda_Armor_Upgrade_1 0 1 1", "Lead container" },
                { "Blueprint_Heavy_Svoboda_Armor_Upgrade_2 0 1 1", "Camelback drinking system" },
                { "Blueprint_Heavy_Dolg_Armor_Upgrade_1 0 1 1", "Camelback drinking system" },
                { "Blueprint_Heavy_Dolg_Armor_Upgrade_2 0 1 1", "Aramid lining" },
                { "Blueprint_HeavyBattle_Spark_Armor_Upgrade_1 0 1 1", "Plexiglass suit" },
                { "Blueprint_HeavyBattle_Spark_Armor_Upgrade_2 0 1 1", "Lead container" },
                { "Blueprint_SEVA_Neutral_Armor_Upgrade_1 0 1 1", "Chainmail inserts" },
                { "Blueprint_SEVA_Neutral_Armor_Upgrade_2 0 1 1", "Shielding coating" },
                { "Blueprint_SciSEVA_Scientific_Armor_Upgrade_1 0 1 1", "Patch pockets" },
                { "Blueprint_SciSEVA_Scientific_Armor_Upgrade_2 0 1 1", "Polyethylene hermetic lining" },
                { "Blueprint_SEVA_Svoboda_Armor_Upgrade_1 0 1 1", "Shielding coating" },
                { "Blueprint_SEVA_Svoboda_Armor_Upgrade_2 0 1 1", "Aramid lining" },
                { "Blueprint_SEVA_Spark_Armor_Upgrade_1 0 1 1", "Patch pockets" },
                { "Blueprint_SEVA_Spark_Armor_Upgrade_2 0 1 1", "Lead container" },
                { "Blueprint_SEVA_Dolg_Armor_Upgrade_1 0 1 1", "Camelback drinking system" },
                { "Blueprint_SEVA_Dolg_Armor_Upgrade_2 0 1 1", "Aramid lining" },
                { "Blueprint_BattleExoskeleton_Varta_Armor_Upgrade_1 0 1 1", "Full titanium components" },
                { "Blueprint_BattleExoskeleton_Varta_Armor_Upgrade_2 0 1 1", "Arm servomotors" },
                { "Blueprint_BattleExoskeleton_Varta_Armor_Upgrade_3 0 1 1", "Lead container" },
                { "Blueprint_BattleExoskeleton_Varta_Armor_Upgrade_4 0 1 1", "Lead container" },
                { "Blueprint_Exoskeleton_Mercenaries_Armor_Upgrade_1 0 1 1", "Full titanium components" },
                { "Blueprint_Exoskeleton_Mercenaries_Armor_Upgrade_2 0 1 1", "Toxic gas extraction system" },
                { "Blueprint_Exoskeleton_Mercenaries_Armor_Upgrade_3 0 1 1", "Servomotor equipment" },
                { "Blueprint_Exoskeleton_Mercenaries_Armor_Upgrade_4 0 1 1", "Shielding coating" },
                { "Blueprint_Exoskeleton_Neutral_Armor_Upgrade_1 0 1 1", "Toxic gas extraction system" },
                { "Blueprint_Exoskeleton_Neutral_Armor_Upgrade_2 0 1 1", "Shielding coating" },
                { "Blueprint_Exoskeleton_Neutral_Armor_Upgrade_3 0 1 1", "Lead container" },
                { "Blueprint_Exoskeleton_Neutral_Armor_Upgrade_4 0 1 1", "Lead container" },
                { "Blueprint_Exoskeleton_Svoboda_Armor_Upgrade_1 0 1 1", "Full titanium components" },
                { "Blueprint_Exoskeleton_Svoboda_Armor_Upgrade_2 0 1 1", "Toxic gas extraction system" },
                { "Blueprint_Exoskeleton_Svoboda_Armor_Upgrade_3 0 1 1", "Shielding coating" },
                { "Blueprint_Exoskeleton_Svoboda_Armor_Upgrade_4 0 1 1", "Shielding coating" },
                { "Blueprint_HeavyExoskeleton_Svoboda_Armor_Upgrade_1 0 1 1", "Patch pockets" },
                { "Blueprint_HeavyExoskeleton_Svoboda_Armor_Upgrade_2 0 1 1", "Polyethylene hermetic lining" },
                { "Blueprint_HeavyExoskeleton_Svoboda_Armor_Upgrade_3 0 1 1", "Active filters" },
                { "Blueprint_HeavyExoskeleton_Svoboda_Armor_Upgrade_4 0 1 1", "Lead container" },
                { "Blueprint_Exoskeleton_Dolg_Armor_Upgrade_1 0 1 1", "Full titanium components" },
                { "Blueprint_Exoskeleton_Dolg_Armor_Upgrade_2 0 1 1", "Toxic gas extraction system" },
                { "Blueprint_Exoskeleton_Dolg_Armor_Upgrade_3 0 1 1", "Shielding coating" },
                { "Blueprint_Exoskeleton_Dolg_Armor_Upgrade_4 0 1 1", "Lead container" },
                { "Blueprint_HeavyExoskeleton_Dolg_Armor_Upgrade_1 0 1 1", "Sprayed protective layer" },
                { "Blueprint_HeavyExoskeleton_Dolg_Armor_Upgrade_2 0 1 1", "Larger backpack" },
                { "Blueprint_HeavyExoskeleton_Dolg_Armor_Upgrade_3 0 1 1", "Shielding coating" },
                { "Blueprint_HeavyExoskeleton_Dolg_Armor_Upgrade_4 0 1 1", "Lead container" },
                { "Blueprint_Heavy_Duty_Helmet_Upgrade_1 0 1 1", "Aramid lining" },
                { "Blueprint_Battle_Military_Helmet_Upgrade_1 0 1 1", "Aramid lining" },
                { "Blueprint_Heavy_Svoboda_Helmet_Upgrade_1 0 1 1", "Aramid lining" },
                { "Blueprint_Heavy_Military_Helmet_Upgrade_1 0 1 1", "Plexiglass inserts" }
            };
    }
}