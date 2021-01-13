using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ComicsReader.QuickAccessModels
{
    public partial class QuickAccess : UserControl
    {
        int y = 0;

        public QuickAccess()
        {
            InitializeComponent();
            
        }

        private void addFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    QAFolder folder = new QAFolder()
                    {
                        Location = fbd.SelectedPath,
                        Count = Directory.GetFiles(fbd.SelectedPath, "*.cbr", SearchOption.AllDirectories).Length + Directory.GetFiles(fbd.SelectedPath, "*.cbz", SearchOption.AllDirectories).Length
                    };

                    QAFolderButton btn = new QAFolderButton(folder, 0, y, this);
                    QAPANEL.Controls.Add(btn.Label);
                    y += 25;
                }
            }
        }

        public void LoadContent(List<string> folders, List<string> files)
        {
            foreach (Control c in QAPANEL.Controls)
            {
                c.Dispose();
            }

            QAPANEL.Controls.Clear();

            y = 0;

            foreach (var folder in folders)
            {
                QAFolder qfolder = new QAFolder()
                {
                    Location = folder,
                    Count = Directory.GetFiles(folder, "*.cbr", SearchOption.AllDirectories).Length + Directory.GetFiles(folder, "*.cbz", SearchOption.AllDirectories).Length
                };

                QAFolderButton btn = new QAFolderButton(qfolder, 0, y, this);
                QAPANEL.Controls.Add(btn.Label);
                y += 25;
            }
        }
    }

    class QAFolderButton
    {
        public Label Label { get; set; }

        QAFolder thisFolder;

        QuickAccess QA;

        public QAFolderButton(QAFolder folder, int x, int y, QuickAccess q)
        {
            thisFolder = folder;
            QA = q;

            Label = new Label()
            {
                Text = Path.GetFileName(folder.Location) + " | " + folder.Count + " comic files",
                Location = new Point(x, y),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 400,
                Height = 25,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 15, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Anchor = (AnchorStyles.Left | AnchorStyles.Right)
            };

            Label.Click += Click;
        }

        void Click(object sender, EventArgs e)
        {
            //Detect all folders (if any)
            List<string> folders = Directory.GetDirectories(thisFolder.Location).ToList();

            //Detect all comic files (if any)
            //CBR
            var cbr = Directory.GetFiles(thisFolder.Location, "*.cbr");
            //CBZ
            var cbz = Directory.GetFiles(thisFolder.Location, "*.cbz");
            //Join them
            List<string> files = new List<string>();
            files.AddRange(cbr);
            files.AddRange(cbz);
            files.Sort();

            //Tell QuickAccess to load all this
            QA.LoadContent(folders, files);
        }
    }


}
