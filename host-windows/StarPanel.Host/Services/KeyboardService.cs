using System.Runtime.InteropServices;

namespace StarPanel.Host.Services;

public class KeyboardService
{
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    private const uint KEYEVENTF_KEYUP = 0x0002;

    private static readonly Dictionary<string, byte> KeyMap = new()
    {
        { "A", 0x41 }, { "B", 0x42 }, { "C", 0x43 }, { "D", 0x44 },
        { "E", 0x45 }, { "F", 0x46 }, { "G", 0x47 }, { "H", 0x48 },
        { "I", 0x49 }, { "J", 0x4A }, { "K", 0x4B }, { "L", 0x4C },
        { "M", 0x4D }, { "N", 0x4E }, { "O", 0x4F }, { "P", 0x50 },
        { "Q", 0x51 }, { "R", 0x52 }, { "S", 0x53 }, { "T", 0x54 },
        { "U", 0x55 }, { "V", 0x56 }, { "W", 0x57 }, { "X", 0x58 },
        { "Y", 0x59 }, { "Z", 0x5A },
        { "Space", 0x20 },
        { "Enter", 0x0D },
        { "Left Shift", 0xA0 },
        { "Right Shift", 0xA1 },
        { "Left Control", 0xA2 },
        { "Right Control", 0xA3 },
        { "Left Alt", 0xA4 },
        { "Right Alt", 0xA5 },
        { "Tab", 0x09 },
        { "Escape", 0x1B },
        { "1", 0x31 }, { "2", 0x32 }, { "3", 0x33 }, { "4", 0x34 },
        { "5", 0x35 }, { "6", 0x36 }, { "7", 0x37 }, { "8", 0x38 },
        { "9", 0x39 }, { "0", 0x30 }
    };

    public void SendKey(string key, string action)
    {
        if (!KeyMap.TryGetValue(key, out var vkCode))
        {
            Console.WriteLine($"Warning: Unknown key '{key}'");
            return;
        }

        switch (action.ToLower())
        {
            case "down":
                keybd_event(vkCode, 0, 0, UIntPtr.Zero);
                break;
            case "up":
                keybd_event(vkCode, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "tap":
                keybd_event(vkCode, 0, 0, UIntPtr.Zero);
                Thread.Sleep(10);
                keybd_event(vkCode, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
        }
    }
}
