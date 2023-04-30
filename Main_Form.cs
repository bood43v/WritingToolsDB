using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WritingToolsDB
{
    public partial class Main_Form : Form
    {

        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataset = null;

        //SqlData MySql();

        private bool newRowAdding = false;
        public Main_Form()
        {
            InitializeComponent();
        }


        /// <summary>
        /// начальная загрузка данных в таблицу
        /// </summary>
        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Operation] FROM Pencils", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                /// комманды для работы с бд
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetDeleteCommand();
                sqlBuilder.GetUpdateCommand();

                dataset = new DataSet();

                sqlDataAdapter.Fill(dataset, "Pencils");
                dataGridView.DataSource = dataset.Tables["Pencils"];

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView[7, i] = linkCell;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// перезагрузка/обновление/сохранение бд
        /// </summary>
        private void ReloadData()
        {
            try
            {
                /// очистка перед новой загрузкой
                dataset.Tables["Pencils"].Clear();
                //

                sqlDataAdapter.Fill(dataset, "Pencils");

                dataGridView.DataSource = dataset.Tables["Pencils"];

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// загрузка формы -> подключение к БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Form_Load(object sender, EventArgs e)
        {

            string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\budae\Documents\WritingToolsDB\Pencils.mdf;Integrated Security=True";
            /// подключение к БД
            sqlConnection = new SqlConnection(path);

            sqlConnection.Open();

            /// загрузка данных
            LoadData();

            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm();
            addform.Owner = this;
            addform.Show();
        }

        private void  dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7 && e.RowIndex != -1)
                {

                    string task = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
    
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView.Rows.RemoveAt(rowIndex);

                            dataset.Tables["Pencils"].Rows[rowIndex].Delete();

                            sqlDataAdapter.Update(dataset, "Pencils");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView.Rows.Count - 2;
                        DataRow row = dataset.Tables["Pencils"].NewRow();

                        row["Manufacturer"] = dataGridView.Rows[rowIndex].Cells["Manufacturer"].Value;
                        row["ModelName"] = dataGridView.Rows[rowIndex].Cells["ModelName"].Value;
                        row["InkColor"] = dataGridView.Rows[rowIndex].Cells["InkColor"].Value;
                        row["BallDiameter"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[rowIndex].Cells["BallDiameter"].Value);
                        row["Quantity"] = dataGridView.Rows[rowIndex].Cells["Quantity"].Value;
                        row["Price"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[rowIndex].Cells["Price"].Value);

                        dataset.Tables["Pencils"].Rows.Add(row);
                        dataset.Tables["Pencils"].Rows.RemoveAt(dataset.Tables["Pencils"].Rows.Count - 1);
                        dataGridView.Rows.RemoveAt(dataGridView.Rows.Count - 2);

                        dataGridView.Rows[e.RowIndex].Cells[7].Value = "Delete";

                        sqlDataAdapter.Update(dataset, "Pencils");

                        newRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        dataset.Tables["Pencils"].Rows[r]["Manufacturer"] = dataGridView.Rows[r].Cells["Manufacturer"].Value;
                        dataset.Tables["Pencils"].Rows[r]["ModelName"] = dataGridView.Rows[r].Cells["ModelName"].Value;
                        dataset.Tables["Pencils"].Rows[r]["InkColor"] = dataGridView.Rows[r].Cells["InkColor"].Value;
                        dataset.Tables["Pencils"].Rows[r]["BallDiameter"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[r].Cells["BallDiameter"].Value);
                        dataset.Tables["Pencils"].Rows[r]["Quantity"] = dataGridView.Rows[r].Cells["Quantity"].Value;
                        dataset.Tables["Pencils"].Rows[r]["Price"] = /*(double)Convert.ToDouble*/(dataGridView.Rows[r].Cells["Price"].Value);

                        sqlDataAdapter.Update(dataset, "Pencils");
                        dataGridView.Rows[e.RowIndex].Cells[7].Value = "Delete";
                        //newRowAdding = false;
                    }
                }
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridView.Rows.Count - 2;

                    DataGridViewRow row = dataGridView.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView[7, lastRow] = linkCell;

                    row.Cells["Operation"].Value = "Insert";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    //newRowAdding = true;

                    int rowIndex = dataGridView.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView[7, rowIndex] = linkCell;

                    editingRow.Cells["Operation"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridView.CurrentCell.ColumnIndex == 4 ||
                dataGridView.CurrentCell.ColumnIndex == 5 ||
                dataGridView.CurrentCell.ColumnIndex == 6)
            {
                TextBox textBox = e.Control as TextBox;
                if(textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// действия при сортировке
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
    }
}
