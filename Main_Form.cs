/// Файл с обработчиками событий для работы с бд SqlClient
/// Автор: Будаев Г.Б.
/// 
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace WritingToolsDB
{
    public partial class Main_Form : Form
    {
        /// Создание объекта SqlData
        SqlData MySql = new SqlData();

        string name_db = "Pencils";

        string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\budae\Documents\WritingToolsDB\Pencils.mdf;Integrated Security=True";

        /// Для проверки вводится ли строка
        private bool newRowAdding = false;

        public static Main_Form SelfRef { get; set; }
        public Main_Form()
        {
            /// для прозрачности
            this.AllowTransparency = true;
            SelfRef = this;
            InitializeComponent();
        }

        /// <summary>
        /// начальная загрузка данных в таблицу
        /// </summary>
        private void LoadData()
        {
            try
            {
                /// загрузка данных в dataset
                MySql.loadDB(name_db);
                /// вывод данных из dataset в dataGridView
                dataGridView.DataSource = MySql.dataset.Tables[name_db];
               
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
                MySql.reloadDB(name_db);
                /// вывод данных из dataset в dataGridView
                dataGridView.DataSource = MySql.dataset.Tables[name_db];
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
                //MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            MySql.connectDB(path);

            //todo
            // dataGridView.BackgroundColor = Color.Transparent;
            /// загрузка данных
            LoadData();

            /// отключение возможности сортировки для первого и последнего стобцов
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[0].ReadOnly = true;

        }

        /// <summary>
        /// открытие окна добавления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {       
            AddForm addform = new AddForm();

            addform.path = path;
            addform.name_db = name_db;
            //addform.Owner = this;
            addform.ShowDialog();
            ReloadData();
            //newRowAdding = true;

            ///// получение номера строки с вычетом 2, т.к. считаем с 1 и новая строка находится в k + 1
            //int rowIndex = dataGridView.Rows.Count - 1;

            //dataGridView.Rows[rowIndex].Cells["Manufacturer"].Value = DataAddForm.manufacturer;
            //dataGridView.Rows[rowIndex].Cells["ModelName"].Value = DataAddForm.model_name;
            //dataGridView.Rows[rowIndex].Cells["InkColor"].Value = DataAddForm.ink_color;
            //dataGridView.Rows[rowIndex].Cells["BallDiameter"].Value = DataAddForm.ball_diameter;
            //dataGridView.Rows[rowIndex].Cells["Quantity"].Value = DataAddForm.quantity;
            //dataGridView.Rows[rowIndex].Cells["Price"].Value = DataAddForm.price;

            ///// Представляет строку данных row в DataTable 
            //DataRow row = MySql.dataset.Tables[name_db].NewRow();

            ///// заполнение строки бд данными из dataGridView
            //row["Manufacturer"] = dataGridView.Rows[rowIndex].Cells["Manufacturer"].Value;
            //row["ModelName"] = dataGridView.Rows[rowIndex].Cells["ModelName"].Value;
            //row["InkColor"] = dataGridView.Rows[rowIndex].Cells["InkColor"].Value;
            //row["BallDiameter"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[rowIndex].Cells["BallDiameter"].Value);
            //row["Quantity"] = dataGridView.Rows[rowIndex].Cells["Quantity"].Value;
            //row["Price"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[rowIndex].Cells["Price"].Value);
     
            ///// добавление строки в бд 
            //MySql.addRow(row, name_db);

            ///// удаление дубликата
            ////dataGridView.Rows.RemoveAt(dataGridView.Rows.Count - 1);

            ///// изменение операции 
            //dataGridView.Rows[rowIndex].Cells[7].Value = "Delete";

            ///// обновление dataset
            //MySql.updateDB(name_db);

            ///// возврат в исходное состояние для следующей операции
            //newRowAdding = false;

        }

        /// <summary>
        /// обработчик на операции в последнем столбце
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
                            MySql.deleteRow(rowIndex, name_db);

                            /// обновление dataset
                            MySql.updateDB(name_db);
                        }
                    }
                    /// вставка
                    else if (task == "Insert")
                    {
                        /// получение номера строки с вычетом 2, т.к. считаем с 1 и новая строка находится в k + 1
                        int rowIndex = dataGridView.Rows.Count - 2;
                        /// Представляет строку данных row в DataTable 
                        DataRow row = MySql.dataset.Tables[name_db].NewRow();
                        /// заполнение строки бд данными из dataGridView
                        row["Manufacturer"] = dataGridView.Rows[rowIndex].Cells["Manufacturer"].Value;
                        row["ModelName"] = dataGridView.Rows[rowIndex].Cells["ModelName"].Value;
                        row["InkColor"] = dataGridView.Rows[rowIndex].Cells["InkColor"].Value;
                        row["BallDiameter"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[rowIndex].Cells["BallDiameter"].Value);
                        row["Quantity"] = dataGridView.Rows[rowIndex].Cells["Quantity"].Value;
                        row["Price"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[rowIndex].Cells["Price"].Value);

                        /// добавление строки в бд 
                        MySql.addRow(row, name_db);
                        
                        /// удаление дубликата
                        dataGridView.Rows.RemoveAt(dataGridView.Rows.Count - 2);

                        /// изменение операции 
                        dataGridView.Rows[e.RowIndex].Cells[7].Value = "Delete";

                        /// обновление dataset
                        MySql.updateDB(name_db);

                        /// возврат в исходное состояние для следующей операции
                        newRowAdding = false;
                    }
                    /// изменение
                    else if (task == "Update")
                    {
                        /// номер строки
                        int r = e.RowIndex;
                        /// заполнение строки бд данными из dataGridView
                        MySql.dataset.Tables[name_db].Rows[r]["Manufacturer"] = dataGridView.Rows[r].Cells["Manufacturer"].Value;
                        MySql.dataset.Tables[name_db].Rows[r]["ModelName"] = dataGridView.Rows[r].Cells["ModelName"].Value;
                        MySql.dataset.Tables[name_db].Rows[r]["InkColor"] = dataGridView.Rows[r].Cells["InkColor"].Value;
                        MySql.dataset.Tables[name_db].Rows[r]["BallDiameter"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[r].Cells["BallDiameter"].Value);
                        MySql.dataset.Tables[name_db].Rows[r]["Quantity"] = dataGridView.Rows[r].Cells["Quantity"].Value;
                        MySql.dataset.Tables[name_db].Rows[r]["Price"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[r].Cells["Price"].Value);

                        /// Обновление dataset
                        MySql.updateDB(name_db);
                        /// возврат в исходное состояние для следующей операции
                        dataGridView.Rows[e.RowIndex].Cells[7].Value = "Delete";
                        //newRowAdding = false;
                    }
                }
                ReloadData();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ошибка операции. " + ex.Message;
                //MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// обработчик на добавление строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //try
            //{
            //    /// если одновременно не добавляются две
            //    if (newRowAdding == false)
            //    {
                    
            //        newRowAdding = true;
            //        ///// номер последней строки
            //        //int lastRow = dataGridView.Rows.Count - 2;

            //        ///// представляет строку в элементе управления DataGridView
            //        //DataGridViewRow row = dataGridView.Rows[lastRow];

            //        ///// изменение операции и её выделение
            //        //DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //        //dataGridView[7, lastRow] = linkCell;
            //        //row.Cells["Operation"].Value = "Insert";
            //        ////newRowAdding = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    toolStripStatusLabel1.Text = "Ошибка. " + ex.Message;
            //    //MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// обработчик на изменение значений в dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                /// если не добавляется строка
                if (newRowAdding == false)
                {

                    //newRowAdding = true;
                    /// номер измененной строки
                    int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                    /// представляет строку в элементе управления DataGridView
                    DataGridViewRow editingRow = dataGridView.Rows[rowIndex];

                    /// изменение операции и её выделение
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView[7, rowIndex] = linkCell;
                    dataGridView.Rows[rowIndex].Cells[1].Selected = true;
                    editingRow.Cells["Operation"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ошибка. " + ex.Message;
                //MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// проверка вводимых символов в ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            //if (dataGridView.CurrentCell.ColumnIndex == 5||
            //    dataGridView.CurrentCell.ColumnIndex == 5 ||
            //    dataGridView.CurrentCell.ColumnIndex == 6)
            //{
            //    TextBox textBox = e.Control as TextBox;
            //    if(textBox != null)
            //    {
            //        textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
            //    }
            //}
        }

        /// <summary>
        /// какие символы запрещены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

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

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // you can obtain current editing value like this:
            string value = null;
            var ctl = dataGridView.EditingControl as DataGridViewTextBoxEditingControl;

            if (ctl != null)
                value = ctl.Text;

            // you can obtain the current commited value
            object current = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string message;
            switch (e.ColumnIndex)
            {
                case 0:
                    // bound to integer field
                    message = "the value should be a number";
                    break;
                default:
                    message = "Invalid data";
                    break;
            }
        }


    }
}
