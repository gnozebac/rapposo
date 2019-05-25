using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
namespace RaposoFact
{
    public partial class Productos : Form
    {
        Clases.ClsProductos productos = new Clases.ClsProductos();
        Clases.Familia familia = new Clases.Familia();
        public Productos()
        {
            InitializeComponent();
        }
        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {


                e.HasMorePages = false;

                //COLOR
                SolidBrush solidBrush = new SolidBrush(Color.Black);
                //TIPO DE LETRA
                Font font1 = new Font("Arial narrow", 10, FontStyle.Regular, GraphicsUnit.Point);
                Font font2 = new Font("Arial narrow", 17, FontStyle.Regular, GraphicsUnit.Point);
                Font font3 = new Font("Arial narrow", 8, FontStyle.Regular, GraphicsUnit.Point);

                StringFormat stringFormat3 = new StringFormat();
                stringFormat3.Alignment = StringAlignment.Far;
                stringFormat3.LineAlignment = StringAlignment.Center;

                StringFormat stringFormatCenter = new StringFormat();
                stringFormatCenter.Alignment = StringAlignment.Near;
                stringFormatCenter.LineAlignment = StringAlignment.Center;

                int g = 0;
                int x = 20;
                int y = 30;
                for (int i = 1; i <= 10; i++) //11->22
                {
                    x = 20;
                    for (int j = 1; j <= 3; j++) // 3->6
                    {
                        //MessageBox.Show("" + dataGridView1[0, 0].Value+ dataGridView1[0, 1].Value+ dataGridView1[0, 2].Value);
                        Rectangle r1 = new Rectangle(x, y, 120, 25);
                        e.Graphics.DrawString(dataGridView2[1, 0 + g].Value.ToString(), font3, solidBrush, r1, stringFormatCenter);
                        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(r1));

                        Rectangle r2 = new Rectangle(x, y + 25, 50, 25);
                        e.Graphics.DrawString(dataGridView2[0, 0 + g].Value.ToString(), font1, solidBrush, r2, stringFormat3);
                        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(r2));

                        Rectangle r3 = new Rectangle(x + 50, y + 25, 70, 25);
                        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(r3));
                        SolidBrush blueBrush = new SolidBrush(Color.Yellow);
                        e.Graphics.FillRectangle(blueBrush, r3);
                        e.Graphics.DrawString(dataGridView2[2, 0 + g].Value.ToString(), font2, solidBrush, r3, stringFormat3);

                        Rectangle r4 = new Rectangle(x + 50, y + 25, 70, 25);
                        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(r4));
                        g++;
                        x = x + 120;
                    }

                    y = y + 50;
                }
                int i1 = 0;
                // AGRAGAR MAS HOJAS
                e.HasMorePages = true;
                if (i1 == 0)
                    e.HasMorePages = false;
                else
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            catch { }
        }//fin while
        private void txtdetalle_TextChanged(object sender, EventArgs e)
        {
            try { 
            dataGridView1.DataSource = productos.cargarsuProductosTodo(txtdetalle.Text).Tables[0];
        }
            catch { }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpvp.Text != "")
                {

                    try
                    {
                        productos.guardar(Convert.ToString(comboBox3.SelectedValue), txtdetalle.Text, Convert.ToDecimal(txtcosto.Text), Convert.ToInt16(txtnumunidades.Text), Convert.ToDecimal(txtgastos.Text), Convert.ToInt16(txtganancia.Text), Convert.ToString(cmbtipoiva.SelectedItem), Convert.ToString(cmbtipocompra.SelectedItem), Convert.ToDecimal(txtpvp.Text), Convert.ToInt16(txtstock.Text), Convert.ToString(comboBox1.SelectedValue), txtcodbar.Text);

                        dataGridView1.DataSource = productos.cargarsuProductosTodo(txtdetalle.Text).Tables[0];
                        MessageBox.Show("Guardado exitosamente");
                     //   ParaImprimir();
                        //limpiar();
                        btnguardar.Enabled = true;
                        btneditar.Enabled = false;

                    }
                    catch
                    {
                        MessageBox.Show("Producto ya registrado/Editar");
                    }
                }
                else
                {
                    MessageBox.Show("Calcular el Precio");
                }
            }
            catch
            { MessageBox.Show("Error"); }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {

                productos.editarProductos(txtdetalle.Text, Convert.ToDouble(txtpvp.Text), Convert.ToDouble(txtgastos.Text), Convert.ToInt16(txtganancia.Text), Convert.ToInt16(txtstock.Text), Convert.ToString(comboBox3.SelectedValue), Convert.ToString(comboBox1.SelectedValue), Convert.ToInt16(txtnumunidades.Text), Convert.ToDecimal(txtcosto.Text), txtid.Text, Convert.ToString(cmbtipoiva.Text), Convert.ToString(cmbtipocompra.Text), txtcodbar.Text);

                MessageBox.Show("Guardado exitosamente");
      
                limpiar();
                btnguardar.Enabled = true;
                btneditar.Enabled = false;
                txtid.Focus();
            }
            catch
            { MessageBox.Show("Error"); }
        }

        private void btndescartar_Click(object sender, EventArgs e)
        {
            if

(MessageBox.Show("Seguro que dese salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                productos.eliminarProductos(txtid.Text);
                limpiar();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarhijo();
        }

        private void cmbtipoiva_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btncalcularprecio_Click(object sender, EventArgs e)
        {
            calcularprecioFactura();
            txtstock.Focus();
        }
        private void calcularprecioFactura()
        {
            try
            {
                decimal sacarcosto;
                decimal costounitario;
                decimal valoriva;
                decimal pvt;
                decimal ganan;

                if (Convert.ToString(cmbtipocompra.SelectedItem) == "Nota venta")
                {

                    pvt = Convert.ToDecimal(txtcosto.Text) + Convert.ToDecimal(txtcosto.Text) * Convert.ToDecimal(txtganancia.Text) / 100;
                    string pvp = string.Format("{0:#,#0.00}", pvt);
                    costounitario = Convert.ToDecimal(pvt) / Convert.ToDecimal(txtnumunidades.Text);
                    string resultado = string.Format("{0:#,#0.00}", costounitario);
                    sacarcosto = Convert.ToDecimal(resultado) + Convert.ToDecimal(txtgastos.Text);
                    txtpvp.Text = Convert.ToString(sacarcosto);

                }
                else
                {
                    if (Convert.ToString(cmbtipocompra.SelectedItem) == "Factura")
                    {
                        if (Convert.ToString(cmbtipoiva.SelectedItem) == "12")
                        {
                            valoriva = Convert.ToDecimal(txtcosto.Text) + Convert.ToDecimal(txtcosto.Text) * Convert.ToDecimal(cmbtipoiva.SelectedItem) / 100;
                            pvt = Convert.ToDecimal(valoriva) + Convert.ToDecimal(valoriva) * Convert.ToDecimal(txtganancia.Text) / 100;
                            //ganan = pvt * Convert.ToDecimal(txtganancia.Text);
                            textBox2.Text = Convert.ToString(valoriva);
                            costounitario = Convert.ToDecimal(pvt) / Convert.ToDecimal(txtnumunidades.Text);
                            string pvu = string.Format("{0:#,#0.00}", costounitario);
                            sacarcosto = Convert.ToDecimal(pvu) + Convert.ToDecimal(txtgastos.Text);
                            string resultado = string.Format("{0:#,#0.00}", sacarcosto);

                            txtpvp.Text = Convert.ToString(resultado);


                        }
                        if (Convert.ToString(cmbtipoiva.SelectedItem) == "14")
                        {
                            valoriva = Convert.ToDecimal(txtcosto.Text) + Convert.ToDecimal(txtcosto.Text) * Convert.ToDecimal(cmbtipoiva.SelectedItem) / 100;
                            pvt = Convert.ToDecimal(valoriva) + Convert.ToDecimal(valoriva) * Convert.ToDecimal(txtganancia.Text) / 100;
                            //ganan = pvt * Convert.ToDecimal(txtganancia.Text);
                            textBox2.Text = Convert.ToString(valoriva);
                            costounitario = Convert.ToDecimal(pvt) / Convert.ToDecimal(txtnumunidades.Text);
                            string pvu = string.Format("{0:#,#0.00}", costounitario);
                            sacarcosto = Convert.ToDecimal(pvu) + Convert.ToDecimal(txtgastos.Text);
                            string resultado = string.Format("{0:#,#0.00}", sacarcosto);

                            txtpvp.Text = Convert.ToString(resultado);


                        }
                        if (Convert.ToString(cmbtipoiva.SelectedItem) == "0")
                        {
                            pvt = Convert.ToDecimal(txtcosto.Text) + Convert.ToDecimal(txtcosto.Text) * Convert.ToDecimal(txtganancia.Text) / 100;

                            costounitario = Convert.ToDecimal(pvt) / Convert.ToDecimal(txtnumunidades.Text);
                            string pvu = string.Format("{0:#,#0.00}", costounitario);
                            sacarcosto = Convert.ToDecimal(pvu) + Convert.ToDecimal(txtgastos.Text);
                            string resultado = string.Format("{0:#,#0.00}", sacarcosto);

                            txtpvp.Text = Convert.ToString(resultado);

                        }

                    }
                }

            }
            catch
            {
            }
        }

        private void txtcosto_KeyPress(object sender, KeyPressEventArgs e)
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
        private void limpiar()
        {
            txtdetalle.Text = "";
            txtpvp.Text = "";
            txtdetalle.Focus();
            txtstock.Text = "1";
            txtnumunidades.Text = "1";
            txtganancia.Text = "45";
            txtgastos.Text = "0";
            txtcosto.Text = "0";
            txtid.Text = "";
            txtcodbar.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            txtpvp.Text = String.Format(txtpvp.Text, "#.##");

            cargarPadre();
            cargarhijo();
            btnguardar.Enabled = false;
            btneditar.Enabled = false;
        }

        private void txtdetalle_TextChanged_1(object sender, EventArgs e)
        {
           // dataGridView1.DataSource = productos.cargarsuProductosTodo(txtdetalle.Text).Tables[0];
        }
        private void cargar_grilla()
        {
            try
            {
                btnguardar.Enabled = false;
                btneditar.Enabled = true;
                txtid.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                comboBox3.SelectedValue = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[11].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value.ToString();

                txtdetalle.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                txtcosto.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
                txtnumunidades.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
                txtgastos.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
                txtganancia.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
                cmbtipoiva.SelectedItem = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString();
                cmbtipocompra.SelectedItem = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString();
                txtpvp.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                txtstock.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                txtcodbar.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[13].Value.ToString();
                
            }
            catch
            { }
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            cargar_grilla();
            txtstock.Focus();
        }

        private void btgnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            btnguardar.Enabled = true;
            btneditar.Enabled = false;
        }

        private void txtgastos_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {



            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
            { 
            try
            {
                if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    Clases.Clsfactura factura = new Clases.Clsfactura();


                    dataGridView1.DataSource = productos.cargarsuProductosTodoxcod(txtid.Text).Tables[0];
                        dataGridView1.Focus();
                }
            }
                catch { }
            }
    }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {

               
                
            }
            catch { }
        }

        private void txtganancia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodbar_TextChanged(object sender, EventArgs e)
    
        {


            dataGridView1.DataSource = productos.cargarsuProductosTodocodbar(this.txtcodbar.Text).Tables[0];
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtganancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true; 

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
          if (!Char.IsDigit(e.KeyChar) && e.KeyChar == 13) // Si no es numerico y si no es espacio
          {
               
              btnguardar.Focus();
               btneditar.Focus();
               
      }

        }

        private void txtnumunidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtcosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodbar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                btnguardar.Focus();
                btneditar.Focus();
            }
        }

        private void txtdetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    dataGridView1.DataSource = productos.cargarsuProductosTodo(txtdetalle.Text).Tables[0];
                }
            }
            catch { }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                           
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                cargar_grilla();
                txtstock.Focus();
            }
            }
            catch { }
        }
     private void ParaImprimir()
            {
            try
            {
                Clases.Clsfactura factura = new Clases.Clsfactura();

                String codigo = factura.cargarProductosxcod(this.txtid.Text).Tables[0].Rows[0].ItemArray[0].ToString();
                String descripcion = factura.cargarProductosxcod(txtid.Text).Tables[0].Rows[0].ItemArray[1].ToString();
                //String precio  = factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[3].ToString();
                //MessageBox.Show( String.Format("{0:f2}", factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[3]));
                this.textBox4.Text = Convert.ToString(dataGridView2.Rows.Count);

                productos.editarProductos(txtdetalle.Text, Convert.ToDouble(txtpvp.Text), Convert.ToDouble(txtgastos.Text), Convert.ToInt16(txtganancia.Text), Convert.ToInt16(txtstock.Text), Convert.ToString(comboBox3.SelectedValue), Convert.ToString(comboBox1.SelectedValue), Convert.ToInt16(txtnumunidades.Text), Convert.ToDecimal(txtcosto.Text), txtid.Text, Convert.ToString(cmbtipoiva.Text), Convert.ToString(cmbtipocompra.Text), txtcodbar.Text);
    
                if (this.dataGridView2.Rows.Count <= 30)
                {
                    for (int i = 0; i <= Convert.ToInt32(this.textBox3.Text) - 1; i++)
                    {

                        dataGridView2.Rows.Add(codigo, descripcion, String.Format("{0:f2}", factura.cargarProductosxcod(txtid.Text).Tables[0].Rows[0].ItemArray[3]));
                        this.textBox4.Text = Convert.ToString(dataGridView2.Rows.Count);
                    }
                    //  limpiar();
                    // textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Imprimir");
                    // button2.Focus();
                    // limpiar();
                }
            }
            catch { }
            }
        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //PrintDocument pd = new PrintDocument();
           /* PrintDocument pd = new PrintDocument();

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PaperSize ps = new PaperSize("Custom", 440, 220);
            pd.DefaultPageSettings.PaperSize = ps;
            PageSettings pa = new PageSettings();
            pa.Margins = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = pa.Margins;
            pd.Print();
            */

            PrintDocument document = new PrintDocument();

            PaperSize ps = new PaperSize("Custom", 410, 580);
            document.DefaultPageSettings.PaperSize = ps;

            document.PrintPage += document_PrintPage;
            //document.PrinterSettings.PrinterName=Factura;
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = document;
            ppd.ShowDialog();

            PrintDocument printDocument1 = new PrintDocument();

            PrintDialog printDialog1 = new PrintDialog();
            printDocument1.PrintPage += document_PrintPage;
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                ParaImprimir();
                btnguardar.Focus();
                btneditar.Focus();

            }
        }
    }
}
