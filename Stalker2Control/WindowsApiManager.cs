using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace Stalker2Control
{
    /// <summary>
    /// Manages Windows API interactions for the application
    /// </summary>
    public class WindowsApiManager
    {
        private readonly ILogger<WindowsApiManager> _logger;

        public WindowsApiManager(ILogger<WindowsApiManager> logger)
        {
            _logger = logger;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern long LoadKeyboardLayout(string pwszKLID, uint Flags);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool CloseClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool EmptyClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
       
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
        public static int GetScreenWidth() => GetSystemMetrics(0);
        public static int GetScreenHeight() => GetSystemMetrics(1);

        private const uint CF_UNICODETEXT = 13;
        public const uint KLF_ACTIVATE = 1;
        public const uint WM_INPUTLANGCHANGEREQUEST = 0x0050;

        public void SendKeyPress(Keys key)
        {
            INPUT[] inputs = new INPUT[2];

            inputs[0].type = (uint)InputType.INPUT_KEYBOARD;
            inputs[0].U.ki.wVk = (ushort)key;

            inputs[1].type = (uint)InputType.INPUT_KEYBOARD;
            inputs[1].U.ki.wVk = (ushort)key;
            inputs[1].U.ki.dwFlags = (uint)KeyEventF.KEYEVENTF_KEYUP;

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        public void CopyTextToClipboard(string text)
        {
            if (!OpenClipboard(IntPtr.Zero))
            {
                _logger.LogError("Failed to open clipboard.");
                throw new Exception("Failed to open clipboard");
            }

            try
            {
                EmptyClipboard();
                IntPtr hGlobal = Marshal.StringToHGlobalUni(text);
                _logger.LogInformation("Allocated global memory for the text.");
                if (SetClipboardData(CF_UNICODETEXT, hGlobal) == IntPtr.Zero)
                {
                    _logger.LogError("Failed to set clipboard data.");
                    throw new Exception("Failed to set clipboard data");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while copying text to clipboard.");
                throw;
            }
            finally
            {
                CloseClipboard();
                _logger.LogInformation("Closed clipboard.");
            }
        }

        public void SendPasteCommand()
        {
            SendKeyDown(Keys.ControlKey);
            SendKey(Keys.V);
            SendKeyUp(Keys.ControlKey);
        }

        public void SendKey(Keys key)
        {
            INPUT[] inputs = new INPUT[2];

            inputs[0].type = (uint)InputType.INPUT_KEYBOARD;
            inputs[0].U.ki.wVk = (ushort)key;

            inputs[1].type = (uint)InputType.INPUT_KEYBOARD;
            inputs[1].U.ki.wVk = (ushort)key;
            inputs[1].U.ki.dwFlags = (uint)KeyEventF.KEYEVENTF_KEYUP;

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        private void SendKeyDown(Keys key)
        {
            INPUT[] inputs = new INPUT[1];

            inputs[0].type = (uint)InputType.INPUT_KEYBOARD;
            inputs[0].U.ki.wVk = (ushort)key;

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        private void SendKeyUp(Keys key)
        {
            INPUT[] inputs = new INPUT[1];

            inputs[0].type = (uint)InputType.INPUT_KEYBOARD;
            inputs[0].U.ki.wVk = (ushort)key;
            inputs[0].U.ki.dwFlags = (uint)KeyEventF.KEYEVENTF_KEYUP;

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint type;
            public InputUnion U;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        public enum InputType : uint
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2
        }

        public enum KeyEventF : uint
        {
            KEYEVENTF_KEYDOWN = 0x0000,
            KEYEVENTF_KEYUP = 0x0002
        }

        public enum Keys : ushort
        {
            Oemtilde = 0xC0,
            Enter = 0x0D,
            ShiftKey = 0x10,
            ControlKey = 0x11,
            V = 0x56
        }
    }
}
