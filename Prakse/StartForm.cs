using System;
using System.Drawing;
using System.Windows.Forms;

namespace Prakse
{
    public partial class StartForm : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;
        public StartForm() { InitializeComponent(); }

        private void StartForm_Load(object sender, EventArgs e)
        {
            jaunuDatuKopaToolStripMenuItem.Click += (s, a) =>
            {
                FileForm f = new FileForm();
                f.Visible = true;
            };

            atvērtDatuKopuToolStripMenuItem.Click += (s, a) =>
            {
                OpemForm open = new OpemForm();
                open.Visible = true;
            };

            aizvērtToolStripMenuItem.Click += (s, a) => { Close(); };

            CloseLabel.Click += (s, a) => { Close(); };

            MinimLabel.Click += (s, a) =>
            {
                if (WindowState == FormWindowState.Normal)
                    WindowState = FormWindowState.Minimized;
            };
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
    }
}
