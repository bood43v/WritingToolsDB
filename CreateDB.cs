/// Форма создания БД
/// Автор: Будаев Г.Б.
using System;
using System.Data;
using System.Data.SqlClient; /// для Sql команд
using System.Windows.Forms;

namespace WritingToolsDB
{
    public partial class CreateDB : Form
    {
        /// <summary>
        /// имя файла
        /// </summary>
        string fileName;
        /// <summary>
        /// каталог
        /// </summary>
        public string currPath;

        public CreateDB()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// выбор каталога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_browse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            currPath = folderBrowserDialog1.SelectedPath;
            textBox_folder.Text = currPath; 
        }

        /// <summary>
        /// создание бд и создание в ней таблицы Pencils
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_create_Click(object sender, EventArgs e)
        {
            //fileName = textBox_name.Text;

            string path = textBox_folder.Text;

            string templHead = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
            string templTale = @";Integrated Security=True";

            path = templHead + currPath + templTale;

            String str;

            SqlConnection myConn = new SqlConnection(path);
            fileName = "MyDB";

            str = "CREATE DATABASE " + fileName + " ON PRIMARY " +
                "(NAME = " + fileName + ", " +
                //"FILENAME = '"+ currPath + "\\" + fileName + ".mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                //"LOG ON (NAME = '" + fileName + "_log', " +
                //"FILENAME = '"+ currPath + "\\" + fileName +".ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            //str = "CREATE DATABASE MyDatabase ON PRIMARY " +
            //    "(NAME = MyDatabase_Data, " +
            //    "FILENAME = 'C:\\MyDatabaseData.mdf', " +
            //    "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            //    "LOG ON (NAME = MyDatabase_Log, " +
            //    "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
            //    "SIZE = 1MB, " +
            //    "MAXSIZE = 5MB, " +
            //    "FILEGROWTH = 10%)";


            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("База данных успешно создана", "Penbase", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string table = "IF NOT EXISTS CREATE TABLE \'Pencils\' ([Id] INT IDENTITY(1, 1) NOT NULL,[Manufacturer] TEXT NULL, [ModelName] TEXT NULL, [InkColor] TEXT NULL, [BallDiameter] FLOAT(53) NULL,[Quantity] INT NULL,[Price] FLOAT(53) NULL, PRIMARY KEY CLUSTERED([Id] ASC));";

                

                SqlCommand createTable;
                createTable = new SqlCommand(table, myConn);
                createTable.ExecuteNonQuery();
                //myConn.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

            //String str;
            //SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            //str = "CREATE DATABASE MyDatabase ON PRIMARY " +
            //    "(NAME = MyDatabase_Data, " +
            //    "FILENAME = 'C:\\MyDatabaseData.mdf', " +
            //    "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            //    "LOG ON (NAME = MyDatabase_Log, " +
            //    "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
            //    "SIZE = 1MB, " +
            //    "MAXSIZE = 5MB, " +
            //    "FILEGROWTH = 10%)";

            //SqlCommand myCommand = new SqlCommand(str, myConn);
            //try
            //{
            //    myConn.Open();
            //    myCommand.ExecuteNonQuery();
            //    MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    if (myConn.State == ConnectionState.Open)
            //    {
            //        myConn.Close();
            //    }
            //}
        }
    }
}
