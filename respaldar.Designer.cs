namespace RaposoFact
{
    partial class respaldar
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
            this.butBackupFilePath = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GBRestore = new System.Windows.Forms.GroupBox();
            this.butRestore = new System.Windows.Forms.Button();
            this.txtBackupFilePath = new System.Windows.Forms.TextBox();
            this.btnCheckPostgres = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butSelectLoc = new System.Windows.Forms.Button();
            this.butBackup = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GetDB = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.GBRestore.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butBackupFilePath
            // 
            this.butBackupFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.butBackupFilePath.Location = new System.Drawing.Point(6, 19);
            this.butBackupFilePath.Name = "butBackupFilePath";
            this.butBackupFilePath.Size = new System.Drawing.Size(354, 37);
            this.butBackupFilePath.TabIndex = 0;
            this.butBackupFilePath.Text = "Select the Backup file Path";
            this.butBackupFilePath.UseVisualStyleBackColor = false;
            this.butBackupFilePath.Click += new System.EventHandler(this.butBackupFilePath_Click_1);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(122, 27);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(42, 20);
            this.txtPort.TabIndex = 12;
            this.txtPort.Text = "5432";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Port";
            // 
            // GBRestore
            // 
            this.GBRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GBRestore.Controls.Add(this.butRestore);
            this.GBRestore.Controls.Add(this.txtBackupFilePath);
            this.GBRestore.Controls.Add(this.butBackupFilePath);
            this.GBRestore.ForeColor = System.Drawing.Color.Black;
            this.GBRestore.Location = new System.Drawing.Point(404, 89);
            this.GBRestore.Name = "GBRestore";
            this.GBRestore.Size = new System.Drawing.Size(382, 211);
            this.GBRestore.TabIndex = 10;
            this.GBRestore.TabStop = false;
            this.GBRestore.Text = "Restore";
            // 
            // butRestore
            // 
            this.butRestore.BackColor = System.Drawing.Color.Red;
            this.butRestore.Enabled = false;
            this.butRestore.Location = new System.Drawing.Point(117, 152);
            this.butRestore.Name = "butRestore";
            this.butRestore.Size = new System.Drawing.Size(129, 47);
            this.butRestore.TabIndex = 2;
            this.butRestore.Text = "Restore DB";
            this.butRestore.UseVisualStyleBackColor = false;
            this.butRestore.Click += new System.EventHandler(this.butRestore_Click);
            // 
            // txtBackupFilePath
            // 
            this.txtBackupFilePath.Location = new System.Drawing.Point(6, 62);
            this.txtBackupFilePath.Multiline = true;
            this.txtBackupFilePath.Name = "txtBackupFilePath";
            this.txtBackupFilePath.Size = new System.Drawing.Size(354, 85);
            this.txtBackupFilePath.TabIndex = 1;
            // 
            // btnCheckPostgres
            // 
            this.btnCheckPostgres.BackColor = System.Drawing.Color.Red;
            this.btnCheckPostgres.Location = new System.Drawing.Point(12, 1);
            this.btnCheckPostgres.Name = "btnCheckPostgres";
            this.btnCheckPostgres.Size = new System.Drawing.Size(154, 47);
            this.btnCheckPostgres.TabIndex = 14;
            this.btnCheckPostgres.Text = "Check for Postgres Installation";
            this.btnCheckPostgres.UseVisualStyleBackColor = false;
            this.btnCheckPostgres.Click += new System.EventHandler(this.btnCheckPostgres_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GBRestore);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.GetDB);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(12, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 313);
            this.panel1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.butSelectLoc);
            this.groupBox1.Controls.Add(this.butBackup);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(16, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 211);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup";
            // 
            // butSelectLoc
            // 
            this.butSelectLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.butSelectLoc.Enabled = false;
            this.butSelectLoc.ForeColor = System.Drawing.Color.Black;
            this.butSelectLoc.Location = new System.Drawing.Point(15, 19);
            this.butSelectLoc.Name = "butSelectLoc";
            this.butSelectLoc.Size = new System.Drawing.Size(354, 37);
            this.butSelectLoc.TabIndex = 2;
            this.butSelectLoc.Text = "Select the location  to Save the Backup file";
            this.butSelectLoc.UseVisualStyleBackColor = false;
            this.butSelectLoc.Click += new System.EventHandler(this.butSelectLoc_Click);
            // 
            // butBackup
            // 
            this.butBackup.BackColor = System.Drawing.Color.Cyan;
            this.butBackup.Enabled = false;
            this.butBackup.ForeColor = System.Drawing.Color.Black;
            this.butBackup.Location = new System.Drawing.Point(128, 152);
            this.butBackup.Name = "butBackup";
            this.butBackup.Size = new System.Drawing.Size(129, 47);
            this.butBackup.TabIndex = 4;
            this.butBackup.Text = "Take Backup of DB";
            this.butBackup.UseVisualStyleBackColor = false;
            this.butBackup.Click += new System.EventHandler(this.butBackup_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(354, 85);
            this.textBox1.TabIndex = 3;
            // 
            // GetDB
            // 
            this.GetDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GetDB.Location = new System.Drawing.Point(256, 12);
            this.GetDB.Name = "GetDB";
            this.GetDB.Size = new System.Drawing.Size(129, 48);
            this.GetDB.TabIndex = 8;
            this.GetDB.Text = "Get All Databases";
            this.GetDB.UseVisualStyleBackColor = false;
            this.GetDB.Click += new System.EventHandler(this.GetDB_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(404, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(354, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(206, 21);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(48, 13);
            this.labelLocation.TabIndex = 15;
            this.labelLocation.Text = "Location";
            this.labelLocation.Visible = false;
            // 
            // respaldar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 581);
            this.Controls.Add(this.btnCheckPostgres);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelLocation);
            this.Name = "respaldar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Respaldar Base de Datos";
            this.Load += new System.EventHandler(this.respaldar_Load);
            this.GBRestore.ResumeLayout(false);
            this.GBRestore.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBackupFilePath;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GBRestore;
        private System.Windows.Forms.Button butRestore;
        private System.Windows.Forms.TextBox txtBackupFilePath;
        private System.Windows.Forms.Button btnCheckPostgres;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butSelectLoc;
        private System.Windows.Forms.Button butBackup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button GetDB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelLocation;
    }
}