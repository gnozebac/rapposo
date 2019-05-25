namespace RaposoFact
{
    partial class peliculas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtfestreno = new System.Windows.Forms.TextBox();
            this.cmbgenero = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtreparto = new System.Windows.Forms.TextBox();
            this.txtactriz = new System.Windows.Forms.TextBox();
            this.txtactor = new System.Windows.Forms.TextBox();
            this.txtespanol = new System.Windows.Forms.TextBox();
            this.txtingles = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btneditar = new System.Windows.Forms.Button();
            this.btndescartar = new System.Windows.Forms.Button();
            this.btgnnuevo = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtfestreno
            // 
            this.txtfestreno.Location = new System.Drawing.Point(518, 156);
            this.txtfestreno.Name = "txtfestreno";
            this.txtfestreno.Size = new System.Drawing.Size(68, 20);
            this.txtfestreno.TabIndex = 8;
            this.txtfestreno.Text = "22/08/2012";
            // 
            // cmbgenero
            // 
            this.cmbgenero.FormattingEnabled = true;
            this.cmbgenero.Items.AddRange(new object[] {
            "ACCION",
            "AVENTURAS",
            "COMEDIA",
            "INFANTIL",
            "DRAMA",
            "DRAMA-CRISTIANO",
            "TERROR",
            "SUSPENSO",
            "PLAY STATION"});
            this.cmbgenero.Location = new System.Drawing.Point(111, 155);
            this.cmbgenero.Name = "cmbgenero";
            this.cmbgenero.Size = new System.Drawing.Size(218, 21);
            this.cmbgenero.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(457, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 110;
            this.label6.Text = "F.Estreno:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtbuscar);
            this.panel1.Location = new System.Drawing.Point(12, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 43);
            this.panel1.TabIndex = 46;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "T.Inglés",
            "T.Español",
            "Actor",
            "Actriz",
            "Reparto",
            "Género"});
            this.comboBox1.Location = new System.Drawing.Point(56, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 20);
            this.button1.TabIndex = 32;
            this.button1.Text = "::";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Khaki;
            this.label2.Location = new System.Drawing.Point(183, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Codigo";
            // 
            // txtbuscar
            // 
            this.txtbuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbuscar.Location = new System.Drawing.Point(252, 9);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(379, 20);
            this.txtbuscar.TabIndex = 29;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtfestreno);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cmbgenero);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtreparto);
            this.panel2.Controls.Add(this.txtactriz);
            this.panel2.Controls.Add(this.txtactor);
            this.panel2.Controls.Add(this.txtespanol);
            this.panel2.Controls.Add(this.txtingles);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtid);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtstock);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(14, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(681, 208);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 109;
            this.label3.Text = "Género:";
            // 
            // txtreparto
            // 
            this.txtreparto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtreparto.Location = new System.Drawing.Point(111, 129);
            this.txtreparto.Name = "txtreparto";
            this.txtreparto.Size = new System.Drawing.Size(475, 20);
            this.txtreparto.TabIndex = 5;
            // 
            // txtactriz
            // 
            this.txtactriz.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtactriz.Location = new System.Drawing.Point(111, 103);
            this.txtactriz.MaxLength = 50;
            this.txtactriz.Name = "txtactriz";
            this.txtactriz.Size = new System.Drawing.Size(326, 20);
            this.txtactriz.TabIndex = 4;
            // 
            // txtactor
            // 
            this.txtactor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtactor.Location = new System.Drawing.Point(111, 77);
            this.txtactor.MaxLength = 50;
            this.txtactor.Name = "txtactor";
            this.txtactor.Size = new System.Drawing.Size(326, 20);
            this.txtactor.TabIndex = 3;
            // 
            // txtespanol
            // 
            this.txtespanol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtespanol.Location = new System.Drawing.Point(111, 54);
            this.txtespanol.MaxLength = 100;
            this.txtespanol.Name = "txtespanol";
            this.txtespanol.Size = new System.Drawing.Size(475, 20);
            this.txtespanol.TabIndex = 0;
            this.txtespanol.TextChanged += new System.EventHandler(this.txtespanol_TextChanged);
            // 
            // txtingles
            // 
            this.txtingles.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtingles.Location = new System.Drawing.Point(111, 31);
            this.txtingles.MaxLength = 100;
            this.txtingles.Name = "txtingles";
            this.txtingles.Size = new System.Drawing.Size(475, 20);
            this.txtingles.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "Actor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 102;
            this.label8.Text = "Id:";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(111, 5);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(100, 20);
            this.txtid.TabIndex = 101;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(54, 110);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 13);
            this.label17.TabIndex = 99;
            this.label17.Text = "Actriz:";
            // 
            // txtstock
            // 
            this.txtstock.Location = new System.Drawing.Point(396, 155);
            this.txtstock.MaxLength = 6;
            this.txtstock.Name = "txtstock";
            this.txtstock.Size = new System.Drawing.Size(41, 20);
            this.txtstock.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 96;
            this.label14.Text = "Español:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(352, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 95;
            this.label13.Text = "Stock:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Reparto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "Ingles:";
            // 
            // btneditar
            // 
            this.btneditar.Location = new System.Drawing.Point(504, 263);
            this.btneditar.Name = "btneditar";
            this.btneditar.Size = new System.Drawing.Size(82, 33);
            this.btneditar.TabIndex = 45;
            this.btneditar.Text = "Editar";
            this.btneditar.UseVisualStyleBackColor = true;
            this.btneditar.Click += new System.EventHandler(this.btneditar_Click);
            // 
            // btndescartar
            // 
            this.btndescartar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndescartar.Location = new System.Drawing.Point(592, 263);
            this.btndescartar.Name = "btndescartar";
            this.btndescartar.Size = new System.Drawing.Size(80, 33);
            this.btndescartar.TabIndex = 47;
            this.btndescartar.Text = "Descartar";
            this.btndescartar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndescartar.UseVisualStyleBackColor = true;
            this.btndescartar.Click += new System.EventHandler(this.btndescartar_Click);
            // 
            // btgnnuevo
            // 
            this.btgnnuevo.Location = new System.Drawing.Point(338, 263);
            this.btgnnuevo.Name = "btgnnuevo";
            this.btgnnuevo.Size = new System.Drawing.Size(75, 33);
            this.btgnnuevo.TabIndex = 48;
            this.btgnnuevo.Text = "Nuevo";
            this.btgnnuevo.UseVisualStyleBackColor = true;
            this.btgnnuevo.Click += new System.EventHandler(this.btgnnuevo_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnguardar.Location = new System.Drawing.Point(416, 263);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(82, 33);
            this.btnguardar.TabIndex = 44;
            this.btnguardar.Text = "Guardar  ";
            this.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(24, 303);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(671, 251);
            this.dataGridView1.TabIndex = 50;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // peliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 566);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btneditar);
            this.Controls.Add(this.btndescartar);
            this.Controls.Add(this.btgnnuevo);
            this.Controls.Add(this.btnguardar);
            this.Name = "peliculas";
            this.Text = "peliculas";
            this.Load += new System.EventHandler(this.peliculas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtfestreno;
        private System.Windows.Forms.ComboBox cmbgenero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtreparto;
        private System.Windows.Forms.TextBox txtactriz;
        private System.Windows.Forms.TextBox txtactor;
        private System.Windows.Forms.TextBox txtespanol;
        private System.Windows.Forms.TextBox txtingles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btneditar;
        private System.Windows.Forms.Button btndescartar;
        private System.Windows.Forms.Button btgnnuevo;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}