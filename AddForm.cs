/// Форма добавления нового элемента в БД
/// Автор Будаев Г.Б. ВМК-21
using System;
using System.Drawing;
using System.Windows.Forms;


namespace WritingToolsDB
{
    public partial class AddForm : Form
    {
        /// Создаём объект SqlData для работы с бд
        SqlData MySql = new SqlData();
        /// путь
        public string path;
        /// имя бд
        public string name_db; 
        public AddForm()
        {
            InitializeComponent();
            /// создание в центре
            StartPosition = FormStartPosition.CenterParent;
        }


        private void AddForm_Load(object sender, EventArgs e)
        {
            /// для корректного ввода запятых/точек
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            //textBox_manufacturer.Text = "Brauberg";
            //textBox_name.Text = "Lite";
            //textBox_color.Text = "синий";
            //numericUpDown_quantity.Value = 1;
            //numericUpDown_diameter.Text = "0.7";
            //numericUpDown_price.Text = "50";

            //textBox_manufacturer.ForeColor = Color.Gray;
            //textBox_name.ForeColor = Color.Gray;
            //textBox_color.ForeColor = Color.Gray;
            //numericUpDown_quantity.ForeColor = Color.Gray;
            //numericUpDown_diameter.ForeColor = Color.Gray;
            //numericUpDown_price.ForeColor = Color.Gray;
        }


        /// <summary>
        /// добавить данные в бд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_addData_Click(object sender, EventArgs e)
        {
            /// если данные введены корректно
            if (CheckParams() == 0) 
            {
                /// подключение к бд
                MySql.connectDB(path); 

                /// заносим данные в переменные
                string manufacturer = textBox_manufacturer.Text; 

                string model_name = textBox_name.Text;

                string ink_color = textBox_color.Text;

                double ball_diameter = (double)Convert.ToDouble(numericUpDown_diameter.Value);

                int quantity = Convert.ToInt32(numericUpDown_quantity.Text);

                double price = (double)Convert.ToDouble(numericUpDown_price.Text);

                /// формируем команду вставки
                string AddQuery = $"insert into " + name_db + $" (manufacturer, modelname, inkcolor, balldiameter, quantity, price) values ('{manufacturer}', '{model_name}','{ink_color}','{ball_diameter   }','{quantity}','{price}')";

                /// вызов метода вставки в бд
                MySql.insertDB(name_db, AddQuery);

                /// обнуляем поля для ввода следующий значений
                textBox_manufacturer.Text = "";
                textBox_color.Text = "";
                textBox_name.Text = "";
                numericUpDown_diameter.Text = "";
                numericUpDown_quantity.Text = "";
                numericUpDown_price.Text = "";


                //toolStripStatusLabel1.Text = "";
            }
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
        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
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
        /// действия при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


    }
}

