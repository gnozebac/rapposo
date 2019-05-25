using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaposoFact.Reportes
{
    public partial class GenerarNotaVentaDia : Form
    {

        public GenerarNotaVentaDia()
        {
            InitializeComponent();
        }
        Clases.Clsreportes reportes = new Clases.Clsreportes();
        Clases.ClsProductos productos = new Clases.ClsProductos();
        Clases.Familia familia = new Clases.Familia();
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
           reportes.BorrarTmpnvxfecha();
           string fecha;
            fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            reportes.nvxfecha(Convert.ToDateTime(fecha));

            FrVentaxdia newMDIChildForm = new FrVentaxdia();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
            }
            catch { }
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

            DataSet da1 = new DataSet();
            da1 = productos.usuario1(comboBox1.Text);
            comboBox2.DataSource = da1.Tables[0];
            comboBox2.DisplayMember = "subfamilia";
            comboBox2.ValueMember = "idfamilia";

        }

        private void GenerarNotaVentaDia_Load(object sender, EventArgs e)
        {
            cargarPadre();
    
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            try { 
            reportes.borrarstock0();
            Clases.FrmCrtRepstock0 newMDIChildForm = new Clases.FrmCrtRepstock0();
            reportes.insertstock0(Convert.ToString(comboBox1.SelectedValue));
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();

            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            reportes.borrarrepxmes();
            string fecha, fecha1;
            string id;
            //fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            //fecha1 = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            fecha = txtfechaini.Text;
            fecha1 = txtfechafin.Text;
            id = comboBox1.SelectedValue.ToString();
            reportes.repxmes( Convert.ToDateTime(fecha), Convert.ToDateTime(fecha1));

            frmRepMes newMDIChildForm = new frmRepMes();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
            }
            catch { }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            cargarhijo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                reportes.borrarreportestockmin();

                reportes.reportestockmin(Convert.ToString(comboBox2.SelectedValue));
                tmp_reportestock newMDIChildForm = new tmp_reportestock();
                newMDIChildForm.MdiParent = this.MdiParent;

                newMDIChildForm.Show();
                this.Close();

            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Move(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargarhijo();
        
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
           
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
   reportes.borrartmp_ventasxcant();
            string fecha, fecha1;
            string id;
            //fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            //fecha1 = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            fecha = txtfechaini.Text;
            fecha1 = txtfechafin.Text;
            id = comboBox1.SelectedValue.ToString();
            reportes.insert_tmp_ventasxcant(Convert.ToDateTime(fecha), Convert.ToDateTime(fecha1));

            FrmProductomasVendido newMDIChildForm = new FrmProductomasVendido();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();

            }
            catch { }
             

        }
    }
}
