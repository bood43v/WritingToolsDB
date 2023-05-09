/// Класс для работы с БД на основе SqlClient
/// Автор: Будаев Г.Б.
using System.Data;
/// предоставляет доступ к данным для Microsoft SQL Server.
using System.Data.SqlClient;

namespace WritingToolsDB
{
    /// <summary>
    /// класс работы с базой данных
    /// </summary>
    internal class SqlData
    {
        /// <summary>
        /// подключение к базе данных SQL Server
        /// </summary>
        public SqlConnection sqlConnection = null;

        /// <summary>
        /// для команд обработки бд
        /// </summary>
        public SqlCommandBuilder sqlBuilder = null;
        public SqlDataAdapter sqlDataAdapter = null;

        /// <summary>
        /// для передачи данных в бд
        /// </summary>
        public DataSet dataset = null;

        /// <summary>
        /// подключение к бд
        /// </summary>
        /// <param name="path"></param>
        /// 
        
        // todo: path
        public void connectDB(string path)
        {
           /// подключение к БД
            sqlConnection = new SqlConnection(path);
            /// Открывает подключение к базе данных со значениями свойств, определяемыми объектом ConnectionString.
            sqlConnection.Open(); 
        }

        /// <summary>
        /// загрузка данных в dataset используя DataAdapter
        /// </summary>
        /// <param name="nameTable"></param>
        public void loadDB(string nameTable)
        {
            /// загрузка данных в sqlDataAdapter c добавлением столбца
            sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Operation] FROM " + nameTable, sqlConnection);
            /// создание объекта для реализации команд
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

            /// комманды для работы с бд
            sqlBuilder.GetInsertCommand();
            sqlBuilder.GetDeleteCommand();
            sqlBuilder.GetUpdateCommand();

            /// для следующего заполнения данными
            dataset = new DataSet();

            /// заполнение dataset данными из бд nameDB
            sqlDataAdapter.Fill(dataset, nameTable);
        }

        /// <summary>
        /// обновление данных из бд
        /// </summary>
        /// <param name="nameTable"></param>
        public void reloadDB(string nameTable)
        {
            /// очистка перед новой загрузкой
            dataset.Tables[nameTable].Clear();
            /// заполнение dataset данными из бд nameDB
            sqlDataAdapter.Fill(dataset, nameTable);
        }
            
        /// <summary>
        /// удаление строки из бд при удалении строки в таблице
        /// </summary>
        /// <param name="rowIndex"></param> /// номер удаляемой строки
        /// <param name="Table"></param>
        public void deleteRow(int rowIndex, string Table)
        {
            dataset.Tables[Table].Rows[rowIndex].Delete();
        }

        /// <summary>
        /// добавление строки в бд 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="nameTable"></param>
        public void addRow(DataRow row, string nameTable)
        {
            /// добавление в бд
            dataset.Tables[nameTable].Rows.Add(row);
            /// удаление из dataset чтобы не было дубликата
            dataset.Tables[nameTable].Rows.RemoveAt(dataset.Tables[nameTable].Rows.Count - 1);
        }

        /// <summary>
        /// изменение данных
        /// </summary>
        /// <param name="nameTable"></param>
        public void updateDB(string nameTable)
        {
            sqlDataAdapter.Update(dataset, nameTable);
        }

        /// <summary>
        /// вставка строки в бд
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="Query"></param>
        public void insertDB(string nameTable, string Query)
        {
            var sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);

            /// для следующего заполнения данными
            var dataset = new DataSet();

            /// заполнение dataset данными из бд nameDB
            sqlDataAdapter.Fill(dataset, nameTable);
        }

        //public void idSearchDB(string Query)
        //{
        //    SqlCommand command = new SqlCommand(Query, sqlConnection);
        //    SqlDataReader reader = command.ExecuteReader();
        //}

        /// <summary>
        /// выполнение изменения строки бд
        /// </summary>
        /// <param name="Query"></param>
        public void updateRowDB(string Query)
        {
            SqlCommand updateCommand = new SqlCommand(Query, sqlConnection);
            updateCommand.ExecuteNonQuery();
        }

    }   
}
