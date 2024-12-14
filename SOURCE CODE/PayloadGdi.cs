using System.Windows.Forms;
using System;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using Vanara.PInvoke;
using static Vanara.PInvoke.Msvfw32;

namespace Puspula
{
    public class GdiPayload
    {
        public static byte MathClamp(double value, byte min, byte max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return (byte)value;
        }

        static Color FromHls(float h, float l, float s)
        {
            if (s == 0)
            {
                int L = (int)(l * 255);
                return Color.FromArgb(L, L, L);
            }

            float v2 = l < 0.5f ? l * (1 + s) : (l + s) - (l * s);
            float v1 = 2 * l - v2;

            byte r = (byte)(255 * HueToRGB(v1, v2, h + 1.0f / 3));
            byte g = (byte)(255 * HueToRGB(v1, v2, h));
            byte b = (byte)(255 * HueToRGB(v1, v2, h - 1.0f / 3));

            return Color.FromArgb(r, g, b);
        }

        static float HueToRGB(float v1, float v2, float vH)
        {
            if (vH < 0) vH += 1;
            if (vH > 1) vH -= 1;
            if ((6 * vH) < 1) return v1 + (v2 - v1) * 6 * vH;
            if ((2 * vH) < 1) return v2;
            if ((3 * vH) < 2) return v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6;
            return v1;
        }

        public static Point RotatePoint(int centerX, int centerY, int x, int y, double angle)
        {
            double radians = angle;
            double cosTheta = Math.Cos(radians);
            double sinTheta = Math.Sin(radians);

            int newX = (int)(cosTheta * (x - centerX) - sinTheta * (y - centerY) + centerX);
            int newY = (int)(sinTheta * (x - centerX) + cosTheta * (y - centerY) + centerY);

            return new Point(newX, newY);
        }

        public static void cls()
        {
            InvalidateRect(HWND.NULL, null, true);
            UpdateWindow(HWND.NULL);
        }

        public static void Carga1()
        {
            while (true)
            {
                for (int i = 1; i <= 17; i++)
                {
                    int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
                    int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
                    HDC hdc = GetDC(IntPtr.Zero);
                    HDC dcCopy = CreateCompatibleDC(hdc);

                    var Brush = CreateSolidBrush(0xF0FFFF);
                    SelectObject(hdc, Brush);
                    PatBlt(hdc, 0, 0, w, h, RasterOperationMode.PATINVERT);
                    DeleteObject(Brush);
                    Sleep(200);
                }
                for (int i = 1; i <= 36; i++)
                {
                    int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
                    int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
                    HDC hdc = GetDC(IntPtr.Zero);
                    HDC dcCopy = CreateCompatibleDC(hdc);

                    var Brush = CreateSolidBrush(0xF0FFFF);
                    SelectObject(hdc, Brush);
                    PatBlt(hdc, 0, 0, w, h, RasterOperationMode.PATINVERT);
                    DeleteObject(Brush);
                    Sleep(50);
                }
                for (int i = 1; i <= 157; i++)
                {
                    int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
                    int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
                    HDC hdc = GetDC(IntPtr.Zero);
                    HDC dcCopy = CreateCompatibleDC(hdc);

                    var Brush = CreateSolidBrush(0xF0FFFF);
                    SelectObject(hdc, Brush);
                    PatBlt(hdc, 0, 0, w, h, RasterOperationMode.PATINVERT);
                    DeleteObject(Brush);
                    Sleep(10);
                }
            }
        }

        public static void Carga2()
        {
            Random r;

            uint[] rndclr = { 0xFF9D09 };

            Point[] lppoint = new Point[3];

            while (true)
            {
                r = new Random();

                int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
                int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
                HDC hdc = GetDC(IntPtr.Zero);
                HDC dcCopy = CreateCompatibleDC(hdc);

                var hbit = CreateCompatibleBitmap(hdc, w, h);
                var holdbit = SelectObject(dcCopy, hbit);
                var Brush = CreateSolidBrush(rndclr[0]);

                SelectObject(hdc, Brush);
                BitBlt(hdc, 0, 0, w, h, hdc, 0, 0, RasterOperationMode.MERGECOPY);
                DeleteObject(Brush);
                DeleteDC(hdc);
                Sleep(100);
            }
        }

        public static void Carga3()
        {
            int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            HDC dc = GetDC(IntPtr.Zero);
            HDC dcCopy = CreateCompatibleDC(dc);

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER));
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BitmapCompressionMode.BI_RGB;

            IntPtr bits;
            var hBitmap = CreateDIBSection(dc, in bmpi, DIBColorMode.DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, hBitmap);

            int radius = 0;
            int centrodatelaX = w / 2;
            int centrodatelaY = h / 2;

            while (true)
            {
                StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, RasterOperationMode.SRCCOPY);

                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int dx = x - centrodatelaX;
                            int dy = y - centrodatelaY;
                            double distance = Math.Sqrt(dx * dx + dy * dy);

                            if (distance <= radius)
                            {
                                int index = y * w + x;
                                double wave = Math.Sin(distance / 40.0);
                                byte intensity = (byte)((1 - distance / radius) * 255);

                                rgbquad[index].rgbRed = (byte)(wave * intensity);
                                rgbquad[index].rgbGreen = (byte)((1 - wave) * intensity);
                                rgbquad[index].rgbBlue = (byte)((Math.Abs(wave - 2000) * 23) * intensity);
                                rgbquad[index].rgbReserved = 255;
                            }
                        }
                    }

                    cls();
                }

                BLENDFUNCTION blendFunction = new BLENDFUNCTION(255);

                AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                radius += 10;
                if (radius > Math.Max(w, h) / 2)
                {
                    radius = 0;
                }

                
                Sleep(1);
            }
        }

        public static void Carga4()
        {
            while (true)
            {
                int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
                int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);

                Random r = new Random();

                HWND hwnd = GetDesktopWindow();
                HDC hdc = GetWindowDC(hwnd);

                StretchBlt(hdc, r.Next(5), r.Next(5), w - r.Next(10), h - r.Next(10), hdc,
                    0, 0, w, h, RasterOperationMode.SRCCOPY);
                StretchBlt(hdc, 0, 0, w, h, hdc, 0, 0, w, h, RasterOperationMode.NOTSRCCOPY);
                StretchBlt(hdc, 0, h, w, -h, hdc, 0, 0, w, h, RasterOperationMode.SRCCOPY);
            }
        }

        public static void Carga5()
        {
            int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            HDC dc = GetDC(IntPtr.Zero);
            HDC dcCopy = CreateCompatibleDC(dc);

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER));
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = 0;

            IntPtr bits;
            var bmp = CreateDIBSection(dc, in bmpi, 0, out bits, IntPtr.Zero, 0);

            var oldBmp = SelectObject(dcCopy, bmp);

            Random rand = new Random();
            double time = 0;

            while (true)
            {
                Point mousePoint;
                GetCursorPos(out mousePoint);
                int mouseX = Math.Max(mousePoint.X, 1);
                int mouseY = Math.Max(mousePoint.Y, 1);

                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int index = y * w + x;

                            double waveX = Math.Sin((x + time) * 0.005 * mouseX * 0.1) * 200 + 200;
                            double waveY = Math.Cos((y + time) * 0.005 * mouseY * 0.1) * 200 + 200;

                            rgbquad[index].rgbRed = (byte)MathClamp(waveX, 0, (byte)rand.Next(255));
                            rgbquad[index].rgbGreen = (byte)MathClamp(waveY, 0, (byte)rand.Next(255));
                            rgbquad[index].rgbBlue = (byte)MathClamp((waveX * waveY) / (byte)rand.Next(255), 0, (byte)rand.Next(255));
                            rgbquad[index].rgbReserved = 0;
                        }
                    }
                }

                StretchBlt(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, RasterOperationMode.SRCCOPY);

                time += 0.1;
                Thread.Sleep(30);
            }
        }

        public static void Carga6()
        {
            while (true)
            {
                int x = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
                int y = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
                HDC hdc = GetDC(IntPtr.Zero);
                HDC dcCopy = CreateCompatibleDC(hdc);

                Point[] lppoint = new Point[3];

                Random r = new Random();

                HDC mhdc = CreateCompatibleDC(hdc);
                HBITMAP hbit = CreateCompatibleBitmap(hdc, x, y);

                RECT rc = new RECT(0,0, x,y);

                var holdbit = SelectObject(mhdc, hbit);
                lppoint[0].X = (rc.left + 50) + 0;
                lppoint[0].Y = (rc.top - 32) + 0;
                lppoint[1].X = (rc.right + 50) + 0;
                lppoint[1].Y = (rc.top + 32) + 0;
                lppoint[2].X = (rc.left - 50) + 0;
                lppoint[2].Y = (rc.bottom - 50) + 0;
                PlgBlt(hdc, lppoint, hdc, rc.left - 20,
                    rc.top - 20, (rc.right - rc.left) + 40, (rc.bottom - rc.top) + 40, HBITMAP.NULL, 0, 0);
                DeleteDC(hdc);
                
                Sleep(50);

            }
        }

        public static void Carga7()
        {
            int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            HDC dc = GetDC(IntPtr.Zero);
            HDC dcCopy = CreateCompatibleDC(dc);

            var hbit = CreateCompatibleBitmap(dc, w, h);
            var holdbit = SelectObject(dcCopy, hbit);

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmpi.bmiHeader);
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BitmapCompressionMode.BI_RGB;

            IntPtr ppvBits;
            var bmp = CreateDIBSection(dc, in bmpi, 0, out ppvBits, IntPtr.Zero, 0);
            SelectObject(dcCopy, bmp);

            unsafe
            {
                RGBQUAD* rgbquad = (RGBQUAD*)ppvBits;
                int i = 0;

                while (true)
                {
                    var Brush = CreateSolidBrush(0);
                    SelectObject(dc, Brush);

                    PatBlt(dc, 0, 0, w, h, RasterOperationMode.PATINVERT);

                    StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, RasterOperationMode.SRCCOPY);

                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            int index = y * w + x;
                            int offsetX = (int)(10 * Math.Sin((double)x / 1 + i * 0.1));
                            int offsetY = (int)(10 * Math.Cos((double)y / 2 + i * 0.1));

                            int newX = x + offsetX;
                            int newY = y + offsetY;

                            if (newX >= 0 && newX < w && newY >= 0 && newY < h)
                            {
                                int newIndex = newY * w + newX;
                                rgbquad[index] = rgbquad[newIndex];
                            }
                        }
                    }

                    i++;
                    StretchBlt(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, RasterOperationMode.SRCCOPY);
                }
            }
        }


        public static void Carga8()
        {
            int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            HDC dc = GetDC(IntPtr.Zero);
            HDC dcCopy = CreateCompatibleDC(dc);

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmpi.bmiHeader);
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BitmapCompressionMode.BI_RGB;

            IntPtr bits;
            HBITMAP hBitmap = CreateDIBSection(dc, in bmpi, DIBColorMode.DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, hBitmap);

            Random r;

            while (true)
            {
                StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, RasterOperationMode.SRCCOPY);
                r = new Random();
                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int index = y * w + x;
                            Color color = Color.FromArgb(rgbquad[index].rgbRed, rgbquad[index].rgbGreen, rgbquad[index].rgbBlue);
                            float hue = (color.GetHue() + 20) % 200;
                            float saturation = color.GetSaturation();
                            float luminance = color.GetBrightness();

                            Color newColor = FromHls(hue, luminance, saturation);
                            rgbquad[index].rgbRed = newColor.R;
                            rgbquad[index].rgbGreen = newColor.G;
                            rgbquad[index].rgbBlue = newColor.B;
                            rgbquad[index].rgbReserved = 199;
                        }
                    }

                    BLENDFUNCTION blendFunction = new BLENDFUNCTION(200);

                    AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                    Thread.Sleep(100);

                    if (r.Next(100) == 50)
                    {
                        cls();
                    }
                }
            }

        }

        public static void Carga9()
        {
            int columnWidth = 1;

            Random random = new Random();

            while (true)
            {
                int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
                int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
                HDC hdc = GetDC(IntPtr.Zero);
                HDC dcCopy = CreateCompatibleDC(hdc);

                var memDC = CreateCompatibleDC(hdc);
                var hBitmap = CreateCompatibleBitmap(hdc, w, h);
                var oldBitmap = SelectObject(memDC, hBitmap);

                BitBlt(memDC, 0, 0, w, h, hdc, 0, 0, RasterOperationMode.SRCCOPY);

                for (int i = 0; i < w; i += columnWidth)
                {
                    int shift = random.Next(-h / 25, h * 10);
                    if (shift != 0)
                    {
                        BitBlt(memDC, i, shift, columnWidth, h, memDC,
                            i, 0, RasterOperationMode.SRCINVERT);
                    }
                }

                BitBlt(hdc, 0, 0, w, h, memDC, 0, 0, RasterOperationMode.SRCCOPY);

                SelectObject(memDC, oldBitmap);
                DeleteObject(hBitmap);
                DeleteDC(memDC);
                ReleaseDC(HWND.NULL, hdc);

                if (random.Next(100) == 50)
                {
                    cls();
                }
            }
        }

        public static void END()
        {

            int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            HDC hdc = GetDC(IntPtr.Zero);
            HDC dcCopy = CreateCompatibleDC(hdc);

            int fontSize = 40;

            Random random = new Random();

            char[] characters = @"PÚSPULA ".ToCharArray();

            int columns = w / fontSize;
            int[] yPositions = new int[columns];

            while (true)
            {
                var memDC = CreateCompatibleDC(hdc);
                var hBitmap = CreateCompatibleBitmap(hdc, w, h);
                var oldBitmap = SelectObject(memDC, hBitmap);

                BitBlt(memDC, 0, 0, w, h, hdc, 0, 0, RasterOperationMode.BLACKNESS);

                for (int i = 0; i < columns; i++)
                {
                    int x = i * fontSize;
                    int y = yPositions[i] * fontSize;

                    char c = characters[random.Next(characters.Length)];
                    var hFont = CreateFont(fontSize, 0, 0, 0, 700, false, false, false, CharacterSet.DEFAULT_CHARSET,
                                                 OutputPrecision.OUT_TT_PRECIS, ClippingPrecision.CLIP_DEFAULT_PRECIS,
                                                 OutputQuality.DEFAULT_QUALITY, PitchAndFamily.FF_DONTCARE, "Consolas");

                    var oldFont = SelectObject(memDC, hFont);

                    SetTextColor(memDC, Color.Green);
                    SetBkMode(memDC, BackgroundMode.TRANSPARENT);
                    TextOut(memDC, x, y, c.ToString(), 1);

                    SelectObject(memDC, oldFont);
                    DeleteObject(hFont);

                    yPositions[i]++;
                    if (yPositions[i] * fontSize > h)
                    {
                        yPositions[i] = 0;
                    }
                }

                BitBlt(hdc, 0, 0, w, h, memDC, 0, 0, RasterOperationMode.SRCCOPY);

                SelectObject(memDC, oldBitmap);
                DeleteObject(hBitmap);
                DeleteDC(memDC);

                Thread.Sleep(100);
            }
        }

        public static void SpawnIcoWarn()
        {
            int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            HDC dc = GetDC(IntPtr.Zero);
            HDC dcCopy = CreateCompatibleDC(dc);

            var hIcon = SystemIcons.Warning.Handle;

            Random rand = new Random();

            while (true)
            {
                int x = rand.Next(w);
                int y = rand.Next(h);

                DrawIcon(dc, x, y, hIcon);
            }
        }

        public static void MouseIcoError()
        {
            HICON hIcon = LoadIcon(HINSTANCE.NULL, IDI_ERROR);

            while (true)
            {
                Point point;
                GetCursorPos(out point);

                HDC hdc = GetDC(IntPtr.Zero);

                DrawIcon(hdc, point.X, point.Y, hIcon);

                ReleaseDC(HWND.NULL, hdc);
                Sleep(10);
            }
        }


        public static void MouseIcoWarn()
        {
            var errorIcon = SystemIcons.Warning.Handle;
            if (errorIcon == IntPtr.Zero) return;

            while (true)
            {
                int posX = Cursor.Position.X;
                int posY = Cursor.Position.Y;

                HDC desktopDC = GetWindowDC(IntPtr.Zero);

                DrawIcon(desktopDC, posX, posY, errorIcon);

                ReleaseDC(HWND.NULL, desktopDC);
                Sleep(10);
            }
        }
    }
}
