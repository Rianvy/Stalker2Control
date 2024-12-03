using System.Diagnostics;
using System.Numerics;
using ImGuiNET;
using ClickableTransparentOverlay;
using Microsoft.Extensions.Logging;
using Serilog;
using static Stalker2Control.WindowsApiManager;
using Stalker2Control.GameManagement.Items;
using Stalker2Control.GameManagement.Locations;
using Stalker2Control.Configuration;
using Stalker2Control.GameManagement;
using Stalker2Control.Render;

namespace Stalker2Control
{
    /// <summary>
    /// Main application class with improved UI and game control logic
    /// </summary>
    public class Stalker2ControlApp : Overlay
    {
        private readonly GameCommandExecutor _commandExecutor;
        private readonly GameWindowManager _gameManagement;
        private readonly ILogger<Stalker2ControlApp> _logger;
        private readonly ControlSettings _controlSettings;
        private readonly AppSettings _appSettings;
        private readonly UIState _uiState;
        private readonly NotificationRenderer _notificationRenderer;

        //Items
        private readonly WeaponCategoriesItems _weaponCategoriesItems;
        private readonly AmmoItems _ammoItems;
        private readonly ArmorItems _armorItems;
        private readonly HelmetAndMaskItems _helmetAndMaskItems;
        private readonly DetectorsItems _detectorsItems;
        private readonly ArtifactItems _artifactItems;
        private readonly ConsumableItems _consumableItems;
        private readonly KeyItems _keyItems;
        private readonly QuestItems _questItems;
        private readonly BlueprintItems _blueprintItems;


        public Stalker2ControlApp(
            GameCommandExecutor commandExecutor,
            GameWindowManager gameWindowManager,
            ControlSettings controlSettings,
            AppSettings appSettings,
            UIState uIState,
            ILogger<Stalker2ControlApp> logger) : base(GetScreenWidth(), GetScreenHeight()){
            _commandExecutor = commandExecutor;
            _gameManagement = gameWindowManager;
            _logger = logger;
            _controlSettings = controlSettings;
            _appSettings= appSettings;
            _uiState = uIState;
            _notificationRenderer = new NotificationRenderer();

            //Items
            _weaponCategoriesItems = new WeaponCategoriesItems();
            _ammoItems = new AmmoItems();
            _armorItems = new ArmorItems();
            _helmetAndMaskItems = new HelmetAndMaskItems();
            _detectorsItems = new DetectorsItems();
            _artifactItems = new ArtifactItems();
            _consumableItems = new ConsumableItems();
            _keyItems = new KeyItems();
            _questItems = new QuestItems();
            _blueprintItems = new BlueprintItems();
        }

        private void HandleToggleWindow()
        {
            if (GetAsyncKeyState(0x24) < 0)
            {
                _uiState.IsMainWindowVisible = !_uiState.IsMainWindowVisible;
                Thread.Sleep(200);
            }
        }

        protected override void Render()
        {
            try
            {
                HandleToggleWindow();

                if (_uiState.IsMainWindowVisible)
                {
                    RenderMainWindow();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Rendering error");
            }
        }

        private void RenderMainWindow()
        {
            Vector2 displaySize = ImGui.GetIO().DisplaySize;
            Vector2 windowPos = new Vector2(displaySize.X, 0);
            Vector2 windowPivot = new Vector2(1.0f, 0.0f);

            ImGui.SetNextWindowPos(windowPos, ImGuiCond.FirstUseEver, windowPivot);
            ImGui.SetNextWindowSizeConstraints(new Vector2(600, 500), new Vector2(displaySize.X, displaySize.Y));
            ImGui.SetWindowSize(new Vector2(500, 500));

            if (!ImGui.Begin($"{_appSettings.NameApp}",
                ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoTitleBar))
            {
                ImGui.End();
                return;
            }

            RenderMenuBar();
            RenderMainTabs();

            ImGui.End();
            _notificationRenderer.RenderNotification();
            RenderDialogs();
        }
        private void RenderMainTabs()
        {
            if (ImGui.BeginTabBar("MainTabs"))
            {
                RenderMainControlTab();
                RenderItemSpawningTab();
                RenderTeleportTab();
                RenderPasswordTab();
                ImGui.EndTabBar();
            }
        }

        private void RenderMainControlTab()
        {
            if (ImGui.BeginTabItem("Main Controls"))
            {
                RenderGodModeSection();
                RenderMoneySection();
                RenderNoClipSection();
                RenderGameTimeSpeedSection();
                RenderForceWeatherSection();
                RenderALifeSection();
                RenderStopFollowingSection();
                RenderSpawnDeadNpc();
                RenderAddAllNotesSection();
                RenderSetWeatherTimeSection();
                RenderKillNPCSection();

                ImGui.EndTabItem();
            }
        }

        private void RenderTeleportTab()
        {
            if (ImGui.BeginTabItem("Teleport"))
            {
                RenderTeleport();

                ImGui.EndTabItem();
            }
        }

        private void RenderItemSpawningTab()
        {
            if (ImGui.BeginTabItem("Item Spawning"))
            {
                RenderSpawnTab();

                ImGui.EndTabItem();
            }
        }

        private void RenderPasswordTab()
        {
            if (ImGui.BeginTabItem("Passwords"))
            {
                RenderCodeTable();

                ImGui.EndTabItem();
            }
        }

        #region  Render Menu Bar
        private void RenderMenuBar()
        {
            if (ImGui.BeginMenuBar())
            {
                RenderFileMenu();
                RenderHelpMenu();
                RenderGameStatus();
                ImGui.EndMenuBar();
            }
        }

        private void RenderFileMenu()
        {
            if (ImGui.BeginMenu("File"))
            {
                //if (ImGui.MenuItem("Install UETools"))
                //{
                //    _uiState.ShowInstallUEToolsDialog = true;
                //}
                if (ImGui.MenuItem("Exit"))
                {
                    Environment.Exit(0);
                }
                ImGui.EndMenu();
            }
        }

        private void RenderHelpMenu()
        {
            if (ImGui.BeginMenu("Help"))
            {
                if (ImGui.MenuItem("About"))
                {
                    _uiState.ShowAboutDialog = true;
                }
                ImGui.EndMenu();
            }
        }

        private void RenderGameStatus()
        {
            if (_gameManagement != null)
            {
                bool isGameRunning = _gameManagement.IsGameRunning();

                string gameStatusIcon = isGameRunning ? "Game Status: Running" : "Game Status: Not Running";

                Vector4 color = isGameRunning ? new Vector4(0.0f, 1.0f, 0.0f, 1.0f) : new Vector4(1.0f, 0.0f, 0.0f, 1.0f);

                ImGui.TextColored(color, gameStatusIcon);
            }
        }
        #endregion

        #region Render Dialogs
        private void RenderDialogs()
        {
            if (_uiState.ShowAboutDialog)
            {
                RenderAboutDialog();
            }
            if (_uiState.ShowInstallUEToolsDialog)
            {
                RenderInstallUEToolsDialog();
            }
        }

        private void RenderAboutDialog()
        {
            bool showAboutDialog = _uiState.ShowAboutDialog;

            ImGui.OpenPopup($"About {_appSettings.NameApp}");
            if (ImGui.BeginPopupModal($"About {_appSettings.NameApp}", ref showAboutDialog, ImGuiWindowFlags.AlwaysAutoResize))
            {
                ImGui.Text($"{_appSettings.NameApp}");
                ImGui.Text($"Version {_appSettings.Version}");
                ImGui.Separator();
                ImGui.Text("A versatile tool for S.T.A.L.K.E.R. 2, allowing you to control the game: item spawning, god mode activation, noclip, time acceleration, and more.");
                ImGui.Text("Developed by [Rianvy].");
                ImGui.Separator();

                if (ImGui.Button($"Open GitHub Repository {_appSettings.NameApp}"))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = _appSettings.RepositoryUrl,
                        UseShellExecute = true
                    });
                }

                ImGui.EndPopup();
            }

            _uiState.ShowAboutDialog = showAboutDialog;
        }

        private void RenderInstallUEToolsDialog() { 
            bool showInstallUEToolsDialog = _uiState.ShowInstallUEToolsDialog; 

            ImGui.OpenPopup($"Install UETools"); 

            if (ImGui.BeginPopupModal("Install UETools", ref showInstallUEToolsDialog, ImGuiWindowFlags.AlwaysAutoResize)) { 
              
                ImGui.EndPopup();
            } 
            _uiState.ShowInstallUEToolsDialog = showInstallUEToolsDialog;
        }

        #endregion

        #region Tabs

        #region Render Main Control Tab

        private void RenderGodModeSection()
        {
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "God Mode");
            ImGui.SameLine();
            ImGui.TextDisabled("(?)");
            if (ImGui.IsItemHovered())
                ImGui.SetTooltip("This feature enables invincibility for the player.");
            ImGui.Separator();

            
            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (ImGui.Button(_controlSettings.IsGodModeEnabled ? "Disable God Mode" : "Enable God Mode", new Vector2(ImGui.GetWindowWidth() - 15, 0)))
            {
                    _controlSettings.IsGodModeEnabled = !_controlSettings.IsGodModeEnabled;
                    _commandExecutor.ExecuteGameCommand("UETools_God");
            }
            ImGui.EndDisabled();

            ImGui.Spacing();
        }

        private void RenderMoneySection()
        {
            int tempMoney = _controlSettings.Money;
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Money");
            ImGui.SameLine();
            ImGui.TextDisabled("(?)");
            if (ImGui.IsItemHovered())
                ImGui.SetTooltip("Get the desired amount of coupons (money).");
            ImGui.Separator();
            
            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (ImGui.DragInt("##moneyInput", ref tempMoney, 1000, 0, int.MaxValue, "%d", ImGuiSliderFlags.AlwaysClamp))
            {
                _controlSettings.Money = tempMoney;
            }
            ImGui.SameLine();
            if (ImGui.Button("Add Money"))
            {
                _commandExecutor.ExecuteGameCommand($"XAddMoneyToPlayer {_controlSettings.Money}");
            }
            ImGui.EndDisabled();
            ImGui.Spacing();
        }

        private void RenderNoClipSection()
        {
            int tempClipSpeed = _controlSettings.ClipSpeed;
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "NoClip Mode");
            ImGui.SameLine();
            ImGui.TextDisabled("(?)");
            if (ImGui.IsItemHovered())
                ImGui.SetTooltip("A way to move between levels or pass impassable objects in the game.");
            ImGui.Separator();

            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (_controlSettings.IsNoClipEnabled)
                ImGui.BeginDisabled();

            if (ImGui.SliderInt("##clipSpeed", ref tempClipSpeed, 1000, 10000, $"Speed: {tempClipSpeed}", ImGuiSliderFlags.AlwaysClamp))
            {
                _controlSettings.ClipSpeed = tempClipSpeed;
            }
            
            if (_controlSettings.IsNoClipEnabled)
                ImGui.EndDisabled();

            ImGui.SameLine();

            if (ImGui.Button(_controlSettings.IsNoClipEnabled ? "Disable NoClip" : "Enable NoClip"))
            {
                _controlSettings.IsNoClipEnabled = !_controlSettings.IsNoClipEnabled;
                _commandExecutor.ExecuteGameCommand(
                    _controlSettings.IsNoClipEnabled
                    ? $"XSetNoClipGSC 1 {_controlSettings.ClipSpeed}"
                    : "XSetNoClipGSC 0");
            }
            ImGui.EndDisabled();
            ImGui.Spacing();

        }

        private void RenderGameTimeSpeedSection()
        {
            var tempTimeSpeed = _controlSettings.TimeSpeed;

            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Game Time Speed");
            ImGui.Separator();

            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (_controlSettings.IsTimeSpeedEnabled)
                ImGui.BeginDisabled();

            if(ImGui.SliderInt("##timeSpeed", ref tempTimeSpeed, 3, 100, $"Speed: {tempTimeSpeed}", ImGuiSliderFlags.AlwaysClamp))
            {
                _controlSettings.TimeSpeed = tempTimeSpeed;
            }

            if (_controlSettings.IsTimeSpeedEnabled)
                ImGui.EndDisabled();

            ImGui.SameLine();

            if (ImGui.Button(_controlSettings.IsTimeSpeedEnabled ? "Disable TimeSpeed" : "Enable TimeSpeed"))
            {
                _controlSettings.IsTimeSpeedEnabled = !_controlSettings.IsTimeSpeedEnabled;
                _commandExecutor.ExecuteGameCommand(_controlSettings.IsTimeSpeedEnabled ? $"XSetTimeSpeed {_controlSettings.TimeSpeed}" : "XSetTimeSpeed 0"); //Fix
            }
            ImGui.EndDisabled();

            ImGui.Spacing();
        }

        private void RenderForceWeatherSection()
        {
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Force Weather");
            ImGui.Separator();

            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            var weatherTypes = Enum.GetNames(typeof(ControlSettings.WeatherTypes.Type));
            int currentWeather = (int)_controlSettings.SelectedWeather;

            ImGui.Combo("##Weather Type", ref currentWeather, weatherTypes, weatherTypes.Length);
            _controlSettings.SelectedWeather = (ControlSettings.WeatherTypes.Type)currentWeather;

            ImGui.SameLine();
            if (ImGui.Button("Update Weather"))
            {
                _commandExecutor.ExecuteGameCommand($"XForceWeather {currentWeather}");
            }
            ImGui.EndDisabled();

            ImGui.Spacing();
        }

        private void RenderALifeSection()
        {
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "ALife");
            ImGui.Separator();

            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (ImGui.Button(_controlSettings.IsALifeEnabled ? "Enable AI" : "Disable AI", new Vector2(ImGui.GetWindowWidth() - 15, 0)))
            {
                _controlSettings.IsALifeEnabled = !_controlSettings.IsALifeEnabled;
                _commandExecutor.ExecuteGameCommand(_controlSettings.IsALifeEnabled ? "XALifeDisable" : "XALifeEnable");
            }
            ImGui.EndDisabled();

            ImGui.Spacing();
        }

        private void RenderStopFollowingSection()
        {
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Stop Following");
            ImGui.Separator();

            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (ImGui.Button("Stop", new Vector2(ImGui.GetWindowWidth() - 15, 0)))
            {
                _commandExecutor.ExecuteGameCommand("StopFollowing");
            }
            ImGui.EndDisabled();

            ImGui.Spacing();
        }

        private void RenderSpawnDeadNpc()
        {
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Spawn Dead Npc");
            ImGui.Separator();

            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (ImGui.Button("Spawn Dead Npc with random loot", new Vector2(ImGui.GetWindowWidth() - 15, 0)))
            {
                _commandExecutor.ExecuteGameCommand("XSpawnDeadNpc");
            }
            ImGui.EndDisabled();

            ImGui.Spacing();
        }

        private void RenderAddAllNotesSection()
       {
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Get All Game Notes");
            ImGui.Separator();

            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (ImGui.Button("Get", new Vector2(ImGui.GetWindowWidth() - 15, 0)))
            {
                _commandExecutor.ExecuteGameCommand("XAddAllNotes");
            }
            ImGui.EndDisabled();
            ImGui.Spacing();
        }

        private void RenderSetWeatherTimeSection()
        {
            var tempHours = _controlSettings.WeatherTimeHours;
            var tempMinutes = _controlSettings.WeatherTimeMinutes;

            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Set Weather Time");
            ImGui.Separator();

            if (ImGui.CollapsingHeader("Weather Time Settings"))
            {
                ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
                if (ImGui.SliderInt("Hours", ref tempHours, 0, 23))
                {
                    _controlSettings.WeatherTimeHours = tempHours;
                }

                if(ImGui.SliderInt("Minutes", ref tempMinutes, 0, 59))
                {
                    _controlSettings.WeatherTimeMinutes = tempMinutes;
                }

                if (ImGui.Button("Set Time", new Vector2(ImGui.GetWindowWidth() - 25, 0)))
                {
                    _commandExecutor.ExecuteGameCommand($"XForceWeather {_controlSettings.WeatherTimeHours} {_controlSettings.WeatherTimeMinutes} 0");
                }
                ImGui.EndDisabled();

                ImGui.Spacing();
            }
        }

        private void RenderKillNPCSection()
        {
            var tempRadius = _controlSettings.KillNPCsRadius;
            var tempDistanceMin = _controlSettings.KillNPCsminDistance;
            var tempDistanceMax = _controlSettings. KillNPCsmaxDistance;

            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Kill NPCs in Radius");
            ImGui.SameLine();
            ImGui.TextDisabled("(?)");
            if (ImGui.IsItemHovered())
                ImGui.SetTooltip("Kill the entire entity around you, where 1000 is the radius and -100000 and 0 is the range in relation to the player.");
            ImGui.Separator();

            if (ImGui.CollapsingHeader("NPC Killing Settings"))
            {
                ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
                if (ImGui.SliderFloat("Radius", ref tempRadius, 0f, 5000f))
                {
                    _controlSettings.KillNPCsRadius = tempRadius;
                }
                if(ImGui.SliderFloat("Min Distance", ref tempDistanceMin, -100000f, 0f))
                {
                    _controlSettings.KillNPCsminDistance = tempDistanceMin;
                }
                if(ImGui.SliderFloat("Max Distance", ref tempDistanceMax, 0f, 100000f))
                {
                    _controlSettings.KillNPCsmaxDistance = tempDistanceMax;
                }

                if (ImGui.Button("Kill NPCs", new Vector2(ImGui.GetWindowWidth() - 25, 0)))
                {
                    _commandExecutor.ExecuteGameCommand($"XKillNPCInRadius {_controlSettings.KillNPCsRadius} {_controlSettings.KillNPCsminDistance} {_controlSettings.KillNPCsmaxDistance}");
                }
                ImGui.EndDisabled();

                ImGui.Spacing();
            }
        }
        #endregion

        #region Render Item Spawning Tab

        private void RenderSpawnTab()
        {
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Item Management");
            ImGui.Separator();

            string searchQuery = _uiState.SearchQuery;
            ImGui.SetNextItemWidth(ImGui.GetWindowWidth() - 80);
            if (ImGui.InputTextWithHint("##Search", "Search for items...", ref searchQuery, 256))
                _uiState.SearchQuery = searchQuery;

            ImGui.SameLine();
            if (ImGui.Button("Clear"))
                _uiState.SearchQuery = string.Empty;

            ImGui.Separator();

            ImGui.BeginChild("ItemsScrollArea", new Vector2(0, -65), ImGuiChildFlags.Border);
            if (ImGui.BeginTabBar("ItemsTabs", ImGuiTabBarFlags.FittingPolicyScroll))
            {
                RenderCategoryTab("Weapons", RenderWeaponsCategory);
                RenderCategoryTab("Ammo", () => RenderTreeNodeWithItems("Ammo", _ammoItems.AmmoDescriptions));
                RenderCategoryTab("Armor", () => RenderTreeNodeWithItems("Armor", _armorItems.ArmorDescriptions));
                RenderCategoryTab("Helmets & Masks", () => RenderTreeNodeWithItems("Helmets And Masks", _helmetAndMaskItems.HelmetsAndMasksDescriptions));
                RenderCategoryTab("Detectors", () => RenderTreeNodeWithItems("Detectors", _detectorsItems.DetectorsDescriptions));
                RenderCategoryTab("Artifacts", () => RenderTreeNodeWithItems("Artifacts", _artifactItems.ArtifactsDescriptions));
                RenderCategoryTab("Consumables", () => RenderTreeNodeWithItems("Consumables", _consumableItems.ConsumablesDescriptions));
                RenderCategoryTab("Keys", () => RenderTreeNodeWithItems("Keys", _keyItems.KeysDescriptions));
                RenderCategoryTab("Quest Items", () => RenderTreeNodeWithItems("Quest Items", _questItems.QuestsDescriptions));
                RenderCategoryTab("Blueprint", () => RenderTreeNodeWithItems("Blueprint", _blueprintItems.BlueprintsDescriptions));

                ImGui.EndTabBar();
            }
            ImGui.EndChild();

            float progress = _commandExecutor.GetProgress();
            ImGui.ProgressBar(progress, new Vector2(-1, 0), $"Spawning: {Math.Round(progress * 100, 1)}%");

            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.2f, 0.8f, 0.2f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(0.3f, 0.9f, 0.3f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(0.1f, 0.7f, 0.1f, 1.0f));
            ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2(0.5f, 0.5f));
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(20, 10));

            float buttonWidth = ImGui.GetWindowWidth();
            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());

            //if (ImGui.Button("Spawn", new Vector2(buttonWidth - 17, 0)))
            //{
            //    _commandExecutor.spawnCommandQueue.Clear();
            //    foreach (var item in _uiState.SelectedItems)
            //    {
            //        string command = _commandExecutor.GenerateSpawnCommand(item);
            //        _commandExecutor.spawnCommandQueue.Enqueue(command);
            //    }
            //    _uiState.SelectedItems.Clear();
            //    _commandExecutor.StartProcessingQueue();
            //}

            if (ImGui.Button("Spawn", new Vector2(buttonWidth - 17, 0)))
            {
                _commandExecutor.spawnCommandQueue.Clear();
                List<string> combinedCommands = new List<string>();

                foreach (var item in _uiState.SelectedItems)
                {
                    string command = _commandExecutor.GenerateSpawnCommand(item);

                    if (_commandExecutor.IsBlueprintOrAmmo(item))
                    {
                        combinedCommands.Add(command);
                    }
                    else
                    {
                        _commandExecutor.spawnCommandQueue.Enqueue(command);
                    }
                }

                if (combinedCommands.Count > 0)
                {
                    string combinedCommand = string.Join(" | ", combinedCommands);
                    _commandExecutor.spawnCommandQueue.Enqueue(combinedCommand);
                }

                _uiState.SelectedItems.Clear();
                _commandExecutor.StartProcessingQueue();
            }
            ImGui.EndDisabled();

            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor(3);
        }

        private void RenderItems(Dictionary<string, string> itemDescriptions, List<string> selectedItems)
        {
            var filteredItems = itemDescriptions
                .Where(a => a.Key.Contains(_uiState.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                            a.Value.Contains(_uiState.SearchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filteredItems.Count == 0)
            {
                ImGui.Text("No items found.");
                return;
            }

            foreach (var item in filteredItems)
            {
                bool isSelected = selectedItems.Contains(item.Key);
                if (ImGui.Checkbox(item.Key, ref isSelected))
                {
                    if (isSelected)
                        selectedItems.Add(item.Key);
                    else
                        selectedItems.Remove(item.Key);
                }

                ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(0.6f, 0.6f, 0.6f, 1.0f));
                ImGui.SameLine();
                ImGui.Text($" Description: {(string.IsNullOrEmpty(item.Value) ? "No description available" : item.Value)}");
                ImGui.PopStyleColor();
            }
        }

        private void RenderCategoryTab(string tabName, Action renderAction)
        {
            if (ImGui.BeginTabItem(tabName))
            {
                renderAction();
                ImGui.EndTabItem();
            }
        }

        private void RenderTreeNodeWithItems(string nodeName, Dictionary<string, string> itemDescriptions)
        {
            var filteredItems = itemDescriptions
                .Where(a => a.Key.Contains(_uiState.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                            a.Value.Contains(_uiState.SearchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

            int itemCount = filteredItems.Count;
            if (itemCount > 0)
            {
                ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
                if (ImGui.TreeNode($"{nodeName} ({itemCount})"))
                {
                    bool allSelected = filteredItems.All(item => _uiState.SelectedItems.Contains(item.Key));
                    bool selectAll = allSelected;

                    if (ImGui.Checkbox("Select all", ref selectAll))
                    {
                        if (selectAll)
                        {
                            foreach (var item in filteredItems)
                            {
                                if (!_uiState.SelectedItems.Contains(item.Key))
                                {
                                    _uiState.SelectedItems.Add(item.Key);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in filteredItems)
                            {
                                _uiState.SelectedItems.Remove(item.Key);
                            }
                        }
                    }

                    RenderItems(itemDescriptions, _uiState.SelectedItems);
                    ImGui.TreePop();
                }
                ImGui.EndDisabled();
            }
        }

        private void RenderWeaponsCategory()
        {
            if (ImGui.TreeNode("Weapons"))
            {
                RenderTreeNodeWithItems("Special Weapons", _weaponCategoriesItems.SpecialWeaponsDescriptions);
                RenderTreeNodeWithItems("Hunting Rifles", _weaponCategoriesItems.HuntingRiflesDescriptions);
                RenderTreeNodeWithItems("Pistols", _weaponCategoriesItems.PistolsDescriptions);
                RenderTreeNodeWithItems("SMGs", _weaponCategoriesItems.SmgsDescriptions);
                RenderTreeNodeWithItems("Machine Guns", _weaponCategoriesItems.MachineGunsDescriptions);
                RenderTreeNodeWithItems("Sniper Rifles", _weaponCategoriesItems.SniperRiflesDescriptions);
                RenderTreeNodeWithItems("Assault Rifles", _weaponCategoriesItems.AssaultRiflesDescriptions);
                RenderTreeNodeWithItems("Unique Weapons", _weaponCategoriesItems.UniqueWeaponsDescriptions);
                RenderTreeNodeWithItems("Grenades", _weaponCategoriesItems.GrenadesDescriptions);
                //RenderTreeNodeWithItems("DLC Weapons", _weaponCategoriesItems.DlcWeaponsDescriptions);

                ImGui.TreePop();
            }
        }
        #endregion

        #region Render Teleport Tab
        public void RenderTeleport()
        {
            var _teleportLocations = new TeleportLocation();
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Teleport");
            ImGui.Separator();

            var locationNames = _teleportLocations.GetLocationNames();
            List<string> filteredLocations = locationNames;


            ImGui.BeginChild("ItemsScrollArea", new System.Numerics.Vector2(0, -35), ImGuiChildFlags.Border);
            foreach (var location in filteredLocations)
            {
                bool isSelected = _controlSettings.SelectedLocation == location;
                if (ImGui.Selectable(location, isSelected))
                {
                    _controlSettings.SelectedLocation = location;
                }
            }
            ImGui.EndChild();

            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.2f, 0.8f, 0.2f, 1.0f)); // Green color
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(0.3f, 0.9f, 0.3f, 1.0f)); // Lighter green on hover
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(0.1f, 0.7f, 0.1f, 1.0f)); // Darker green when active

            ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2(0.5f, 0.5f)); // Center text alignment
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(20, 10)); // Add padding for larger button size

            float buttonWidth = ImGui.GetWindowWidth();
            ImGui.BeginDisabled(!_gameManagement.IsGameRunning());
            if (ImGui.Button($"Teleport to {_controlSettings.SelectedLocation}", new Vector2(buttonWidth - 30, 0)))
            {
                if (_controlSettings.SelectedLocation != string.Empty)
                {
                    string coordinates = _teleportLocations.GetLocationCoordinates(_controlSettings.SelectedLocation);
                    _commandExecutor.ExecuteGameCommand(coordinates);
                    _logger.LogInformation($"Teleporting to coordinates: {coordinates}");
                }
                else
                {
                    _logger.LogWarning("No location selected!");
                    _notificationRenderer.ShowNotification("No location selected!", NotificationRenderer.NotificationType.Info);
                }
            }
            ImGui.EndDisabled();


            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor(3);
        }
        #endregion

        #region Render Password Tab
        private void RenderCodeTable()
        {
            ImGui.Spacing();
            ImGui.TextColored(new Vector4(0.8f, 0.8f, 0.3f, 1f), "Passwords for doors, safes and locks");
            ImGui.Separator();

            if (ImGui.BeginTable("CodesTable", 3, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
            {
                // Headers
                ImGui.TableSetupColumn("Place");
                ImGui.TableSetupColumn("Location");
                ImGui.TableSetupColumn("Code");
                ImGui.TableHeadersRow();

                // Data
                AddRow("Safe in the Pioneers camp 'Fairytale'", "Burnt Forest", "1861");
                AddRow("Door to Kaimanov's office in Laboratory X15 at 'Orbita' Station", "Burnt Forest", "1995");
                AddRow("Laboratory X15 at 'Orbita' Station", "Burnt Forest", "4221");
                AddRow("Container with zombies", "Cooling Towers", "2777");
                AddRow("Door at the checkpoint of the Waste Processing Station", "Wild Island", "2711");
                AddRow("Monolith's stash at the Waste Processing Station", "Wild Island", "0505");
                AddRow("Hatch at the 'Duga'", "Duga", "2110");
                AddRow("Door at the Service Station", "Zaton", "2468");
                AddRow("Service Station Railway", "Zaton", "2468");
                AddRow("Scientist's stash near the Hydrodynamics Laboratory", "Zaton", "4824");
                AddRow("Door in the tunnel (quest 'Light at the end of the tunnel')", "Cordon", "1268");
                AddRow("Door at the Radar", "Malachite", "1287975");
                AddRow("Collector 'Sphere' (quest 'Needle in a haystack')", "Small Zone", "2765");
                AddRow("Doctor Dalin's safe (quest 'Long-awaited visit')", "NIIChAZ", "2006");
                AddRow("Journalist's stash", "Pripyat", "2021");
                AddRow("Safe at the SAM site 'Volkhov'", "Rostok", "195726");
                AddRow("Safe near the Electrofield", "Garbage", "1708");
                AddRow("Codes for doors at the Factory, Laboratory X18 (quest 'Answers are expensive')", "Garbage", "2605 and 2603");
                AddRow("Door at the Chemical Plant arsenal 'Varta'", "Chemical Plant", "8506");
                AddRow("Door at the Military Warehouses", "Chemical Plant", "0690");
                AddRow("Code to the underground laboratory of the CMD 'Luch' Plant (quest 'Dawn of a new day')", "Chemical Plant", "1976");
                AddRow("Safe at the Selector Tower", "Cement Plant", "030794");
                AddRow("Basement in Lesnoy", "Yanov", "240983");
                AddRow("Stash under the dam 'Yantar'", "Yantar", "5578");

                ImGui.EndTable();
            }
        }
        #endregion

        #endregion

        private void AddRow(string place, string location, string code)
        {
            ImGui.TableNextRow();

            ImGui.TableNextColumn();
            ImGui.Text(place);
            if (ImGui.IsItemHovered())
            {
                ImGui.SetTooltip(place);
            }

            ImGui.TableNextColumn();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1.0f, 1.0f, 0.0f, 1.0f)); // Yellow
            ImGui.Text(location);
            ImGui.PopStyleColor();

            ImGui.TableNextColumn();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(0.0f, 1.0f, 0.0f, 1.0f)); // Green
            ImGui.Text(code);
            ImGui.PopStyleColor();
        }

        public static async Task Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/stalker2control.log")
                .CreateLogger();

            try
            {
                var app = ConfigureServices();
                await app.Start();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application startup failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static Stalker2ControlApp ConfigureServices()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
                builder.AddSerilog());

            var windowsApiManager = new WindowsApiManager(
                loggerFactory.CreateLogger<WindowsApiManager>());

            var gameWindowManager = new GameWindowManager(
                loggerFactory.CreateLogger<GameWindowManager>());

            var commandExecutor = new GameCommandExecutor(
                loggerFactory.CreateLogger<GameCommandExecutor>(),
                windowsApiManager,
                gameWindowManager);

            var controlSettings = new ControlSettings();

            var appSettings = new AppSettings();

            var uIState = new UIState();

            return new Stalker2ControlApp(
                commandExecutor,
                gameWindowManager,
                controlSettings,
                appSettings,
                uIState,
                loggerFactory.CreateLogger<Stalker2ControlApp>());
        }
    }
}