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
    public partial class FrmBuscarProducto : Form
    {
        public FrmBuscarProducto()
        {
            InitializeComponent();
        }
        Clases.Clsfactura factura = new Clases.Clsfactura();
        private int? _idbusqueda = null;

        private void txtprod_TextChanged(object sender, EventArgs e)
        {
            cargar();
        }
        public FrmBuscarProducto(int idbusqueda)
            : this()
        {
            this._idbusqueda = idbusqueda;
        }
        private void cargar()
        {
            if (_idbusqueda.HasValue)
                txtIdBusqueda.Text = Convert.ToString(_idbusqueda);

           dataGridView1.DataSource = factura.cargarProductos(txtIdBusqueda.Text).Tables[0];
        }

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
        {
            cargar();
       
        }
    }
}
