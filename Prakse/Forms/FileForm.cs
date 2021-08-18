using System;
using System.Windows.Forms;
using System.Drawing;

namespace Prakse
{
    public partial class FileForm : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;
        private Dataset dataset = new Dataset();
        public FileForm() 
        {
            InitializeComponent();
        }

        private void FolderChooseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogWithFilesForSorting = new FolderBrowserDialog(); // Atveram FolderBrowserDialog un izvēlamies mapi ar attēliem
            if (folderBrowserDialogWithFilesForSorting.ShowDialog() == DialogResult.OK) // Pārbaudām, vai lietotājs noklikšķina uz pogas (Labi)
            {
                directoryWithFilesForSorting.Text = (dataset.DirectoryPathWithImages = folderBrowserDialogWithFilesForSorting.SelectedPath); // Aizpildām TextBox ar mapes saiti
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (datasetName.Text != "") // Tiek pārbaudīts, vai datukopas nosaukums ir ievadīts
            {
                if (datasetName.Text.Length < 150)
                {
                    if (directoryWithFilesForSorting.Text != "") // Tiek pārbaudīts, vai ir mapes saiti
                    {
                        dataset.DatasetName = datasetName.Text; // Dataset
                        dataset.FillImagesArray(); // Dataset
                        ImportForm importForm = new ImportForm(dataset);
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
                        }
                    } 
                }
                else
                {
                    MessageBox.Show("Kļūda! Datukopas nosaukums nevar būt garāks par 150 rakstzīmēm!");
                }
            }
            else
            {
                MessageBox.Show("Kļūda! Lūdzu, aizpildiet datukopas nosaukumu!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) 
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
    }
}
