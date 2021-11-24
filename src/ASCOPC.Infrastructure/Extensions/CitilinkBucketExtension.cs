using System.Runtime.InteropServices;

namespace ASCOPC.Infrastructure.Extensions
{
    /// <summary>
    /// This class provides methods for working with the keyboard, 
    /// which in the final operations should give us the closure of the tab when sending an item to orders.
    /// </summary>
    public class CitilinkBucketExtension
    {
        [DllImportAttribute("user32.dll", EntryPoint = "SetForegroundWindow")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow([InAttribute()] IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public static void Send(byte KeyCode, bool Ctrl, bool Alt, bool Shift, bool Win)
        {
            byte Keycode = (byte)KeyCode;

            uint KEYEVENTF_KEYUP = 2;
            byte VK_CONTROL = 0x11;
            byte VK_MENU = 0x12;
            byte VK_LSHIFT = 0xA0;
            byte VK_LWIN = 0x5B;

            if (Ctrl)
                keybd_event(VK_CONTROL, 0, 0, 0);
            if (Alt)
                keybd_event(VK_MENU, 0, 0, 0);
            if (Shift)
                keybd_event(VK_LSHIFT, 0, 0, 0);
            if (Win)
                keybd_event(VK_LWIN, 0, 0, 0);

            //true keycode
            keybd_event(Keycode, 0, 0, 0); //down
            keybd_event(Keycode, 0, KEYEVENTF_KEYUP, 0); //up

            if (Ctrl)
                keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
            if (Alt)
                keybd_event(VK_MENU, 0, KEYEVENTF_KEYUP, 0);
            if (Shift)
                keybd_event(VK_LSHIFT, 0, KEYEVENTF_KEYUP, 0);
            if (Win)
                keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);

        }
    }
}
