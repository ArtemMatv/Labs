using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResizeImage;

namespace ResizingImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Зображення(*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg";
            saveFileDialog1.Filter = "Зображення(*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg";

            MyImage = new Resizing(); ;
        }

        private Resizing MyImage { get; set; }

        private void ButtonChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            MyImage.Image = new Bitmap(openFileDialog1.OpenFile());
            pictureBoxChosen.Image = MyImage.Image;
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            MyImage.Start();
            pictureBoxReady.Image = MyImage.ReadyImage;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            MyImage.ReadyImage.Save(saveFileDialog1.FileName);
        }
    }
}
