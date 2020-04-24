using ProgramThatSavesItsStatus.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ProgramThatSavesItsStatus
{
    public partial class ResultForm : Form
    {
        private SaveType _type;
        private TextBox textBox = null;
        private CheckBox firstBox = null;
        private CheckBox secondBox = null;

        public ResultForm(SaveType type)
        {
            InitializeComponent();
            _type = type;
            this.FormClosing += SaveData;
            this.StartPosition = FormStartPosition.Manual;

            CreateControls();

            GetSavedData();
        }
        private void CreateControls()
        {
            textBox = new TextBox()
            {
                Width = 300,
                Location = new Point(30, 10)
            };

            firstBox = new CheckBox()
            {
                Location = new Point(10, 9)
            };

            secondBox = new CheckBox()
            {
                Location = new Point(334, 9)
            };

            Controls.Add(textBox);
            Controls.Add(firstBox);
            Controls.Add(secondBox);
        }
        private void GetSavedData()
        {
            switch (_type)
            {
                case SaveType.XML:
                    GetFromXML();
                    break;
                case SaveType.TXT:
                    GetFromTXT();
                    break;
                case SaveType.Binary:
                    GetFromBinary();
                    break;
                case SaveType.Register:
                    GetFromRegister();
                    break;
                default:
                    break;
            }
        }

        private void GetFromXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(ConfigurationManager.AppSettings["fileXml"]);

            XmlElement xRoot = xDoc.DocumentElement;

            firstBox.Checked = xRoot.ChildNodes[0].Attributes["first"].Value == "True";
            secondBox.Checked = xRoot.ChildNodes[0].Attributes["second"].Value == "True";

            textBox.Text = xRoot.ChildNodes[0].FirstChild.InnerText;

            Width = int.Parse(xRoot.ChildNodes[1].Attributes["width"].Value);
            Height = int.Parse(xRoot.ChildNodes[1].Attributes["height"].Value);

            SetDesktopLocation(
                int.Parse(xRoot.ChildNodes[2].Attributes["x"].Value),
                int.Parse(xRoot.ChildNodes[2].Attributes["y"].Value)
                );
        }

        private void GetFromTXT()
        {
            using (var sr = new StreamReader(ConfigurationManager.AppSettings["fileTXT"]))
            {
                string fileContent = sr.ReadToEnd();
                if (fileContent != "")
                {
                    string[] saves = fileContent.Split('|');

                    firstBox.Checked = saves[0] == "True";
                    secondBox.Checked = saves[1] == "True";

                    textBox.Text = saves[2];

                    Width = int.Parse(saves[3]);
                    Height = int.Parse(saves[4]);

                    SetDesktopLocation(int.Parse(saves[5]), int.Parse(saves[6]));
                }
            }
        }

        private void GetFromBinary()
        {
            using (BinaryReader binaryReader = new BinaryReader(
               File.Open(ConfigurationManager.AppSettings["fileBinary"],
               FileMode.Open)))
            {
                firstBox.Checked = binaryReader.ReadString() == "True\n";
                secondBox.Checked = binaryReader.ReadString() == "True\n";
                textBox.Text = binaryReader.ReadString();

                Width = int.Parse(binaryReader.ReadString());
                Height = int.Parse(binaryReader.ReadString());

                SetDesktopLocation(
                    int.Parse(binaryReader.ReadString()),
                    int.Parse(binaryReader.ReadString())
                    );
            }
        }

        private void GetFromRegister()
        {
            if (Registry.CurrentUser.GetSubKeyNames().Contains("homeworkContent"))
            {
                RegistryKey content = Registry.CurrentUser.OpenSubKey("homeworkContent");

                firstBox.Checked = (string)content.GetValue("first") == "True";
                secondBox.Checked = (string)content.GetValue("second") == "True";
                textBox.Text = (string)content.GetValue("text");

                Width = (int)content.GetValue("width");
                Height = (int)content.GetValue("height");

                SetDesktopLocation(
                    (int)content.GetValue("x"),
                    (int)content.GetValue("y")
                    );
            }

        }

        private void SaveData(object sender, FormClosingEventArgs e)
        {
            switch (_type)
            {
                case SaveType.XML:
                    SaveToXml();
                    break;
                case SaveType.TXT:
                    SaveToTXT();
                    break;
                case SaveType.Binary:
                    SaveToBinary();
                    break;
                case SaveType.Register:
                    SaveToRegister();
                    break;
                default:
                    break;
            }
        }

        private void SaveToRegister()
        {
            if (Registry.CurrentUser.GetSubKeyNames().Contains("homeworkContent"))
                Registry.CurrentUser.DeleteSubKey("homeworkContent");

            RegistryKey content = Registry.CurrentUser.CreateSubKey("homeworkContent");

            content.SetValue("first", firstBox.Checked);
            content.SetValue("second", secondBox.Checked);
            content.SetValue("text", textBox.Text);
            content.SetValue("width", Width);
            content.SetValue("height", Height);
            content.SetValue("x", Location.X);
            content.SetValue("y", Location.Y);
        }

        private void SaveToBinary()
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(
                File.Open(ConfigurationManager.AppSettings["fileBinary"],
                FileMode.OpenOrCreate)))
            {
                binaryWriter.Write(firstBox.Checked + "\n");
                binaryWriter.Write(secondBox.Checked + "\n");
                binaryWriter.Write(textBox.Text + "\n");
                binaryWriter.Write(Size.Width + "\n");
                binaryWriter.Write(Size.Height + "\n");
                binaryWriter.Write(Location.X + "\n");
                binaryWriter.Write(Location.Y + "\n");
            }
        }

        private void SaveToXml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(ConfigurationManager.AppSettings["fileXml"]);

            XmlElement xRoot = xDoc.DocumentElement;

            XmlElement content = xDoc.CreateElement("content");
            XmlAttribute firstBoxChecked = xDoc.CreateAttribute("first");
            XmlAttribute secondBoxChecked = xDoc.CreateAttribute("second");
            XmlElement textBoxText = xDoc.CreateElement("text");

            XmlElement formSize = xDoc.CreateElement("size");
            XmlAttribute width = xDoc.CreateAttribute("width");
            XmlAttribute height = xDoc.CreateAttribute("height");

            XmlElement formLocation = xDoc.CreateElement("location");
            XmlAttribute x = xDoc.CreateAttribute("x");
            XmlAttribute y = xDoc.CreateAttribute("y");

            XmlText firstText = xDoc.CreateTextNode(firstBox.Checked.ToString());
            XmlText secondText = xDoc.CreateTextNode(secondBox.Checked.ToString());
            XmlText text = xDoc.CreateTextNode(textBox.Text);

            XmlText widthText = xDoc.CreateTextNode(Size.Width.ToString());
            XmlText heightText = xDoc.CreateTextNode(Size.Height.ToString());

            XmlText xText = xDoc.CreateTextNode(Location.X.ToString());
            XmlText yText = xDoc.CreateTextNode(Location.Y.ToString());

            firstBoxChecked.AppendChild(firstText);
            secondBoxChecked.AppendChild(secondText);
            textBoxText.AppendChild(text);

            width.AppendChild(widthText);
            height.AppendChild(heightText);

            x.AppendChild(xText);
            y.AppendChild(yText);

            content.Attributes.Append(firstBoxChecked);
            content.Attributes.Append(secondBoxChecked);
            content.AppendChild(textBoxText);

            formSize.Attributes.Append(width);
            formSize.Attributes.Append(height);

            formLocation.Attributes.Append(x);
            formLocation.Attributes.Append(y);

            xRoot.RemoveAll();

            xRoot.AppendChild(content);
            xRoot.AppendChild(formSize);
            xRoot.AppendChild(formLocation);

            xDoc.Save(ConfigurationManager.AppSettings["fileXml"]);
        }

        private void SaveToTXT()
        {
            using (var sw = new StreamWriter(ConfigurationManager.AppSettings["fileTXT"]))
            {
                sw.Write(firstBox.Checked +
                    "|" + secondBox.Checked +
                    "|" + textBox.Text +
                    "|" + Size.Width +
                    "|" + Size.Height +
                    "|" + Location.X +
                    "|" + Location.Y);
            }
        }
    }
}
