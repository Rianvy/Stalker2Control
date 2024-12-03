namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Represents a collection of ammunition items and their descriptions.
    /// </summary>
    internal class AmmoItems
    {
        /// <summary>
        /// Gets the dictionary containing ammunition descriptions.
        /// </summary>
        public Dictionary<string, string> AmmoDescriptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmmoItems"/> class.
        /// </summary>
        public AmmoItems()
        {
            AmmoDescriptions = InitializeAmmoDescriptions();
        }

        private Dictionary<string, string> InitializeAmmoDescriptions() =>
            new()
            {
                { "A918A 0 900 1", "9x18mm RG028" },
                { "A045D 0 900 1", ".45 ACP FMJ" },
                { "A045A 0 900 1", ".45 ACP AP" },
                { "A045E 0 900 1", ".45 ACP HP" },
                { "AVOG 0 900 1", "VOG-25" },
                { "A918D 0 900 1", "9x18mm PST" },
                { "A919D 0 900 1", "9x19mm FMJ" },
                { "A919A 0 900 1", "9x19mm +P" },
                { "A545D 0 900 1", "5.45x39mm PS" },
                { "A545A 0 900 1", "5.45x39mm PP" },
                { "A545E 0 900 1", "5.45x39mm MZhV-13" },
                { "AHEDP 0 900 1", "HEDP" },
                { "A939D 0 900 1", "9x39mm PA" },
                { "A939A 0 900 1", "9x39mm SP-6" },
                { "A939S 0 900 1", "9x39mm SP-5" },
                { "A939E 0 900 1", "9x39mm PPE" },
                { "A556D 0 900 1", "5.56x45mm M885" },
                { "A556A 0 900 1", "5.56x45mm M995" },
                { "A556S 0 900 1", "5.56x45mm Mk 262" },
                { "A556E 0 900 1", "5.56x45mm HP" },
                { "APG7V 0 900 1", "PG-7V" },
                { "A762SniperD 0 900 1", "7.62x54mm LPS" },
                { "A762SniperA 0 900 1", "7.62x54mm B-32" },
                { "A762SniperS 0 900 1", "7.62x54mm 7N1" },
                { "A012D 0 900 1", "12/70mm Buckshot" },
                { "A012A 0 900 1", "12/76mm Slug" },
                { "A012E 0 900 1", "12/76mm Expanding Dart" },
                { "AGA 0 900 1", "Gauss Cassette" },
                { "A762D 0 900 1", "7.62x39mm PS" },
                { "A762A 0 900 1", "7.62x39mm B3" },
                { "A762E 0 900 1", "7.62x39mm 'Lan'" },
                { "A762NATOD 0 900 1", ".308 W" },
                { "A762NATOA 0 900 1", ".308 AP" },
                { "A762NATOS 0 900 1", ".308 Match" }
            };
    }
}