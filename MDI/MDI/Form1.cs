using MDI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class Form1 : Form
    {
        private Bitmap Image = new Bitmap(Resources.image);
        private int _clickAmount;
        private int _textBoxNumValue;
        private string _childLabel => textBoxLabel.Text + " " + textBoxNum.Text;
        public Form1()
        {
            InitializeComponent();
            ReStyle();

            _clickAmount = 0;
            int.TryParse(textBoxNum.Text, out _textBoxNumValue);
        }

        private void ReStyle()
        {
            comboBoxNumActions.SelectedIndex = 0;

            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.FlatAppearance.BorderSize = 0;

            ToolStripMenuItem fileItem = new ToolStripMenuItem("File");

            fileItem.Click += (s, e) => { label1.Text = "File:"; };
            fileItem.DropDownItems.Add("New         CTRL+N", Image);
            fileItem.DropDownItems[0].Click +=
                (s, e) =>
                {
                    label2.Text = "New";
                    CreateWindow();
                };
            fileItem.DropDownItems.Add("Empty");
            fileItem.DropDownItems[1].Click += (s, e) => { label2.Text = "Empty"; };

            menuStrip1.Items.Add(fileItem);

            ToolStripMenuItem rootItem = new ToolStripMenuItem("Root 1");

            rootItem.Click += (s, e) => { label1.Text = "Root:"; };
            rootItem.DropDownItems.Add("Item 1");
            rootItem.DropDownItems[0].Click += (s, e) => { label2.Text = "Item 1"; };
            rootItem.DropDownItems.Add("Item 2");
            rootItem.DropDownItems[0].Click += (s, e) => { label2.Text = "Item 2"; };

            menuStrip1.Items.Add(rootItem);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            _clickAmount++;

            textBoxAmount.Text = _clickAmount.ToString();
            label1.Text = "File:";
            label2.Text = "New";

            if (!int.TryParse(textBoxNum.Text, out _textBoxNumValue))
            {
                textBoxNum.Text = _textBoxNumValue.ToString();
            }

            CreateWindow();

            TextBoxAction();
        }

        private void TextBoxAction()
        {
            switch (comboBoxNumActions.SelectedItem.ToString())
            {
                case "Increment Num":
                    textBoxNum.Text = (++_textBoxNumValue).ToString();
                    break;
                case "Decrement Num":
                    textBoxNum.Text = (--_textBoxNumValue).ToString();
                    break;
                case "Same Num":
                    break;
            }
        }

        private void CreateWindow()
        {
            ChildForm form = new ChildForm(
                new Point(200 + _clickAmount * 5, 50 + _clickAmount * 5),
                _childLabel)
            {
                MdiParent = this
            };
            form.Show();
            IncrementProgressBar();
        }

        private void IncrementProgressBar()
        {
            if (progressBar1.Value == 10)
                progressBar1.Value = 0;
            else
                progressBar1.Value++;
        }
    }
}
