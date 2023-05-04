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
            //Main_Form Main_Form = this.Owner as Main_Form;
            try
            {

                string manufacturer = textBox_manufacturer.Text;
                string name = textBox_name.Text;
                string color = textBox_color.Text;
                double diameter = (double)Convert.ToDouble(textBox_diameter.Text);
                uint quantity = (uint)Convert.ToUInt64(textBox_quantity.Text);
                double price = (double)Convert.ToDouble(textBox_price.Text);

                textBox_manufacturer.Text = "";
                textBox_name.Text = "";
                textBox_color.Text = "";
                textBox_diameter.Text = "";
                textBox_quantity.Text = "";
                textBox_price.Text = "";                           
            }
            catch
            {
                //MessageBox.Show("Некорректные данные!");
            }
        }
    }
}
