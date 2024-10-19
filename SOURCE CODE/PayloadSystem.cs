using System;
using static Windows.WinApi;
using System.Threading;
using System.IO;
using System.Linq;

namespace Puspula
{
    public class PayloadSystem
    {
        public static void MoveMouse()
        {

            int shakeAmount = 10;

            while (true)
            {
                POINT currentPos;
                GetCursorPos(out currentPos);

                Random rand = new Random();
                int offsetX = rand.Next(-shakeAmount, shakeAmount);
                int offsetY = rand.Next(-shakeAmount, shakeAmount);

                SetCursorPos(currentPos.X + offsetX, currentPos.Y + offsetY);

                Thread.Sleep(1);
            }
        }

        public static void PressKey(byte key, byte key2, byte key3)
        {
            while(true)
            {
                keybd_event(key, 0, 0, UIntPtr.Zero);

                keybd_event(key2, 0, 0, UIntPtr.Zero);

                keybd_event(key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);

                keybd_event(key2, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);

                Thread.Sleep(1000 * 5);
                keybd_event(key3, 0, 0, UIntPtr.Zero);
                keybd_event(key3, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            }
        }

        public static void PressKeySpeed(byte key, byte key2, byte key3)
        {
            while (true)
            {
                keybd_event(key, 0, 0, UIntPtr.Zero);

                keybd_event(key2, 0, 0, UIntPtr.Zero);

                keybd_event(key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);

                keybd_event(key2, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);

                Thread.Sleep(500);
                keybd_event(key3, 0, 0, UIntPtr.Zero);
                keybd_event(key3, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            }
        }





    }
}
