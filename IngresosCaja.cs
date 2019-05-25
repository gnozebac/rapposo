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
    public partial class IngresosCaja : Form
    {
        Clases.ClsCaja caja = new Clases.ClsCaja();
        public IngresosCaja()
        {
            InitializeComponent();
        }

        private void IngresosCaja_Load(object sender, EventArgs e)
        {
            label4.Text = System.DateTime.Now.ToString();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet datos;
                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                datos = caja.cargarVerificarCajainicial(Convert.ToDateTime(fecha));
                int a = 0;
                a = Convert.ToInt16(datos.Tables[0].Rows[0].ItemArray[0].ToString());

                caja.guardardepositos(label5.Text, Convert.ToDateTime(fecha), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDouble(this.txtvalor.Text), Convert.ToDecimal(0), comboBox1.Text, Convert.ToDecimal(0));

                txtvalor.Text = "";
           
                this.Close();
                
            }
            catch { }
        }

        private void btncanc_Click(object sender, EventArgs e)
        {
            txtvalor.Text = "";
           
            txtvalor.Focus();
        }

        private void txtvalor_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
