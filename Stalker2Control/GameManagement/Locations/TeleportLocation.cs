namespace Stalker2Control.GameManagement.Locations
{
    /// <summary>
    /// Provides teleport locations in the game with their corresponding names and coordinates.
    /// </summary>
    public class TeleportLocation
    {
        private readonly Dictionary<string, string> teleportLocations;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeleportLocation"/> class.
        /// </summary>
        public TeleportLocation()
        {
            teleportLocations = InitializeTeleportLocations();
        }

        private Dictionary<string, string> InitializeTeleportLocations() =>
            new()
            {
                { "XTeleportTo 340931.38 666722.19 409.60", "Introduction" },
                { "XTeleportTo 367538.00 595014.00 212.17", "Beginning" },
                { "XTeleportTo 362269.19 589130.19 750.27", "Watchhouse" },
                { "XTeleportTo 401922.22 549398.50 698.31", "Zalessie" },
                { "XTeleportTo 761943.12 712179.81 2849.92", "Old Church" },
                { "XTeleportTo 743126.25 764860.44 400.00", "Second Outpost" },
                { "XTeleportTo 767872.62 732877.50 400.00", "Fishing Hamlet" },
                { "XTeleportTo 743319.88 736860.38 1000.00", "Pump Station" },
                { "XTeleportTo 783729.06 756685.00 400.00", "Abandoned Hamlet" },
                { "XTeleportTo 737051.75 709953.06 400.00", "Burnt Hamlet" },
                { "XTeleportTo 761805.69 710109.50 1428.26", "Old Church" },
                { "XTeleportTo 317827.750000 415159.250000 702.566772", "Rostok" },
                { "XTeleportTo 737051.75 539953.06 400.00", "Hydrodynamics Laboratory" },
                { "XTeleportTo 750051.75 575953.06 500.00", "Dry Cargo Ship" },
                { "XTeleportTo 750051.75 635953.06 4700.00", "Forestry" },
                { "XTeleportTo 331951.75 596953.06 800.00", "Cherevach" },
                { "XTeleportTo 231951.75 526953.06 800.00", "Bloodsucker Village" },
                { "XTeleportTo 261951.75 596953.06 800.00", "Pioneer Camp 'Fairytale'" },
                { "XTeleportTo 294951.75 618953.06 4000.00", "Laboratory X15 / Orbit Station" },
                { "XTeleportTo 200951.75 618953.06 1000.00", "Collector Descent" },
                { "XTeleportTo 230951.75 618953.06 1000.00", "Helicopter Base" },
                { "XTeleportTo 245951.75 555953.06 1000.00", "Military Warehouses" },
                { "XTeleportTo 155951.75 560353.06 1000.00", "Technical Zone Checkpoint" },
                { "XTeleportTo 135951.75 520353.06 2000.00", "Railway Crossing" },
                { "XTeleportTo 125951.75 515353.06 1000.00", "Malachite Repair Base" },
                { "XTeleportTo 109951.75 477353.06 400.00", "Malachite NTC" },
                { "XTeleportTo 72951.75 427353.06 1400.00", "Tropospheric Communication Point" },
                { "XTeleportTo 72951.75 467353.06 3100.00", "CVP Mirror" },
                { "XTeleportTo 142951.75 437353.06 400.00", "Burner Tunnel" },
                { "XTeleportTo 114951.75 437353.06 2300.00", "Brain Burner" },
                { "XTeleportTo 330851.75 415053.06 400.00", "Rostok Base" }
            };

        /// <summary>
        /// Gets the list of location names.
        /// </summary>
        /// <returns>A list of location names.</returns>
        public List<string> GetLocationNames()
        {
            return teleportLocations.Values.ToList();
        }

        /// <summary>
        /// Gets the coordinates for a given location name.
        /// </summary>
        /// <param name="locationName">The name of the location.</param>
        /// <returns>The coordinates of the location, or an empty string if not found.</returns>
        public string GetLocationCoordinates(string locationName)
        {
            return teleportLocations.FirstOrDefault(location => location.Value == locationName).Key ?? string.Empty;
        }
    }
}
