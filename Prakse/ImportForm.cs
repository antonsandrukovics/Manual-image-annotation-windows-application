using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace Prakse
{
    public partial class ImportForm : Form
    {
        private string datasetName;
        private int datasetLength;
        private string[] arrWithPictures;
        private Point mouseOffset;
        private bool isMouseDown = false;

        public ImportForm(string data, TextBox directory)
        {
            InitializeComponent();
            datasetName = data;
            arrWithPictures = (from lst in Directory.GetFiles(directory.Text)
                               where lst.EndsWith(".jpg") || lst.EndsWith(".jpeg") || lst.EndsWith(".png") || lst.EndsWith(".gif") || lst.EndsWith(".tif") || lst.EndsWith(".JPG") || lst.EndsWith(".PNG")
                               select lst).ToArray<string>();
            datasetLength = arrWithPictures.Length;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            NameOfDataset.Text += datasetName;
            lengthOfDataset.Text += datasetLength;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAddNewClass.Text != "")
            {
                if (textBoxAddNewClass.Text.Length < 150)
                {
                    listBoxWithNewClass.Items.Add(textBoxAddNewClass.Text);
                    textBoxAddNewClass.Clear();  
                }
                else
                {
                    MessageBox.Show("Kļūda! Klases nosaukums nevar būt garāks par 150 rakstzīmēm!");
                }
            }
            else
                MessageBox.Show("Kļūda! Lūdzu, ievadiet klasi!");
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxWithNewClass.Items.Count != 0)
                if (listBoxWithNewClass.SelectedIndex > -1)
                    listBoxWithNewClass.Items.RemoveAt(listBoxWithNewClass.SelectedIndex);
                else
                    MessageBox.Show("Kļūda! Lūdzu, izvēlieties klasi");
            else
                MessageBox.Show("Kļūda! Klašu saraksts ir tukšs!\nLūdzu, pievienojiet klasi!");
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (listBoxWithNewClass.Items.Count > 0) // Pārbaudām, vai lietotājs ir pievienojis klasi
            {
                if (textBox1.Text != "") // Pārbaudām, vai lietotājs ir pievienojis mapi priekš datukopas glabašanai
                {
                    string[] arrWithClassName = new string[listBoxWithNewClass.Items.Count]; // Veidojam masīvu ar klašu nosaukumiem 
                    for (int i = 0; i < listBoxWithNewClass.Items.Count; i++)
                    {
                        arrWithClassName[i] = listBoxWithNewClass.Items[i].ToString(); // Aizpildām masīvu
                    }
                    ImageForm imageForm = new ImageForm(arrWithClassName, arrWithPictures, datasetName, textBox1.Text);
                    imageForm.Visible = true; 
                }
                else
                    MessageBox.Show("Kļūda! Izvēlieties mapi, kurā tiks glabāts datukopa!");
            }
            else
                MessageBox.Show("Pievienojiet klasi!");
        }

        private void label5_Click(object sender, EventArgs e) { Close(); }

        private void label4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
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
                isMouseDown = false;
        }

        private void ChoseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            if (textBox1.Text != "")
            {
                AddToTxtDataSetLocation addToTxt = new AddToTxtDataSetLocation(textBox1.Text, datasetName); 
            }
            else
            {
                MessageBox.Show("Jūs izvēlējāties saiti, kurā ir tukša!");
            }
        }
    }
}
