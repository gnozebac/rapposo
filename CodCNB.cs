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
    public partial class CodCNB : Form
    {
        public CodCNB()
        {
            InitializeComponent();
        }
        Clases.ClscodCNB codcnb = new Clases.ClscodCNB();
        private void CodCNB_Load(object sender, EventArgs e)
        {

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = codcnb.cargarcodigo(txtbuscar.Text).Tables[0];
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
