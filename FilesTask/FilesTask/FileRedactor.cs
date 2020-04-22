using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesTask
{
    public partial class FileRedactor : Form
    {
        public FileRedactor(string path)
        {
            InitializeComponent();

            RichTextBox textBox = new RichTextBox()
            {
                Size = new Size(this.Width - 25, this.Height - 50),
                Location = new Point(5, 5),
                Visible = true,
                ReadOnly = true,
                BackColor = Color.White
            };
            string text = "";
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] buf = new byte[1024];
                int c;

                while ((c = fs.Read(buf, 0, buf.Length)) > 0)
                {
                    text += Encoding.UTF8.GetString(buf, 0, c);
                }
            }

            textBox.Text = text;
            Controls.Add(textBox);
        }
    }
}
