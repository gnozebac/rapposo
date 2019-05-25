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
    public partial class cobrarNV : Form
    {
        public static string producto;
        public static string Texto;
        Clases.Clsfactura factura = new Clases.Clsfactura();
        public cobrarNV()
        {
            InitializeComponent();
        }

        private void txtefectivo_KeyPress(object sender, KeyPressEventArgs e)
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
                // Invalidar la accion
                e.Handled = true;
                // Enviar el sonido de beep de windows
                System.Media.SystemSounds.Beep.Play();

                if

                     (MessageBox.Show("Guardar?", "Nota Venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //guardarnotaventa();
                    factura.borrarTmpnotaventa();
                    //cargarventalOAD();
                    //limpiar();

                }
                else
                {

                    txtcambio.Text = "";
                    txtefectivo.Text = "";
                    txttotalg.Text = "";
                    //txtprod.Focus();
                }

            }
        }
    }
}
