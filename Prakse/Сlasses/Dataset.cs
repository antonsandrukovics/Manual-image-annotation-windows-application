using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prakse
{
    public partial class Dataset
    {
        private static string datasetName;
        private static string directoryPathWithImages;
        private string[] arrayWithImagesPath;
        private List<string> clasesNamesList = new List<string>();
        private string directoryPathForSortingFiles;
        private List<string> urlList = new List<string>();
        private List<string> licenceList = new List<string>();

        public Dataset()
        {
            
        }
        public List<string> UrlList
        {
            get { return urlList; }
            set { urlList = value; }
        }
        public List<string> LicenceList
        {
            get { return licenceList; }
            set { licenceList = value; }
        }

        public string DirectoryPathForSortingFiles
        {
            get { return directoryPathForSortingFiles; }
            set { directoryPathForSortingFiles = value; }
        }
        public string[] ArrayWithImagesPath
        {
            get { return arrayWithImagesPath; }
            set { arrayWithImagesPath = value; }
        }
        public List<string> ClasesNamesList
        {
            get { return clasesNamesList; }
            set { clasesNamesList = value; }
        }
        public static string DatasetName
        {
            get { return datasetName; }
            set 
            {
                if (value.Length < 150 && value != "")
                {
                    datasetName = value; 
                }
                else
                {
                    MessageBox.Show("Kļūda! Datukopas nosaukums nevar būt garāks par 150 rakstzīmēm!");
                }
            }
        }
        public static string DirectoryPathWithImages
        {
            get { return directoryPathWithImages; }
            set 
            {
                if (GetArrayOfImagesPaths(value).Length > 0)
                { 
                    directoryPathWithImages = value;
                }
            }
        }
        public List<string> GetExistingDatasetPath()
        {
            List<string> existingDataset = new List<string>();
            if (File.Exists("datuKopuVieta.txt"))
            {
                string dataSetPath = "";
                try
                {
                    FileStream datasetPath = new FileStream("datuKopuVieta.txt",
                                    FileMode.Open, FileAccess.Read);
                    StreamReader txtReader = new StreamReader(datasetPath);

                    for (int i = 0; i < File.ReadAllLines(datasetPath.Name.ToString()).Length; i++)
                    {
                        if ((dataSetPath = txtReader.ReadLine()) != null)
                        {
                            if (Directory.Exists(dataSetPath))
                            {
                                existingDataset.Add(dataSetPath);
                            }
                        }
                    }
                    txtReader.Close();
                    datasetPath.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return existingDataset;
        }

        public void ChoseDatasetName(string newDatasetName, string oldDatasetPath)
        {
            DatasetName = newDatasetName;
            List<string> datasetPathList = GetExistingDatasetPath();
            string newName = Path.GetDirectoryName(oldDatasetPath) + "\\" + newDatasetName;
            try
            {
                for (int i = 0; i < datasetPathList.Count; i++)
                {
                    if (datasetPathList[i] == oldDatasetPath)
                    {
                        datasetPathList[i] = Path.GetDirectoryName(oldDatasetPath) + "\\" + newDatasetName;
                    }
                }
                File.Move((oldDatasetPath + "\\" + Path.GetFileName(oldDatasetPath) + ".db"), (oldDatasetPath + "\\" + Path.GetFileName(newDatasetName) + ".db"));
                Directory.Move(oldDatasetPath, newName);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            TxtDataSet addToTxt = new TxtDataSet(newName, oldDatasetPath, true);

            MessageBox.Show("Nosaukums ir mainīts!");
        }
        public void DeleteDatasetFromTxt(string datasetName)
        {
            List<string> existingDatasetPathsList = GetExistingDatasetPath();
            for (int i = 0; i < existingDatasetPathsList.Count; i++)
            {
                if (datasetName == Path.GetFileName(existingDatasetPathsList[i]))
                {
                    FileStream datuKopuVieta1 = new FileStream("datuKopuVieta.txt",
                        FileMode.Open, FileAccess.ReadWrite);
                    StreamReader reader = new StreamReader(datuKopuVieta1);
                    List<string> arr = new List<string>();
                    string data;
                    for (int j = 0; (data = reader.ReadLine()) != null; j++)
                    {
                        if (data != "")
                        {
                            arr.Add(data);
                        }
                    }


                    reader.Close();
                    datuKopuVieta1.Close();
                    File.WriteAllText(@"datuKopuVieta.txt", string.Empty);
                    FileStream datuKopuVieta2 = new FileStream("datuKopuVieta.txt",
                        FileMode.Open, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(datuKopuVieta2);
                    for (int j = 0; j < arr.Count; j++)
                    {
                        if (arr[j] != existingDatasetPathsList[i])
                        {
                            writer.WriteLine(arr[j]);
                        }
                    }

                    writer.Close();
                    datuKopuVieta2.Close();
                    Directory.Delete(existingDatasetPathsList[i], true);
                }
            }
        }
        public void FillImagesArray()
        {
            string[] arrayWithImagesPath = GetArrayOfImagesPaths(DirectoryPathWithImages);
            this.arrayWithImagesPath = new string[arrayWithImagesPath.Length];
            for (int i = 0; i < arrayWithImagesPath.Length; i++)
            {
                ArrayWithImagesPath[i] = arrayWithImagesPath[i];
            }
        }

        private static string[] GetArrayOfImagesPaths(string directoryWithImages)
        {
            string[] arrayWithImagesPath = (from image in Directory.GetFiles(directoryWithImages)
                                            where image.EndsWith(".jpg") || image.EndsWith(".jpeg") || image.EndsWith(".png") ||
                                            image.EndsWith(".gif") || image.EndsWith(".tif") ||
                                            image.EndsWith(".JPG") || image.EndsWith(".PNG")
                                            select image).ToArray<string>(); // Veidojam masīvu ar attēliem
            return arrayWithImagesPath;
        }

        
    }
}
