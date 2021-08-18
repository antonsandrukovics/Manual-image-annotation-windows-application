using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Prakse
{
    public partial class OpemForm : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;

        protected string checkedItemPath;
        protected List<string> classNamesList = new List<string>();
        protected string newNameDataSet;
        private Dataset dataset = new Dataset();
        public OpemForm()
        {
            InitializeComponent();
            FillCheckedListBoxWithDatasetNames();            
        }
        private void FillCheckedListBoxWithDatasetNames()
        {
            foreach (var item in dataset.GetExistingDatasetPath())
            {
                checkedListBoxWithExistingDatasets.Items.Add(Path.GetFileName(item));
            }
        }

        private void OpemForm_Load(object sender, EventArgs e)
        {
            buttonStartSend.Enabled = false;
            DeleteDataset.Enabled = false;
            checkedListBoxWithExistingDatasets.CheckOnClick = true;
        }

        private void checkedListBoxWithExistingDatasets_ItemCheck(object sender, EventArgs e)
        {
            CheckedOnlyOneItem();
            EnabledButtonsIfItemFromCheckedListBoxIsSelected();
            InitializeCheckedItemPath();
            comboBox1.Items.Clear();
            textBox1.Text = GetCheckedItemNameFromCheckedListBox();
            FillComboBoxAndClassNamesList();
        }

        private void FillComboBoxAndClassNamesList()
        {
            string[] className = DBSqlite.GetClassNamesFromDB(checkedItemPath);
            for (int i = 0; i < className.Length; i++)
            {
                comboBox1.Items.Add(className[i]);
                classNamesList.Add(className[i]);
            }
        }

        private void InitializeCheckedItemPath()
        {
            for (int i = 0; i < dataset.GetExistingDatasetPath().Count; i++)
            {
                if (GetCheckedItemNameFromCheckedListBox() == Path.GetFileName(dataset.GetExistingDatasetPath()[i]))
                {
                    checkedItemPath = dataset.GetExistingDatasetPath()[i];
                }
            }
        }

        private string GetCheckedItemNameFromCheckedListBox()
        {
            string checkedItemName = "";
            foreach (string checkedName in checkedListBoxWithExistingDatasets.CheckedItems)
            {
                checkedItemName = checkedName;
            }
            return checkedItemName;
        }

        private void EnabledButtonsIfItemFromCheckedListBoxIsSelected()
        {
            if (checkedListBoxWithExistingDatasets.CheckedItems.Count == 0)
            {
                buttonStartSend.Enabled = false;
                DeleteDataset.Enabled = false;
            }
            else
            {
                buttonStartSend.Enabled = true;
                DeleteDataset.Enabled = true;
            }
        }

        private void CheckedOnlyOneItem()
        {
            for (int i = 0; i < checkedListBoxWithExistingDatasets.Items.Count; i++)
            {
                if (checkedListBoxWithExistingDatasets.SelectedIndex != i)
                {
                    checkedListBoxWithExistingDatasets.SetItemChecked(i, false);
                }
            }
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            FillNewDirectoryWithImage();
            dataset.FillImagesArray();

            if (newDirectoryPathWithImage.Text != "")
            {

                if (dataset.ArrayWithImagesPath.Length > 0)
                {
                    int length = dataset.ArrayWithImagesPath.Length;
                    newDirectoryFileLength.Text = "Failu skaits: " + length.ToString();
                }
                else
                {
                    MessageBox.Show("Jūs izvēlējāties mapi, kurā nav attēlu!\nIzvēlieties mapi ar attēlu!");
                    newDirectoryPathWithImage.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Jūs izvēlējāties saiti, kurā ir tukša!");
            }
        }

        private void FillNewDirectoryWithImage()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                newDirectoryPathWithImage.Text = (dataset.DirectoryPathWithImages = folderBrowserDialog1.SelectedPath);
            }
        }

        private void buttonStartSend_Click(object sender, EventArgs e)
        {
            InitializeCheckedItemPath();
            if (newDirectoryPathWithImage.Text != "")
            {
                if (checkedListBoxWithExistingDatasets.CheckedItems.Count != 0)
                {

                    if (File.Exists($"{checkedItemPath}\\{Path.GetFileName(checkedItemPath)}.db"))
                    {
                        dataset.DatasetName = checkedItemPath;
                        OpenImageForm();
                    }                        
                    else
                    {
                        if (File.Exists($"{Path.GetDirectoryName(checkedItemPath)}\\{newNameDataSet}\\{newNameDataSet}.db"))
                        {
                            dataset.DatasetName = $"{Path.GetDirectoryName(checkedItemPath)}\\{newNameDataSet}";
                            OpenImageForm();
                        }
                        else
                        {
                            MessageBox.Show($"Kļūda! Nevar atrast {Path.GetFileName(newNameDataSet)}.db ");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Kļūda! Izvēlēties klasi!");
                }
            }
            else
            {
                MessageBox.Show("Kļūda! Izvēlēties mapi!");
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

        private void DeleteDataset_Click(object sender, EventArgs e)
        {
            dataset.DeleteDatasetFromTxt(GetCheckedItemNameFromCheckedListBox());
            checkedListBoxWithExistingDatasets.Items.RemoveAt(checkedListBoxWithExistingDatasets.SelectedIndex);
            textBox1.Text = "";
        }        

        private void ChoseName_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Length < 150)
                {
                    newNameDataSet = textBox1.Text;
                    dataset.ChoseDatasetName(newNameDataSet, checkedItemPath);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Kļūda! Datukopas nosaukums nevar būt garāks par 150 rakstzīmēm!");
                }
            }
            else
            {
                MessageBox.Show("Izvelieties datukopu!");
            }
            
        }

        private void AddClass_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                comboBox1.Items.Add(textBox2.Text);
                classNamesList.Add(textBox2.Text);
                textBox2.Text = "";
            }
            else
                MessageBox.Show("Ievadiet jaunu klasi!");
        }

        private void EditClass_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox2.Text.Length < 150)
                {
                    classNamesList.RemoveAt(comboBox1.SelectedIndex);
                    classNamesList.Add(textBox2.Text);
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    comboBox1.Items.Clear();
                    for (int i = 0; i < classNamesList.Count; i++)
                    {
                        comboBox1.Items.Add(classNamesList[i]);
                    }
                    comboBox1.Enabled = true; 
                }
                else
                {
                    MessageBox.Show("Kļūda! Klases nosaukums nevar būt garāks par 150 rakstzīmēm");
                }
            }
            else
            {
                MessageBox.Show("Izvelieties klasi redaktēšanai!");
            }
        }

        private void buttonPress_Click(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;
            comboBox1.Enabled = false;
        }

        private void DeleteClass_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                classNamesList.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Items.Clear();
                for (int i = 0; i < classNamesList.Count; i++)
                {
                    comboBox1.Items.Add(classNamesList[i]);
                }
                comboBox1.Enabled = true; 
            }
            else
            {
                MessageBox.Show("Izvelieties klasi dzēšanai!");
            }
        }

        public void OpenImageForm()
        {
            FillDatasetItem();
            if (dataset.ClasesNamesList.Count != 0) // Pārbaudiet, vai masīvs nav tukšs 
            {
                
                ImageForm imageOpen = new ImageForm(dataset, true);
                imageOpen.Visible = true;
            }
            else
            {
                MessageBox.Show(
                    "Izvēlētajai datukopai nav klašu! Pievienojiet jaunas klases!",
                    "Ziņojums",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void FillDatasetItem()
        {
            dataset.ClasesNamesList = classNamesList.ToList();
        }
    }
}
