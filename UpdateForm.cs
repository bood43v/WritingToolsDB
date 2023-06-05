/// Форма изменения элемента в БД по id
/// Автор Будаев Г.Б. ВМК-21
using System;
using System.Data.SqlClient; /// для Sql команд
using System.Drawing;
using System.Windows.Forms;


namespace WritingToolsDB
{
    public partial class UpdateForm : Form
    {
        /// объект SqlData для работы с бд
        public SqlData MySql;
        /// путь
        public string path;
        /// имя бд
        public string name_table;
        /// id изменяемого элемента
        public int id;
        public UpdateForm()
        {
            InitializeComponent();
            /// создание в центре
            StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// действия при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateForm_Load(object sender, EventArgs e)
        {
            // toolStripStatusLabel1.Text = "";
            /// для корректного ввода запятых/точек
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            textBox_manufacturer.Text = "";
            textBox_color.Text = "";
            textBox_name.Text = "";
            numericUpDown_quantity.Text = "";
            numericUpDown_diameter.Text = "";
            numericUpDown_price.Text = "";

            textBox_manufacturer.Enabled = false;
            textBox_color.Enabled = false;
            textBox_name.Enabled = false;
            numericUpDown_quantity.Enabled = false;
            numericUpDown_diameter.Enabled = false;
            numericUpDown_price.Enabled = false;
            button_updateData.Enabled = false;
        }

        /// <summary>
        /// проверка ввода данных
        /// </summary>
        /// <returns></returns>
        private int CheckParams()
        {
            int count = 0; /// Счётчик ошибок
            /// обнуление цветов
            textBox_manufacturer.BackColor = Color.White;
            textBox_name.BackColor = Color.White;
            textBox_color.BackColor = Color.White;
            numericUpDown_quantity.BackColor = Color.White;
            numericUpDown_diameter.BackColor = Color.White;
            numericUpDown_price.BackColor = Color.White;

            /// если строка пустая, увеличиваем count и изменяем цвет
            if (string.IsNullOrWhiteSpace(textBox_manufacturer.Text))
            {
                textBox_manufacturer.BackColor = Color.LightPink;
                count++;
            }
            else textBox_manufacturer.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                textBox_name.BackColor = Color.LightPink;
                count++;
            }
            else textBox_name.BackColor = Color.White;


            if (string.IsNullOrWhiteSpace(textBox_color.Text))
            {
                textBox_color.BackColor = Color.LightPink;
                count++;
            }
            else textBox_color.BackColor = Color.White;

            /// если не вещественное число, увеличиваем count и изменяем цвет
            //float temp4;
            //if (float.TryParse(numericUpDown_diameter.Text, out temp4) == false)
            //{
            //    numericUpDown_diameter.BackColor = Color.LightPink;
            //    count++;
            //}
            //else numericUpDown_diameter.BackColor = Color.White;


            //int temp5;
            //if (int.TryParse(numericUpDown_quantity.Text, out temp5) == false)
            //{
            //    numericUpDown_quantity.BackColor = Color.LightPink;
            //    count++;
            //}
            //else numericUpDown_quantity.BackColor = Color.White;


            //float temp6;
            //if (float.TryParse(numericUpDown_price.Text, out temp6) == false)
            //{
            //    numericUpDown_price.BackColor = Color.LightPink;
            //    count++;
            //}
            //else numericUpDown_price.BackColor = Color.White;
            return count;
        }

        /// <summary>
        /// закрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// замена запятой на точку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_diameter.Text = numericUpDown_diameter.Text.Replace(',', '.');
        }


        private void numericUpDown_price_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_price.Text = numericUpDown_price.Text.Replace(',', '.');
        }

        /// <summary>
        /// вывод данных по id, если существует
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_idChoosing_Click(object sender, EventArgs e)
        {
            /// подключение к бд
            MySql.connectDB(path);
            /// формируем команду select и выполняем
            string SelectQuery = $"SELECT * FROM " + name_table + $" WHERE id =  ('{numericUpDown_id.Value}')";     
            SqlCommand command = new SqlCommand(SelectQuery, MySql.sqlConnection);
            /// выполнение команды
            SqlDataReader reader = command.ExecuteReader();
            /// если возвращены строки (1 строка, т.к. id - первичный ключ
            if (reader.HasRows)
            {
                /// выводим данные на форму и делаем активными
                numericUpDown_id.BackColor = Color.White;
                id = Convert.ToInt32(numericUpDown_id.Value);
                textBox_manufacturer.Enabled = true;
                textBox_color.Enabled = true;
                textBox_name.Enabled = true;
                numericUpDown_quantity.Enabled = true;
                numericUpDown_diameter.Enabled = true;
                numericUpDown_price.Enabled = true;
                button_updateData.Enabled = true;

                /// выводим сами данные
                while(reader.Read())
                {
                    textBox_manufacturer.Text = reader.GetValue(1).ToString();
                    textBox_name.Text = reader.GetValue(2).ToString();
                    textBox_color.Text = reader.GetValue(3).ToString();
                    numericUpDown_diameter.Text = reader.GetValue(4).ToString();
                    numericUpDown_quantity.Text = reader.GetValue(5).ToString();
                    numericUpDown_price.Text = reader.GetValue(6).ToString();
                }
                /// закрытие reader
                reader.Close();
            }
            /// меняем цвет, если такого id нет
            else numericUpDown_id.BackColor = Color.LightPink;
        }

        /// <summary>
        /// кнопка изменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_updateData_Click_1(object sender, EventArgs e)
        {
            /// если данные введены корректно
            if (CheckParams() == 0)
            {
                /// заносим данные в переменные
                string manufacturer = textBox_manufacturer.Text;

                string model_name = textBox_name.Text;

                string ink_color = textBox_color.Text;

                double ball_diameter = (double)Convert.ToDouble(numericUpDown_diameter.Value);

                int quantity = Convert.ToInt32(numericUpDown_quantity.Text);

                double price = (double)Convert.ToDouble(numericUpDown_price.Text);

                /// формируем команду изменения
                string updateQuery = $"UPDATE " + name_table + $" SET Manufacturer = '{manufacturer}', ModelName = '{model_name}', InkColor = '{ink_color}', BallDiameter = '{ball_diameter}'," +
                    $"quantity = '{quantity}',price = '{price}' WHERE id = '{id}'";

                MySql.updateRowDB(updateQuery);

                /// обнуляем поля
                textBox_manufacturer.Text = "";
                textBox_color.Text = "";
                textBox_name.Text = "";
                numericUpDown_diameter.Text = "";
                numericUpDown_quantity.Text = "";
                numericUpDown_price.Text = "";
            }
        }

        /// <summary>
        /// отправка изменений по Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_id_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_idChoosing_Click(sender, e);
            }
        }

    }
}

