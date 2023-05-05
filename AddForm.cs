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

            MySql.connectDB(path);

            string manufacturer = textBox_manufacturer.Text;

            string model_name = textBox_name.Text;

            string ink_color = textBox_color.Text;

            double ball_diameter = Convert.ToDouble(textBox_diameter.Text);

            int quantity = Convert.ToInt32(textBox_quantity.Text);

            double price = Convert.ToDouble(textBox_price.Text);

            string AddQuery = $"insert into Pencils (manufacturer, modelname, inkcolor, balldiameter, quantity, price) values ('{manufacturer}', '{model_name}','{ink_color}','{ball_diameter}','{quantity}','{price}')";

            var sqlDataAdapter = new SqlDataAdapter(AddQuery, MySql.sqlConnection);
            /// для следующего заполнения данными

            /// для следующего заполнения данными
            var dataset = new DataSet();

            /// заполнение dataset данными из бд nameDB
            sqlDataAdapter.Fill(dataset, name_db);

            textBox_manufacturer.Text = "";
            textBox_color.Text = "";
            textBox_name.Text = "";
            textBox_color.Text = "";
            textBox_diameter.Text = "";
            textBox_quantity.Text = "";
            textBox_price.Text = "";
            //Main_Form mainForm = this.Owner as Main_Form;
            try
            {
                //DataAddForm.manufacturer = textBox_manufacturer.Text;

                //DataAddForm.model_name = textBox_name.Text;

                //DataAddForm.ink_color = textBox_color.Text;

                //DataAddForm.ball_diameter = Convert.ToDouble(textBox_diameter.Text);

                //DataAddForm.quantity = Convert.ToInt32(textBox_quantity.Text);

                //DataAddForm.price = Convert.ToDouble(textBox_price.Text);

                //this.Close();


            }
            catch
            {
                //MessageBox.Show("Некорректные данные!");
            }
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
