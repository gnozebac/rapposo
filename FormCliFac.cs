using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaposoFact
{
    public partial class FormCliFac : Form
    {
        public FormCliFac()
        {
            InitializeComponent();
        }
        public IForm Opener { get; set; }
        private int ik;
        Clases.Clsfactura factura = new Clases.Clsfactura();

        private DataTable LoadDataTable()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("ced");
            dt.Columns.Add("nom");
            dt.Columns.Add("dir");
            dt.Columns.Add("tel");

            for (int i = 0; i <= 1; i++)
            {
                DataRow row = dt.NewRow();

                row["ced"] = dataGridView1[1,ik].Value;
                row["nom"] = dataGridView1[2, ik].Value;

                row["dir"] = dataGridView1[3, ik].Value;
                row["tel"] = dataGridView1[4, ik].Value;

                dt.Rows.Add(row);

            }

            return dt;
        }
        private void FormCliFac_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dataTable = LoadDataTable();

            bool estadoOperacion = this.Opener.LoadDataCli(dataTable);

            e.Cancel = !estadoOperacion;
        }

        private void FormCliFac_Load(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = factura.cargarclientesxnombre(textBox1.Text).Tables[0];
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                // MessageBox.Show(dataGridView1 .CurrentCell.ToString());

                this.Close();


            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           ik = dataGridView1.CurrentRow.Index;
        }

    }
}
