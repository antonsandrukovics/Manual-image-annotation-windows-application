using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Prakse
{
    class DBSqlite
    {
        private string DBPlace;
        protected int numberOfImage = 0;
        
        public DBSqlite(Dataset dataset, string[] imageNameAndClassName)
        {
            DBPlace = "URI=file:" + dataset.DirectoryPathForSortingFiles + $"\\{Path.GetFileName(dataset.DirectoryPathForSortingFiles)}.db";
            using (SQLiteConnection con = new SQLiteConnection(DBPlace))
            {
                if (File.Exists(dataset.DirectoryPathForSortingFiles + $"\\{Path.GetFileName(dataset.DirectoryPathForSortingFiles)}.db"))
                {
                    con.Open();
                    SQLiteCommand command1, command2, command3, command4;

                    command1 = AddImageNameAndImageClassIfDBExist(imageNameAndClassName, con);
                    command2 = AddClasesListToDBIfDBExist(dataset, con);
                    command3 = AddNumberOfImagesToDBIfDBExist(dataset, imageNameAndClassName, con);
                    command4 = AddUrlAndLicenseToDBIfDBExist(dataset, con);
                }
                else
                {
                    con.Open();
                    SQLiteCommand command1, command2, command3, command4;

                    command1 = AddImageNameAndImageClassToDB(imageNameAndClassName, con);
                    command2 = AddClasesListToDB(dataset, con);
                    command3 = AddNumerOfImagesToDB(imageNameAndClassName, con);
                    command4 = AddUrlAndLicenseToDB(dataset, con);
                }
            }
            
        }

        private static SQLiteCommand AddUrlAndLicenseToDB(Dataset dataset, SQLiteConnection con)
        {
            SQLiteCommand command4 = new SQLiteCommand(
                                    "CREATE TABLE IF NOT EXISTS \"Sources\"" +
                                    "(\"URL\" VARCHAR(150), " +
                                    "\"License\" VARCHAR(150))", con);
            command4.ExecuteNonQuery();
            for (int i = 0; i < dataset.UrlList.ToArray().Length || i < dataset.LicenceList.ToArray().Length; i++)
            {
                if (i < dataset.UrlList.ToArray().Length && i < dataset.LicenceList.ToArray().Length)
                {
                    command4 = new SQLiteCommand($"INSERT INTO Sources (URL, License) VALUES('{dataset.UrlList.ToArray()[i]}', '{dataset.LicenceList.ToArray()[i]}')", con);
                    command4.ExecuteNonQuery();
                }
                else
                {
                    if (i < dataset.UrlList.ToArray().Length)
                    {
                        command4 = new SQLiteCommand($"INSERT INTO Sources (URL) VALUES('{dataset.UrlList.ToArray()[i]}')", con);
                        command4.ExecuteNonQuery();
                    }
                    if (i < dataset.LicenceList.ToArray().Length)
                    {
                        command4 = new SQLiteCommand($"INSERT INTO Sources (License) VALUES('{dataset.LicenceList.ToArray()[i]}')", con);
                        command4.ExecuteNonQuery();
                    }
                }
            }
            command4.Dispose();
            return command4;
        }

        private static SQLiteCommand AddNumerOfImagesToDB(string[] imageNameAndClassName, SQLiteConnection con)
        {
            SQLiteCommand command3 = new SQLiteCommand(
                                    "CREATE TABLE IF NOT EXISTS \"Number_of_image\"" +
                                    "(\"Number\" INTEGER)", con);
            command3.ExecuteNonQuery();
            command3 = new SQLiteCommand($"INSERT INTO Number_of_image (Number) VALUES('{imageNameAndClassName.Length}')", con);
            command3.ExecuteNonQuery();
            command3.Dispose();
            return command3;
        }

        private static SQLiteCommand AddClasesListToDB(Dataset dataset, SQLiteConnection con)
        {
            SQLiteCommand command2 = new SQLiteCommand(
                                    "CREATE TABLE IF NOT EXISTS \"Classes\"" +
                                    "(\"Class\" VARCHAR(150))"
                                    , con);
            command2.ExecuteNonQuery();
            for (int i = 0; i < dataset.ClasesNamesList.ToArray().Length; i++)
            {
                command2 = new SQLiteCommand($"INSERT INTO Classes (Class) VALUES('{dataset.ClasesNamesList.ToArray()[i]}')", con);
                command2.ExecuteNonQuery();
            }
            command2.Dispose();
            return command2;
        }

        private static SQLiteCommand AddImageNameAndImageClassToDB(string[] imageNameAndClassName, SQLiteConnection con)
        {
            SQLiteCommand command1;
            command1 = new SQLiteCommand(
              "CREATE TABLE IF NOT EXISTS \"Datukopa\"" +
              "(\"Image_ID\" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, " +
              "\"Image_Name\" VARCHAR(150), " +
              "\"Image_Class\" VARCHAR(150))"
              , con); // Pievienot tabulu ar kolonnām
            command1.ExecuteNonQuery();

            for (int i = 0; i < imageNameAndClassName.Length; i++)
            {
                int pos = imageNameAndClassName[i].LastIndexOf(' ');
                string bbb = imageNameAndClassName[i].Substring(pos);
                command1 = new SQLiteCommand($"INSERT INTO Datukopa (Image_Name, Image_Class) VALUES" +
                    $"('{imageNameAndClassName[i].Substring(0, pos)}', '{bbb}')", con); // Aizpildīt kolonnas
                command1.ExecuteNonQuery();
            }
            command1.Dispose();
            return command1;
        }

        private static SQLiteCommand AddUrlAndLicenseToDBIfDBExist(Dataset dataset, SQLiteConnection con)
        {
            SQLiteCommand command4 = new SQLiteCommand(
                                    "CREATE TABLE IF NOT EXISTS \"Sources\"" +
                                    "(\"URL\" VARCHAR(150), " +
                                    "\"License\" VARCHAR(150))", con);
            command4.ExecuteNonQuery();
            command4 = new SQLiteCommand("DELETE FROM Sources;", con);
            command4.ExecuteNonQuery();
            for (int i = 0; i < dataset.UrlList.ToArray().Length || i < dataset.LicenceList.ToArray().Length; i++)
            {
                if (i < dataset.UrlList.ToArray().Length && i < dataset.LicenceList.ToArray().Length)
                {
                    command4 = new SQLiteCommand($"INSERT INTO Sources (URL, License) VALUES('{dataset.UrlList.ToArray()[i]}', '{dataset.LicenceList.ToArray()[i]}')", con);
                    command4.ExecuteNonQuery();
                }
                else
                {
                    if (i < dataset.UrlList.ToArray().Length)
                    {
                        command4 = new SQLiteCommand($"INSERT INTO Sources (URL) VALUES('{dataset.UrlList.ToArray()[i]}')", con);
                        command4.ExecuteNonQuery();
                    }
                    if (i < dataset.LicenceList.ToArray().Length)
                    {
                        command4 = new SQLiteCommand($"INSERT INTO Sources (License) VALUES('{dataset.LicenceList.ToArray()[i]}')", con);
                        command4.ExecuteNonQuery();
                    }
                }
            }
            command4.Dispose();
            return command4;
        }

        private SQLiteCommand AddNumberOfImagesToDBIfDBExist(Dataset dataset, string[] imageNameAndClassName, SQLiteConnection con)
        {
            SQLiteCommand command3 = new SQLiteCommand(
                                    "CREATE TABLE IF NOT EXISTS \"Number_of_image\"" +
                                    "(\"Number\" INTEGER)", con);
            command3.ExecuteNonQuery();
            string cs = $"Data Source={dataset.DirectoryPathForSortingFiles}\\{Path.GetFileName(dataset.DirectoryPathForSortingFiles)}.db";
            using (SQLiteConnection con1 = new SQLiteConnection(cs))
            {
                con1.Open();
                string stm = "SELECT * FROM Number_of_image";
                SQLiteCommand cmd = new SQLiteCommand(stm, con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                    numberOfImage = rdr.GetInt32(0);

                rdr.Close();
                cmd.Dispose();
            }
            command3 = new SQLiteCommand("DELETE FROM Number_of_image;", con);
            command3.ExecuteNonQuery();
            command3 = new SQLiteCommand($"INSERT INTO Number_of_image (Number) VALUES('{imageNameAndClassName.Length + numberOfImage}')", con);
            command3.ExecuteNonQuery();
            command3.Dispose();
            return command3;
        }

        private static SQLiteCommand AddClasesListToDBIfDBExist(Dataset dataset, SQLiteConnection con)
        {
            SQLiteCommand command2 = new SQLiteCommand(
                                    "CREATE TABLE IF NOT EXISTS \"Classes\"" +
                                    "(\"Class\" VARCHAR(150))"
                                    , con);
            command2.ExecuteNonQuery();
            command2 = new SQLiteCommand("DELETE FROM Classes;", con);
            command2.ExecuteNonQuery();
            for (int i = 0; i < dataset.ClasesNamesList.ToArray().Length; i++)
            {
                command2 = new SQLiteCommand($"INSERT INTO Classes (Class) VALUES('{dataset.ClasesNamesList.ToArray()[i]}')", con);
                command2.ExecuteNonQuery();
            }
            command2.Dispose();
            return command2;
        }

        private static SQLiteCommand AddImageNameAndImageClassIfDBExist(string[] imageNameAndClassName, SQLiteConnection con)
        {
            SQLiteCommand command1 = new SQLiteCommand(
                                    "CREATE TABLE \"Datukopa\"" +
                                    "(\"Image_ID\" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, " +
                                    "\"Image_Name\" VARCHAR(150), " +
                                    "\"Image_Class\" VARCHAR(150))"
                                    , con);
            //command1.ExecuteNonQuery();

            for (int i = 0; i < imageNameAndClassName.Length; i++)
            {
                int pos = imageNameAndClassName[i].LastIndexOf(' ');
                string bbb = imageNameAndClassName[i].Substring(pos);
                command1 =
                    new SQLiteCommand($"INSERT INTO Datukopa (Image_Name, Image_Class) VALUES" +
                    $"('{imageNameAndClassName[i].Substring(0, pos)}', '{bbb}')", con);
                command1.ExecuteNonQuery();
            }
            command1.Dispose();
            return command1;
        }

        public DBSqlite(string dataBasePlace) //Создаем пустую базу данных
        {
            DBPlace = "URI=file:" + dataBasePlace + $"\\{Path.GetFileName(dataBasePlace)}.db";

            using(SQLiteConnection con = new SQLiteConnection(DBPlace))
            {
                con.Open();

                SQLiteCommand command1, command2, command3, command4;

                command1 = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS \"Datukopa\"" +
                    "(\"Image_ID\" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, " +
                    "\"Image_Name\" VARCHAR(150), " +
                    "\"Image_Class\" VARCHAR(150))"
                    , con);
                command1.ExecuteNonQuery();
                command1.Dispose();

                command2 = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS \"Classes\"" +
                    "(\"Class\" VARCHAR(150))"
                    , con);
                command2.ExecuteNonQuery();
                command2.Dispose();

                command3 = new SQLiteCommand(
                        "CREATE TABLE IF NOT EXISTS \"Number_of_image\"" +
                        "(\"Number\" INTEGER)", con);
                command3.ExecuteNonQuery();
                command3.Dispose();

                command4 = new SQLiteCommand(
                        "CREATE TABLE IF NOT EXISTS \"Sources\"" +
                        "(\"URL\" VARCHAR(150), " +
                        "\"License\" VARCHAR(150))", con);
                command4.ExecuteNonQuery();                
                command4.Dispose();
            }
        }
        public static string[] GetClassNamesFromDB(string checkedItemPath)
        {
            string cs = $"Data Source={checkedItemPath}\\{Path.GetFileName(checkedItemPath)}.db";
            List<string> nameClass = new List<string>();
            if (File.Exists($"{checkedItemPath}\\{Path.GetFileName(checkedItemPath)}.db"))
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();
                    string stm = "SELECT * FROM Classes";
                    SQLiteCommand cmd = new SQLiteCommand(stm, con);
                    SQLiteDataReader rdr = cmd.ExecuteReader();
                    

                    try
                    {
                        while (rdr.Read())
                        {
                            nameClass.Add(rdr.GetString(0));
                        }
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
                } 
            }
            string[] className = nameClass.Distinct().ToArray();
            return className;
        }
        public static List<string> GetUrlNamesFromDB(string datasetPath)
        {
            List<string> urlList = new List<string>();
            string cs = $"Data Source={datasetPath}\\{Path.GetFileName(datasetPath)}.db";
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
                        urlList.Add(rdr.GetString(0));
                    }
                    catch
                    {
                        continue;
                    }
                }

                rdr.Close();
                cmd.Dispose();
            }
            return urlList;
        }
        public static List<string> GetLicencesNamesFromDB(string datasetPath)
        {
            List<string> licencesList = new List<string>();
            string cs = $"Data Source={datasetPath}\\{Path.GetFileName(datasetPath)}.db";
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
                        licencesList.Add(rdr.GetString(1));
                    }
                    catch
                    {
                        continue;
                    }
                }

                rdr.Close();
                cmd.Dispose();
            }
            return licencesList;
        }
    }
}
