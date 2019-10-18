using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Bfh.Wba.AspNetCore.Services.Images
{
    public class Thumbnail
    {
        public int Size { get; set; } = 200;

        public string Path { get; set; } = "/notfound.jpg";

        public byte[] ToBytes()
        {
            var img = System.Drawing.Image.FromFile(this.Path);

            int w = img.Width;
            int h = img.Height;
            double factor = (double)this.Size / ((w > h) ? (double)w : (double)h);
            w = (int)(w * factor);
            h = (int)(h * factor);

            var tn = new Bitmap(img, new Size(w, h));

            MemoryStream s = new MemoryStream();
            tn.Save(s, ImageFormat.Png);

            return s.ToArray();
        }
    }
}
