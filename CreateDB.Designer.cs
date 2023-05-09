namespace WritingToolsDB
{
    partial class CreateDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDB));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label_name = new System.Windows.Forms.Label();
            this.label_folder = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.Color.Transparent;
            this.label_name.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.ForeColor = System.Drawing.Color.White;
            this.label_name.Location = new System.Drawing.Point(24, 34);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(158, 22);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Имя базы данных";
            // 
            // label_folder
            // 
            this.label_folder.AutoSize = true;
            this.label_folder.BackColor = System.Drawing.Color.Transparent;
            this.label_folder.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_folder.ForeColor = System.Drawing.Color.White;
            this.label_folder.Location = new System.Drawing.Point(24, 95);
            this.label_folder.Name = "label_folder";
            this.label_folder.Size = new System.Drawing.Size(135, 22);
            this.label_folder.TabIndex = 1;
            this.label_folder.Text = "Расположение";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_name.Location = new System.Drawing.Point(202, 31);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(255, 27);
            this.textBox_name.TabIndex = 2;
            // 
            // textBox_folder
            // 
            this.textBox_folder.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_folder.Location = new System.Drawing.Point(202, 95);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(255, 27);
            this.textBox_folder.TabIndex = 3;
            // 
            // CreateDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(531, 203);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label_folder);
            this.Controls.Add(this.label_name);
            this.Name = "CreateDB";
            this.Text = "Создать базу данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_folder;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_folder;
    }
}