﻿namespace WritingToolsDB
{
    partial class UpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.button_updateData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_quantity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_price = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_diameter = new System.Windows.Forms.NumericUpDown();
            this.textBox_manufacturer = new System.Windows.Forms.TextBox();
            this.textBox_color = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label_quantity = new System.Windows.Forms.Label();
            this.label_diameter = new System.Windows.Forms.Label();
            this.label_price = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_inkColor = new System.Windows.Forms.Label();
            this.label_manufacturer = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.numericUpDown_id = new System.Windows.Forms.NumericUpDown();
            this.button_idChoosing = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_diameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_id)).BeginInit();
            this.SuspendLayout();
            // 
            // button_updateData
            // 
            this.button_updateData.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_updateData.Location = new System.Drawing.Point(121, 482);
            this.button_updateData.Margin = new System.Windows.Forms.Padding(2);
            this.button_updateData.Name = "button_updateData";
            this.button_updateData.Size = new System.Drawing.Size(144, 41);
            this.button_updateData.TabIndex = 15;
            this.button_updateData.Text = "Изменить";
            this.button_updateData.UseVisualStyleBackColor = true;
            this.button_updateData.Click += new System.EventHandler(this.button_updateData_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_quantity, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_price, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_diameter, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_manufacturer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_color, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_name, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_quantity, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_diameter, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_price, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_inkColor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_manufacturer, 0, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(57, 181);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 292);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // numericUpDown_quantity
            // 
            this.numericUpDown_quantity.Location = new System.Drawing.Point(138, 200);
            this.numericUpDown_quantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_quantity.Name = "numericUpDown_quantity";
            this.numericUpDown_quantity.Size = new System.Drawing.Size(129, 27);
            this.numericUpDown_quantity.TabIndex = 17;
            // 
            // numericUpDown_price
            // 
            this.numericUpDown_price.DecimalPlaces = 2;
            this.numericUpDown_price.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_price.Location = new System.Drawing.Point(138, 252);
            this.numericUpDown_price.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_price.Name = "numericUpDown_price";
            this.numericUpDown_price.Size = new System.Drawing.Size(129, 27);
            this.numericUpDown_price.TabIndex = 16;
            // 
            // numericUpDown_diameter
            // 
            this.numericUpDown_diameter.DecimalPlaces = 2;
            this.numericUpDown_diameter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_diameter.Location = new System.Drawing.Point(138, 150);
            this.numericUpDown_diameter.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_diameter.Name = "numericUpDown_diameter";
            this.numericUpDown_diameter.Size = new System.Drawing.Size(129, 27);
            this.numericUpDown_diameter.TabIndex = 15;
            // 
            // textBox_manufacturer
            // 
            this.textBox_manufacturer.Location = new System.Drawing.Point(137, 2);
            this.textBox_manufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_manufacturer.Name = "textBox_manufacturer";
            this.textBox_manufacturer.Size = new System.Drawing.Size(131, 27);
            this.textBox_manufacturer.TabIndex = 6;
            // 
            // textBox_color
            // 
            this.textBox_color.Location = new System.Drawing.Point(137, 98);
            this.textBox_color.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_color.Name = "textBox_color";
            this.textBox_color.Size = new System.Drawing.Size(131, 27);
            this.textBox_color.TabIndex = 8;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_name.Location = new System.Drawing.Point(3, 46);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(111, 22);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "Model name";
            // 
            // label_quantity
            // 
            this.label_quantity.AutoSize = true;
            this.label_quantity.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_quantity.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_quantity.Location = new System.Drawing.Point(3, 197);
            this.label_quantity.Name = "label_quantity";
            this.label_quantity.Size = new System.Drawing.Size(81, 22);
            this.label_quantity.TabIndex = 4;
            this.label_quantity.Text = "Quantity";
            // 
            // label_diameter
            // 
            this.label_diameter.AutoSize = true;
            this.label_diameter.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_diameter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_diameter.Location = new System.Drawing.Point(3, 147);
            this.label_diameter.Name = "label_diameter";
            this.label_diameter.Size = new System.Drawing.Size(117, 22);
            this.label_diameter.TabIndex = 3;
            this.label_diameter.Text = "Ball diameter";
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_price.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_price.Location = new System.Drawing.Point(3, 249);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(50, 22);
            this.label_price.TabIndex = 5;
            this.label_price.Text = "Price";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(137, 48);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(131, 27);
            this.textBox_name.TabIndex = 7;
            // 
            // label_inkColor
            // 
            this.label_inkColor.AutoSize = true;
            this.label_inkColor.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_inkColor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_inkColor.Location = new System.Drawing.Point(3, 96);
            this.label_inkColor.Name = "label_inkColor";
            this.label_inkColor.Size = new System.Drawing.Size(79, 22);
            this.label_inkColor.TabIndex = 2;
            this.label_inkColor.Text = "Ink color";
            // 
            // label_manufacturer
            // 
            this.label_manufacturer.AutoSize = true;
            this.label_manufacturer.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_manufacturer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_manufacturer.Location = new System.Drawing.Point(3, 0);
            this.label_manufacturer.Name = "label_manufacturer";
            this.label_manufacturer.Size = new System.Drawing.Size(119, 22);
            this.label_manufacturer.TabIndex = 0;
            this.label_manufacturer.Text = "Manufacturer";
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.BackColor = System.Drawing.Color.Transparent;
            this.label_id.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_id.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_id.Location = new System.Drawing.Point(180, 31);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(28, 22);
            this.label_id.TabIndex = 16;
            this.label_id.Text = "ID";
            // 
            // numericUpDown_id
            // 
            this.numericUpDown_id.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_id.Location = new System.Drawing.Point(129, 65);
            this.numericUpDown_id.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_id.Name = "numericUpDown_id";
            this.numericUpDown_id.Size = new System.Drawing.Size(129, 27);
            this.numericUpDown_id.TabIndex = 17;
            this.numericUpDown_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_id_KeyDown);
            // 
            // button_idChoosing
            // 
            this.button_idChoosing.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_idChoosing.Location = new System.Drawing.Point(122, 111);
            this.button_idChoosing.Margin = new System.Windows.Forms.Padding(2);
            this.button_idChoosing.Name = "button_idChoosing";
            this.button_idChoosing.Size = new System.Drawing.Size(144, 41);
            this.button_idChoosing.TabIndex = 18;
            this.button_idChoosing.Text = "Найти";
            this.button_idChoosing.UseVisualStyleBackColor = true;
            this.button_idChoosing.Click += new System.EventHandler(this.button_idChoosing_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(394, 541);
            this.Controls.Add(this.button_idChoosing);
            this.Controls.Add(this.numericUpDown_id);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.button_updateData);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UpdateForm";
            this.Text = "Update";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_diameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_id)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_updateData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDown_quantity;
        private System.Windows.Forms.NumericUpDown numericUpDown_price;
        private System.Windows.Forms.NumericUpDown numericUpDown_diameter;
        private System.Windows.Forms.TextBox textBox_manufacturer;
        private System.Windows.Forms.TextBox textBox_color;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_quantity;
        private System.Windows.Forms.Label label_inkColor;
        private System.Windows.Forms.Label label_diameter;
        private System.Windows.Forms.Label label_price;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_manufacturer;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.NumericUpDown numericUpDown_id;
        private System.Windows.Forms.Button button_idChoosing;
    }
}