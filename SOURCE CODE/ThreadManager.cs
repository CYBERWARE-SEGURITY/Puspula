using System.Threading;
using System.Windows.Forms;

namespace Puspula
{
    public class ThreadManager
    {
        private const byte VK_LWIN = 0x5B;
        private const byte VK_CAPITAL = 0x14;
        private const byte VK_TAB = 0x09;


        // FORMS STRANGE : D
        public static Thread StrangeBox = new Thread(() => Application.Run(new Strange()));


        //AUTOMATION PAYLOADS
        public static Thread winClick = new Thread(() => PayloadSystem.PressKey(VK_LWIN, 0, 0));
        public static Thread capsClick = new Thread(() => PayloadSystem.PressKeySpeed(VK_CAPITAL, 0, 0));
        public static Thread tabClick = new Thread(() => PayloadSystem.PressKeySpeed(VK_TAB, 0, 0));


        // BYTEBEATS
        public static Thread tbb1 = new Thread(ByteBeat.Bytebeat1);
        public static Thread tbb2 = new Thread(ByteBeat.Bytebeat2);
        public static Thread tbb3 = new Thread(ByteBeat.Bytebeat3);
        public static Thread tbb4 = new Thread(ByteBeat.Bytebeat4);
        public static Thread tbb5 = new Thread(ByteBeat.Bytebeat5);
        public static Thread tbb6 = new Thread(ByteBeat.Bytebeat6);
        public static Thread tbb7 = new Thread(ByteBeat.Bytebeat7);
        public static Thread tbb8 = new Thread(ByteBeat.Bytebeat8);
        public static Thread tbb9 = new Thread(ByteBeat.Bytebeat9);


        //GDIS
        public static Thread gd1 = new Thread(GdiPayload.Carga1);
        public static Thread gd2 = new Thread(GdiPayload.Carga2);
        public static Thread gd3 = new Thread(GdiPayload.Carga3);
        public static Thread gd4 = new Thread(GdiPayload.Carga4);
        public static Thread gd5 = new Thread(GdiPayload.Carga5);
        public static Thread gd6 = new Thread(GdiPayload.Carga6);
        public static Thread gd7 = new Thread(GdiPayload.Carga7);
        public static Thread gd8 = new Thread(GdiPayload.Carga8);
        public static Thread gd9 = new Thread(GdiPayload.Carga9);
        public static Thread gdiEND = new Thread(GdiPayload.END);


        // ICONS EFFECTS
        public static Thread gd1Mouse = new Thread(GdiPayload.MouseIcoError);
        public static Thread gd2Mouse = new Thread(GdiPayload.MouseIcoWarn);
        public static Thread gdSpawn1 = new Thread(GdiPayload.SpawnIcoWarn);
        public static Thread tsp1 = new Thread(PayloadSystem.MoveMouse);
    }
}
