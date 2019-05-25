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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        private NotadeVenta form = null;
        public MDIParent1()
        {
            InitializeComponent();
        }
        private NotadeVenta FormInstance
        {
            get
            {
                if (form == null)
                {
                    form = new NotadeVenta();
                    form.MdiParent = this;

                    form.Disposed += new EventHandler(form_Disposed);
                    form.FormClosed += new FormClosedEventHandler(form_FormClosed);
                    form.Load += new EventHandler(form_Load);

                }

                return form;
            }
        }

        void form_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Formulario abierto";
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            textBox1.Text = "Se ha cerrado el Formulario";
        }

        void form_Disposed(object sender, EventArgs e)
        {
            form = null;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void familiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Familia nuevo = new Familia();
            nuevo.MdiParent = this;
            nuevo.Show();  
        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos nuevo = new Productos();
            nuevo.MdiParent = this;
            nuevo.Show(); 
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            peliculas nuevo = new peliculas();
            nuevo.MdiParent = this;
            nuevo.Show(); 
        }

        private void buscarYVenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentaPeliculas nuevo = new VentaPeliculas();
            nuevo.MdiParent = this;
            nuevo.Show(); 
        }

        private void anularVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnularVentaPeliculas nuevo = new AnularVentaPeliculas();
            nuevo.MdiParent = this;
            nuevo.Show(); 
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura nuevo = new Factura();
            nuevo.MdiParent = this;
            nuevo.Show(); 
        }

        private void notaDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NotadeVenta nuevo = new NotadeVenta();
            //nuevo.MdiParent = this;
            //nuevo.Show(); 
            NotadeVenta frm = this.FormInstance;

            // se varifica si el formulario no esta minimizado, en caso de estarlo
            // se lo cambia a un estado normal
            if (frm.WindowState == FormWindowState.Minimized)
                frm.WindowState = FormWindowState.Normal;

            frm.Show(); 
        }

        private void lIstaPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarListadoPrecios nuevo = new GenerarListadoPrecios();
            nuevo.MdiParent = this;
            nuevo.Show(); 
        }

        private void notaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.GenerarNotaVentaDia nuevo = new Reportes.GenerarNotaVentaDia();
            nuevo.MdiParent = this;
            nuevo.Show(); 
        }

        private void cNBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodCNB nuevo = new CodCNB();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void aperturaDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AperturaCaja nuevo = new AperturaCaja();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void retirarEfectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ingresarEfectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void verTotalesDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerTotalesCaja nuevo = new VerTotalesCaja();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetirosDetalle nuevo = new RetirosDetalle();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void retirarEfectivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RetirosCaja nuevo = new RetirosCaja();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarClienteFac nuevo = new BuscarClienteFac();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void recargasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recargas nuevo = new Recargas();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void recargasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResumenRecargas nuevo = new ResumenRecargas();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prueba nuevo = new Prueba();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void deudasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DEUDAS nuevo = new DEUDAS();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void bdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            respaldar nuevo = new respaldar();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresosCaja nuevo = new IngresosCaja();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void tRXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTRX nuevo = new FormTRX();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prueba prueba = new Prueba();
            prueba.MdiParent = this;
            prueba.Show();

        }

        private void pruebaFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturar Facturarm = new Facturar();
            Facturarm.MdiParent = this;
            Facturarm.Show();
        }

        private void recargasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            undolar formun = new undolar();
            formun.MdiParent = this;
            formun.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedor formun = new Proveedor();
            formun.MdiParent = this;
            formun.Show();
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Factura_compras formun = new Factura_compras();
            formun.MdiParent = this;
            formun.Show();
        }

        private void tRXguayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBus nuevo = new frmBus();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormTRX nuevo = new FormTRX();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormTRX_guay nuevo = new FormTRX_guay();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Productos nuevo = new Productos();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void buscarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void buscarProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vuetos nuevo = new vuetos();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void preciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPricer nuevo = new PrintPricer();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void controlStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPrecioyStock nuevo = new ReportPrecioyStock();
            nuevo.MdiParent = this;
            nuevo.Show();
            
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResumenRecargas nuevo = new ResumenRecargas();
            nuevo.MdiParent = this;
            nuevo.Show();
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
          frmBus nuevo = new frmBus();
            nuevo.MdiParent = this;
            nuevo.Show();
        }
    }
}
