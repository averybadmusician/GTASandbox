using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASandbox
{
    internal static unsafe class Functions
    {
        public static void Screenshot(int x, int y, int w, int h, string file, bool jpg)
        {
            System.Drawing.Bitmap captureBitmap = new System.Drawing.Bitmap(w, h);
            System.Drawing.Graphics captureGraphics = System.Drawing.Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(w, h));
            captureBitmap.Save(file + (jpg ? ".jpg" : ".png"), jpg ?  System.Drawing.Imaging.ImageFormat.Jpeg : System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
