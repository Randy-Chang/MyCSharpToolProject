using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_ImageViewer
{
    internal partial class TemplateMatching
    {
        public Point MatchTemplate(Bitmap sourceImage, Bitmap templateImage)
        {
            // 確保來源圖片和模板的尺寸
            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;
            int templateWidth = templateImage.Width;
            int templateHeight = templateImage.Height;

            if (sourceWidth < templateWidth || sourceHeight < templateHeight)
                throw new ArgumentException("Template is larger than source image.");

            BitmapData sourceData = sourceImage.LockBits(new Rectangle(0, 0, sourceWidth, sourceHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData templateData = templateImage.LockBits(new Rectangle(0, 0, templateWidth, templateHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            IntPtr sourcePtr = sourceData.Scan0;
            IntPtr templatePtr = templateData.Scan0;

            int strideSource = sourceData.Stride;
            int strideTemplate = templateData.Stride;

            int minDistance = int.MaxValue;
            Point matchLocation = Point.Empty;

            // 遍歷源圖像
            for (int y = 0; y <= sourceHeight - templateHeight; y++)
            {
                for (int x = 0; x <= sourceWidth - templateWidth; x++)
                {
                    int sum = 0;

                    // 比對這個區域的每個像素
                    for (int j = 0; j < templateHeight; j++)
                    {
                        for (int i = 0; i < templateWidth; i++)
                        {
                            // 取源圖像和模板的對應像素值 (24-bit RGB)
                            Color sourcePixel = GetPixel(sourcePtr, strideSource, x + i, y + j);
                            Color templatePixel = GetPixel(templatePtr, strideTemplate, i, j);

                            // 計算平方差
                            sum += (sourcePixel.R - templatePixel.R) * (sourcePixel.R - templatePixel.R);
                            sum += (sourcePixel.G - templatePixel.G) * (sourcePixel.G - templatePixel.G);
                            sum += (sourcePixel.B - templatePixel.B) * (sourcePixel.B - templatePixel.B);
                        }
                    }

                    // 儲存最佳匹配點
                    if (sum < minDistance)
                    {
                        minDistance = sum;
                        matchLocation = new Point(x, y);
                    }
                }
            }

            sourceImage.UnlockBits(sourceData);
            templateImage.UnlockBits(templateData);

            return matchLocation;
        }

        private Color GetPixel(IntPtr ptr, int stride, int x, int y)
        {
            int index = (y * stride) + (x * 3); // RGB (24bpp)
            byte b = Marshal.ReadByte(ptr, index);
            byte g = Marshal.ReadByte(ptr, index + 1);
            byte r = Marshal.ReadByte(ptr, index + 2);

            return Color.FromArgb(r, g, b);
        }

    }

    internal partial class TemplateMatching
    {
        public Point MatchTemplateToGray(Bitmap sourceImage, Bitmap template, out double maxVal)
        {
            // 灰階處理
            Bitmap sourceGray = ToGrayscaleFast(sourceImage);
            Bitmap templateGray = ToGrayscaleFast(template);

            int sw = sourceGray.Width;
            int sh = sourceGray.Height;
            int tw = templateGray.Width;
            int th = templateGray.Height;

            Point bestMatch = Point.Empty;
            maxVal = double.MinValue;

            for (int y = 0; y <= sh - th; y++)
            {
                for (int x = 0; x <= sw - tw; x++)
                {
                    double sum = 0;
                    double sumTemplate = 0;
                    double sumSource = 0;
                    double sumTemplateSq = 0;
                    double sumSourceSq = 0;
                    double sumProduct = 0;
                    int count = 0;

                    for (int j = 0; j < th; j++)
                    {
                        for (int i = 0; i < tw; i++)
                        {
                            Color templatePixel = templateGray.GetPixel(i, j);
                            Color sourcePixel = sourceGray.GetPixel(x + i, y + j);

                            double t = templatePixel.R;
                            double s = sourcePixel.R;

                            sumTemplate += t;
                            sumSource += s;
                            sumTemplateSq += t * t;
                            sumSourceSq += s * s;
                            sumProduct += t * s;
                            count++;
                        }
                    }

                    double numerator = (count * sumProduct - sumTemplate * sumSource);
                    double denominator = Math.Sqrt((count * sumTemplateSq - sumTemplate * sumTemplate) *
                                                   (count * sumSourceSq - sumSource * sumSource) + 1e-5); // 避免除以 0

                    double ncc = numerator / denominator;

                    if (ncc > maxVal)
                    {
                        maxVal = ncc;
                        bestMatch = new Point(x, y);
                    }
                }
            }

            return bestMatch;
        }

        public static Bitmap ToGrayscaleFast(Bitmap original)
        {
            Bitmap grayImage = new Bitmap(original.Width, original.Height, PixelFormat.Format24bppRgb);

            BitmapData originalData = original.LockBits(
                new Rectangle(0, 0, original.Width, original.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            BitmapData grayData = grayImage.LockBits(
                new Rectangle(0, 0, grayImage.Width, grayImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int stride = originalData.Stride;
            IntPtr originalScan0 = originalData.Scan0;
            IntPtr grayScan0 = grayData.Scan0;

            unsafe
            {
                byte* originalPtr = (byte*)originalScan0;
                byte* grayPtr = (byte*)grayScan0;

                for (int y = 0; y < original.Height; y++)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        byte b = originalPtr[y * stride + x * 3];
                        byte g = originalPtr[y * stride + x * 3 + 1];
                        byte r = originalPtr[y * stride + x * 3 + 2];

                        byte gray = (byte)(r * 0.299 + g * 0.587 + b * 0.114);

                        grayPtr[y * stride + x * 3] = gray;
                        grayPtr[y * stride + x * 3 + 1] = gray;
                        grayPtr[y * stride + x * 3 + 2] = gray;
                    }
                }
            }

            original.UnlockBits(originalData);
            grayImage.UnlockBits(grayData);

            return grayImage;
        }

    }

    internal partial class TemplateMatching
    {
        public Point MatchTemplateFast(Bitmap source, Bitmap template, out double maxVal)
        {
            Bitmap srcGray = ToGrayscaleFast(source);
            Bitmap tplGray = ToGrayscaleFast(template);

            int sw = srcGray.Width;
            int sh = srcGray.Height;
            int tw = tplGray.Width;
            int th = tplGray.Height;

            Point bestMatch = Point.Empty;
            maxVal = double.MinValue;

            BitmapData srcData = srcGray.LockBits(new Rectangle(0, 0, sw, sh), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData tplData = tplGray.LockBits(new Rectangle(0, 0, tw, th), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0;
                byte* tplPtr = (byte*)tplData.Scan0;

                int srcStride = srcData.Stride;
                int tplStride = tplData.Stride;

                for (int y = 0; y <= sh - th; y++)
                {
                    for (int x = 0; x <= sw - tw; x++)
                    {
                        double sumS = 0, sumT = 0;
                        double sumS2 = 0, sumT2 = 0;
                        double sumST = 0;
                        int count = 0;

                        for (int j = 0; j < th; j++)
                        {
                            byte* pS = srcPtr + (y + j) * srcStride + x * 3;
                            byte* pT = tplPtr + j * tplStride;

                            for (int i = 0; i < tw; i++)
                            {
                                byte s = pS[i * 3]; // 灰階 r=g=b
                                byte t = pT[i * 3];

                                sumS += s;
                                sumT += t;
                                sumS2 += s * s;
                                sumT2 += t * t;
                                sumST += s * t;
                                count++;
                            }
                        }

                        double numerator = (count * sumST - sumS * sumT);
                        double denominator = Math.Sqrt((count * sumS2 - sumS * sumS) * (count * sumT2 - sumT * sumT) + 1e-5);

                        double ncc = numerator / denominator;

                        if (ncc > maxVal)
                        {
                            maxVal = ncc;
                            bestMatch = new Point(x, y);
                        }
                    }
                }
            }

            srcGray.UnlockBits(srcData);
            tplGray.UnlockBits(tplData);

            return bestMatch;
        }

    }
}
