using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.IO;

namespace Prakse
{
    public partial class FileForm : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;
        public FileForm() { InitializeComponent(); }

        private void folderChooseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog(); // Atveram FolderBrowserDialog un izvēlamies mapi ar attēliem
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) // Pārbaudām, vai lietotājs noklikšķina uz pogas (Labi)
                directoryWithFile.Text = folderBrowserDialog1.SelectedPath; // Aizpildām TextBox ar mapes saiti

            if (directoryWithFile.Text != "") // Pārbaudām, vai TextBox nav tukšs
            {
                string[] files = (from image in Directory.GetFiles(directoryWithFile.Text) 
                                  where image.EndsWith(".jpg") || image.EndsWith(".jpeg") || image.EndsWith(".png") ||
                                  image.EndsWith(".gif") || image.EndsWith(".tif") ||
                                  image.EndsWith(".JPG") || image.EndsWith(".PNG")
                                  select image).ToArray<string>(); // Veidojam masīvu ar attēliem
                if (files.Length < 1) // Jā masīvs ir tukšs, tad tiks parādīts brīdinājums 
                {
                    MessageBox.Show(
                        "Jūs izvēlējāties mapi, kurā nav attēlu!\nIzvēlieties mapi ar attēlu!",
                        "Ziņojums",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    directoryWithFile.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Jūs izvēlējāties saiti, kurā ir tukša!");
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (datasetName.Text != "") // Tiek pārbaudīts, vai datukopas nosaukums ir ievadīts
            {
                if (datasetName.Text.Length < 150)
                {
                    if (directoryWithFile.Text != "") // Tiek pārbaudīts, vai ir mapes saiti
                    {
                        ImportForm importForm = new ImportForm(datasetName.Text, directoryWithFile);
                        importForm.Visible = true;
                    }
                    else // Ja lietotājs vēlas izveidot tukšu datukopu
                    {
                        DialogResult result = MessageBox.Show(
                            "Vai Jūs vēlaties izveidot tukšu datukopu?",
                            "Ziņojums",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            EmptyDataSet emptyDataSet = new EmptyDataSet(datasetName.Text);
                            emptyDataSet.Visible = true;
                            datasetName.Text = "";
                        }
                    } 
                }
                else
                {
                    MessageBox.Show("Kļūda! Datukopas nosaukums nevar būt garāks par 150 rakstzīmēm!");
                }
            }
            else
                MessageBox.Show("Kļūda! Lūdzu, aizpildiet mapes nosaukumu!");

        }

        private void buttonCancel_Click(object sender, EventArgs e) { Close(); }

        private void label4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void NameFormLabel_MouseDown(object sender, MouseEventArgs e)
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

        private void NameFormLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void NameFormLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
        }

        private void datasetName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
