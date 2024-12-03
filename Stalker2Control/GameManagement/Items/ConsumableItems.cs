namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Represents a collection of consumables items and their descriptions.
    /// </summary>
    public class ConsumableItems
    {
        /// <summary>
        /// Gets the dictionary containing consumables descriptions.
        /// </summary>
        public Dictionary<string, string> ConsumablesDescriptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableItems"/> class.
        /// </summary>
        public ConsumableItems()
        {
            ConsumablesDescriptions = InitializeConsumablesDescriptions();
        }

        private Dictionary<string, string> InitializeConsumablesDescriptions() =>
            new()
            {
                { "TemplateConsumable", "Non-game item (backpack)" },
                { "Bread", "Loaf of bread" },
                { "FreshBread", "Fresh bread" },
                { "CannedFood", "Canned food" },
                { "SpoiledCannedFood", "Spoiled canned food" },
                { "Vodka", "Vodka 'Kazaki'" },
                { "Sausage", "Sausage" },
                { "Energetic", "Energetic NON STOP" },
                { "Energetic_Limited", "Energetic NON STOP Limited Edition" },
                { "Bandage", "Bandage" },
                { "Medkit", "Medkit" },
                { "ArmyMedkit", "Army medkit" },
                { "EcoMedkit", "Scientific medkit" },
                { "AntiRad", "Anti-radiation drugs" },
                { "Hercules", "Hercules" },
                { "Cinnamon", "Periwinkle" },
                { "Beer", "Beer" },
                { "Water", "Water" },
                { "Milk", "Condensed milk" },
                { "PSYBlocker", "Psy-blocker" }
            };
    }
}
