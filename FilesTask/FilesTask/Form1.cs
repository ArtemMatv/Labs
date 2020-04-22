using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FilesTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Button create100FoldersOneByOne = new Button()
            {
                Visible = true,
                Size = new Size(150, 25),
                Location = new Point(10, 10),
                Text = "Create 100 Folders!!!"
            };
            create100FoldersOneByOne.Click += OneByOne;

            Button create100Subfolders = new Button()
            {
                Visible = true,
                Size = new Size(150, 25),
                Location = new Point(170, 10),
                Text = "Create 100 Subfolders!!!"
            };
            create100Subfolders.Click += Subfolders;

            Controls.Add(create100FoldersOneByOne);
            Controls.Add(create100Subfolders);

            FileSearch();
        }

        private void Subfolders(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["subfolder"] + "\\Folder_";
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Directory.CreateDirectory(path + i);
                    path += i + "\\Folder_";
                }
                catch (PathTooLongException)
                {
                    Label exLabel = new Label()
                    {
                        Text = (i + 1) + " folders created,\n" +
                        "imposible create more (260 chars limit)\n" +
                        "the last folder name:\n" +
                        "Folder_" + i,
                        Font = new Font("Arial", 10),
                        ForeColor = Color.Red,
                        Visible = true,
                        Location = new Point(170, 50),
                        Size = new Size(200, 100)
                    };
                    Controls.Add(exLabel);
                    break;
                }
            }
        }

        private void OneByOne(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["oneByOne"] + "\\Folder_";
            for (int i = 0; i < 100; i++)
            {
                Directory.CreateDirectory(path + i);
            }
            Label successLabel = new Label()
            {
                Text = "Folders created",
                Font = new Font("Arial", 10),
                ForeColor = Color.Green,
                Visible = true,
                Location = new Point(10, 50),
                Size = new Size(150, 100)
            };
            Controls.Add(successLabel);
        }

        private void FileSearch()
        {
            TextBox searchField = new TextBox()
            {
                Visible = true,
                Width = 200,
                Location = new Point(10, 150)
            };

            TableLayoutPanel searchResult = null;
            Label searchError = null;

            Button searchButton = new Button()
            {
                Visible = true,
                Size = new Size(100, 22),
                Location = new Point(210, 149),
                Text = "Search file"
            };
            searchButton.Click += (s, e) =>
            {
                string[] result = Directory.GetFiles(
                    ConfigurationManager.AppSettings["searchPath"],
                    searchField.Text,
                    SearchOption.AllDirectories
                    );

                ProcessSearchResult(ref searchResult, ref searchError, result);
            };

            Label noteLabel = new Label()
            {
                Text = "Note: search is provided in folder 'AllFoldersAreHere'",
                ForeColor = Color.FromArgb(210, 210, 0),
                Font = new Font("Arial", 10),
                Location = new Point(330, 152),
                Width = 500
            };

            Controls.Add(searchField);
            Controls.Add(searchButton);
            Controls.Add(noteLabel);
        }

        private void ProcessSearchResult(ref TableLayoutPanel searchResult, ref Label searchError, string[] result)
        {
            if (result.Length != 0)
            {
                if (Controls.Contains(searchError))
                    Controls.Remove(searchError);

                searchResult = new TableLayoutPanel()
                {
                    Size = new Size(700, result.Length * 25 +50),
                    Location = new Point(10, 180),
                    Visible = true,
                    ColumnCount = 1,
                    RowCount = result.Length + 1,
                    BackColor = Color.White,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
                };

                for (int i = 0; i < result.Length; i++)
                {
                    Label item = new Label()
                    {
                        Text = result[i],
                        Width = 650
                    };

                    item.Click += OpenFile;

                    searchResult.Controls.Add(item, 1, i);
                }

                Controls.Add(searchResult);
            }
            else
            {
                if (Controls.Contains(searchResult))
                    Controls.Remove(searchResult);

                searchError = new Label()
                {
                    Size = new Size(100, 50),
                    Location = new Point(10, 180),
                    Visible = true,
                    ForeColor = Color.Red,
                    Text = "Nothing found"
                };
                Controls.Add(searchError);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                string filePath = (sender as Label).Text;
                FileRedactor redactor = new FileRedactor(filePath);
                redactor.Show();
            }
        }
    }
}
