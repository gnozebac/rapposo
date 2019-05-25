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
    public partial class RetirosCaja : Form
    {
        Clases.ClsCaja caja = new Clases.ClsCaja();
        public RetirosCaja()
        {
            InitializeComponent();
        }

        private void RetirosCaja_Load(object sender, EventArgs e)
        {
            label4.Text = System.DateTime.Now.ToString();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                caja.guardarRetiros(label5.Text, Convert.ToDateTime(fecha), Convert.ToDecimal(0), Convert.ToDecimal(txtvalor.Text), Convert.ToDecimal(0), Convert.ToDecimal(0), this.comboBox1.Text,Convert.ToDecimal(0));
                //txtdescripcion.Text = "";
                txtvalor.Text = "";
                this.Close();
            }
            catch
            { }
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
