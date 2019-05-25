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
    public partial class ReportPrecioyStock : Form
    {
        Clases.ClsProductos productos = new Clases.ClsProductos();
        Clases.Familia familia = new Clases.Familia();


         
        public ReportPrecioyStock()
        {
            InitializeComponent();
        }
        private void cargarPadre()
        {

            DataSet da = new DataSet();
            da = productos.usuario();
            comboBox1.DataSource = da.Tables[0];
            comboBox1.DisplayMember = "familia";
            comboBox1.ValueMember = "idfamilia";

        }
        private void cargarhijo()
        {
            DataSet da = new DataSet();
            da = productos.cargarsubfamilia(Convert.ToString(comboBox1.SelectedValue));
            comboBox3.DataSource = da.Tables[0];
            comboBox3.DisplayMember = "subfamilia";
            comboBox3.ValueMember = "idfamilia";

        }
        private void txtdetalle_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productos.cargarsuProd_parastock(txtdetalle.Text).Tables[0];
        }

       
        private void ReportPrecioyStock_Load(object sender, EventArgs e)
        {
          //  dataGridView1.DataSource = productos.cargarsuProductosTodo(txtdetalle.Text).Tables[0];
            cargarPadre();
            cargarhijo();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
        }
            
    }
}
