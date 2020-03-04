using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator_uni
{
    public partial class Form1 : Form
    {
        public RichTextBox TextBox { get; set; }

        private char _operator = '0';
        private bool _isCalculated = false;
        public Form1()
        {
            InitializeComponent();

            CreateButtons();

            TextBox = new RichTextBox
            {
                Visible = true,
                Size = new Size(365, 100),
                Location = new Point(10, 10)
            };
            this.Controls.Add(TextBox);
        }

        private void CreateButtons()
        {
            int x = 0;
            int y = 0;
            for (int i = 1; i < 10; i++)
            {
                if (x == 3)
                {
                    x = 0;
                    y++;
                }
                Button b = new Button
                {
                    Location = new Point(10 + (100 * x), 120 + 30 * y),
                    Size = new Size(100, 25),
                    Text = $"{i}",
                    Visible = true
                };
                b.Click += AnyButton_Click;
                this.Controls.Add(b);
                x++;
            }

            Button b0 = new Button
            {
                Location = new Point(110, 210),
                Size = new Size(100, 25),
                Text = "0",
                Visible = true
            };
            b0.Click += AnyButton_Click;
            this.Controls.Add(b0);

            Button badd = new Button
            {
                Location = new Point(320, 120),
                Size = new Size(50, 25),
                Text = "+",
                Visible = true
            };
            badd.Click += AnyButton_Click;
            this.Controls.Add(badd);

            Button bsub = new Button
            {
                Location = new Point(320, 150),
                Size = new Size(50, 25),
                Text = "-",
                Visible = true
            };
            bsub.Click += AnyButton_Click;
            this.Controls.Add(bsub);

            Button bmul = new Button
            {
                Location = new Point(320, 180),
                Size = new Size(50, 25),
                Text = "*",
                Visible = true
            };
            bmul.Click += AnyButton_Click;
            this.Controls.Add(bmul);

            Button bdiv = new Button
            {
                Location = new Point(320, 210),
                Size = new Size(50, 25),
                Text = "/",
                Visible = true
            };
            bdiv.Click += AnyButton_Click;
            this.Controls.Add(bdiv);

            Button bC = new Button
            {
                Location = new Point(10, 210),
                Size = new Size(100, 25),
                Text = "C",
                Visible = true
            };
            bC.Click += bC_Click;
            this.Controls.Add(bC);

            Button bresult = new Button
            {
                Location = new Point(210, 210),
                Size = new Size(100, 25),
                Text = "=",
                Visible = true
            };
            bresult.Click += bResult_Click;
            this.Controls.Add(bresult);
        }

        private void bResult_Click(object sender, EventArgs e)
        {
            if (_operator == '0')
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (!_isCalculated)
                {
                    string[] values = TextBox.Text.Split(_operator);
                    int[] numbers = new int[values.Length];

                    for (int i = 0; i < values.Length; i++)
                    {
                        int.TryParse(values[i], out numbers[i]);
                    }

                    double result = Calculate(numbers, _operator);

                    _isCalculated = true;

                    TextBox.Text += "=" + result.ToString();
                }
            }
        }

        private double Calculate(int[] numbers, char @operator)
        {
            double result = 0.0;
            switch (@operator)
            {
                case '+':
                    result = numbers[0] + numbers[1];
                    break;
                case '-':
                    result = numbers[0] - numbers[1];
                    break;
                case '/':
                    result = numbers[0] / numbers[1];
                    break;
                case '*':
                    result = numbers[0] * numbers[1];
                    break;
                default:
                    break;
            }
            return result;
        }

        private void bC_Click(object sender, EventArgs e)
        {
            this.TextBox.Text = "";
            _operator = '0';
            _isCalculated = false;
        }

        private void AnyButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            this.TextBox.Text += b.Text;

            if (b.Text == "+"
                || b.Text == "-"
                || b.Text == "/"
                || b.Text == "*")
                _operator = b.Text.ToCharArray()[0];
        }
    }
}
