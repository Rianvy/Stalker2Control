using Microsoft.Extensions.Logging;
using Stalker2Control.Configuration;
using System.Diagnostics;
using static Stalker2Control.WindowsApiManager;

namespace Stalker2Control.GameManagement
{
    public class GameWindowManager
    {
        private readonly ILogger<GameWindowManager> _logger;

        public GameWindowManager(ILogger<GameWindowManager> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Checks if the game is currently running.
        /// </summary>
        /// <returns>true if the game is running, false otherwise.</returns>
        public bool IsGameRunning()
        {
            try
            {
                var gameProcesses = Process.GetProcessesByName(AppConfiguration.GAME_PROCESS_NAME);
                return gameProcesses.Length > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if the game is running");
                return false;
            }
        }

        /// <summary>
        /// Attempts to activate the game window by restoring and bringing it to the foreground.
        /// </summary>
        /// <returns>true if the game window was successfully activated, false otherwise.</returns>
        public bool ActivateGameWindow()
        {
            try
            {
                var gameProcesses = Process.GetProcessesByName(AppConfiguration.GAME_PROCESS_NAME);
                if (gameProcesses.Length == 0)
                {
                    _logger.LogWarning("Game window not found.");
                    return false;
                }

                var process = gameProcesses[0];
                _logger.LogInformation("Found game process with ID {ProcessId}", process.Id);

                // Restores and brings the game window to the foreground
                ShowWindow(process.MainWindowHandle, AppConfiguration.WindowFlags.SW_RESTORE);
                SetForegroundWindow(process.MainWindowHandle);

                _logger.LogInformation("Successfully activated game window.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating game window");
                return false;
            }
        }
    }
}