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
    public partial class FrmFactura : Form
    {
        Clases.Clsfactura Ventas = new Clases.Clsfactura();
        Clases.Clsreportes reportes = new Clases.Clsreportes();
        Clases.Clscliente cliente = new Clases.Clscliente();
        public int numfilaact;
        public static string productos;
        public static string Textos;
        public static string nombres;
        public static string Texto;
        Clases.Clsfactura factura = new Clases.Clsfactura();

        public double subtotaliva;
        public double totaltotal;
        public double aux1 = 0;
        public int nFilaSel;

        //    clsVentas Ventas = new clsVentas();
        //  clsDetalleVenta Detalle = new clsDetalleVenta();


        public FrmFactura()
        {
            InitializeComponent();
        }
        private List<Clases.Clsfactura> lst = new List<Clases.Clsfactura>();
        private void LlenarGrilla()
        {
            Decimal SumaSubTotal = 0; Decimal SumaIgv = 0; Decimal SumaTotal = 0;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                dataGridView1.Rows.Add();
    
                SumaSubTotal += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                SumaIgv += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[lst.Count + 1].Cells[3].Value = "SUB-TOTAL  S/.";
            dataGridView1.Rows[lst.Count + 1].Cells[4].Value = SumaSubTotal;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[lst.Count + 2].Cells[3].Value = "      I.G.V.        %";
            dataGridView1.Rows[lst.Count + 2].Cells[4].Value = SumaIgv;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[lst.Count + 3].Cells[3].Value = "     TOTAL     S/.";
            SumaTotal += SumaSubTotal + SumaIgv;
            dataGridView1.Rows[lst.Count + 3].Cells[4].Value = SumaTotal;
            dataGridView1.ClearSelection();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {

        }

        private void btnBusquedaProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
