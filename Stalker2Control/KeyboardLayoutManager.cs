using Serilog;
using Stalker2Control.Configuration;

namespace Stalker2Control
{
    public static class KeyboardLayoutManager
    {
        public static void CheckAndSwitchToEnglishLayout()
        {
            try
            {
                IntPtr hWnd = WindowsApiManager.GetForegroundWindow();
                IntPtr currentLayout = WindowsApiManager.GetKeyboardLayout(0);

                Log.Information($"Current keyboard layout: {currentLayout}");

                IntPtr englishLayout = new IntPtr(Convert.ToInt64(AppConfiguration.ENGLISH_LAYOUT, 16));

                if (currentLayout != englishLayout)
                {
                    Log.Information("Switching to English layout.");

                    WindowsApiManager.LoadKeyboardLayout(AppConfiguration.ENGLISH_LAYOUT, WindowsApiManager.KLF_ACTIVATE);
                    bool result = WindowsApiManager.PostMessage(hWnd, WindowsApiManager.WM_INPUTLANGCHANGEREQUEST, IntPtr.Zero, englishLayout);

                    if (result)
                    {
                        Log.Information("Successfully switched to English layout.");
                    }
                    else
                    {
                        Log.Error("Failed to post message to switch to English layout.");
                    }
                }
                else
                {
                    Log.Information("Already using the English layout.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while trying to switch to the English layout.");
            }
        }
    }
}
