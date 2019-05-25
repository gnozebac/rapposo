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
    public partial class RetirosDetalle : Form
    {
        Clases.ClsCaja caja = new Clases.ClsCaja();
        public RetirosDetalle()
        {
            InitializeComponent();
        }

        private void RetirosDetalle_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem =="Retiros")

                 {
            string fecha;
            fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            dataGridView1.DataSource = caja.cargarDetalleRetiros(Convert.ToDateTime(fecha)).Tables[0];
                 }
            if (comboBox1.SelectedItem == "Ingresos")
            {
                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                dataGridView1.DataSource = caja.cargarDetalleingresos(Convert.ToDateTime(fecha)).Tables[0];
            }
        }
    }
}
