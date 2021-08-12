using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Prakse
{
    public partial class ImportForm : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;
        private Dataset dataset1;
        public ImportForm(Dataset dataset)
        {
            InitializeComponent();
            dataset1 = dataset;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            NameOfDataset.Text += Dataset.DatasetName;
            lengthOfDataset.Text += dataset1.ArrayWithImagesPath.Length;
        }

        private void ButtonAddNewClass_Click(object sender, EventArgs e)
        {
            if (textBoxWithNewClassName.Text != "")
            {
                if (textBoxWithNewClassName.Text.Length < 150)
                {
                    listBoxWithNewClass.Items.Add(textBoxWithNewClassName.Text);
                    textBoxWithNewClassName.Clear();  
                }
                else
                {
                    MessageBox.Show("Kļūda! Klases nosaukums nevar būt garāks par 150 rakstzīmēm!");
                }
            }
            else
            {
                MessageBox.Show("Kļūda! Lūdzu, ievadiet klasi!");
            }
        }

        private void ButtonClassRemove_Click(object sender, EventArgs e)
        {
            if (listBoxWithNewClass.Items.Count != 0)
            {
                if (listBoxWithNewClass.SelectedIndex > -1)
                {
                    listBoxWithNewClass.Items.RemoveAt(listBoxWithNewClass.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Kļūda! Lūdzu, izvēlieties klasi");
                }                    
            }
            else
            {
                MessageBox.Show("Kļūda! Klašu saraksts ir tukšs!\nLūdzu, pievienojiet klasi!");
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (listBoxWithNewClass.Items.Count > 0) // Pārbaudām, vai lietotājs ir pievienojis klasi
            {
                if (directoryPathForSortingFiles.Text != "") // Pārbaudām, vai lietotājs ir pievienojis mapi priekš datukopas glabašanai
                {
                    dataset1.ClasesNamesList = CreateArrayWithClassNames();
                    dataset1.DirectoryPathForSortingFiles = directoryPathForSortingFiles.Text;
                    ImageForm imageForm = new ImageForm(dataset1);
                    imageForm.Visible = true; 
                }
                else
                {
                    MessageBox.Show("Kļūda! Izvēlieties mapi, kurā tiks glabāts datukopa!");
                }
            }
            else
            {
                MessageBox.Show("Pievienojiet klasi!");
            }
        }

        private List<string> CreateArrayWithClassNames()
        {
            List<string> arrWithClassNames = new List<string>(); // Veidojam masīvu ar klašu nosaukumiem 
            for (int i = 0; i < listBoxWithNewClass.Items.Count; i++)
            {
                arrWithClassNames.Add(listBoxWithNewClass.Items[i].ToString()); // Aizpildām masīvu
            }
            return arrWithClassNames;
        }

        private void label5_Click(object sender, EventArgs e) 
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void ChoseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogWithDirectoryPathForSortingFiles = new FolderBrowserDialog();
            if (folderBrowserDialogWithDirectoryPathForSortingFiles.ShowDialog() == DialogResult.OK)
            {
                directoryPathForSortingFiles.Text = folderBrowserDialogWithDirectoryPathForSortingFiles.SelectedPath;
            }
            if (directoryPathForSortingFiles.Text != "")
            {
                AddToTxtDataSetLocation addToTxt = new AddToTxtDataSetLocation(directoryPathForSortingFiles.Text, Dataset.DatasetName); 
            }
            else
            {
                MessageBox.Show("Jūs izvēlējāties saiti, kurā ir tukša!");
            }
        }
    }
}
