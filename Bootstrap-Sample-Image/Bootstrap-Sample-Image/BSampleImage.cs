using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace BootstrapSampleImage
{
    public static class BSampleImage
    {
        public static Bitmap ProvideImage(int width, int height)
        {
            // Calculate the font size relative to the length and height photo, like bootstrap sample images 
            var z = height;
            if (z > width / 5)
                z = width / 5;
            var fontSize = (int)(Math.Sqrt(z) * 2);

            // Create a new 32-bit bitmap image.
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Create a graphics object for drawing.
            Graphics gfxCaptchaImage = Graphics.FromImage(bitmap);
            gfxCaptchaImage.PageUnit = GraphicsUnit.Pixel;
            gfxCaptchaImage.SmoothingMode = SmoothingMode.HighQuality;
            gfxCaptchaImage.CompositingQuality = CompositingQuality.HighQuality;
            gfxCaptchaImage.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            gfxCaptchaImage.Clear(ColorTranslator.FromHtml("#EEEEEE"));

            // Set up the text format.
            var format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            var font = new Font("Arial", fontSize, FontStyle.Bold);

            var myBrush = new SolidBrush(ColorTranslator.FromHtml("#AAAAAA"));

            //-- Draw the graphic to the bitmap
            gfxCaptchaImage.DrawString($"{width}x{height}", font, myBrush, new Rectangle(0, 0, width, height), format);
            gfxCaptchaImage.Flush();


            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            ms.Position = 0;

            // Clean up.
            font.Dispose();
            gfxCaptchaImage.Dispose();

            return bitmap;
        }

    }
}
