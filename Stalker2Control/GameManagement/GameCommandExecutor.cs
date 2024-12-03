using Microsoft.Extensions.Logging;
using Serilog;
using Stalker2Control.GameManagement.Items;
using Stalker2Control.GameManagement;
using Stalker2Control;

public class GameCommandExecutor
{
    private readonly ILogger<GameCommandExecutor> _logger;
    private readonly WindowsApiManager _windowsApiManager;
    private readonly GameWindowManager _gameWindowManager;

    // Items
    private readonly BlueprintItems _blueprintItems;
    private readonly AmmoItems _ammoItems;

    public Queue<string> spawnCommandQueue = new Queue<string>();
    private int totalCommands;
    private int processedCommands;

    public GameCommandExecutor(
        ILogger<GameCommandExecutor> logger,
        WindowsApiManager windowsApiManager,
        GameWindowManager gameWindowManager)
    {
        _logger = logger;
        _windowsApiManager = windowsApiManager;
        _gameWindowManager = gameWindowManager;

        // Items
        _blueprintItems = new BlueprintItems();
        _ammoItems = new AmmoItems();
    }

    public bool ExecuteGameCommand(string command)
    {
        try
        {
            if (!_gameWindowManager.ActivateGameWindow())
                return false;

            KeyboardLayoutManager.CheckAndSwitchToEnglishLayout();

            Thread.Sleep(100);
            _windowsApiManager.SendKeyPress(WindowsApiManager.Keys.Oemtilde);
            Thread.Sleep(100);

            _windowsApiManager.CopyTextToClipboard(command);
            _windowsApiManager.SendPasteCommand();
            Thread.Sleep(100);
            _windowsApiManager.SendKey(WindowsApiManager.Keys.Enter);

            _logger.LogInformation($"Executed command: {command}");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing game command");
            return false;
        }
    }

    public string GenerateSpawnCommand(string item)
    {
        var category = DetermineItemCategory(item);
        return category switch
        {
            ItemCategory.Blueprint or ItemCategory.Ammo => $"XCreateItemInInventoryByID {item}",
            _ => $"XSpawnItemNearPlayerBySID {item}"
        };
    }

    public bool IsBlueprintOrAmmo(string item)
    {
        return DetermineItemCategory(item) is ItemCategory.Blueprint or ItemCategory.Ammo;
    }

    private ItemCategory DetermineItemCategory(string item)
    {
        if (_blueprintItems.BlueprintsDescriptions.ContainsKey(item))
        {
            return ItemCategory.Blueprint;
        }

        if (_ammoItems.AmmoDescriptions.ContainsKey(item))
        {
            return ItemCategory.Ammo;
        }

        return ItemCategory.Other;
    }

    public void StartProcessingQueue()
    {
        totalCommands = spawnCommandQueue.Count;
        processedCommands = 0;

        KeyboardLayoutManager.CheckAndSwitchToEnglishLayout();

        while (spawnCommandQueue.Count > 0)
        {
            string command = spawnCommandQueue.Dequeue();
            bool success = ExecuteGameCommand(command);
            if (success)
            {
                processedCommands++;
            }

            _logger.LogInformation($"Processed {processedCommands}/{totalCommands} commands.");
            Thread.Sleep(500);
        }

        Log.Information("All spawn commands have been processed.");
    }

    public float GetProgress()
    {
        if (totalCommands == 0) return 0;
        return (float)processedCommands / totalCommands;
    }
}

public enum ItemCategory
{
    Blueprint,
    Ammo,
    Other
}
