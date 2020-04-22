using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsCSharpLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int offset = 1;
            foreach (var item in this.chart1.Series)
            {
                
                for (double i = 100.1; i <= 140; i+=0.1)
                {
                    item.Points.AddXY(i, Math.Sin(i * offset/2)*70 + offset*130);
                }
                offset++;
            }
            
        }
    }
}
