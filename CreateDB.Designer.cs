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
            this.button_create = new System.Windows.Forms.Button();
            this.button_browse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.Color.Transparent;
            this.label_name.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.ForeColor = System.Drawing.Color.White;
            this.label_name.Location = new System.Drawing.Point(68, 43);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(92, 22);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Название";
            // 
            // label_folder
            // 
            this.label_folder.AutoSize = true;
            this.label_folder.BackColor = System.Drawing.Color.Transparent;
            this.label_folder.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_folder.ForeColor = System.Drawing.Color.White;
            this.label_folder.Location = new System.Drawing.Point(25, 93);
            this.label_folder.Name = "label_folder";
            this.label_folder.Size = new System.Drawing.Size(135, 22);
            this.label_folder.TabIndex = 1;
            this.label_folder.Text = "Расположение";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_name.Location = new System.Drawing.Point(179, 40);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(255, 27);
            this.textBox_name.TabIndex = 2;
            // 
            // textBox_folder
            // 
            this.textBox_folder.Enabled = false;
            this.textBox_folder.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_folder.Location = new System.Drawing.Point(179, 93);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(255, 27);
            this.textBox_folder.TabIndex = 3;
            // 
            // button_create
            // 
            this.button_create.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_create.Location = new System.Drawing.Point(461, 137);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(93, 27);
            this.button_create.TabIndex = 4;
            this.button_create.Text = "Создать";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_browse
            // 
            this.button_browse.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_browse.Location = new System.Drawing.Point(461, 93);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(93, 27);
            this.button_browse.TabIndex = 5;
            this.button_browse.Text = "Обзор";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // CreateDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(584, 191);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label_folder);
            this.Controls.Add(this.label_name);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 230);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 230);
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
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_browse;
    }
}