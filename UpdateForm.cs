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
    public partial class UpdateForm : Form
    {
        SqlData MySql = new SqlData();
        public string path;
        public string name_db;
        public int id;
        public UpdateForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            // toolStripStatusLabel1.Text = "";
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

        private void button_idChoosing_Click(object sender, EventArgs e)
        {
            MySql.connectDB(path);

            SqlCommand command = new SqlCommand($"SELECT * FROM " + name_db + $" WHERE id =  ('{numericUpDown_id.Value}')", MySql.sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                id = Convert.ToInt32(numericUpDown_id.Value);
                textBox_manufacturer.Enabled = true;
                textBox_color.Enabled = true;
                textBox_name.Enabled = true;
                numericUpDown_quantity.Enabled = true;
                numericUpDown_diameter.Enabled = true;
                numericUpDown_price.Enabled = true;
                button_updateData.Enabled = true;

                while(reader.Read())
                {
                    textBox_manufacturer.Text = reader.GetValue(1).ToString();
                    textBox_name.Text = reader.GetValue(2).ToString();
                    textBox_color.Text = reader.GetValue(3).ToString();
                    numericUpDown_diameter.Text = reader.GetValue(4).ToString();
                    numericUpDown_quantity.Text = reader.GetValue(5).ToString();
                    numericUpDown_price.Text = reader.GetValue(6).ToString();
                }
                reader.Close();
            }
        }

        private void button_updateData_Click_1(object sender, EventArgs e)
        {
            if (CheckParams() == 0)
            {
                string manufacturer = textBox_manufacturer.Text;

                string model_name = textBox_name.Text;

                string ink_color = textBox_color.Text;

                double ball_diameter = (double)Convert.ToDouble(numericUpDown_diameter.Value);

                int quantity = Convert.ToInt32(numericUpDown_quantity.Text);

                double price = (double)Convert.ToDouble(numericUpDown_price.Text);

                string updateQuery = $"UPDATE " + name_db + $" SET Manufacturer = '{manufacturer}', ModelName = '{model_name}', InkColor = '{ink_color}', BallDiameter = '{ball_diameter}'," +
                    $"quantity = '{quantity}',price = '{price}' WHERE id = '{id}'";

                SqlCommand updateCommand = new SqlCommand(updateQuery, MySql.sqlConnection);
                updateCommand.ExecuteNonQuery();

                textBox_manufacturer.Text = "";
                textBox_color.Text = "";
                textBox_name.Text = "";
                numericUpDown_diameter.Text = "";
                numericUpDown_quantity.Text = "";
                numericUpDown_price.Text = "";
            }
        }

        private void numericUpDown_id_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_idChoosing_Click(sender, e);
            }
        }
    }
}

