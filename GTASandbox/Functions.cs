using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASandbox
{
    internal static unsafe class Functions
    {
        public static void Screenshot(int x, int y, int w, int h, string file, bool jpg, long quality = 25L)
        {
            System.Drawing.Bitmap captureBitmap = new System.Drawing.Bitmap(w, h);
            System.Drawing.Graphics captureGraphics = System.Drawing.Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(w, h));
            string path = file + (jpg ? ".jpg" : ".png");
            if(jpg)
            {
                var cdc = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders().Where(e => e.MimeType == "image/jpeg").First();
                var enc = System.Drawing.Imaging.Encoder.Quality;
                var eps = new System.Drawing.Imaging.EncoderParameters(1);
                var ep = new System.Drawing.Imaging.EncoderParameter(enc, quality);
                eps.Param[0] = ep;
                captureBitmap.Save(path, cdc, eps);
            }
            else
            {
                captureBitmap.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
