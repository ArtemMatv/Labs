using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace CrossWord
{
    public partial class Form1 : Form
    {
        private XmlDocument _configuration;
        private int _amount;
        private readonly string _configPath;
        private List<int> lengths;
        public Form1()
        {
            InitializeComponent();

            Width = 580;
            Height = 600;

            Button usePrevious = new Button()
            {
                Location = new Point(360, 25),
                Size = new Size(200, 30),
                Text = "Використати останню конфігурацію"
            };
            usePrevious.Click += (s, e) =>
            {
                CrossWord crossWord = new CrossWord();

                crossWord.FormClosed += (senser, evArgs) =>
                {
                    Close();
                };

                crossWord.Show();
                Hide();
            };
            Controls.Add(usePrevious);

            Text = "Генератор кросвордів";

            _amount = 0;
            _configPath = ConfigurationManager.AppSettings["configuration"];

            CreateStartControls();
        }

        private void CreateStartControls()
        {
            Label wLabel = new Label()
            {
                Location = new Point(10, 10),
                Size = new Size(100, 20),
                Text = "Ширина:"
            };
            NumericUpDown width = new NumericUpDown()
            {
                Maximum = 1366,
                Minimum = 100,
                Width = 100,
                Location = new Point(10, 30)
            };

            Label hLabel = new Label()
            {
                Location = new Point(120, 10),
                Size = new Size(100, 20),
                Text = "Висота:"
            };
            NumericUpDown height = new NumericUpDown()
            {
                Maximum = 768,
                Minimum = 100,
                Width = 100,
                Location = new Point(120, 30)
            };

            Button buttonAccept = new Button()
            {
                Text = "Підтвердити",
                Size = new Size(100, 30),
                Location = new Point(250, 25)
            };
            buttonAccept.Click += (s, e) =>
            {
                if (_amount > 1)
                {
                    SaveConfiguration(width.Value, height.Value);
                    GoToWordCreating();
                }
                else
                {
                    Label ex = new Label()
                    {
                        Location = new Point(370, 20),
                        Width = 150,
                        Text = "Too few words!",
                        Font = new Font("Arial", 12),
                        ForeColor = Color.Red
                    };
                    Controls.Add(ex);
                }
            };

            Label xLabel = new Label()
            {
                Location = new Point(10, 60),
                Size = new Size(40, 20),
                Text = "X:"
            };
            NumericUpDown wordX = new NumericUpDown()
            {
                Maximum = 100,
                Minimum = 0,
                Width = 40,
                Location = new Point(10, 80)
            };

            Label yLabel = new Label()
            {
                Location = new Point(60, 60),
                Size = new Size(40, 20),
                Text = "Y:"
            };
            NumericUpDown wordY = new NumericUpDown()
            {
                Maximum = 100,
                Minimum = 0,
                Width = 40,
                Location = new Point(60, 80)
            };

            Label lengthLabel = new Label()
            {
                Location = new Point(110, 60),
                Size = new Size(60, 20),
                Text = "Довжина:"
            };
            NumericUpDown wordLength = new NumericUpDown()
            {
                Maximum = 100,
                Minimum = 1,
                Width = 60,
                Location = new Point(110, 80)
            };

            Label positionLabel = new Label()
            {
                Location = new Point(190, 60),
                Size = new Size(100, 20),
                Text = "Положення:"
            };
            ComboBox wordPosition = new ComboBox()
            {
                Location = new Point(190, 80)
            };

            wordPosition.Items.Add("Горизонтальне");
            wordPosition.Items.Add("Ветикальне");
            wordPosition.SelectedIndex = 0;

            Button buttonAddConfig = new Button()
            {
                Location = new Point(330, 79),
                Text = "Додати слово"
            };
            buttonAddConfig.Click += (s, e) =>
            {
                AddConfig(wordX, wordY, wordLength, wordPosition);
            };

            Controls.Add(xLabel);
            Controls.Add(wordX);
            Controls.Add(yLabel);
            Controls.Add(wordY);
            Controls.Add(lengthLabel);
            Controls.Add(wordLength);
            Controls.Add(positionLabel);
            Controls.Add(wordPosition);
            Controls.Add(buttonAddConfig);

            Controls.Add(wLabel);
            Controls.Add(width);
            Controls.Add(hLabel);
            Controls.Add(height);
            Controls.Add(buttonAccept);
        }

        private void SaveConfiguration(decimal cWidth, decimal cHeight)
        {
            XmlNode config = _configuration.DocumentElement.FirstChild;

            XmlAttribute width = _configuration.CreateAttribute("width");
            XmlAttribute height = _configuration.CreateAttribute("height");

            width.AppendChild(_configuration.CreateTextNode(cWidth.ToString()));
            height.AppendChild(_configuration.CreateTextNode(cHeight.ToString()));

            config.Attributes.Append(width);
            config.Attributes.Append(height);

            _configuration.DocumentElement.AppendChild(config);
        }

        private void GoToWordCreating()
        {
            Controls.Clear();
            Width = 665;
            Height = 600;

            Label nameLabel = new Label()
            {
                Location = new Point(10, 10),
                Size = new Size(100, 20),
                Text = "Слово:"
            };

            Label definitionLabel = new Label()
            {
                Location = new Point(120, 10),
                Size = new Size(100, 20),
                Text = "Визначення:"
            };

            for (int i = 0; i < _amount; i++)
            {

                TextBox wordName = new TextBox()
                {
                    Location = new Point(10, 30 + i * 50),
                    Width = 100,
                    MaxLength = lengths[i]
                };

                RichTextBox wordDefinition = new RichTextBox()
                {
                    Location = new Point(120, 30 + i * 50),
                    Width = 200,
                    Height = 40
                };

                Controls.Add(nameLabel);
                Controls.Add(wordName);
                Controls.Add(definitionLabel);
                Controls.Add(wordDefinition);
            }

            Button createCrossword = new Button()
            {
                Location = new Point(325, 30),
                Text = "Створити"
            };
            createCrossword.Click += (s, e) =>
            {
                AddWords();

                CrossWord crossWord = new CrossWord();

                crossWord.FormClosed += (senser, evArgs) =>
                {
                    Close();
                };

                crossWord.Show();
                Hide();
            };

            Controls.Add(createCrossword);
        }

        private void AddConfig(NumericUpDown x,
                               NumericUpDown y,
                               NumericUpDown length,
                               ComboBox position)
        {
            XmlNode config;
            if (_amount == 0)
            {
                _configuration = new XmlDocument();
                _configuration.Load(_configPath);
                _configuration.DocumentElement.RemoveAll();
                config = _configuration.CreateElement("configuration");
            }
            else
            {
                config = _configuration.DocumentElement.FirstChild;
            }

            XmlElement wConf = _configuration.CreateElement("wConf");

            XmlAttribute xXml = _configuration.CreateAttribute("x");
            xXml.AppendChild(_configuration.CreateTextNode(x.Value.ToString()));

            XmlAttribute yXml = _configuration.CreateAttribute("y");
            yXml.AppendChild(_configuration.CreateTextNode(y.Value.ToString()));

            XmlAttribute lengthXml = _configuration.CreateAttribute("length");
            lengthXml.AppendChild(_configuration.CreateTextNode(length.Value.ToString()));

            XmlAttribute positionXml = _configuration.CreateAttribute("position");
            positionXml.AppendChild(_configuration.CreateTextNode(position.SelectedIndex.ToString()));

            wConf.Attributes.Append(xXml);
            wConf.Attributes.Append(yXml);
            wConf.Attributes.Append(lengthXml);
            wConf.Attributes.Append(positionXml);

            config.AppendChild(wConf);
            _configuration.DocumentElement.AppendChild(config);



            if (lengths == null)
                lengths = new List<int>();

            lengths.Add((int)length.Value);

            CreateLabelsAndMoveControls(x, y, length, position);

            _amount++;
        }

        private void AddWords()
        {
            XmlElement words = _configuration.CreateElement("words");
            _configuration.DocumentElement.AppendChild(words);
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    XmlElement word = _configuration.CreateElement("word");

                    XmlAttribute name = _configuration.CreateAttribute("name");
                    name.AppendChild(_configuration.CreateTextNode((item as TextBox).Text));
                    word.Attributes.Append(name);

                    words.AppendChild(word);
                }

                if (item is RichTextBox)
                {
                    XmlNode word = words.LastChild;

                    XmlElement definition = _configuration.CreateElement("definition");
                    definition.AppendChild(_configuration.CreateTextNode((item as RichTextBox).Text));

                    word.AppendChild(definition);
                }
            }
            _configuration.Save(_configPath);
        }

        private void CreateLabelsAndMoveControls(params Control[] controls)
        {
            foreach (Control item in controls)
            {
                Label label = new Label()
                {
                    Location = item.Location,
                    Text = item.Text,
                    Width = item.Width
                };

                item.Location = new Point(
                    item.Location.X,
                    item.Location.Y + 50
                    );

                Controls.Add(label);
            }
        }
    }
}
