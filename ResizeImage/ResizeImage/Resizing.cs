using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage
{
    public class Resizing
    {
        public Bitmap Image { get; set; } 

        private Bitmap ReadyImage { get; set; }

        public Resizing()
        {
            
        }

        public void Start()
        {
            ReadyImage = new Bitmap(Image.Width * 2, Image.Height * 2);

            DividePicture();
        }

        private void DividePicture()
        {
            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width; x++)
                {
                    var pixel = Image.GetPixel(x, y);
                    DividePixel(pixel, x, y);   
                }
            }
        }

        private void DividePixel(Color pixel, int x, int y)
        {

            if (x == 0 && y == 0)
            {
                ReadyImage.SetPixel(0, 0, pixel);
                ReadyImage.SetPixel(1, 0, GetNewColor(pixel, Image.GetPixel(1, 0)));
                ReadyImage.SetPixel(0, 1, GetNewColor(pixel, Image.GetPixel(0, 1)));
                ReadyImage.SetPixel(1, 1, GetNewColor(pixel, Image.GetPixel(1, 1), Image.GetPixel(1, 0), Image.GetPixel(0, 1)));//Review
            }
            else if (x == Image.Width - 1 && y == 0)
            {
                ReadyImage.SetPixel(2 * x, 0, pixel);
                ReadyImage.SetPixel(2 * x - 1, 0, GetNewColor(pixel, Image.GetPixel(x - 1, 0)));
                ReadyImage.SetPixel(2 * x, 1, GetNewColor(pixel, Image.GetPixel(x, 1)));
                ReadyImage.SetPixel(2 * x - 1, 1, GetNewColor(pixel, Image.GetPixel(x - 1, 0), Image.GetPixel(x - 1, 1), Image.GetPixel(x, 1)));
            }
            else if (x == 0 && y == Image.Height - 1)
            {
                ReadyImage.SetPixel(0, 2 * y, pixel);
                ReadyImage.SetPixel(0, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(0, y - 1)));
                ReadyImage.SetPixel(1, 2 * y, GetNewColor(pixel, Image.GetPixel(1, y)));
                ReadyImage.SetPixel(1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(1, y), Image.GetPixel(0, y - 1), Image.GetPixel(1, y - 1)));
            }
            else if (x == Image.Width - 1 && y == Image.Height - 1)
            {
                ReadyImage.SetPixel(2 * x, 2 * y, pixel);
                ReadyImage.SetPixel(2 * x - 1, 2 * y, GetNewColor(pixel, Image.GetPixel(x - 1, y)));
                ReadyImage.SetPixel(2 * x, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x, y - 1)));
                ReadyImage.SetPixel(2 * x - 1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x - 1, y), Image.GetPixel(x, y - 1), Image.GetPixel(x - 1, y - 1)));
            }
            else if (x == 0)
            {
                ReadyImage.SetPixel(0, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(0, y - 1)));
                ReadyImage.SetPixel(0, 2 * y, GetNewColor(pixel, Image.GetPixel(0, y + 1)));
                ReadyImage.SetPixel(1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(0, y - 1), Image.GetPixel(1, y - 1), Image.GetPixel(1, y)));
                ReadyImage.SetPixel(1, 2 * y, GetNewColor(pixel, Image.GetPixel(0, y + 1), Image.GetPixel(1, y + 1), Image.GetPixel(1, y)));
            }
            else if (x == Image.Width - 1)
            {
                ReadyImage.SetPixel(2 * x, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x, y - 1)));
                ReadyImage.SetPixel(2 * x, 2 * y, GetNewColor(pixel, Image.GetPixel(x, y + 1)));
                ReadyImage.SetPixel(2 * x - 1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x, y - 1), Image.GetPixel(x - 1, y - 1), Image.GetPixel(x - 1, y)));
                ReadyImage.SetPixel(2 * x - 1, 2 * y, GetNewColor(pixel, Image.GetPixel(x, y + 1), Image.GetPixel(x - 1, y + 1), Image.GetPixel(x - 1, y)));
            }
            else if (y == 0)
            {
                ReadyImage.SetPixel(2 * x - 1, 0, GetNewColor(pixel, Image.GetPixel(x - 1, 0)));
                ReadyImage.SetPixel(2 * x, 0, GetNewColor(pixel, Image.GetPixel(x + 1, 0)));
                ReadyImage.SetPixel(2 * x - 1, 1, GetNewColor(pixel, Image.GetPixel(x - 1, 0), Image.GetPixel(x - 1, 1), Image.GetPixel(x, 1)));
                ReadyImage.SetPixel(2 * x, 1, GetNewColor(pixel, Image.GetPixel(x + 1, 0), Image.GetPixel(x + 1, 1), Image.GetPixel(x, 1)));
            }
            else if (y == Image.Height - 1)
            {
                ReadyImage.SetPixel(2 * x - 1, 2 * y, GetNewColor(pixel, Image.GetPixel(x - 1, y)));
                ReadyImage.SetPixel(2 * x, 2 * y, GetNewColor(pixel, Image.GetPixel(x + 1, y)));
                ReadyImage.SetPixel(2 * x - 1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x - 1, y), Image.GetPixel(x - 1, y - 1), Image.GetPixel(x, y - 1)));
                ReadyImage.SetPixel(2 * x, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x + 1, y), Image.GetPixel(x + 1, y - 1), Image.GetPixel(x, y - 1)));
            }
            else
            {
                ReadyImage.SetPixel(2 * x - 1, 2 * y, GetNewColor(pixel, Image.GetPixel(x - 1, y), Image.GetPixel(x - 1, y + 1), Image.GetPixel(x, y + 1)));
                ReadyImage.SetPixel(2 * x - 1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x - 1, y), Image.GetPixel(x - 1, y - 1), Image.GetPixel(x, y - 1)));
                ReadyImage.SetPixel(2 * x, 2 * y, GetNewColor(pixel, Image.GetPixel(x, y + 1), Image.GetPixel(x + 1, y + 1), Image.GetPixel(x + 1, y)));
                ReadyImage.SetPixel(2 * x, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x, y - 1), Image.GetPixel(x + 1, y - 1), Image.GetPixel(x + 1, y)));
            }

        }

        private Color GetNewColor(Color This, params Color[] Next)
        {
            int R = This.R, G = This.G, B = This.B;
            for (int i = 0; i < Next.Length; i++)
            {
                R += Next[i].R;
                G += Next[i].G;
                B += Next[i].B;
            }
            R /= Next.Length;
            G /= Next.Length;
            B /= Next.Length;

            return Color.FromArgb(1, R, G, B);
        }
    }
}
