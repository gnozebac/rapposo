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
    public partial class GenerarListadoPrecios : Form
    {
        Clases.ClsProductos productos = new Clases.ClsProductos();
        Clases.Clsreportes reportes = new Clases.Clsreportes();
        public GenerarListadoPrecios()
        {
            InitializeComponent();
        }

        Clases.Familia familia = new Clases.Familia();
        private void GenerarListadoPrecios_Load(object sender, EventArgs e)
        {
            cargarPadre();

            cargarhijo();
            comboBox2.Visible = true;
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
            comboBox2.DataSource = da.Tables[0];
            comboBox2.DisplayMember = "subfamilia";
            comboBox2.ValueMember = "idfamilia";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            productos.Borrarlistaproductos();
            productos.listaproductos();

            pruebacristal2 newMDIChildForm = new pruebacristal2();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarhijo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            productos.borrarlistaprecioscategoria();
            productos.listaprecioscategoria(Convert.ToString(comboBox1.SelectedValue));

            ImpListaprecios newMDIChildForm = new ImpListaprecios();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reportes.borrarreportestock();

            reportes.reportestock(Convert.ToString(comboBox1.SelectedValue));
            tmp_reportestock newMDIChildForm = new tmp_reportestock();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            productos.borrarlistaprecioscategoria();
            productos.listapreciostodox();

            ImpListaprecios newMDIChildForm = new ImpListaprecios();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            reportes.borrarreportestockmin();

            reportes.reportestockmin(Convert.ToString(comboBox2.SelectedValue));
            tmp_reportestock newMDIChildForm = new tmp_reportestock();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
        }
    }
}
