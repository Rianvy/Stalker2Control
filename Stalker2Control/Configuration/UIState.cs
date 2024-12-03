namespace Stalker2Control.Configuration
{
    /// <summary>
    /// Represents the current state of the UI.
    /// </summary>
    public class UIState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIState"/> class.
        /// </summary>
        public UIState()
        {
            SelectedItems = new List<string>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the main window is visible.
        /// </summary>
        public bool IsMainWindowVisible { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the About dialog is visible.
        /// </summary>
        public bool ShowAboutDialog { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the Install UETools dialog is visible.
        /// </summary>
        public bool ShowInstallUEToolsDialog { get; set; } = false;

        /// <summary>
        /// Gets or sets the list of selected items.
        /// </summary>
        public List<string> SelectedItems { get; }

        /// <summary>
        /// Gets or sets the search query string.
        /// </summary>
        public string SearchQuery { get; set; } = string.Empty;
    }
}
