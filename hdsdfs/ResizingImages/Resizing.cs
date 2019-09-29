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

        private Bitmap TMPImage { get; set; }

        public Bitmap ReadyImage { get; set; }

        public Resizing()
        {

        }

        public void Start()
        {
            TMPImage = new Bitmap(Image.Width * 2, Image.Height * 2);

            DividePicture();

            TurnTheImageBack();
        }

        private void TurnTheImageBack()
        {
            ReadyImage = new Bitmap(Image.Width, Image.Height);
            for (int y = 0; y < TMPImage.Height; y += 2)
            {
                for (int x = 0; x < TMPImage.Width - 1; x += 2)
                {
                    var pixel1 = TMPImage.GetPixel(x, y);
                    var pixel2 = TMPImage.GetPixel(x + 1, y);
                    var pixel3 = TMPImage.GetPixel(x, y + 1);
                    var pixel4 = TMPImage.GetPixel(x + 1, y + 1);
                    SetPixel(pixel1, pixel2, pixel3, pixel4, x, y);
                }
            }
        }

        private void SetPixel(Color pixel1, Color pixel2, Color pixel3, Color pixel4, int x, int y)
        {
            ReadyImage.SetPixel((x + 1) / 2, (y + 1) / 2, GetNewColor(pixel1, pixel2, pixel3, pixel4));
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
                TMPImage.SetPixel(0, 0, pixel);
                TMPImage.SetPixel(1, 0, GetNewColor(pixel, Image.GetPixel(1, 0)));
                TMPImage.SetPixel(0, 1, GetNewColor(pixel, Image.GetPixel(0, 1)));
                TMPImage.SetPixel(1, 1, GetNewColor(pixel, Image.GetPixel(1, 1), Image.GetPixel(1, 0), Image.GetPixel(0, 1)));//Review
            }
            else if (x == Image.Width - 1 && y == 0)
            {
                TMPImage.SetPixel(2 * x, 0, pixel);
                TMPImage.SetPixel(2 * x - 1, 0, GetNewColor(pixel, Image.GetPixel(x - 1, 0)));
                TMPImage.SetPixel(2 * x, 1, GetNewColor(pixel, Image.GetPixel(x, 1)));
                TMPImage.SetPixel(2 * x - 1, 1, GetNewColor(pixel, Image.GetPixel(x - 1, 0), Image.GetPixel(x - 1, 1), Image.GetPixel(x, 1)));
            }
            else if (x == 0 && y == Image.Height - 1)
            {
                TMPImage.SetPixel(0, 2 * y, pixel);
                TMPImage.SetPixel(0, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(0, y - 1)));
                TMPImage.SetPixel(1, 2 * y, GetNewColor(pixel, Image.GetPixel(1, y)));
                TMPImage.SetPixel(1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(1, y), Image.GetPixel(0, y - 1), Image.GetPixel(1, y - 1)));
            }
            else if (x == Image.Width - 1 && y == Image.Height - 1)
            {
                TMPImage.SetPixel(2 * x, 2 * y, pixel);
                TMPImage.SetPixel(2 * x - 1, 2 * y, GetNewColor(pixel, Image.GetPixel(x - 1, y)));
                TMPImage.SetPixel(2 * x, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x, y - 1)));
                TMPImage.SetPixel(2 * x - 1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x - 1, y), Image.GetPixel(x, y - 1), Image.GetPixel(x - 1, y - 1)));
            }
            else if (x == 0)
            {
                TMPImage.SetPixel(0, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(0, y - 1)));
                TMPImage.SetPixel(0, 2 * y, GetNewColor(pixel, Image.GetPixel(0, y + 1)));
                TMPImage.SetPixel(1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(0, y - 1), Image.GetPixel(1, y - 1), Image.GetPixel(1, y)));
                TMPImage.SetPixel(1, 2 * y, GetNewColor(pixel, Image.GetPixel(0, y + 1), Image.GetPixel(1, y + 1), Image.GetPixel(1, y)));
            }
            else if (x == Image.Width - 1)
            {
                TMPImage.SetPixel(2 * x, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x, y - 1)));
                TMPImage.SetPixel(2 * x, 2 * y, GetNewColor(pixel, Image.GetPixel(x, y + 1)));
                TMPImage.SetPixel(2 * x - 1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x, y - 1), Image.GetPixel(x - 1, y - 1), Image.GetPixel(x - 1, y)));
                TMPImage.SetPixel(2 * x - 1, 2 * y, GetNewColor(pixel, Image.GetPixel(x, y + 1), Image.GetPixel(x - 1, y + 1), Image.GetPixel(x - 1, y)));
            }
            else if (y == 0)
            {
                TMPImage.SetPixel(2 * x - 1, 0, GetNewColor(pixel, Image.GetPixel(x - 1, 0)));
                TMPImage.SetPixel(2 * x, 0, GetNewColor(pixel, Image.GetPixel(x + 1, 0)));
                TMPImage.SetPixel(2 * x - 1, 1, GetNewColor(pixel, Image.GetPixel(x - 1, 0), Image.GetPixel(x - 1, 1), Image.GetPixel(x, 1)));
                TMPImage.SetPixel(2 * x, 1, GetNewColor(pixel, Image.GetPixel(x + 1, 0), Image.GetPixel(x + 1, 1), Image.GetPixel(x, 1)));
            }
            else if (y == Image.Height - 1)
            {
                TMPImage.SetPixel(2 * x - 1, 2 * y, GetNewColor(pixel, Image.GetPixel(x - 1, y)));
                TMPImage.SetPixel(2 * x, 2 * y, GetNewColor(pixel, Image.GetPixel(x + 1, y)));
                TMPImage.SetPixel(2 * x - 1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x - 1, y), Image.GetPixel(x - 1, y - 1), Image.GetPixel(x, y - 1)));
                TMPImage.SetPixel(2 * x, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x + 1, y), Image.GetPixel(x + 1, y - 1), Image.GetPixel(x, y - 1)));
            }
            else
            {
                TMPImage.SetPixel(2 * x - 1, 2 * y, GetNewColor(pixel, Image.GetPixel(x - 1, y), Image.GetPixel(x - 1, y + 1), Image.GetPixel(x, y + 1)));
                TMPImage.SetPixel(2 * x - 1, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x - 1, y), Image.GetPixel(x - 1, y - 1), Image.GetPixel(x, y - 1)));
                TMPImage.SetPixel(2 * x, 2 * y, GetNewColor(pixel, Image.GetPixel(x, y + 1), Image.GetPixel(x + 1, y + 1), Image.GetPixel(x + 1, y)));
                TMPImage.SetPixel(2 * x, 2 * y - 1, GetNewColor(pixel, Image.GetPixel(x, y - 1), Image.GetPixel(x + 1, y - 1), Image.GetPixel(x + 1, y)));
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
            R /= Next.Length + 1;
            G /= Next.Length + 1;
            B /= Next.Length + 1;

            return Color.FromArgb(255, R, G, B);
        }
    }
}
