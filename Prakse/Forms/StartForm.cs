using System;
using System.Drawing;
using System.Windows.Forms;

namespace Prakse
{
    public partial class startForm : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;
        
        public startForm() 
        {
            InitializeComponent(); 
        }

        private void CreateNewDataset_Click(object sender, EventArgs e)
        {
            FileForm fileForm = new FileForm();
            fileForm.Visible = true;
        }
        private void OpenDataset_Click(object sender, EventArgs e)
        {
            OpemForm openForm = new OpemForm();
            openForm.Visible = true;
        }
        private void CloseApplication_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void StartForm_MouseDown(object sender, MouseEventArgs e)
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
        private void StartForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }
        private void StartForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
        }
        private void MinimLabel_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }
    }
}
