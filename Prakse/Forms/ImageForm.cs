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
        private int counterForTxt = 0;
        private bool openForm = false;
        private string oldFolderName;
        private int imageCounter = 0;
        private Point mouseOffset;
        private bool isMouseDown = false;
        private string[] imageNameAndClassName;
        private List<string> listWithURL = new List<string>();
        private List<string> listWithLicense = new List<string>();
        private Dataset dataset1;

        public ImageForm(Dataset dataset)
        {
            InitializeComponent();
            dataset1 = dataset;
            InitializeVariablesAndAddInformationToScreen(dataset);
            oldFolderName = $"{dataset.DirectoryPathForSortingFiles}\\{Dataset.DatasetName}";
            Directory.CreateDirectory(oldFolderName);
        }
        public ImageForm(Dataset dataset, bool openForm = false)
        {
            InitializeComponent();
            dataset1 = dataset;
            InitializeVariablesAndAddInformationToScreen(dataset);
            oldFolderName = Dataset.DatasetName;
            this.openForm = openForm;

            GetInformationFromDB(Dataset.DatasetName);
            getURLToComboBox();
            getLicenceToComboBox();
        }
        private void InitializeVariablesAndAddInformationToScreen(Dataset dataset)
        {
            imageNameAndClassName = new string[dataset.ArrayWithImagesPath.Length];
            checkedListBoxWithClassName.CheckOnClick = true;
            pictureBoxWithImage.Image = Image.FromFile($"{dataset.ArrayWithImagesPath[imageCounter]}");
            ImageLengthCounter.Text = $"1/{dataset.ArrayWithImagesPath.Length}";
            buttonSend.Enabled = false;
        }

        private void GetInformationFromDB(string datasetPath)
        {
            listWithURL = DBSqlite.GetUrlNamesFromDB(datasetPath);
            listWithLicense = DBSqlite.GetLicencesNamesFromDB(datasetPath);
        }

        public void getURLToComboBox()
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < listWithURL.Count; i++)
            {
                comboBox1.Items.Add(listWithURL[i]);
            }
        }
        private void ImageForm_Load_1(object sender, EventArgs e)
        {
            if (!IsDatasetExist())
            {
                CreateTrainValTestDirectories();
                AddClassToCheckedListBox();
            }
            else
            {
                AddClassToCheckedListBox();
            }
        }
        private bool IsDatasetExist()
        {
            return openForm == true;
        }
        private void CreateTrainValTestDirectories()
        {
            Directory.CreateDirectory($"{oldFolderName}\\Train");
            Directory.CreateDirectory($"{oldFolderName}\\Val");
            Directory.CreateDirectory($"{oldFolderName}\\Test");
        }
        public void AddClassToCheckedListBox()
        {
            for (int i = 0; i < dataset1.ClasesNamesList.ToArray().Length; i++)
            {
                checkedListBoxWithClassName.Items.Add(dataset1.ClasesNamesList.ToArray()[i].ToString());
            }
        }
        
        private void checkedListBoxWithClassName_ItemCheck(object sender, EventArgs e)
        {
            if (checkedListBoxWithClassName.CheckedItems.Count == 0)
            {
                buttonSend.Enabled = false;
            }
            else
            {
                buttonSend.Enabled = true;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (checkedListBoxWithClassName.CheckedItems.Count != 0)
            {
                if ((dataset1.ArrayWithImagesPath.Length - 1) != imageCounter)
                {
                    pictureBoxWithImage.Image = Image.FromFile($"{dataset1.ArrayWithImagesPath[++imageCounter].ToString()}");
                }
            }
            else
            {
                MessageBox.Show("Kļūda! Izvēlieties klasi!");
            }
            buttonSend.Enabled = false;
            AddInformationAboutDatasetToDB();
        }

        public void AddInformationAboutDatasetToDB()
        {
            if (counterForTxt + 1 < dataset1.ArrayWithImagesPath.Length)
            {
                FillListImageNameAndClassName();
                FillListCheckedListBoxWithClassName();
            }
            else
            {
                FillListImageNameAndClassName();
                dataset1.UrlList = listWithURL;
                dataset1.LicenceList = listWithLicense;
                dataset1.DirectoryPathForSortingFiles = oldFolderName;
                DBSqlite sqlitePrakse = new DBSqlite(dataset1, imageNameAndClassName);
                CopyImagesToDataset();
                MessageBox.Show(
                    $"Jauna datu kopa ir izveidota un saglabāta: {oldFolderName}",
                    "Ziņojums",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
        }
        private void FillListImageNameAndClassName()
        {
            imageNameAndClassName[counterForTxt] = Path.GetFileName(dataset1.ArrayWithImagesPath[counterForTxt]);
            foreach (string item in checkedListBoxWithClassName.CheckedItems)
            {
                imageNameAndClassName[counterForTxt] += " " + item;
            }
        }

        private void FillListCheckedListBoxWithClassName()
        {
            ImageLengthCounter.Text = $"{++counterForTxt + 1}/{dataset1.ArrayWithImagesPath.Length}";
            foreach (int checkedItemIndex in checkedListBoxWithClassName.CheckedIndices)
            {
                checkedListBoxWithClassName.SetItemChecked(checkedItemIndex, false);
            }
        }        

        private void CopyImagesToDataset()
        {
            for (int i = 0; i < dataset1.ArrayWithImagesPath.Length; i++)
            {
                if (i < (dataset1.ArrayWithImagesPath.Length * 0.1))
                {
                    File.Copy(dataset1.ArrayWithImagesPath[i], (oldFolderName + "\\Test\\" + Path.GetFileName(dataset1.ArrayWithImagesPath[i])));
                }
                else
                {
                    if (i < (dataset1.ArrayWithImagesPath.Length * 0.3))
                    {
                        File.Copy(dataset1.ArrayWithImagesPath[i], (oldFolderName + "\\Val\\" + Path.GetFileName(dataset1.ArrayWithImagesPath[i])));
                    }
                    else
                    {
                        File.Copy(dataset1.ArrayWithImagesPath[i], (oldFolderName + "\\Train\\" + Path.GetFileName(dataset1.ArrayWithImagesPath[i])));
                    }
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "StartForm")
                {
                    Application.OpenForms[i].Close();
                }
            }
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

        public void getLicenceToComboBox()
        {
            comboBox2.Items.Clear();
            for (int i = 0; i < listWithLicense.Count; i++)
            {
                comboBox2.Items.Add(listWithLicense[i]);
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
                    listWithURL.Add(textBox3.Text);
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
                    listWithLicense.Add(textBox4.Text);
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
                    listWithURL.RemoveAt(comboBox1.SelectedIndex);
                    listWithURL.Add(textBox3.Text);
                    textBox3.Text = "";
                    comboBox1.Text = "";
                    comboBox1.Items.Clear();
                    for (int i = 0; i < listWithURL.Count; i++)
                        comboBox1.Items.Add(listWithURL[i]);
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
                    listWithLicense.RemoveAt(comboBox2.SelectedIndex);
                    listWithLicense.Add(textBox4.Text);
                    textBox4.Text = "";
                    comboBox2.Text = "";
                    comboBox2.Items.Clear();
                    for (int i = 0; i < listWithLicense.Count; i++)
                        comboBox2.Items.Add(listWithLicense[i]);
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
                listWithURL.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.Text = "";
                textBox3.Text = "";
                comboBox1.Items.Clear();
                for (int i = 0; i < listWithURL.Count; i++)
                {
                    comboBox1.Items.Add(listWithURL[i]);
                }
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
                listWithLicense.RemoveAt(comboBox2.SelectedIndex);
                comboBox2.Text = "";
                textBox4.Text = "";
                comboBox2.Items.Clear();
                for (int i = 0; i < listWithLicense.Count; i++)
                {
                    comboBox2.Items.Add(listWithLicense[i]);
                }
                comboBox2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Izvelieties licenci dzēšanai!");
            }
        }
    }
}
