using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WritingToolsDB
{
    public partial class AddForm : Form
    {
        SqlData MySql = new SqlData();
        public string path;
        public string name_db;
        public AddForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void button_addData_Click(object sender, EventArgs e)
        {
            if (CheckParams() == 0)
            {
                MySql.connectDB(path);

                string manufacturer = textBox_manufacturer.Text;

                string model_name = textBox_name.Text;

                string ink_color = textBox_color.Text;

                double ball_diameter = (double)Convert.ToDouble(numericUpDown_diameter.Value);

                int quantity = Convert.ToInt32(numericUpDown_quantity.Text);

                double price = (double)Convert.ToDouble(numericUpDown_price.Text);

                string AddQuery = $"insert into " + name_db + $" (manufacturer, modelname, inkcolor, balldiameter, quantity, price) values ('{manufacturer}', '{model_name}','{ink_color}','{ball_diameter   }','{quantity}','{price}')";

                var sqlDataAdapter = new SqlDataAdapter(AddQuery, MySql.sqlConnection);

                /// для следующего заполнения данными
                var dataset = new DataSet();

                /// заполнение dataset данными из бд nameDB
                sqlDataAdapter.Fill(dataset, name_db);

                textBox_manufacturer.Text = "";
                textBox_color.Text = "";
                textBox_name.Text = "";
                numericUpDown_diameter.Text = "";
                numericUpDown_quantity.Text = "";
                numericUpDown_price.Text = "";


                //toolStripStatusLabel1.Text = "";
            }
        }

        private int CheckParams()
        {
            int count = 0; /// Счётчик ошибок
            textBox_manufacturer.BackColor = Color.White;
            textBox_name.BackColor = Color.White;
            textBox_color.BackColor = Color.White;
            numericUpDown_quantity.BackColor = Color.White;
            numericUpDown_diameter.BackColor = Color.White;
            numericUpDown_price.BackColor = Color.White;

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

            float temp4; 
            if (float.TryParse(numericUpDown_diameter.Text, out temp4) == false) 
            {
                numericUpDown_diameter.BackColor = Color.LightPink;
                count++;
            }
            else numericUpDown_diameter.BackColor = Color.White;


            int temp5;
            if (int.TryParse(numericUpDown_quantity.Text, out temp5) == false)
            {
                numericUpDown_quantity.BackColor = Color.LightPink;
                count++;
            }
            else numericUpDown_quantity.BackColor = Color.White;


            float temp6;
            if (float.TryParse(numericUpDown_price.Text, out temp6) == false)
            {
                numericUpDown_price.BackColor = Color.LightPink;
                count++;
            }
            else numericUpDown_price.BackColor = Color.White;
            return count;
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_diameter.Text = numericUpDown_diameter.Text.Replace(',', '.');
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

            // toolStripStatusLabel1.Text = "";
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            numericUpDown_quantity.Text = "";
            numericUpDown_diameter.Text = "";
            numericUpDown_price.Text = "";
        }
    }
}

