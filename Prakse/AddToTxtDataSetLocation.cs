using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace Prakse
{
    class AddToTxtDataSetLocation
    {
        public AddToTxtDataSetLocation(string datasetLocation, string datasetName)
        {
            if (File.Exists("datuKopuVieta.txt"))
            {
                FileStream datuKopuVieta = new FileStream("datuKopuVieta.txt",
                    FileMode.OpenOrCreate, FileAccess.Read);

                StreamReader reader = new StreamReader(datuKopuVieta);
                string datukopa = reader.ReadToEnd();
                reader.Close();
                datuKopuVieta.Close();


                FileStream datuKopuVieta1 = new FileStream("datuKopuVieta.txt",
                    FileMode.OpenOrCreate, FileAccess.Write);

                StreamWriter writer = new StreamWriter(datuKopuVieta1);
                writer.WriteLine(datukopa);
                writer.Write(datasetLocation + $"\\{datasetName}");
                writer.Close();
                datuKopuVieta1.Close();
            }
            else
            {
                FileStream datuKopuVieta1 = new FileStream("datuKopuVieta.txt",
                        FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(datuKopuVieta1);
                writer.Write(datasetLocation + $"\\{datasetName}");
                writer.Close();
                datuKopuVieta1.Close();
            }
        }

        public AddToTxtDataSetLocation(string newDataSetName, string oldDataSetName, bool a)
        {
            FileStream datuKopuVieta = new FileStream("datuKopuVieta.txt",
                    FileMode.OpenOrCreate, FileAccess.Read);

            StreamReader reader = new StreamReader(datuKopuVieta);
            List<string> dataSet = new List<string>();
            string x = "";
            for (int i = 0; (x = reader.ReadLine()) != null; i++)
            {
                if (x != oldDataSetName)
                {
                    dataSet.Add(x);
                }
                else
                {
                    dataSet.Add(newDataSetName);
                }
            }
            reader.Close();
            datuKopuVieta.Close();


            FileStream datuKopuVieta1 = new FileStream("datuKopuVieta.txt",
                FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(datuKopuVieta1);

            for (int i = 0; i < dataSet.Count; i++)
            {
                writer.WriteLine(dataSet[i]);
            }
            writer.Close();
            datuKopuVieta1.Close();
        }
    }
}
