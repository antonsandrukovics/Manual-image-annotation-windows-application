using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Prakse
{
    public partial class EmptyDataSet : Form
    {
        private string nameDataSet;
        private Point mouseOffset;
        private bool isMouseDown = false;
        public EmptyDataSet(string name)
        {
            InitializeComponent();
            nameDataSet = name;
        }

        private void folderChooseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                directoryWithFile.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonCancel_Click(object sender, EventArgs e) { Close(); }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            CreateDirectory();

            DBSqlite sqlitePrakseEmptyDataSet = new DBSqlite($"{directoryWithFile.Text}\\{nameDataSet}");

            AddToTxtDataSetLocation addToTxt = new AddToTxtDataSetLocation(directoryWithFile.Text, nameDataSet);

            MessageBox.Show(
                    $"Datukopa \"{nameDataSet}\" ir izveidota!",
                    "Ziņojums",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                if (Application.OpenForms[i].Name != "StartForm")
                    Application.OpenForms[i].Close();
        }

        private void CreateDirectory()
        {
            Directory.CreateDirectory($"{directoryWithFile.Text}\\{nameDataSet}\\Train");
            Directory.CreateDirectory($"{directoryWithFile.Text}\\{nameDataSet}\\Val");
            Directory.CreateDirectory($"{directoryWithFile.Text}\\{nameDataSet}\\Test");
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

        private void MinimLabel_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void CloseLabel_Click(object sender, EventArgs e) { Close(); }
    }
}
