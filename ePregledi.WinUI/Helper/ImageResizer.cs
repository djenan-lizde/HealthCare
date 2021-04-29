using System.Drawing;
using System.IO;

namespace ePregledi.WinUI.Helper
{
    public static class ImageResizer
    {
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }
        public static Image ResizeImage(Image image, int width, int height)
        {
            var size = new Size(width, height);
            Image newImage = new Bitmap(image, size);
            using (Graphics graphics = Graphics.FromImage((Bitmap)newImage))
            {
                graphics.DrawImage(image, new Rectangle(Point.Empty, size));
            }
            return newImage;
        }
    }
}
