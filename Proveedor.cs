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
    public partial class Proveedor : Form
    {

        public Proveedor()
        {
            InitializeComponent();
        }
        public static string Texto;
        public static string textid;
        public static string textdir;
        public static string textemail;
        public static string textfono;
        public string Nombre { get; set; }
        public string id { get; set; }
        public string ruc { get; set; }
        //public string Stock { get; set; }
        public string direccion { get; set; }
        public string Email { get; set; }
        public string fono { get; set; }
        private Form FormPadres;
        Clases.ClsProveedor cliente = new Clases.ClsProveedor();
        public Form _FormPadres
        {
            get { return FormPadres; }
            set { FormPadres = value; }
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            txtcliente.Text = Factura_compras.Texto;
            dataGridView2.DataSource = cliente.cargarclientesxnombre(txtcliente.Text).Tables[0];
        }
        private void cargartextodesdegrilla()
        {
            try
            {
                this.txtid.Text =
        dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
                this.txtcliente.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
                this.txtruc.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
                this.txtdir.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();
                this.txtfono.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString();
                this.txtemail.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[5].Value.ToString();
            }
            catch { }
        }
        private void txtcliente_TextChanged(object sender, EventArgs e)
        {
            Nombre = this.txtcliente.Text;

            dataGridView2.DataSource = cliente.cargarclientesxnombre(txtcliente.Text).Tables[0];
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
          
        }
        private void cerrar()
        {
            DialogResult = DialogResult.OK;

            this.Close();
        }


        private void cargarid()
        {
            textid = dataGridView2.Rows[dataGridView2.CurrentRow.Index - 1].Cells[0].Value.ToString();
            ruc = dataGridView2.Rows[dataGridView2.CurrentRow.Index - 1].Cells[1].Value.ToString();
            Nombre = dataGridView2.Rows[dataGridView2.CurrentRow.Index - 1].Cells[2].Value.ToString();
            textdir = dataGridView2.Rows[dataGridView2.CurrentRow.Index - 1].Cells[3].Value.ToString();

            textfono = dataGridView2.Rows[dataGridView2.CurrentRow.Index - 1].Cells[4].Value.ToString();
            textemail = dataGridView2.Rows[dataGridView2.CurrentRow.Index - 1].Cells[5].Value.ToString();
            txtid.Text = textid;
            this.txtruc.Text = ruc;
            this.txtcliente.Text = Nombre;
            txtdir.Text = textdir;
            txtemail.Text = textemail;
            txtfono.Text = textfono;
        }
        private void limpiar()
        {
        }

        private void txtcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                dataGridView2.Focus();
                dataGridView2.DataSource = cliente.cargarclientesxnombre(txtcliente.Text).Tables[0];

            }
        }

        private void txtruc_TextChanged(object sender, EventArgs e)
        {
            ruc = txtruc.Text;


            dataGridView2.DataSource = cliente.cargarxcicliente(this.txtruc.Text).Tables[0];

        }

        private void txtfono_TextChanged(object sender, EventArgs e)
        {
            fono = txtfono.Text;
        }

        private void txtdir_TextChanged(object sender, EventArgs e)
        {
            direccion = txtdir.Text;
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            Email = txtemail.Text;
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            id = txtid.Text;
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {

                Int32 i;


                for (i = 0; i < dataGridView2.Rows.Count; i++)
                {


                    if (dataGridView2.Rows.Count == 1)
                    {
                        textid = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
                        ruc = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
                        Nombre = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
                        textdir = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();
                        textfono = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString();
                        textemail = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[5].Value.ToString();
                        txtid.Text = textid;
                        this.txtruc.Text = ruc;
                        this.txtcliente.Text = Nombre;
                        txtdir.Text = textdir;
                        txtemail.Text = textemail;
                        txtfono.Text = textfono;
                    }


                    if (dataGridView2.Rows.Count >= 2)
                    {
                        cargarid();
                    }

                }



                cerrar();

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                cargartextodesdegrilla();
            }
            catch
            {
                limpiar();
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            cerrar();
        }

        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                cliente.guardarproveedor(txtruc.Text, txtcliente.Text, txtdir.Text, txtfono.Text, txtemail.Text);
                MessageBox.Show("Datos guardados con éxito");
                cerrar();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cliente.EDITARcliente(txtid.Text, txtruc.Text, txtcliente.Text, txtdir.Text, txtfono.Text, txtemail.Text);
            MessageBox.Show("Datos EDITADOS con éxito");
            cerrar();
        }

        private void txtdir_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    btnguardar.Focus();
                }
        }

    
    }
}
