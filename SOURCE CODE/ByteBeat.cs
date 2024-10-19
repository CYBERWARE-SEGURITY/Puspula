using System;
using System.Runtime.InteropServices;
using System.Threading;
using static Windows.WinApi;

namespace Puspula
{
    public class ByteBeat
    {
        public static void Bytebeat1()
        {
            IntPtr hWaveOut = IntPtr.Zero;

            wfx.wFormatTag = WAVE_FORMAT_PCM;
            wfx.nChannels = 1;
            wfx.nSamplesPerSec = 8000;
            wfx.nAvgBytesPerSec = 8000;
            wfx.nBlockAlign = 1;
            wfx.wBitsPerSample = 8;
            wfx.cbSize = 0;

            waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

            byte[] sbuffer = new byte[16000 * 60];

            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t * (t >> 8 * (int)(t >> 15 | t >> 8) & (2 | 5 * (t >> 9) >> (int)t | t >> 3)));
            }

            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

            try
            {
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                }
            }
            finally
            {
                handle.Free();
                waveOutClose(hWaveOut);
            }
        }

        public static void Bytebeat2()
        {
            for (; ; )
            {
                Random r = new Random();
                Console.Beep(r.Next(100, 3000), 100);
                Console.Beep(r.Next(37, 200), 100);
            }
        }

        public static void Bytebeat3()
        {
            IntPtr hWaveOut = IntPtr.Zero;

            wfx.wFormatTag = WAVE_FORMAT_PCM;
            wfx.nChannels = 1;
            wfx.nSamplesPerSec = 8000;
            wfx.nAvgBytesPerSec = 8000;
            wfx.nBlockAlign = 1;
            wfx.wBitsPerSample = 8;
            wfx.cbSize = 0;

            waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

            byte[] sbuffer = new byte[16000 * 60];

            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t * (t >> 2 | t >> 8) >> (int)(t >> 2));
            }

            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

            try
            {
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                }
            }
            finally
            {
                handle.Free();
                waveOutClose(hWaveOut);
            }
        }

        public static void Bytebeat4()
        {
            IntPtr hWaveOut = IntPtr.Zero;

            wfx.wFormatTag = WAVE_FORMAT_PCM;
            wfx.nChannels = 1;
            wfx.nSamplesPerSec = 8000;
            wfx.nAvgBytesPerSec = 8000;
            wfx.nBlockAlign = 1;
            wfx.wBitsPerSample = 8;
            wfx.cbSize = 0;

            waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

            byte[] sbuffer = new byte[16000 * 60];

            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)((int)t << ((int)t >> 1) % (1 << (7 * ((int)t >> 6 & (int)t >> 2 & 2) >> 3)) ^ ((int)t >> 5));
            }

            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

            try
            {
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                }
            }
            finally
            {
                handle.Free();
                waveOutClose(hWaveOut);
            }
        }


        public static void Bytebeat5()
        {
            IntPtr hWaveOut = IntPtr.Zero;

            wfx.wFormatTag = WAVE_FORMAT_PCM;
            wfx.nChannels = 1;
            wfx.nSamplesPerSec = 8000;
            wfx.nAvgBytesPerSec = 8000;
            wfx.nBlockAlign = 1;
            wfx.wBitsPerSample = 8;
            wfx.cbSize = 0;

            waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

            byte[] sbuffer = new byte[16000 * 60];

            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)((t >> (int)(t >> 10 & 31) & 50) + ((t & t >> 12) * t << 2) + 3e5 / (t % 16384));
            }

            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

            try
            {
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                }
            }
            finally
            {
                handle.Free();
                waveOutClose(hWaveOut);
            }
        }

        public static void Bytebeat6()
        {
            IntPtr hWaveOut = IntPtr.Zero;

            wfx.wFormatTag = WAVE_FORMAT_PCM;
            wfx.nChannels = 1;
            wfx.nSamplesPerSec = 8000;
            wfx.nAvgBytesPerSec = 8000;
            wfx.nBlockAlign = 1;
            wfx.wBitsPerSample = 8;
            wfx.cbSize = 0;

            waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

            byte[] sbuffer = new byte[16000 * 60];

            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)((t >> 3) ^ -(t << 2 & 11));
            }

            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

            try
            {
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                }
            }
            finally
            {
                handle.Free();
                waveOutClose(hWaveOut);
            }
        }

        public static void Bytebeat7()
        {
            IntPtr hWaveOut = IntPtr.Zero;

            wfx.wFormatTag = WAVE_FORMAT_PCM;
            wfx.nChannels = 1;
            wfx.nSamplesPerSec = 8000;
            wfx.nAvgBytesPerSec = 8000;
            wfx.nBlockAlign = 1;
            wfx.wBitsPerSample = 8;
            wfx.cbSize = 0;

            waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

            byte[] sbuffer = new byte[16000 * 60];

            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t * -(t << 3 | t | t >> 9 | t >> 10) ^ t);
            }

            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

            try
            {
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                }
            }
            finally
            {
                handle.Free();
                waveOutClose(hWaveOut);
            }
        }

        public static void Bytebeat8()
        {
            IntPtr hWaveOut = IntPtr.Zero;

            wfx.wFormatTag = WAVE_FORMAT_PCM;
            wfx.nChannels = 1;
            wfx.nSamplesPerSec = 8000;
            wfx.nAvgBytesPerSec = 8000;
            wfx.nBlockAlign = 1;
            wfx.wBitsPerSample = 8;
            wfx.cbSize = 0;

            waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

            byte[] sbuffer = new byte[16000 * 60];

            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t | t % 32 | t % 122);

            }

            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

            try
            {
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                }
            }
            finally
            {
                handle.Free();
                waveOutClose(hWaveOut);
            }
        }


        public static void Bytebeat9()
        {
            IntPtr hWaveOut = IntPtr.Zero;

            wfx.wFormatTag = WAVE_FORMAT_PCM;
            wfx.nChannels = 1;
            wfx.nSamplesPerSec = 8000;
            wfx.nAvgBytesPerSec = 8000;
            wfx.nBlockAlign = 1;
            wfx.wBitsPerSample = 8;
            wfx.cbSize = 0;

            waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

            byte[] sbuffer = new byte[16000 * 60];
                
            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t * t << 4 | t + (t >> 2) | t >> 4);       
                
            }
                    
            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

            try
            {
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                }
            }
            finally
            {
                handle.Free();
                waveOutClose(hWaveOut);
            }
        }




    }
}

