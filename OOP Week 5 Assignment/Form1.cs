using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OOP_Week_5_Assignment
{
    public partial class Form1 : Form
    {
        //this is to store the last used file path, when saving the file it will automatically use this
        string filePath = "";

        public Form1()
        {
            InitializeComponent();
            this.Text = "New File";
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            rTxtBMain.Text = "";
            filePath = "";
            this.Text = "New File";
        }

        private void menuItemNewWindow_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.filePath = "";
            form.Show();
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                this.Text = filePath;
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    rTxtBMain.Text = "";
                    rTxtBMain.Text += sr.ReadToEnd();
                }
            }
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (filePath == "")
            {
                menuItemSaveAs_Click(null, null);
            }else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(rTxtBMain.Text);
                }
            }
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
                this.Text = filePath;
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(rTxtBMain.Text);
                }
            }
        }
    }
}
