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
        private string dataSetPla;
        private List<string> dataSetPlase = new List<string>();
        protected string checkedItems;
        protected string checkedName;
        protected List<string> NameClass = new List<string>();
        protected string newNameDataSet;
        public OpemForm()
        {
            InitializeComponent();
            checkedListBoxWithExistingDatasets.CheckOnClick = true;

            if (File.Exists("datuKopuVieta.txt"))
            {
                FileStream datuKopuVieta = new FileStream("datuKopuVieta.txt",
                        FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(datuKopuVieta);
                
                for (int i = 0; i < File.ReadAllLines(datuKopuVieta.Name.ToString()).Length; i++)
                {
                    if ((dataSetPla = reader.ReadLine()) != null)
                    {
                        if (Directory.Exists(dataSetPla))
                        {
                            dataSetPlase.Add(dataSetPla);
                            checkedListBoxWithExistingDatasets.Items.Add(Path.GetFileName(dataSetPla));
                        }
                    }
                }
                reader.Close();
                datuKopuVieta.Close();
            }
        }

        private void OpemForm_Load(object sender, EventArgs e)
        {
            buttonStartSend.Enabled = false;
            DeleteDataset.Enabled = false;
        }

        private void checkedListBoxWithExistingDatasets_ItemCheck(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxWithExistingDatasets.Items.Count; i++)
                if (checkedListBoxWithExistingDatasets.SelectedIndex != i)
                {
                    checkedListBoxWithExistingDatasets.SetItemChecked(i, false);
                }
                    

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
            
            foreach (string s in checkedListBoxWithExistingDatasets.CheckedItems)
            {
                checkedName = s;
            }
            for (int i = 0; i < dataSetPlase.Count; i++)
            {
                if (checkedName == Path.GetFileName(dataSetPlase[i]))
                {
                    checkedItems = dataSetPlase[i];
                }
            }
            comboBox1.Items.Clear();
            textBox1.Text = checkedName;
            string[] className = GetDbClassName(checkedItems);
            for (int i = 0; i < className.Length; i++)
            {
                comboBox1.Items.Add(className[i]);
                NameClass.Add(className[i]);
            }
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                newDirectoryWithFileName.Text = folderBrowserDialog1.SelectedPath;

            
            if (newDirectoryWithFileName.Text != "")
            {
                string[] files = (from lst in Directory.GetFiles(newDirectoryWithFileName.Text)
                                  where lst.EndsWith(".jpg") || lst.EndsWith(".jpeg") || lst.EndsWith(".png") || lst.EndsWith(".gif") || lst.EndsWith(".tif") || lst.EndsWith(".JPG") || lst.EndsWith(".PNG") select lst).ToArray<string>();
                if (files.Length > 0)
                {
                    int length = files.Length;
                    newDirectoryFileLength.Text = "Failu skaits: " + length.ToString(); 
                }
                else
                {
                    MessageBox.Show("Jūs izvēlējāties mapi, kurā nav attēlu!\nIzvēlieties mapi ar attēlu!");
                    newDirectoryWithFileName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Jūs izvēlējāties saiti, kurā ir tukša!");
            }
        }

        private void buttonStartSend_Click(object sender, EventArgs e)
        {
            foreach (string s in checkedListBoxWithExistingDatasets.CheckedItems)
            {
                checkedName = s;
            }
            for (int i = 0; i < dataSetPlase.Count; i++)
            {
                if (checkedName == Path.GetFileName(dataSetPlase[i]))
                {
                    checkedItems = dataSetPlase[i];
                }
            }

            if (newDirectoryWithFileName.Text != "")
            {
                if (checkedListBoxWithExistingDatasets.CheckedItems.Count != 0)
                {
                    string[] files = (from lst in Directory.GetFiles(newDirectoryWithFileName.Text)
                                      where lst.EndsWith(".jpg") || lst.EndsWith(".jpeg") || lst.EndsWith(".png") || lst.EndsWith(".gif") || lst.EndsWith(".tif") || lst.EndsWith(".JPG") || lst.EndsWith(".PNG")
                                      select lst).ToArray<string>();

                    if (File.Exists($"{checkedItems}\\{Path.GetFileName(checkedItems)}.db"))
                        FinalFunction(files, checkedItems);
                    else
                    {
                        if (File.Exists($"{Path.GetDirectoryName(checkedItems)}\\{newNameDataSet}\\{newNameDataSet}.db"))
                            FinalFunction(files, $"{Path.GetDirectoryName(checkedItems)}\\{newNameDataSet}");
                        else
                            MessageBox.Show($"Kļūda! Nevar atrast {Path.GetFileName(newNameDataSet)}.db ");
                    }
                }
                else
                    MessageBox.Show("Kļūda! Izvēlēties klasi!");
            }
            else
                MessageBox.Show("Kļūda! Izvēlēties mapi!");
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

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void DeleteDataset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataSetPlase.Count; i++)
            {
                if (checkedName == Path.GetFileName(dataSetPlase[i]))
                {
                    FileStream datuKopuVieta1 = new FileStream("datuKopuVieta.txt",
                        FileMode.Open, FileAccess.ReadWrite);
                    StreamReader reader = new StreamReader(datuKopuVieta1);
                    List<string> arr = new List<string>();
                    string data;
                    for (int j = 0; (data = reader.ReadLine()) != null; j++)
                        if (data != "")
                            arr.Add(data);

                    reader.Close();
                    datuKopuVieta1.Close();
                    File.WriteAllText(@"datuKopuVieta.txt", string.Empty);
                    FileStream datuKopuVieta2 = new FileStream("datuKopuVieta.txt",
                        FileMode.Open, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(datuKopuVieta2);
                    for (int j = 0; j < arr.Count; j++)
                        if (arr[j] != dataSetPlase[i])
                            writer.WriteLine(arr[j]);
                    writer.Close();
                    datuKopuVieta2.Close();
                    checkedListBoxWithExistingDatasets.Items.RemoveAt(checkedListBoxWithExistingDatasets.SelectedIndex);
                    Directory.Delete(dataSetPlase[i], true);
                }
            }
            textBox1.Text = "";
        }

        

        private void ChoseName_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Length < 150)
                {
                    newNameDataSet = textBox1.Text;
                    string newName = Path.GetDirectoryName(checkedItems) + "\\" + textBox1.Text;
                    try
                    {
                        for (int i = 0; i < dataSetPlase.Count; i++)
                        {
                            if (dataSetPlase[i] == checkedItems)
                                dataSetPlase[i] = Path.GetDirectoryName(checkedItems) + "\\" + textBox1.Text;
                        }
                        File.Move((checkedItems + "\\" + Path.GetFileName(checkedItems) + ".db"), (checkedItems + "\\" + Path.GetFileName(textBox1.Text) + ".db"));
                        Directory.Move(checkedItems, newName);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    AddToTxtDataSetLocation addToTxt = new AddToTxtDataSetLocation(newName, checkedItems, true);

                    textBox1.Text = "";
                    MessageBox.Show("Nosaukums ir mainīts!"); 
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
                NameClass.Add(textBox2.Text);
                textBox2.Text = "";
            }
            else
                MessageBox.Show("Ievadiet jaunu klasi!");
        }

        public string[] GetDbClassName(string checkedItems)
        {
            string cs = $"Data Source={checkedItems}\\{Path.GetFileName(checkedItems)}.db";
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                con.Open();
                string stm = "SELECT * FROM Classes";
                SQLiteCommand cmd = new SQLiteCommand(stm, con);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                List<string> nameClass = new List<string>();

                try
                {
                    while (rdr.Read())
                        nameClass.Add(rdr.GetString(0));
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                rdr.Close();
                cmd.Dispose();

                string[] className = nameClass.Distinct().ToArray();
                return className;
            }            
        }

        private void EditClass_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox2.Text.Length < 150)
                {
                    NameClass.RemoveAt(comboBox1.SelectedIndex);
                    NameClass.Add(textBox2.Text);
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    comboBox1.Items.Clear();
                    for (int i = 0; i < NameClass.Count; i++)
                        comboBox1.Items.Add(NameClass[i]);
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
                NameClass.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Items.Clear();
                for (int i = 0; i < NameClass.Count; i++)
                    comboBox1.Items.Add(NameClass[i]);
                comboBox1.Enabled = true; 
            }
            else
            {
                MessageBox.Show("Izvelieties klasi dzēšanai!");
            }
        }

        public void FinalFunction(string[] filesFromNewFolder, string newDataSetName)
        {
            string[] className = NameClass.ToArray(); // Izveidot masīvu ar jauniem klašu nosaukumiem
            if (className.Length != 0) // Pārbaudiet, vai masīvs nav tukšs 
            {
                ImageForm imageOpen = new ImageForm(className, filesFromNewFolder, newDataSetName, true);
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
    }
}
