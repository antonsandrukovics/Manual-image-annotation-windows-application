using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Prakse
{
    public partial class ImageForm : Form
    {
        private string[] arrWithClassForCheckedListBox;
        private string[] arrWithPictures;
        protected int counterForTxt = 0;
        private bool openForm = false;
        private string oldFolderName;
        protected int picturesCounterToTxt = 0;
        protected int imageCounter = 0;
        private Point mouseOffset;
        private bool isMouseDown = false;
        protected string[] imageNameAndClassName;
        protected List<string> arrWithURL = new List<string>();
        protected List<string> arrWithLicense = new List<string>();
        public ImageForm(string[] arrClass, string[] arrPictures, string oldFolder, string newFolder)
        {
            InitializeComponent();
            arrWithClassForCheckedListBox = arrClass;
            arrWithPictures = arrPictures;
            oldFolderName = $"{newFolder}\\{oldFolder}";
            Directory.CreateDirectory(oldFolderName);
            imageNameAndClassName = new string[arrPictures.Length];
        }
        public ImageForm(string[] arrClass, string[] arrPictures, string oldFolder, bool openForm = false)
        {
            InitializeComponent();
            arrWithClassForCheckedListBox = arrClass;
            arrWithPictures = arrPictures;
            oldFolderName = oldFolder;
            this.openForm = openForm;            
            imageNameAndClassName = new string[arrPictures.Length];

            string cs = $"Data Source={oldFolder}\\{Path.GetFileName(oldFolder)}.db";
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                con.Open();
                string stm = "SELECT * FROM Sources";
                SQLiteCommand cmd = new SQLiteCommand(stm, con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    try
                    {
                        arrWithURL.Add(rdr.GetString(0));
                    }
                    catch 
                    {
                        continue;
                    }
                }

                rdr.Close();
                cmd.Dispose();

                SQLiteCommand cmd1 = new SQLiteCommand(stm, con);
                SQLiteDataReader rdr1 = cmd1.ExecuteReader();

                while (rdr1.Read())
                {
                    try
                    {
                        arrWithLicense.Add(rdr1.GetString(1));
                    }
                    catch
                    {
                        continue;
                    }
                }

                rdr1.Close();
                cmd1.Dispose();
            }

            getURLToComboBox();
            getLicenceToComboBox();
        }

        public ImageForm() { InitializeComponent(); }

        private void ImageForm_Load_1(object sender, EventArgs e)
        {
            checkedListBoxWithClassName.CheckOnClick = true;
            
            if (openForm == false)
            {
                Directory.CreateDirectory($"{oldFolderName}\\Train");
                Directory.CreateDirectory($"{oldFolderName}\\Val");
                Directory.CreateDirectory($"{oldFolderName}\\Test");

                AddClassToCheckedListBox();

                pictureBoxWithImage.Image = Image.FromFile($"{arrWithPictures[imageCounter]}");
                ImageLengthCounter.Text = $"1/{arrWithPictures.Length}";

                buttonSend.Enabled = false;
            }
            else
            {
                AddClassToCheckedListBox();
                
                buttonSend.Enabled = false;
                pictureBoxWithImage.Image = Image.FromFile($"{arrWithPictures[imageCounter].ToString()}");
                ImageLengthCounter.Text = $"1/{arrWithPictures.Length}";                
            }
        }

        private void checkedListBoxWithClassName_ItemCheck(object sender, EventArgs e)
        {
            if (checkedListBoxWithClassName.CheckedItems.Count == 0)
                buttonSend.Enabled = false;
            else
                buttonSend.Enabled = true;
        }

        public void AddClassToCheckedListBox()
        {
            for (int i = 0; i < arrWithClassForCheckedListBox.Length; i++)
                checkedListBoxWithClassName.Items.Add(arrWithClassForCheckedListBox[i].ToString());
        }

        public void AddInformationToTxt()
        {
            if (counterForTxt + 1 < arrWithPictures.Length)
            {
                imageNameAndClassName[counterForTxt] = Path.GetFileName(arrWithPictures[counterForTxt]);
                foreach (string item in checkedListBoxWithClassName.CheckedItems)
                {
                    imageNameAndClassName[counterForTxt] += " " + item;
                }

                ImageLengthCounter.Text = $"{++counterForTxt + 1}/{arrWithPictures.Length}";
                foreach (int checkedItemIndex in checkedListBoxWithClassName.CheckedIndices)
                    checkedListBoxWithClassName.SetItemChecked(checkedItemIndex, false);
                
            }
            else
            {
                imageNameAndClassName[counterForTxt] = Path.GetFileName(arrWithPictures[counterForTxt]);
                foreach (string item in checkedListBoxWithClassName.CheckedItems)
                {
                    imageNameAndClassName[counterForTxt] += " " + item;
                }

                DBSqlite sqlitePrakse = new DBSqlite(oldFolderName, imageNameAndClassName, arrWithClassForCheckedListBox, arrWithURL.ToArray(), arrWithLicense.ToArray());

                for (int i = 0; i < arrWithPictures.Length; i++)
                {
                    if (i < (arrWithPictures.Length * 0.1))
                        File.Copy(arrWithPictures[i], (oldFolderName + "\\Test\\" + Path.GetFileName(arrWithPictures[i])));
                    else
                    {
                        if (i < (arrWithPictures.Length * 0.3))
                            File.Copy(arrWithPictures[i], (oldFolderName + "\\Val\\" + Path.GetFileName(arrWithPictures[i])));
                        else
                            File.Copy(arrWithPictures[i], (oldFolderName + "\\Train\\" + Path.GetFileName(arrWithPictures[i])));
                    }
                }

                MessageBox.Show(
                    $"Jauna datu kopa ir izveidota un saglabāta: {oldFolderName}",
                    "Ziņojums",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                if (Application.OpenForms[i].Name != "StartForm")
                    Application.OpenForms[i].Close();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (checkedListBoxWithClassName.CheckedItems.Count != 0)
            {
                if ((arrWithPictures.Length - 1) != imageCounter)
                    pictureBoxWithImage.Image = Image.FromFile($"{arrWithPictures[++imageCounter].ToString()}");
            }
            else
            {
                MessageBox.Show("Kļūda! Izvēlieties klasi!");
            }
            buttonSend.Enabled = false;
            AddInformationToTxt();
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
                isMouseDown = false;
        }

        public void getURLToComboBox()
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < arrWithURL.Count; i++)
            {
                comboBox1.Items.Add(arrWithURL[i]);
            }
        }

        public void getLicenceToComboBox()
        {
            comboBox2.Items.Clear();
            for (int i = 0; i < arrWithLicense.Count; i++)
            {
                comboBox2.Items.Add(arrWithLicense[i]);
            }
        }

        private void buttonPressURL_Click(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text;
            comboBox1.Enabled = false;
        }

        private void buttonPressLicense_Click(object sender, EventArgs e)
        {
            textBox4.Text = comboBox2.Text;
            comboBox2.Enabled = false;
        }

        private void AddURL_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (textBox3.Text.Length < 150)
                {
                    arrWithURL.Add(textBox3.Text);
                    comboBox1.Items.Add(textBox3.Text);
                    textBox3.Text = ""; 
                }
                else
                {
                    MessageBox.Show("Kļūda! URL nevar būt garāks par 150 rakstzīmēm!");
                }
            }
            else
            {
                MessageBox.Show("Izvēlēties URL!");
            }
        }

        private void AddClassLicense_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (textBox4.Text.Length < 150)
                {
                    arrWithLicense.Add(textBox4.Text);
                    comboBox2.Items.Add(textBox4.Text);
                    textBox4.Text = ""; 
                }
                else
                {
                    MessageBox.Show("Kļūda! Licence nevar būt garāks par 150 rakstzīmēm!");
                }
            }
            else
            {
                MessageBox.Show("Izvēlēties licenci!");
            }
        }

        private void EditURL_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (textBox3.Text.Length < 150)
                {
                    arrWithURL.RemoveAt(comboBox1.SelectedIndex);
                    arrWithURL.Add(textBox3.Text);
                    textBox3.Text = "";
                    comboBox1.Text = "";
                    comboBox1.Items.Clear();
                    for (int i = 0; i < arrWithURL.Count; i++)
                        comboBox1.Items.Add(arrWithURL[i]);
                    comboBox1.Enabled = true; 
                }
                else
                {
                    MessageBox.Show("Kļūda! URL nevar būt garāks par 150 rakstzīmēm!");
                }
            }
            else
            {
                MessageBox.Show("Izvelieties URL redaktēšanai!");
            }
        }

        private void EditClassLicense_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (textBox4.Text.Length < 150)
                {
                    arrWithLicense.RemoveAt(comboBox2.SelectedIndex);
                    arrWithLicense.Add(textBox4.Text);
                    textBox4.Text = "";
                    comboBox2.Text = "";
                    comboBox2.Items.Clear();
                    for (int i = 0; i < arrWithLicense.Count; i++)
                        comboBox2.Items.Add(arrWithLicense[i]);
                    comboBox2.Enabled = true; 
                }
                else
                {
                    MessageBox.Show("Kļūda! Licence nevar būt garāka par 150 rakstzīmēm!");
                }
            }
            else
            {
                MessageBox.Show("Izvelieties licenci redaktēšanai!");
            }
        }

        private void DeleteURL_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                arrWithURL.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.Text = "";
                textBox3.Text = "";
                comboBox1.Items.Clear();
                for (int i = 0; i < arrWithURL.Count; i++)
                    comboBox1.Items.Add(arrWithURL[i]);
                comboBox1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Izvelieties URL dzēšanai!");
            }
        }

        private void DeleteClassLicense_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                arrWithLicense.RemoveAt(comboBox2.SelectedIndex);
                comboBox2.Text = "";
                textBox4.Text = "";
                comboBox2.Items.Clear();
                for (int i = 0; i < arrWithLicense.Count; i++)
                    comboBox2.Items.Add(arrWithLicense[i]);
                comboBox2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Izvelieties licenci dzēšanai!");
            }
        }
    }
}
