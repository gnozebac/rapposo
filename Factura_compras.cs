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
    public partial class Factura_compras : Form
    {
        public Factura_compras()
        {
            InitializeComponent();
        }
        public int numfilaact;
        public static string productos;
        public static string Textos;
        public static string nombres;
        public static string Texto;
        Clases.Clscompras compras = new Clases.Clscompras();
        Clases.Clsreportes reportes = new Clases.Clsreportes();
        Clases.ClsProveedor proveedor = new Clases.ClsProveedor();
        private void Factura_compras_Load(object sender, EventArgs e)
        {

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                try
                {
                    Proveedor g = new Proveedor();
                    Texto = this.txtbuscar.Text;

                    g._FormPadres = this;
                    if (g.ShowDialog() == DialogResult.OK)
                    {

                        string nombre = g.Nombre; //lee la propiedad
                        string txtid = g.id;
                        string textruc = g.ruc;
                        string dir = g.direccion;
                        string email = g.Email;
                        string fono = g.fono;
                        this.txtidcliente.Text = txtid;
                        txtbuscar.Text = nombre;
                        //txtdir.Text = dir;
                        textBox8.Text = g.ruc;
                        this.txtdireccion.Text = dir;
                        txtfono.Text = fono;
                        txtcodigo.Focus();





                    }
                }
                catch
                {
                }


            }

        }
         private void limpiar()
        {
          
            txtidcliente.Text ="";
            textBox8.Text = "";
            txtbuscar.Text = "";
            txtdireccion.Text = "";
            txtfono.Text = "";
            txtemail.Text = "";
            txtfecha.Text = "";
            txtfactura.Text = "";
            txtautorizacion.Text = "";
            txtfechacaducidad.Text = "";
            txtiva.Text = "0";
            txtiva0.Text = "0";
            txttotal.Text = "0";
            txtsub12.Text = "0";
            textBox8.Focus();

        }
       
        private void cargarTextosxcod()
        {
            try
            {
                DataSet datos;
                datos =proveedor.cargarProveedorxcod(this.textBox8.Text);
                txtidcliente.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                textBox8.Text = datos.Tables[0].Rows[0].ItemArray[1].ToString();
        txtbuscar.Text = datos.Tables[0].Rows[0].ItemArray[2].ToString();
                txtdireccion.Text = datos.Tables[0].Rows[0].ItemArray[3].ToString();
                txtfono.Text = datos.Tables[0].Rows[0].ItemArray[3].ToString();

               
            }

            catch { }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Clases.Clsfactura factura = new Clases.Clsfactura();

             dataGridView2.DataSource = proveedor.cargarProveedorxcod(textBox8.Text).Tables[0];
            cargarTextosxcod();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    txtfecha.Focus();
                }
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            try
            {
                proveedor.guardarproveedor(this.textBox8.Text, txtbuscar.Text, this.txtdireccion.Text, txtfono.Text, this.txtemail.Text);
                MessageBox.Show("Datos guardados con éxito");
             
                txtfecha.Focus();
            }
            catch { }
        }

        private void txtiva0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                //txtFecha.Focus();
            }
            else if (e.KeyChar == '.')
            {
                // si se pulsa en el punto se convertirá en coma
                e.Handled = true;
                SendKeys.Send(",");
            }
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtsub12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                //txtFecha.Focus();
            }
            else if (e.KeyChar == '.')
            {
                // si se pulsa en el punto se convertirá en coma
                e.Handled = true;
                SendKeys.Send(",");
            }
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtiva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                //txtFecha.Focus();
            }
            else if (e.KeyChar == '.')
            {
                // si se pulsa en el punto se convertirá en coma
                e.Handled = true;
                SendKeys.Send(",");
            }
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                //txtFecha.Focus();
            }
            else if (e.KeyChar == '.')
            {
                // si se pulsa en el punto se convertirá en coma
                e.Handled = true;
                SendKeys.Send(",");
            }
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
             if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    this.btnguardar.Focus();
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            reportes.borrarFacturasCompras();


            //fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            reportes.FacturasCompras(Convert.ToDateTime(this.textBox1.Text), Convert.ToDateTime(this.textBox2.Text));

            Impcompras newMDIChildForm = new Impcompras();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();


        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //guardar
            try
            {
                compras.guardarFACTURA(txtidcliente.Text, Convert.ToDateTime(txtfecha.Text), txtfactura.Text, txtautorizacion.Text, Convert.ToDateTime(txtfechacaducidad.Text), Convert.ToDouble(txtiva0.Text), Convert.ToDouble(txtsub12.Text), Convert.ToDouble(txtiva.Text), Convert.ToDouble(txttotal.Text));


                MessageBox.Show("Datos guardados con éxito");
                limpiar();
            }
            catch { }
        }

       

       

     
    }
}
