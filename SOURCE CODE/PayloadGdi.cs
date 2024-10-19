using System.Windows.Forms;
using System;
using static Windows.WinApi;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;

namespace Puspula
{
    public class GdiPayload
    {
        public static int w = Screen.PrimaryScreen.Bounds.Width;
        public static int h = Screen.PrimaryScreen.Bounds.Height;

        public static int left = Screen.PrimaryScreen.Bounds.Left;
        public static int right = Screen.PrimaryScreen.Bounds.Right;
        public static int top = Screen.PrimaryScreen.Bounds.Top;
        public static int botton = Screen.PrimaryScreen.Bounds.Bottom;

        public static IntPtr hdc = GetDC(IntPtr.Zero);
        public static IntPtr dcCopy = CreateCompatibleDC(hdc);

        public static void Carga1()
        {
            while (true)
            {
                for (int i = 1; i <= 17; i++)
                {
                    var Brush = CreateSolidBrush(0xF0FFFF);
                    SelectObject(hdc, Brush);
                    PatBlt(hdc, 0, 0, w, h, TernaryRasterOperations.PATINVERT);
                    DeleteObject(Brush);
                    Sleep(200);
                }
                for (int i = 1; i <= 36; i++)
                {
                    var Brush = CreateSolidBrush(0xF0FFFF);
                    SelectObject(hdc, Brush);
                    PatBlt(hdc, 0, 0, w, h, TernaryRasterOperations.PATINVERT);
                    DeleteObject(Brush);
                    Sleep(50);
                }
                for (int i = 1; i <= 157; i++)
                {
                    var Brush = CreateSolidBrush(0xF0FFFF);
                    SelectObject(hdc, Brush);
                    PatBlt(hdc, 0, 0, w, h, TernaryRasterOperations.PATINVERT);
                    DeleteObject(Brush);
                    Sleep(10);
                }
            }

            DeleteDC(hdc);
        }

        public static void Carga2()
        {
            Random r;

            uint[] rndclr = { 0xFF9D09 };

            POINT[] lppoint = new POINT[3];

            while (true)
            {
                r = new Random();

                var hdc = GetDC(IntPtr.Zero);
                var hbit = CreateCompatibleBitmap(hdc, w, h);
                var holdbit = SelectObject(dcCopy, hbit);
                var Brush = CreateSolidBrush(rndclr[0]);
                SelectObject(hdc, Brush);
                BitBlt(hdc, 0, 0, w, h, hdc, 0, 0, TernaryRasterOperations.MERGECOPY);
                DeleteObject(Brush);
                DeleteDC(hdc);
                Sleep(100);
            }
        }

        public static void Carga3()
        {
            IntPtr dc = GetDC(IntPtr.Zero);

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER));
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BI_RGB;

            IntPtr bits;
            IntPtr hBitmap = CreateDIBSection(dc, ref bmpi, DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, hBitmap);

            int radius = 0;
            int centrodatelaX = w / 2;
            int centrodatelaY = h / 2;

            while (true)
            {
                StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, TernaryRasterOperations.SRCCOPY);

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

                BLENDFUNCTION blendFunction = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = 1
                };

                AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                radius += 10;
                if (radius > Math.Max(w, h) / 2)
                {
                    radius = 0;
                }

                
                Sleep(1);
            }

            DeleteObject(hBitmap);
            DeleteDC(dcCopy);
            ReleaseDC(IntPtr.Zero, dc);
        }

        public static void Carga4()
        {
            while (true)
            {
                Random r = new Random();
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                StretchBlt(hdc, r.Next(5), r.Next(5), w - r.Next(10), h - r.Next(10), hdc, 0, 0, w, h, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, 0, w, h, hdc, 0, 0, w, h, TernaryRasterOperations.NOTSRCCOPY);
                StretchBlt(hdc, 0, h, w, -h, hdc, 0, 0, w, h, TernaryRasterOperations.SRCCOPY);
            }
        }

        public static void Carga5()
        {
            IntPtr dc = GetDC(IntPtr.Zero);
            IntPtr dcCopy = CreateCompatibleDC(dc);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER));
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = 0;

            IntPtr bits;
            IntPtr bmp = CreateDIBSection(dc, ref bmpi, 0, out bits, IntPtr.Zero, 0);
            IntPtr oldBmp = SelectObject(dcCopy, bmp);

            Random rand = new Random();
            double time = 0;

            while (true)
            {
                POINT mousePoint;
                GetCursorPos(out mousePoint);
                int mouseX = mousePoint.X;
                int mouseY = mousePoint.Y;

                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int index = y * w + x;

                            double waveX = Math.Sin((x + time) * 0.05 * mouseX * 0.01) * 200 + 200;
                            double waveY = Math.Cos((y + time) * 0.05 * mouseY * 0.01) * 200 + 200;

                            rgbquad[index].rgbRed = (byte)waveX;
                            rgbquad[index].rgbGreen = (byte)waveY;
                            rgbquad[index].rgbBlue = (byte)((waveX * waveY) / 255);
                            rgbquad[index].rgbReserved = 0;
                        }
                    }
                }

                StretchBlt(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, TernaryRasterOperations.SRCCOPY);

                time += 0.1;
                Sleep(30);
            }

            // Limpeza
            SelectObject(dcCopy, oldBmp);
            ReleaseDC(IntPtr.Zero, dc);
            ReleaseDC(IntPtr.Zero, dcCopy);
        }

        public static void Carga6()
        {
            Random r;
            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
            POINT[] lppoint = new POINT[3];

            while (true)
            {
                r = new Random();
                IntPtr hdc = GetDC(IntPtr.Zero);
                IntPtr mhdc = CreateCompatibleDC(hdc);
                IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                IntPtr holdbit = SelectObject(mhdc, hbit);
                lppoint[0].X = (left + 50) + 0;
                lppoint[0].Y = (top - 32) + 0;
                lppoint[1].X = (right + 50) + 0;
                lppoint[1].Y = (top + 32) + 0;
                lppoint[2].X = (left - 50) + 0;
                lppoint[2].Y = (botton - 50) + 0;
                PlgBlt(hdc, lppoint, hdc, left - 20, top - 20, (right - left) + 40, (botton - top) + 40, IntPtr.Zero, 0, 0);
                DeleteDC(hdc);
                
                Sleep(50);

            }
        }

        public static void Carga7()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            IntPtr dc = GetDC(IntPtr.Zero);
            IntPtr dcCopy = CreateCompatibleDC(dc);
            IntPtr hbit = CreateCompatibleBitmap(dc, w, h);
            IntPtr holdbit = SelectObject(dcCopy, hbit);

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmpi.bmiHeader);
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BI_RGB;

            IntPtr ppvBits;
            IntPtr bmp = CreateDIBSection(dc, ref bmpi, 0, out ppvBits, IntPtr.Zero, 0);
            SelectObject(dcCopy, bmp);
            POINT[] lppoint = new POINT[3];
            uint[] rndclr = { 0x1B4BE8, 0x7C8D0F, 0xF51D1D, 0x21BDFF };
            int left = Screen.PrimaryScreen.Bounds.Left, right = Screen.PrimaryScreen.Bounds.Right, top = Screen.PrimaryScreen.Bounds.Top, bottom = Screen.PrimaryScreen.Bounds.Bottom;
            Random r;

            unsafe
            {
                RGBQUAD* rgbquad = (RGBQUAD*)ppvBits;
                int i = 0;

                while (true)
                {
                    r = new Random();
                    IntPtr Brush = CreateHatchBrush(r.Next(4), 0);
                    SetBkColor(hdc, rndclr[r.Next(rndclr.Length)]);
                    SelectObject(hdc, Brush);
                    PatBlt(hdc, 0, 0, w, h, TernaryRasterOperations.PATINVERT);

                    StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, TernaryRasterOperations.SRCCOPY);

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
                    StretchBlt(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, TernaryRasterOperations.SRCCOPY);
                }
            }


            ReleaseDC(IntPtr.Zero, dc);

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


        public static void Carga8()
        {
            IntPtr dc = GetDC(IntPtr.Zero);
            IntPtr dcCopy = CreateCompatibleDC(dc);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmpi.bmiHeader);
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BI_RGB;

            IntPtr bits;
            IntPtr hBitmap = CreateDIBSection(dc, ref bmpi, DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, hBitmap);

            while (true)
            {
                StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, TernaryRasterOperations.SRCCOPY);

                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int index = y * w + x;
                            Color color = Color.FromArgb(rgbquad[index].rgbRed, rgbquad[index].rgbGreen, rgbquad[index].rgbBlue);
                            float hue = (color.GetHue() + 10) % 200;
                            float saturation = color.GetSaturation();
                            float luminance = color.GetBrightness();

                            Color newColor = FromHls(hue, luminance, saturation);
                            rgbquad[index].rgbRed = newColor.R;
                            rgbquad[index].rgbGreen = newColor.G;
                            rgbquad[index].rgbBlue = newColor.B;
                            rgbquad[index].rgbReserved = 100;
                        }
                    }
                }

                BLENDFUNCTION blendFunction = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = 1
                };

                AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                Thread.Sleep(100);
            }

        }


        public static void Carga9()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int columnWidth = 2;
            Random random = new Random();

            while (true)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                IntPtr mhdc = CreateCompatibleDC(hdc);
                IntPtr hbit = CreateCompatibleBitmap(hdc, screenWidth, screenHeight);
                IntPtr holdbit = SelectObject(mhdc, hbit);
                BitBlt(mhdc, 0, 0, screenWidth, screenHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                            
                using (Graphics g = Graphics.FromHdc(mhdc))
                {
                    Bitmap bitmap = new Bitmap(screenWidth, screenHeight);
                    using (Graphics gb = Graphics.FromImage(bitmap))
                    {
                        gb.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
                    }

                    for (int i = 0; i < screenWidth; i += columnWidth)
                    {
                        int shift = random.Next(-screenHeight / 5, screenHeight / 5);

                        if (shift != 0)
                        {
                            g.DrawImage(bitmap, new Rectangle(i, shift, columnWidth, screenHeight), new Rectangle(i, 0, columnWidth, screenHeight), GraphicsUnit.Pixel);
                        }
                    }
                }

                BitBlt(hdc, 0, 0, screenWidth, screenHeight, mhdc, 0, 0, TernaryRasterOperations.SRCCOPY);

                SelectObject(mhdc, holdbit);
                DeleteObject(holdbit);
                DeleteObject(hbit);
                DeleteObject(mhdc);
                ReleaseDC(IntPtr.Zero, hdc);                                                                    
            }
        }

        public static void END()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int fontSize = 40;
            Random random = new Random();
            char[] characters = @"PÚSPULA ".ToCharArray();

            int columns = screenWidth / fontSize;
            int[] yPositions = new int[columns];

            while (true)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                IntPtr mhdc = CreateCompatibleDC(hdc);
                IntPtr hbit = CreateCompatibleBitmap(hdc, screenWidth, screenHeight);
                IntPtr holdbit = SelectObject(mhdc, hbit);
                BitBlt(mhdc, 0, 0, screenWidth, screenHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);

                using (Graphics g = Graphics.FromHdc(mhdc))
                {
                    g.Clear(Color.Black);
                    using (Font font = new Font("Consolas", fontSize))
                    {
                        for (int i = 0; i < columns; i++)
                        {
                            int x = i * fontSize;
                            int y = yPositions[i] * fontSize;
                            // Pegar um caractere aleatório do array
                            char c = characters[random.Next(characters.Length)];
                            g.DrawString(c.ToString(), font, Brushes.Lime, x, y);

                            yPositions[i]++;
                            if (yPositions[i] * fontSize > screenHeight)
                            {
                                yPositions[i] = 0;
                            }
                        }
                    }
                }

                BitBlt(hdc, 0, 0, screenWidth, screenHeight, mhdc, 0, 0, TernaryRasterOperations.SRCERASE);

                SelectObject(mhdc, holdbit);
                DeleteObject(hbit);
                DeleteDC(mhdc);
                ReleaseDC(IntPtr.Zero, hdc);

                Thread.Sleep(100);
            }
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
        public static void SpawnIcoWarn()
        {
            IntPtr hdc = GetWindowDC(IntPtr.Zero);
            IntPtr hIcon = SystemIcons.Warning.Handle;

            Random rand = new Random();

            while (true)
            {
                int x = rand.Next(Screen.PrimaryScreen.Bounds.Width);
                int y = rand.Next(Screen.PrimaryScreen.Bounds.Height);

                DrawIcon(hdc, x, y, hIcon);
            }

            ReleaseDC(IntPtr.Zero, hdc);
        }

        public static void MouseIcoError()
        {
            while (true)
            {
                Cursor cursor = new Cursor(Cursor.Current.Handle);
                int PosX = Cursor.Position.X;
                int PosY = Cursor.Position.Y;

                IntPtr desktop = GetWindowDC(IntPtr.Zero);

                using (Graphics g = Graphics.FromHdc(desktop))
                {
                    // ou Coloque:
                    //  # SystemIcons.Error
                    //  # SystemIcons.Information
                    //  # SystemIcons.Warning
                    //  # SystemIcons.Question

                    g.DrawIcon(SystemIcons.Error, PosX, PosY);
                    //g.DrawImage(image, PosX, PosY);
                    Thread.Sleep(10);
                }
            }
        }

        public static void MouseIcoWarn()
        {
            IntPtr errorIcon = SystemIcons.Warning.Handle;
            if (errorIcon == IntPtr.Zero) return;

            while (true)
            {
                int posX = Cursor.Position.X;
                int posY = Cursor.Position.Y;

                IntPtr desktopDC = GetWindowDC(IntPtr.Zero);
                DrawIcon(desktopDC, posX, posY, errorIcon);
                ReleaseDC(IntPtr.Zero, desktopDC);

                Sleep(10);
            }
        }
    }
}
