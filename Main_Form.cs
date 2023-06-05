/// Файл с обработчиками событий для работы с бд 
/// Автор: Будаев Г.Б.

using System;
using System.Data;
using System.IO;
using System.Data.SqlClient; /// для Sql команд
using System.Windows.Forms;


namespace WritingToolsDB
{
    public partial class Main_Form : Form
    {
        /// Создание объекта SqlData
        SqlData MySql = new SqlData();

        bool DB_loaded = false;
        /// имя бд
        string name_db;
        /// имя таблицы для работы (всегда одинаковое)
        string name_table = "Pencils";

        string templHead = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
        string templTale = @";Integrated Security=True";
        /// <summary>
        /// текущее расположение выбранной бд при открытии
        /// </summary>
        string currPath;

        /// <summary>
        /// расположение для работы с бд
        /// </summary>
        string path;

        /// Для проверки вводится ли строка
       // private bool newRowAdding = false;

        public static Main_Form SelfRef { get; set; }
        public Main_Form()
        {
            /// для прозрачности
            this.AllowTransparency = true;
            SelfRef = this;
            InitializeComponent();
        }

        /// <summary>
        /// загрузка формы -> подключение к БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Form_Load(object sender, EventArgs e)
        {

            /// строка подключения бд
            /// LocalDB — упрощенная версия ядра СУБД SQL Server Express
            /// MSSQLLocalDB предотвращает конфликты имен с именованными экземплярами LocalDB
            /// AttachDbFilename - полный путь к подключаемой базе данных.
            //

            /// подключение к бд

        }


        private void Main_Form_loadDB()
        {

            /// строка подключения бд
            /// LocalDB — упрощенная версия ядра СУБД SQL Server Express
            /// MSSQLLocalDB предотвращает конфликты имен с именованными экземплярами LocalDB
            /// AttachDbFilename - полный путь к подключаемой базе данных.
            //
            path = templHead + currPath + templTale;
            /// подключение к бд
            MySql.connectDB(path);
            /// загрузка данных
            LoadData();

            /// отключение возможности сортировки для первого и последнего стобцов
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            /// первый столбец неактивный, т.к. заполняется сам
            dataGridView.Columns[0].ReadOnly = true;
            /// прокрутка вниз
            dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.RowCount - 1;
        }


        /// <summary>
        /// начальная загрузка данных в таблицу
        /// </summary>
        private void LoadData()
        {
            try
            {
                /// загрузка данных в dataset
                MySql.loadDB(name_table);
                /// вывод данных из dataset в dataGridView

                /// как работает datasourse
                dataGridView.DataSource = MySql.dataset.Tables[name_table];

                /// выделение команд с столбце операций
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ошибка загрузки данных. " + ex.Message;
                //MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// перезагрузка/обновление/сохранение бд
        /// </summary>
        private void ReloadData()
        {
            try
            {
                /// обновление данных из бд
                MySql.reloadDB(name_table);
                /// вывод данных из dataset в dataGridView
                dataGridView.DataSource = MySql.dataset.Tables[name_table];
                /// выделение команд с столбце операций
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ошибка обновления данных. " + ex.Message;
            }
        }



        /// <summary>
        /// открытие окна добавления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            if(DB_loaded == true)
            {
                AddForm addform = new AddForm();

                addform.path = path;
                addform.MySql = MySql;
                addform.name_table = name_table;
                addform.ShowDialog();
                ReloadData();
                dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.RowCount - 1;
            }

        }

        /// <summary>
        /// обработчик на операции в последнем столбце
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int k = e.RowIndex;
            try
            {
                /// только столбец операций
                if (e.ColumnIndex == 7 && e.RowIndex != -1)
                {
                    /// получение значения операции
                    string task = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                    /// удаление
                    if (task == "Delete")
                    {
                        /// подтверждение удаления
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            /// получение номера строки
                            int rowIndex = e.RowIndex;

                            /// удаление строки из dataGridView
                            dataGridView.Rows.RemoveAt(rowIndex);

                            /// удаление строки из бд
                            MySql.deleteRow(rowIndex, name_table);

                            /// обновление dataset
                            MySql.updateDB(name_table);
                        }
                    }
                    /// изменение
                    //else if (task == "Update")
                    //{
                    //    /// номер строки
                    //    int r = e.RowIndex;
                    //    /// заполнение строки бд данными из dataGridView
                    //    MySql.dataset.Tables[name_db].Rows[r]["Manufacturer"] = dataGridView.Rows[r].Cells["Manufacturer"].Value;
                    //    MySql.dataset.Tables[name_db].Rows[r]["ModelName"] = dataGridView.Rows[r].Cells["ModelName"].Value;
                    //    MySql.dataset.Tables[name_db].Rows[r]["InkColor"] = dataGridView.Rows[r].Cells["InkColor"].Value;
                    //    MySql.dataset.Tables[name_db].Rows[r]["BallDiameter"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[r].Cells["BallDiameter"].Value);
                    //    MySql.dataset.Tables[name_db].Rows[r]["Quantity"] = dataGridView.Rows[r].Cells["Quantity"].Value;
                    //    MySql.dataset.Tables[name_db].Rows[r]["Price"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[r].Cells["Price"].Value);

                    //    /// Обновление dataset
                    //    MySql.updateDB(name_db);
                    //    /// возврат в исходное состояние для следующей операции
                    //    dataGridView.Rows[e.RowIndex].Cells[7].Value = "Delete";
                    //    //newRowAdding = false;
                    //}
                }
                ReloadData();
                dataGridView.FirstDisplayedScrollingRowIndex = k;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ошибка операции. " + ex.Message;
                //MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// обработчик на изменение значений в dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        /// если не добавляется строка
        //        if (newRowAdding == false)
        //        {

        //            //newRowAdding = true;
        //            /// номер измененной строки
        //            int rowIndex = dataGridView.SelectedCells[0].RowIndex;
        //            /// представляет строку в элементе управления DataGridView
        //            DataGridViewRow editingRow = dataGridView.Rows[rowIndex];

        //            /// изменение операции и её выделение
        //            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
        //            dataGridView[7, rowIndex] = linkCell;
        //            dataGridView.Rows[rowIndex].Cells[1].Selected = true;
        //            editingRow.Cells["Operation"].Value = "Update";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        toolStripStatusLabel1.Text = "Ошибка. " + ex.Message;
        //        //MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        /// <summary>
        /// действия при сортировке - сохранение выделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView[7, i] = linkCell;
            }
        }

        /// <summary>
        /// изменение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            if (DB_loaded)
            {
                UpdateForm updateForm = new UpdateForm();
                updateForm.MySql = MySql;
                updateForm.path = path;
                updateForm.name_table = name_table;
                updateForm.ShowDialog();
                ReloadData();
                dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.RowCount - 1;
            }
        }

        /// <summary>
        /// сброс поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_clearSearch_Click(object sender, EventArgs e)
        {
            if(DB_loaded)
            {
                DataView dv = (dataGridView.DataSource as DataTable).DefaultView;
                textBox_search.Text = "";
                dv.RowFilter = $"Manufacturer LIKE '%{textBox_search.Text}%'";
                ReloadData();
            }     
        }

        /// <summary>
        /// открыть бд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// если не был выбран файл -> выход
            openFileDialog1.Filter = "Mdf files(*.mdf)|*.mdf|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            /// ext хранит расширение вырбанного файла
            string ext = Path.GetExtension(openFileDialog1.FileName);
            /// если выбран mdf
            if (ext == ".mdf")
            {
                // отключение, если бд была загружена, для следующего запуска
                if (DB_loaded == true)
                {
                    //SqlConnection.ClearPool(MySql.sqlConnection);
                    
                    MySql.sqlConnection.Close();
                }
                /// имя файла
                name_db = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                
                /// полный путь к файлу
                currPath = openFileDialog1.FileName;
               
                /// загрузка бд
                Main_Form_loadDB();
                DB_loaded = true;
            }
            /// если выбрана не бд
            else MessageBox.Show("Неверный формат базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDB createForm = new CreateDB();
            createForm.ShowDialog();
           // ReloadData();
        }

        /// <summary>
        /// фильтр-поиск 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_find_Click(object sender, EventArgs e)
        {
            //(dataGridView.DataSource as DataTable).DefaultView.RowFilter = $"Manufacturer LIKE '%{domainUpDown.Text}%'";
            /// если бд загружена
            if(DB_loaded == true)
            {
                DataView dv = (dataGridView.DataSource as DataTable).DefaultView;
                if(domainUpDown.Text == "по производителю")
                {
                    dv.RowFilter = $"Manufacturer LIKE '%{textBox_search.Text}%'";
                }
                if (domainUpDown.Text == "по названию модели")
                {
                    dv.RowFilter = $"ModelName LIKE '%{textBox_search.Text}%'";
                }

                if (domainUpDown.Text == "по цвету")
                {
                    dv.RowFilter = $"InkColor LIKE '%{textBox_search.Text}%'";
                }

                dataGridView.DataSource = dv;
                ReloadData();
            }
        }

        /// <summary>
        /// о разработчике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Будаев Г.Б. ВМК-21", "О разработчике", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// поиск по Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_find_Click(sender, e);
            }
        }

        /// <summary>
        /// фильтр-поиск 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            if (DB_loaded == true)
            {
                DataView dv = (dataGridView.DataSource as DataTable).DefaultView;
                if (domainUpDown.Text == "по производителю")
                {
                    dv.RowFilter = $"Manufacturer LIKE '%{textBox_search.Text}%'";
                }
                if (domainUpDown.Text == "по названию модели")
                {
                    dv.RowFilter = $"ModelName LIKE '%{textBox_search.Text}%'";
                }

                if (domainUpDown.Text == "по цвету")
                {
                    dv.RowFilter = $"InkColor LIKE '%{textBox_search.Text}%'";
                }

                dataGridView.DataSource = dv;
                ReloadData();
            }
        }

        private void инструкцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.ShowDialog();
        }
    }
}
