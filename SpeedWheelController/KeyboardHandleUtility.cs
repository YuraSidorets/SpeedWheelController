using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SpeedWheelController
{
    public static class KeyboardHandleUtility
    {
        const UInt32 WM_KEYDOWN = 0x0100;
        const int VK_RETURN = 0x0D;

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [STAThread]
        public static void SendKey(Process process, int key)
        {
            PostMessage(process.MainWindowHandle, WM_KEYDOWN, key, 0);
        }
    }
}
