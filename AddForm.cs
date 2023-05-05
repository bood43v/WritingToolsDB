using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WritingToolsDB
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button_addData_Click(object sender, EventArgs e)
        {
            //Main_Form mainForm = this.Owner as Main_Form;
            try
            {
                DataAddForm.manufacturer = textBox_manufacturer.Text;

                DataAddForm.model_name = textBox_name.Text;

                DataAddForm.ink_color = textBox_color.Text;

                DataAddForm.ball_diameter = Convert.ToDouble(textBox_diameter.Text);

                DataAddForm.quantity = Convert.ToInt32(textBox_quantity.Text);

                DataAddForm.price = Convert.ToDouble(textBox_price.Text);

                this.Close();
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
