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
    public partial class vuetos : Form
    {
        public static string producto;
        public static string Texto;
        Clases.Clsreportes reportes = new Clases.Clsreportes();
        Clases.Clsfactura factura = new Clases.Clsfactura();
        public vuetos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         


        }
        private void cargarTextosxcod()
        {
            try
            {
                DataSet datos;
                DataSet datos1;
                DataSet datos2;
                DataSet datos3;
                datos = factura.cargarProductosxcod(this.txtcodigo.Text);
                datos1 = factura.cargarProductosxcod(txtcodigo.Text);
                datos2 = factura.cargarProductosxcod(txtcodigo.Text);
                datos3 = factura.cargarProductosxcod(txtcodigo.Text);
                txtcodigo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                txtprod.Text = datos.Tables[0].Rows[0].ItemArray[1].ToString();
                txtprecio.Text = datos.Tables[0].Rows[0].ItemArray[3].ToString();
                txtstock.Text = datos.Tables[0].Rows[0].ItemArray[4].ToString();
            }

            catch { }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Clases.Clsfactura factura = new Clases.Clsfactura();

   
            cargarTextosxcod();
        }

        private void vuetos_Load(object sender, EventArgs e)
        {

        }
    }
}
