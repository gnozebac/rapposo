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
    public partial class ProdFac : Form
    {

        public ProdFac()
        {
            InitializeComponent();
        }
        Clases.Clsfactura factura = new Clases.Clsfactura();
        public static string Textos;
        public static string textids;
        public static string txtpvpss;
        public static string txttipoiva;
        public static string textstocks;
        public string Nombres { get; set; }
        public string ids { get; set; }
        public string Pvps { get; set; }
        public string Stocks { get; set; }
        public string Tiva { get; set; }
        private Form FormPadref;


        public Form _FormPadref
        {
            get { return FormPadref; }
            set { FormPadref = value; }
        }
        private void ProdFac_Load(object sender, EventArgs e)
        {
            textBox1.Text = Factura.Textos;
            dataGridView1.DataSource = factura.cargarProductos(textBox1.Text).Tables[0];
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                dataGridView1.Focus();
                dataGridView1.DataSource = factura.cargarProductos(textBox1.Text).Tables[0];

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Nombres = textBox1.Text;
            dataGridView1.DataSource = factura.cargarProductos(textBox1.Text).Tables[0];
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textids = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            Textos = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txttipoiva = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txtpvpss = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textstocks = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox1.Text = Textos;
            textBox2.Text = textids;
            txtpvp.Text = txtpvpss;
            txtstock.Text = textstocks;
            txtiva.Text = txttipoiva;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ids = textBox2.Text;
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            ids = textBox2.Text;
        }
        private void cerrar()
        {
            DialogResult = DialogResult.OK;

            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            cerrar();
        }
        private void cargarid()
        {
            textids = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[0].Value.ToString();
            Textos = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[1].Value.ToString();
            txttipoiva = dataGridView1.Rows[dataGridView1.CurrentRow.Index-1].Cells[2].Value.ToString();
            txtpvpss = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[3].Value.ToString();
            textstocks = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[4].Value.ToString();
            textBox1.Text = Textos;
            textBox2.Text = textids;
            txtpvp.Text = txtpvpss;
            txtstock.Text = textstocks;
            txtiva.Text = txttipoiva;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {

                Int32 i;


                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {


                    if (dataGridView1.Rows.Count == 1)
                    {
                        textids = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                        Textos = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                        txttipoiva = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                        txtpvpss = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                        textstocks = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                        textBox1.Text = Textos;
                        textBox2.Text = textids;
                        txtpvp.Text = txtpvpss;
                        txtstock.Text = textstocks;
                        txtiva.Text = txttipoiva;
                    }


                    if (dataGridView1.Rows.Count >= 2)
                    {
                        cargarid();
                    }

                }



                cerrar();

            }
        }

        private void txtpvp_TextChanged(object sender, EventArgs e)
        {
            Pvps = txtpvp.Text;
        }

        private void txtstock_TextChanged(object sender, EventArgs e)
        {
            Stocks = txtstock.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtiva_TextChanged(object sender, EventArgs e)
        {
            Tiva = txtiva.Text;
        }



    }
}
