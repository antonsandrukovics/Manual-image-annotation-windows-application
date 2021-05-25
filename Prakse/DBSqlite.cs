using System.Data.SQLite;
using System.IO;

namespace Prakse
{
    class DBSqlite
    {
        private string DBPlace;
        protected int numberOfImage = 0;
        public DBSqlite(string dataBasePlace, string[] imageNameAndClassName, 
            string[] allClassName, string[] arrWithURL, string[] arrWithLicense)
        {
            if (File.Exists(dataBasePlace + $"\\{Path.GetFileName(dataBasePlace)}.db")) 
            {
                DBPlace = "URI=file:" + dataBasePlace + $"\\{Path.GetFileName(dataBasePlace)}.db";
                using (SQLiteConnection con = new SQLiteConnection(DBPlace))
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

                    command2 = new SQLiteCommand(
                        "CREATE TABLE IF NOT EXISTS \"Classes\"" +
                        "(\"Class\" VARCHAR(150))"
                        , con);
                    command2.ExecuteNonQuery();
                    command2 = new SQLiteCommand("DELETE FROM Classes;", con);
                    command2.ExecuteNonQuery();
                    for (int i = 0; i < allClassName.Length; i++)
                    {
                        command2 = new SQLiteCommand($"INSERT INTO Classes (Class) VALUES('{allClassName[i]}')", con);
                        command2.ExecuteNonQuery();
                    }
                    command2.Dispose();

                    command3 = new SQLiteCommand(
                        "CREATE TABLE IF NOT EXISTS \"Number_of_image\"" + 
                        "(\"Number\" INTEGER)", con);
                    command3.ExecuteNonQuery();
                    string cs = $"Data Source={dataBasePlace}\\{Path.GetFileName(dataBasePlace)}.db";
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

                    command4 = new SQLiteCommand(
                        "CREATE TABLE IF NOT EXISTS \"Sources\"" +
                        "(\"URL\" VARCHAR(150), " +
                        "\"License\" VARCHAR(150))", con);
                    command4.ExecuteNonQuery();
                    command4 = new SQLiteCommand("DELETE FROM Sources;", con);
                    command4.ExecuteNonQuery();
                    for (int i = 0; i < arrWithURL.Length || i < arrWithLicense.Length; i++)
                    {
                        if (i < arrWithURL.Length && i < arrWithLicense.Length)
                        {
                            command4 = new SQLiteCommand($"INSERT INTO Sources (URL, License) VALUES('{arrWithURL[i]}', '{arrWithLicense[i]}')", con);
                            command4.ExecuteNonQuery();
                        }
                        else
                        {
                            if (i < arrWithURL.Length)
                            {
                                command4 = new SQLiteCommand($"INSERT INTO Sources (URL) VALUES('{arrWithURL[i]}')", con);
                                command4.ExecuteNonQuery();
                            }
                            if (i < arrWithLicense.Length)
                            {
                                command4 = new SQLiteCommand($"INSERT INTO Sources (License) VALUES('{arrWithLicense[i]}')", con);
                                command4.ExecuteNonQuery();
                            }
                        }
                    }
                    command4.Dispose();

                }
            }
            else 
            {
                DBPlace = "URI=file:" + dataBasePlace + $"\\{Path.GetFileName(dataBasePlace)}.db";
                using (SQLiteConnection con = new SQLiteConnection(DBPlace)) // Izveidot datu bāzi
                {
                    con.Open();
                    SQLiteCommand command1, command2, command3, command4;

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

                    command2 = new SQLiteCommand(
                        "CREATE TABLE IF NOT EXISTS \"Classes\"" +
                        "(\"Class\" VARCHAR(150))"
                        , con);
                    command2.ExecuteNonQuery();
                    for (int i = 0; i < allClassName.Length; i++)
                    {
                        command2 = new SQLiteCommand($"INSERT INTO Classes (Class) VALUES('{allClassName[i]}')", con);
                        command2.ExecuteNonQuery();
                    }
                    command2.Dispose();

                    command3 = new SQLiteCommand(
                        "CREATE TABLE IF NOT EXISTS \"Number_of_image\"" +
                        "(\"Number\" INTEGER)", con);
                    command3.ExecuteNonQuery();
                    command3 = new SQLiteCommand($"INSERT INTO Number_of_image (Number) VALUES('{imageNameAndClassName.Length}')", con);
                    command3.ExecuteNonQuery();
                    command3.Dispose();

                    command4 = new SQLiteCommand(
                        "CREATE TABLE IF NOT EXISTS \"Sources\"" +
                        "(\"URL\" VARCHAR(150), " +
                        "\"License\" VARCHAR(150))", con);
                    command4.ExecuteNonQuery();
                    for (int i = 0; i < arrWithURL.Length || i < arrWithLicense.Length; i++)
                    {
                        if (i < arrWithURL.Length && i < arrWithLicense.Length)
                        {
                            command4 = new SQLiteCommand($"INSERT INTO Sources (URL, License) VALUES('{arrWithURL[i]}', '{arrWithLicense[i]}')", con);
                            command4.ExecuteNonQuery();
                        }
                        else
                        {
                            if (i < arrWithURL.Length)
                            {
                                command4 = new SQLiteCommand($"INSERT INTO Sources (URL) VALUES('{arrWithURL[i]}')", con);
                                command4.ExecuteNonQuery();
                            }
                            if (i < arrWithLicense.Length)
                            {
                                command4 = new SQLiteCommand($"INSERT INTO Sources (License) VALUES('{arrWithLicense[i]}')", con);
                                command4.ExecuteNonQuery();
                            }
                        }
                    }
                    command4.Dispose();
                }
            }
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
    }
}
