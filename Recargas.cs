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
    public partial class Recargas : Form
    {
        public Recargas()
        {
            InitializeComponent();
        }
        Clases.ClsRecargas recargas = new Clases.ClsRecargas();
        private void ACierreCaja_Load(object sender, EventArgs e)
        {
            txtfecha.Text = DateTime.Now.ToString();
          
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
               {
            recargas.guardarrecargas(txtidusuario.Text,Convert.ToDecimal( txtvalor.Text), this.comboBox1.Text, Convert.ToDateTime(txtfecha.Text),comboBox2.Text);
            MessageBox.Show("Registrado");
            txtvalor.Text = "0";
                }
            catch
                {
                }
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
