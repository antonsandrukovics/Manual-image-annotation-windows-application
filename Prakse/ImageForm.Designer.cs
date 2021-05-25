namespace Prakse
{
    partial class ImageForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageForm));
            this.checkedListBoxWithClassName = new System.Windows.Forms.CheckedListBox();
            this.ClassName = new System.Windows.Forms.Label();
            this.ImageLength = new System.Windows.Forms.Label();
            this.ImageLengthCounter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.pictureBoxWithImage = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.DeleteURL = new System.Windows.Forms.Button();
            this.buttonPressURL = new System.Windows.Forms.Button();
            this.EditURL = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.AddURL = new System.Windows.Forms.Button();
            this.DeleteClassLicense = new System.Windows.Forms.Button();
            this.buttonPressLicense = new System.Windows.Forms.Button();
            this.EditClassLicense = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.AddClassLicense = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWithImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxWithClassName
            // 
            this.checkedListBoxWithClassName.FormattingEnabled = true;
            this.checkedListBoxWithClassName.Location = new System.Drawing.Point(303, 87);
            this.checkedListBoxWithClassName.Name = "checkedListBoxWithClassName";
            this.checkedListBoxWithClassName.Size = new System.Drawing.Size(222, 304);
            this.checkedListBoxWithClassName.TabIndex = 0;
            this.checkedListBoxWithClassName.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxWithClassName_ItemCheck);
            // 
            // ClassName
            // 
            this.ClassName.AutoSize = true;
            this.ClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassName.Location = new System.Drawing.Point(298, 53);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(77, 25);
            this.ClassName.TabIndex = 3;
            this.ClassName.Text = "Klases";
            // 
            // ImageLength
            // 
            this.ImageLength.AutoSize = true;
            this.ImageLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageLength.Location = new System.Drawing.Point(28, 53);
            this.ImageLength.Name = "ImageLength";
            this.ImageLength.Size = new System.Drawing.Size(135, 25);
            this.ImageLength.TabIndex = 4;
            this.ImageLength.Text = "Attēlu skaits:";
            // 
            // ImageLengthCounter
            // 
            this.ImageLengthCounter.AutoSize = true;
            this.ImageLengthCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageLengthCounter.Location = new System.Drawing.Point(155, 53);
            this.ImageLengthCounter.Name = "ImageLengthCounter";
            this.ImageLengthCounter.Size = new System.Drawing.Size(70, 25);
            this.ImageLengthCounter.TabIndex = 5;
            this.ImageLengthCounter.Text = "label4";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SeaGreen;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(793, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 35);
            this.label5.TabIndex = 17;
            this.label5.Text = "X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SeaGreen;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(752, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 35);
            this.label4.TabIndex = 16;
            this.label4.Text = "_";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SeaGreen;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 35);
            this.label3.TabIndex = 18;
            this.label3.Text = "Bilžu importēšana";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label3_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label3_MouseUp);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 35);
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            this.pictureBox5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label3_MouseMove);
            this.pictureBox5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label3_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(5, 468);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(818, 5);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(823, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(5, 438);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox4.Location = new System.Drawing.Point(0, 35);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(5, 438);
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonClose.Image = global::Prakse.Properties.Resources.button_aizvert;
            this.buttonClose.Location = new System.Drawing.Point(438, 424);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(109, 37);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonSend.Image = global::Prakse.Properties.Resources.button_pievienot1;
            this.buttonSend.Location = new System.Drawing.Point(268, 424);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(107, 37);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // pictureBoxWithImage
            // 
            this.pictureBoxWithImage.Location = new System.Drawing.Point(28, 87);
            this.pictureBoxWithImage.Name = "pictureBoxWithImage";
            this.pictureBoxWithImage.Size = new System.Drawing.Size(243, 303);
            this.pictureBoxWithImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWithImage.TabIndex = 1;
            this.pictureBoxWithImage.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(828, 35);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(562, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(243, 21);
            this.comboBox1.TabIndex = 27;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(562, 263);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(243, 21);
            this.comboBox2.TabIndex = 28;
            // 
            // DeleteURL
            // 
            this.DeleteURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteURL.ForeColor = System.Drawing.Color.RosyBrown;
            this.DeleteURL.Image = global::Prakse.Properties.Resources.button_nodzest__1_;
            this.DeleteURL.Location = new System.Drawing.Point(649, 176);
            this.DeleteURL.Name = "DeleteURL";
            this.DeleteURL.Size = new System.Drawing.Size(66, 23);
            this.DeleteURL.TabIndex = 37;
            this.DeleteURL.UseVisualStyleBackColor = true;
            this.DeleteURL.Click += new System.EventHandler(this.DeleteURL_Click);
            // 
            // buttonPressURL
            // 
            this.buttonPressURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.buttonPressURL.Location = new System.Drawing.Point(668, 114);
            this.buttonPressURL.Name = "buttonPressURL";
            this.buttonPressURL.Size = new System.Drawing.Size(29, 28);
            this.buttonPressURL.TabIndex = 36;
            this.buttonPressURL.Text = "↓";
            this.toolTip1.SetToolTip(this.buttonPressURL, "Izvēlēties esošos (URL) un pēc tam noklikšķiniet uz šīs pogas!");
            this.buttonPressURL.UseVisualStyleBackColor = true;
            this.buttonPressURL.Click += new System.EventHandler(this.buttonPressURL_Click);
            // 
            // EditURL
            // 
            this.EditURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditURL.ForeColor = System.Drawing.Color.RosyBrown;
            this.EditURL.Image = global::Prakse.Properties.Resources.button_redaktet__1_;
            this.EditURL.Location = new System.Drawing.Point(564, 174);
            this.EditURL.Name = "EditURL";
            this.EditURL.Size = new System.Drawing.Size(72, 25);
            this.EditURL.TabIndex = 35;
            this.EditURL.UseVisualStyleBackColor = true;
            this.EditURL.Click += new System.EventHandler(this.EditURL_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(562, 148);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(243, 20);
            this.textBox3.TabIndex = 34;
            // 
            // AddURL
            // 
            this.AddURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddURL.ForeColor = System.Drawing.Color.RosyBrown;
            this.AddURL.Image = global::Prakse.Properties.Resources.button_pievienot__1_;
            this.AddURL.Location = new System.Drawing.Point(728, 172);
            this.AddURL.Name = "AddURL";
            this.AddURL.Size = new System.Drawing.Size(77, 29);
            this.AddURL.TabIndex = 33;
            this.AddURL.UseVisualStyleBackColor = true;
            this.AddURL.Click += new System.EventHandler(this.AddURL_Click);
            // 
            // DeleteClassLicense
            // 
            this.DeleteClassLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteClassLicense.ForeColor = System.Drawing.Color.RosyBrown;
            this.DeleteClassLicense.Image = global::Prakse.Properties.Resources.button_nodzest__1_;
            this.DeleteClassLicense.Location = new System.Drawing.Point(649, 359);
            this.DeleteClassLicense.Name = "DeleteClassLicense";
            this.DeleteClassLicense.Size = new System.Drawing.Size(66, 23);
            this.DeleteClassLicense.TabIndex = 42;
            this.DeleteClassLicense.UseVisualStyleBackColor = true;
            this.DeleteClassLicense.Click += new System.EventHandler(this.DeleteClassLicense_Click);
            // 
            // buttonPressLicense
            // 
            this.buttonPressLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.buttonPressLicense.Location = new System.Drawing.Point(668, 292);
            this.buttonPressLicense.Name = "buttonPressLicense";
            this.buttonPressLicense.Size = new System.Drawing.Size(29, 28);
            this.buttonPressLicense.TabIndex = 41;
            this.buttonPressLicense.Text = "↓";
            this.toolTip1.SetToolTip(this.buttonPressLicense, "Izvēlēties esošos (Licinces) un pēc tam noklikšķiniet uz šīs pogas!");
            this.buttonPressLicense.UseVisualStyleBackColor = true;
            this.buttonPressLicense.Click += new System.EventHandler(this.buttonPressLicense_Click);
            // 
            // EditClassLicense
            // 
            this.EditClassLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditClassLicense.ForeColor = System.Drawing.Color.RosyBrown;
            this.EditClassLicense.Image = global::Prakse.Properties.Resources.button_redaktet__1_;
            this.EditClassLicense.Location = new System.Drawing.Point(562, 359);
            this.EditClassLicense.Name = "EditClassLicense";
            this.EditClassLicense.Size = new System.Drawing.Size(72, 25);
            this.EditClassLicense.TabIndex = 40;
            this.EditClassLicense.UseVisualStyleBackColor = true;
            this.EditClassLicense.Click += new System.EventHandler(this.EditClassLicense_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(562, 326);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(243, 20);
            this.textBox4.TabIndex = 39;
            // 
            // AddClassLicense
            // 
            this.AddClassLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddClassLicense.ForeColor = System.Drawing.Color.RosyBrown;
            this.AddClassLicense.Image = global::Prakse.Properties.Resources.button_pievienot__1_;
            this.AddClassLicense.Location = new System.Drawing.Point(728, 355);
            this.AddClassLicense.Name = "AddClassLicense";
            this.AddClassLicense.Size = new System.Drawing.Size(77, 29);
            this.AddClassLicense.TabIndex = 38;
            this.AddClassLicense.UseVisualStyleBackColor = true;
            this.AddClassLicense.Click += new System.EventHandler(this.AddClassLicense_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label6.Location = new System.Drawing.Point(557, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 25);
            this.label6.TabIndex = 43;
            this.label6.Text = "Esošos URL:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label7.Location = new System.Drawing.Point(559, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 25);
            this.label7.TabIndex = 44;
            this.label7.Text = "Esošos licences:";
            // 
            // ImageForm
            // 
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(828, 473);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DeleteClassLicense);
            this.Controls.Add(this.buttonPressLicense);
            this.Controls.Add(this.EditClassLicense);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.AddClassLicense);
            this.Controls.Add(this.DeleteURL);
            this.Controls.Add(this.buttonPressURL);
            this.Controls.Add(this.EditURL);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.AddURL);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.ImageLengthCounter);
            this.Controls.Add(this.ImageLength);
            this.Controls.Add(this.ClassName);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.pictureBoxWithImage);
            this.Controls.Add(this.checkedListBoxWithClassName);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ImageForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWithImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
                
        private System.Windows.Forms.CheckedListBox checkedListBoxWithClassName;
        private System.Windows.Forms.PictureBox pictureBoxWithImage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label ClassName;
        private System.Windows.Forms.Label ImageLength;
        private System.Windows.Forms.Label ImageLengthCounter;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button DeleteURL;
        private System.Windows.Forms.Button buttonPressURL;
        private System.Windows.Forms.Button EditURL;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button AddURL;
        private System.Windows.Forms.Button DeleteClassLicense;
        private System.Windows.Forms.Button buttonPressLicense;
        private System.Windows.Forms.Button EditClassLicense;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button AddClassLicense;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}