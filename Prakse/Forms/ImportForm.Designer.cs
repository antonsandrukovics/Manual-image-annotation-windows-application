namespace Prakse
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.NameOfDataset = new System.Windows.Forms.Label();
            this.lengthOfDataset = new System.Windows.Forms.Label();
            this.listBoxWithNewClass = new System.Windows.Forms.ListBox();
            this.ClassName = new System.Windows.Forms.Label();
            this.textBoxWithNewClassName = new System.Windows.Forms.TextBox();
            this.addClassName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonClassRemove = new System.Windows.Forms.Button();
            this.buttonAddNewClass = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ChoseFolder = new System.Windows.Forms.Button();
            this.directoryPathForSortingFiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // NameOfDataset
            // 
            this.NameOfDataset.AutoSize = true;
            this.NameOfDataset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfDataset.ForeColor = System.Drawing.Color.Black;
            this.NameOfDataset.Location = new System.Drawing.Point(204, 137);
            this.NameOfDataset.Name = "NameOfDataset";
            this.NameOfDataset.Size = new System.Drawing.Size(116, 25);
            this.NameOfDataset.TabIndex = 0;
            this.NameOfDataset.Text = "Datukopa: ";
            // 
            // lengthOfDataset
            // 
            this.lengthOfDataset.AutoSize = true;
            this.lengthOfDataset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lengthOfDataset.ForeColor = System.Drawing.Color.Black;
            this.lengthOfDataset.Location = new System.Drawing.Point(204, 162);
            this.lengthOfDataset.Name = "lengthOfDataset";
            this.lengthOfDataset.Size = new System.Drawing.Size(135, 25);
            this.lengthOfDataset.TabIndex = 1;
            this.lengthOfDataset.Text = "Attēlu skaits:";
            // 
            // listBoxWithNewClass
            // 
            this.listBoxWithNewClass.FormattingEnabled = true;
            this.listBoxWithNewClass.Location = new System.Drawing.Point(28, 74);
            this.listBoxWithNewClass.Name = "listBoxWithNewClass";
            this.listBoxWithNewClass.Size = new System.Drawing.Size(140, 225);
            this.listBoxWithNewClass.TabIndex = 2;
            // 
            // ClassName
            // 
            this.ClassName.AutoSize = true;
            this.ClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassName.ForeColor = System.Drawing.Color.Black;
            this.ClassName.Location = new System.Drawing.Point(24, 47);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(127, 24);
            this.ClassName.TabIndex = 3;
            this.ClassName.Text = "Klašu saraksts";
            // 
            // textBoxWithNewClassName
            // 
            this.textBoxWithNewClassName.Location = new System.Drawing.Point(209, 75);
            this.textBoxWithNewClassName.Name = "textBoxWithNewClassName";
            this.textBoxWithNewClassName.Size = new System.Drawing.Size(307, 20);
            this.textBoxWithNewClassName.TabIndex = 6;
            // 
            // addClassName
            // 
            this.addClassName.AutoSize = true;
            this.addClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClassName.ForeColor = System.Drawing.Color.Black;
            this.addClassName.Location = new System.Drawing.Point(205, 48);
            this.addClassName.Name = "addClassName";
            this.addClassName.Size = new System.Drawing.Size(115, 24);
            this.addClassName.TabIndex = 7;
            this.addClassName.Text = "Ievadiet klasi";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SeaGreen;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(500, 0);
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
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(469, 0);
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
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(40, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 35);
            this.label3.TabIndex = 15;
            this.label3.Text = "Klašu pievienošana";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label3_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label3_MouseUp);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(5, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 29);
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            this.pictureBox5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label3_MouseMove);
            this.pictureBox5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label3_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox3.Location = new System.Drawing.Point(5, 317);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(525, 5);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Location = new System.Drawing.Point(0, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(5, 287);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(530, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(5, 287);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // buttonImport
            // 
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Image = global::Prakse.Properties.Resources.button_importet_attelus;
            this.buttonImport.Location = new System.Drawing.Point(340, 275);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(171, 40);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonClassRemove
            // 
            this.buttonClassRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClassRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassRemove.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonClassRemove.Image = global::Prakse.Properties.Resources.button_nodzest;
            this.buttonClassRemove.Location = new System.Drawing.Point(404, 93);
            this.buttonClassRemove.Name = "buttonClassRemove";
            this.buttonClassRemove.Size = new System.Drawing.Size(112, 37);
            this.buttonClassRemove.TabIndex = 5;
            this.buttonClassRemove.UseVisualStyleBackColor = true;
            this.buttonClassRemove.Click += new System.EventHandler(this.ButtonClassRemove_Click);
            // 
            // buttonAddNewClass
            // 
            this.buttonAddNewClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddNewClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddNewClass.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonAddNewClass.Image = global::Prakse.Properties.Resources.button_pievienot;
            this.buttonAddNewClass.Location = new System.Drawing.Point(209, 97);
            this.buttonAddNewClass.Name = "buttonAddNewClass";
            this.buttonAddNewClass.Size = new System.Drawing.Size(106, 29);
            this.buttonAddNewClass.TabIndex = 4;
            this.buttonAddNewClass.UseVisualStyleBackColor = true;
            this.buttonAddNewClass.Click += new System.EventHandler(this.ButtonAddNewClass_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(535, 35);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // ChoseFolder
            // 
            this.ChoseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoseFolder.Image = global::Prakse.Properties.Resources.button_izveleties_mapi__1_;
            this.ChoseFolder.Location = new System.Drawing.Point(399, 249);
            this.ChoseFolder.Name = "ChoseFolder";
            this.ChoseFolder.Size = new System.Drawing.Size(117, 20);
            this.ChoseFolder.TabIndex = 18;
            this.ChoseFolder.UseVisualStyleBackColor = true;
            this.ChoseFolder.Click += new System.EventHandler(this.ChoseFolder_Click);
            // 
            // directoryPathForSortingFiles
            // 
            this.directoryPathForSortingFiles.Location = new System.Drawing.Point(293, 249);
            this.directoryPathForSortingFiles.Name = "directoryPathForSortingFiles";
            this.directoryPathForSortingFiles.Size = new System.Drawing.Size(100, 20);
            this.directoryPathForSortingFiles.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(205, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 81);
            this.label1.TabIndex = 20;
            this.label1.Text = "Izvēlēties mapi, kurā glabāt datukopu:";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(535, 322);
            this.Controls.Add(this.directoryPathForSortingFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChoseFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.addClassName);
            this.Controls.Add(this.textBoxWithNewClassName);
            this.Controls.Add(this.buttonClassRemove);
            this.Controls.Add(this.buttonAddNewClass);
            this.Controls.Add(this.ClassName);
            this.Controls.Add(this.listBoxWithNewClass);
            this.Controls.Add(this.lengthOfDataset);
            this.Controls.Add(this.NameOfDataset);
            this.Controls.Add(this.pictureBox4);
            this.ForeColor = System.Drawing.Color.RosyBrown;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportForm";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameOfDataset;
        private System.Windows.Forms.Label lengthOfDataset;
        private System.Windows.Forms.ListBox listBoxWithNewClass;
        private System.Windows.Forms.Label ClassName;
        private System.Windows.Forms.Button buttonAddNewClass;
        private System.Windows.Forms.Button buttonClassRemove;
        private System.Windows.Forms.TextBox textBoxWithNewClassName;
        private System.Windows.Forms.Label addClassName;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChoseFolder;
        private System.Windows.Forms.TextBox directoryPathForSortingFiles;
        private System.Windows.Forms.Label label1;
    }
}