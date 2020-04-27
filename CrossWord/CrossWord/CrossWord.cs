using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CrossWord
{
    public partial class CrossWord : Form
    {
        private readonly XmlDocument _configuration;
        private int _widthCapacity;
        private int _heightCapacity;
        public CrossWord()
        {
            InitializeComponent();

            _configuration = new XmlDocument();
            _configuration.Load(ConfigurationManager.AppSettings["configuration"]);

            FindCapacities();
            BuildCrossword();
            AddDefinitions();
        }

        private void FindCapacities()
        {
            _widthCapacity = 0;
            _heightCapacity = 0;

            foreach (XmlElement word in _configuration.DocumentElement.FirstChild)
            {
                int x = int.Parse(word.Attributes["x"].Value);
                int y = int.Parse(word.Attributes["y"].Value);
                int length = int.Parse(word.Attributes["length"].Value);

                if (x + length > _widthCapacity
                    && word.Attributes["position"].Value == "0")
                {
                    _widthCapacity = x + length;
                }

                if (y + length > _heightCapacity
                    && word.Attributes["position"].Value == "1")
                {
                    _heightCapacity = y + length;
                }
            }
        }

        private void BuildCrossword()
        {
            TableLayoutPanel crossword = new TableLayoutPanel()
            {
                ColumnCount = _widthCapacity,
                RowCount = _heightCapacity,
                Width = int.Parse(_configuration.DocumentElement.FirstChild.Attributes["width"].Value) + 5,
                Height = int.Parse(_configuration.DocumentElement.FirstChild.Attributes["height"].Value) + 5,
                Location = new Point(0, 0),
                BackColor = Color.Red
            };


            int elementWidth = (int.Parse(_configuration.DocumentElement.FirstChild.Attributes["width"].Value)
                - _widthCapacity * 5) / _widthCapacity;

            int elementHeight = (int.Parse(_configuration.DocumentElement.FirstChild.Attributes["height"].Value)
                - _heightCapacity * 5) / _heightCapacity;

            List<string> positions = new List<string>();


            foreach (XmlElement conf in _configuration.DocumentElement.FirstChild)
            {
                int x = int.Parse(conf.Attributes["x"].Value);
                int y = int.Parse(conf.Attributes["y"].Value);
                int length = int.Parse(conf.Attributes["length"].Value);

                if (conf.Attributes["position"].Value == "0")
                {
                    for (int i = 0; i < length; i++)
                    {
                        RichTextBox box = new RichTextBox()
                        {
                            MaxLength = 1,
                            Width = elementWidth,
                            Height = elementHeight,
                            Font = new Font("Arial", elementWidth / 2)
                        };

                        if (!positions.Contains((x + i).ToString() + ";" + y))
                        {
                            positions.Add((x + i).ToString() + ";" + y);
                            crossword.Controls.Add(box, x + i, y);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < length; i++)
                    {
                        RichTextBox box = new RichTextBox()
                        {
                            MaxLength = 1,
                            Width = elementWidth,
                            Height = elementHeight,
                            Font = new Font("Arial", elementWidth / 2)
                        };

                        if (!positions.Contains(x + ";" + (y + i).ToString()))
                        {
                            positions.Add(x + ";" + (y + i).ToString());
                            crossword.Controls.Add(box, x, y + i);
                        }
                    }
                }
            }
            Controls.Add(crossword);
        }
        private void AddDefinitions()
        {
            int i = 0;
            foreach (XmlElement item in _configuration.DocumentElement.LastChild)
            {
                string position = _configuration.DocumentElement.FirstChild.ChildNodes[i].Attributes["position"].Value == "0"
                    ? "горизонталь" : "вертикаль";
                Label definition = new Label()
                {
                    Text = (i + 1) + " (" + position + "): " + item.FirstChild.InnerText,
                    Font = new Font("Arial", 15),
                    Location = new Point(
                        int.Parse(_configuration.DocumentElement.FirstChild.Attributes["width"].Value) + 10,
                        30 * i)
                };

                definition.Width = Width - definition.Location.X;

                SizeChanged += (s, e) =>
                {
                    definition.Width = Width - definition.Location.X;
                };

                Controls.Add(definition);
                i++;
            }
        }
    }
}
