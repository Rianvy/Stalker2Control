namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Represents a collection of detector items and their descriptions.
    /// </summary>
    public class DetectorsItems
    {
        /// <summary>
        /// Gets the dictionary containing detector descriptions.
        /// </summary>
        public Dictionary<string, string> DetectorsDescriptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DetectorsItems"/> class.
        /// </summary>
        public DetectorsItems()
        {
            DetectorsDescriptions = InitializeDetectorsDescriptions();
        }

        private Dictionary<string, string> InitializeDetectorsDescriptions() =>
            new()
            {
                { "TemplateDetector", "non-playable item (backpack)" },
                { "Veles", "Detector 'Veles'" },
                { "Bear", "Detector 'Bear'" },
                { "Echo", "Detector 'Echo'" },
                { "Gilka", "Detector 'Gilka'" }
            };
    }
}
