namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Represents a collection of keys items and their descriptions.
    /// </summary>
    public class KeyItems
    {
        /// <summary>
        /// Gets the dictionary containing keys descriptions.
        /// </summary>
        public Dictionary<string, string> KeysDescriptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyItems"/> class.
        /// </summary>
        public KeyItems()
        {
            KeysDescriptions = InitializeKeysDescriptions();
        }

        private Dictionary<string, string> InitializeKeysDescriptions() =>
            new()
            {
                { "Tamplate_Key_Chest", "Key shell (not a game item)" },
                { "Tamplate_Key_Padlock", "Key shell (not a game item)" },
                { "Tamplate_Key_DoorOld", "Key shell (not a game item)" },
                { "Tamplate_Key_DoorNew", "Key shell (not a game item)" },
                { "PripyatCafe_Key_Chest", "Key to the chest in the \"Pripyat\" cafe" },
                { "Garbage_DetentionCenter_Key_Padlock", "Key to the padlock in the detention center in the garbage dump" },
                { "Garbage_Hlynka_Key_Chest", "Key to the chest in Hlynka at the garbage dump" },
                { "Cordon_Brainwasher_Key_Padlock", "Key to the padlock in the \"Brainwasher\" office on Cordon" },
                { "Pripyat_Restoran_1_Key_DoorNew", "Key to the new door in restaurant #1 in Pripyat" },
                { "Pripyat_Restoran_2_Key_Chest", "Key to the chest in restaurant #2 in Pripyat" },
                { "Yantar_Agro_1_Key_DoorNew", "Key to the new door in Agro-1 in Yantar" },
                { "Yantar_Agro_2_Key_Chest", "Key to the chest in Agro-2 in Yantar" },
                { "BurnedForest_Mist_Key_DoorOld", "Key to the old door in the Mist area of the Burned Forest" },
                { "Jupiter_HlebZavod_Key_DoorNew", "Key to the new door in the bread factory in Jupiter" },
                { "Malachite_X17_Key_DoorNew", "Key to the new door in X17 in Malachite" },
                { "Pripyat_Polesie_Key_DoorNew", "Key to the new door in \"Polesie\" in Pripyat" },
                { "BurntForest_X15_Key_Chest", "Key to the chest in location X15 in the Burnt Forest" },
                { "WildIsland_Trestle_Key_Padlock", "Key to the padlock on the trestle on Wild Island" },
                { "CementPlant_ConcreteForest_Key_DoorNew", "Key to the new door in the Concrete Forest near the cement plant" },
                { "RedForest_Leshyna_Key_DoorNew", "Key to the new door in Leshyna in the Red Forest" },
                { "CementPlant_IslandNearKopachi_Key_DoorNew", "Key to the new door on the island near Kopachi, near the cement plant" },
                { "PromzonaArmyStorageKey", "Key to the Army storage in the industrial zone" },
                { "RostokKeyForDoor01", "Key to door 01 in Rostok" },
                { "BurntForest_FairyTaleCamp_Key_DoorNew", "Key to the new door in the Fairy Tale camp in the Burnt Forest" },
                { "ChemicalPlant_RailwayCloset_Key_DoorOld", "Key to the old door in the railway closet at the chemical plant" },
                { "YantarArgarFactoryKeyForDoor01", "Key to door 01 at the Yantar Argar factory" },
                { "Pripyat_Vysokopoverhivka_Teleport_Key_DoorNew", "Key to the new door in the teleport at Vysokopoverhivka in Pripyat" },
                { "BurntForest_Cherevach_Key_Padlock", "Key to the padlock in Cherevach in the Burnt Forest" },
                { "Garbage_X18DressRoom_Key_Chest", "Key to the chest in the dressing room at X18 in the garbage dump" }
            };
    }
}