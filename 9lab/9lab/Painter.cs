using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9lab
{
    public class Painter
    {
        static public void Paint(IDraw shape)
        {
            shape.Draw();
        }

        static public void Paint(params IDraw[] shapes)
        {
            foreach (IDraw shape in shapes)
            {
                shape.Draw();
            }
        }

        static public void Paint(List<IDraw> shapes)
        {
            foreach (IDraw shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}
