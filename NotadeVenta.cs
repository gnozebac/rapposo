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
    
    public partial class NotadeVenta : Form
    {
      
        public NotadeVenta()
        {
            InitializeComponent();
        }
        public static string producto;
        public static string Texto;
        Clases.Clsreportes reportes = new Clases.Clsreportes();
        Clases.Clsfactura factura = new Clases.Clsfactura();
        
        
        private void NotadeVenta_Load(object sender, EventArgs e)
        {

        }


        private void txtproducto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
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
                txtstocks.Text = datos.Tables[0].Rows[0].ItemArray[4].ToString();
            }

            catch { }
        }
        private void cargarTextosxcodbar()
        {
            try
            {
                DataSet datos;
                DataSet datos1;
                DataSet datos2;
                DataSet datos3;
                datos = factura.cargarProductosxcodbar(this.txtcodbar.Text);
                datos1 = factura.cargarProductosxcodbar(txtcodbar.Text);
                datos2 = factura.cargarProductosxcodbar(txtcodbar.Text);
                datos3 = factura.cargarProductosxcodbar(txtcodbar.Text);
               
               
                txtcodigo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                txtprod.Text = datos.Tables[0].Rows[0].ItemArray[1].ToString();
                txtprecio.Text = datos.Tables[0].Rows[0].ItemArray[2].ToString();
                txtstocks.Text = datos.Tables[0].Rows[0].ItemArray[3].ToString();


            }

            catch { }
        }
        
        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void cargarventalOAD()
        {
            
            dataGridView2.DataSource = factura.cargarTmpnotaventa().Tables[0];
         

            limpiar();
        }
        private void cargarventa()
        {
            try
            {
                calculartot();

                DataSet datos;
                factura.guardarTmpnotaventa(Convert.ToString(txtcodigo.Text), Convert.ToDateTime(label1.Text), Convert.ToInt16(txtcantidad.Text), txtprod.Text, Convert.ToDouble(txtprecio.Text), Convert.ToDouble(txttotal.Text));
              datos=  factura.codmaxtaventa();
              txtcodigo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();

                dataGridView2.DataSource = factura.cargarTmpnotaventa().Tables[0];
                
                limpiar();
                txtid.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
            }

            catch { }
        }
        private void limpiar()
        {
            txtprod.Text = "";
            txtcodigo.Text = "";
            txtprecio.Text ="0";
            txtcantidad.Text = "1";
           txttotal.Text = "0";
           this.txtcodbar.Focus();
            txtefectivo.Text="";
            txttotalg.Text = "";
            txtcambio.Text = "";
            txtstock.Text = "";
             txtcodbar.Text = "";
        }
        private void calculartot()
        {
            try
            {
                double var;
                var = Convert.ToDouble(txtcantidad.Text) * Convert.ToDouble(txtprecio.Text);

                string resultado = string.Format("{0:#,#0.00}", var);
                txttotal.Text = Convert.ToString(var);


            }
            catch
            { }
        }
        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtprecio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
           
        }

        #region IForm Members

        public bool LoadDataGridView(DataTable dataTableParam)
        {
            dataGridView1.DataSource = dataTableParam;

            return true;
        }

        #endregion
      

        private void txtprod_KeyPress(object sender, KeyPressEventArgs e)
        {


         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            int f = this.dataGridView2.CurrentRow.Index;
            dataGridView2.Rows.RemoveAt(f);

            
            

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
         
          
           
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            

        }
        private void guardarnotaventa()
        {
            try
            {
                //select cantidad, descripcion, pvp, total, id, idproducto from tmpnotaventa
                Int32 i;
                String idproducto;
                String id;
                Int32 cantidad;
                String descripcion;
                Double pvp;
                Double total;
                DateTime fecha;
                DataGridViewCell idD;
                DataGridViewCell idprodD;
                DataGridViewCell totalD;
                DataGridViewCell fechaD;
                DataGridViewCell cantidadD;
                DataGridViewCell descripcionD;
                DataGridViewCell pvpD;

                for (i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {


                    cantidadD = dataGridView2.Rows[i].Cells[0];
                    descripcionD = dataGridView2.Rows[i].Cells[1];
                    pvpD = dataGridView2.Rows[i].Cells[2];
                    totalD = dataGridView2.Rows[i].Cells[3];
                    idD = dataGridView2.Rows[i].Cells[4];
                    idprodD = dataGridView2.Rows[i].Cells[5];
                    fechaD = dataGridView2.Rows[i].Cells[6];

                    cantidad = (Convert.ToInt32(cantidadD.Value));
                    descripcion = (Convert.ToString(descripcionD.Value));
                    pvp = (Convert.ToDouble(pvpD.Value));
                    total = (Convert.ToDouble(totalD.Value));
                    id = (Convert.ToString(idD.Value));
                    idproducto = (Convert.ToString(idprodD.Value));
                    //idprodD = (Convert.ToString(idprodD.Value));
                    fecha = (Convert.ToDateTime(fechaD.Value));
                    factura.guardarnotaventa(id, idproducto, fecha, cantidad, descripcion, pvp, total);

                }
                actualizarstock();
                this.txtcodigo.Focus();
            }

            catch { }
        }
        private void actualizarstock()
        {
            try
            {
                Int32 i;
                Int32 cantidad;
                String id;
                DataGridViewCell dgc;
                DataGridViewCell sid;
                for (i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    dgc = dataGridView2.Rows[i].Cells[5];
                    id = ((String)dgc.Value);
                    sid = dataGridView2.Rows[i].Cells[0];
                    cantidad = Convert.ToInt32(sid.Value);
                    factura.actualizarstock((id), (cantidad));
                }
            }

            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void txtprecio_TabIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void calcularTotalCobrar()
        {
            try
            {
                Int32 i;
                Double celda;
                Double aux;
                Double suma = 0;
                DataGridViewCell dgc;

                for (i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    dgc = dataGridView2.Rows[i].Cells[3];
                    celda = (Convert.ToDouble(dgc.Value));
                    //peliculas.actualizarstock(celda);
                    suma = suma + celda;
                }
                aux = suma;
                //txttotalg.Text =Convert.ToString (aux);

                string resultado = string.Format("{0:#,#0.00}", aux);

                txttotalg.Text = Convert.ToString(resultado);
            }

            catch { }

        }
        private void txtprecio_TextChanged(object sender, EventArgs e)
        {
           

            //txttotalg.Text = Convert.ToString(resultado);

       

           
        }

        private void txtcambio_TextChanged(object sender, EventArgs e)
        {
          
        }

      
        private void txttotalg_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                 
                         
        }

        private void txttotalg_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void txtefectivo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtefectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
           
           
        }
        private void cobrarguardar()
        {
            try{
            if

                       (MessageBox.Show("Guardar?", "Nota Venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                guardarnotaventa();
                factura.borrarTmpnotaventa();
                cargarventalOAD();
                limpiar();
          
            }
            else
            {

                //txtcambio.Text = "";
                //txtefectivo.Text = "";
                //txttotalg.Text = "";
                txtcodigo.Focus();
            }
            }
            catch { }
        }
        private void txttotal_TextChanged(object sender, EventArgs e)
        {

        }
        private void cargartextodesdegrilla()
        {
            try
            {
                txtcodigo.Text =
        dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[5].Value.ToString();
                this.txtprod.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
                txtid.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString();
                txtcantidad.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
                txtprecio.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
                txttotal.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();
            }
            catch { }
        }
        private void cargartextodesdegrillavarios()
        {
           try{
            txtcodigo.Text =
    dataGridView2.Rows[dataGridView2.CurrentRow.Index-1].Cells[5].Value.ToString();
            this.txtprod.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index-1].Cells[1].Value.ToString();
            txtid.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index - 1].Cells[4].Value.ToString();
            txtcantidad.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index-1].Cells[0].Value.ToString();
            txtprecio.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index-1].Cells[2].Value.ToString();
            txttotal.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index-1].Cells[3].Value.ToString();
           }
           catch {
               limpiar();
           }
        }
        private void dataGridView2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
         
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtcodigo.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
      
      
        }

        private void txtprod_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtcodbar_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtcodbar_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void NotadeVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Hide();
            } 
        }

        private void NotadeVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (e.KeyChar == (char)27)
               this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b(object sender, EventArgs e)
        {

            try
            {

                NotadeVenta.ActiveForm.KeyPreview = true;

                this.txtcodigo.Focus();
                label1.Text = DateTime.Now.ToString();
                cargarventalOAD();
                calcularTotalCobrar();
                //Invocamos al Evento
                //PonerTitulo es un método
                //formulario.MiEvento += new Form1.DelegadoTitulo(PonerTitulo);
            }
            catch { }
        }

        private void txtcantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    if (this.dataGridView2.Rows.Count <= 40)
                    {
                        if (Convert.ToInt16(txtcantidad.Text) <= Convert.ToInt16(txtstocks.Text))
                        {
                            // Invalidar la accion
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            cargarventa();
                            calcularTotalCobrar();
                            btnguardar.Focus();
                            dataGridView1.Visible = false;
                            dataGridView2.Visible = true;
                            txtcodigo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No hay suficiente stock");
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            cargarventa();
                            calcularTotalCobrar();
                            btnguardar.Focus();
                            dataGridView1.Visible = false;
                            dataGridView2.Visible = true;
                            txtcodigo.Focus();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Guarde y/o imprima antes de continuar");
                        btnguardar.Focus();

                    }


                }
            }
            catch { }
        }

        private void txtcantidad_TextChanged_1(object sender, EventArgs e)
        {
            calculartot();
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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

                if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    if (this.dataGridView2.Rows.Count <= 40)
                    {
                        if (Convert.ToInt16(txtcantidad.Text) <= Convert.ToInt16(txtstocks.Text))
                        {

                            // Invalidar la accion
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            cargarventa();
                            calcularTotalCobrar();
                            btnguardar.Focus();
                            txtcodigo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No hay suficiente stock");
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            cargarventa();
                            calcularTotalCobrar();
                            btnguardar.Focus();
                            txtcodigo.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Guarde y/o imprima antes de continuar");
                        btnguardar.Focus();

                    }
                }
            }

            catch { }
        }

        private void txtcodbar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == 13)) // Si no es numerico y si no es espacio
                {
                    if (this.dataGridView2.Rows.Count <= 40)
                    {
                        if (Convert.ToInt16(txtcantidad.Text) <= Convert.ToInt16(txtstocks.Text))
                        {
                            // Invalidar la accion
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            cargarventa();
                            calcularTotalCobrar();
                            btnguardar.Focus();
                            dataGridView2.Visible = true;
                            dataGridView1.Visible = false;
                            this.txtcodbar.Focus();
                            txtcodbar.Text = "";
                            //limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No hay suficiente stock");
                            // Invalidar la accion
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            cargarventa();
                            calcularTotalCobrar();
                            btnguardar.Focus();
                            dataGridView2.Visible = true;
                            dataGridView1.Visible = false;
                            this.txtcodbar.Focus();
                            txtcodbar.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Guarde y/o imprima antes de continuar");
                        btnguardar.Focus();
                        limpiar();
                    }
                }
            }

            catch { }
        }

        private void txtprod_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                try
                {
                    Form1 f = new Form1();
                    Texto = this.txtprod.Text;
                    f._FormPadre = this;

                    if (f.ShowDialog() == DialogResult.OK)
                    {

                        string nombre = f.Nombre; //lee la propiedad
                        string txtid = f.id;
                        string txtpvp = f.Pvp;
                        string textstock = f.Stock;
                        txtprod.Text = nombre;
                        txtcodigo.Text = txtid;
                        txtprecio.Text = txtpvp;
                        Double precio = Convert.ToDouble(txtprecio.Text);
                        string resultado = string.Format("{0:#,#0.00}", precio);
                        txtprecio.Text = resultado;
                        txtstocks.Text = textstock;
                        txtcantidad.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            Texto = this.txtBusqueda.Text;

            f._FormPadre = this;
            if (f.ShowDialog() == DialogResult.OK)
            {


            }
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            try
            {

                if

                         (MessageBox.Show("Se eliminarán todos los productos que tengan el mismo codigo", "Cancelar Venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    factura.borrarTmpnotaventaxcodigo(txtid.Text, txtcodigo.Text);
                    cargarventalOAD();
                    calcularTotalCobrar();
                    this.txtcodigo.Focus();
                }
            }

            catch { }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {

                if

                         (MessageBox.Show("Seguro que desea cancelar?", "Cancelar Venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    factura.borrarTmpnotaventa();
                    cargarventalOAD();
                    this.txtcodigo.Focus();
                    txtid.Text = "";
                }
            }

            catch { }
        }

        private void txttotalg_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
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

            catch { }
        }

        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                cobrarguardar();
            }

            catch { }
        }

        private void txtprecio_TextChanged_1(object sender, EventArgs e)
        {
            calculartot();
        }

        private void txttotalg_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                Double cambio;
                cambio = Convert.ToDouble(txtefectivo.Text) - Convert.ToDouble(txttotalg.Text);
                txtcambio.Text = Convert.ToString(cambio);
            }
            catch
            { }
        }

        private void txtcodigo_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                Clases.Clsfactura factura = new Clases.Clsfactura();

                dataGridView2.Visible = true;
                dataGridView1.DataSource = factura.cargarProductosxcod(txtprod.Text).Tables[0];
                cargarTextosxcod();
            }
            catch { }
        }

        private void txtcodigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
            try
            {
                if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    if (this.dataGridView2.Rows.Count <= 40)
                    {
                        if (Convert.ToInt16(txtcantidad.Text) <= Convert.ToInt16(txtstocks.Text))
                        {
                            // Invalidar la accion
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            cargarventa();
                            calcularTotalCobrar();
                            btnguardar.Focus();
                            dataGridView2.Visible = true;
                            dataGridView1.Visible = false;
                            this.txtcodigo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No hay suficiente stock");
                            // Invalidar la accion
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            cargarventa();
                            calcularTotalCobrar();
                            btnguardar.Focus();
                            dataGridView2.Visible = true;
                            dataGridView1.Visible = false;
                            this.txtcodigo.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Guarde y/o imprima antes de continuar");
                        btnguardar.Focus();
                    }
                }
            }

            catch { }
        }

        private void txtefectivo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
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
                if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    // Invalidar la accion
                    e.Handled = true;
                    // Enviar el sonido de beep de windows
                    System.Media.SystemSounds.Beep.Play();
                    cobrarguardar();

                }
            }

            catch { }
        }

        private void dataGridView2_Click_1(object sender, EventArgs e)
        {
            try
            {
                cargartextodesdegrilla();
            }
            catch
            {
                limpiar();
            }
        }

        private void txtcodbar_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                if (txtcodbar.Text != "")
                {
                    Clases.Clsfactura factura = new Clases.Clsfactura();

                    dataGridView2.Visible = true;

                    dataGridView1.DataSource = factura.cargarProductosxcodbar(txtcodbar.Text).Tables[0];
                    cargarTextosxcodbar();
                    //cargarventa();


                }
            }
            catch { }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                decimal r;

                r = Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox4.Text);
                textBox1.Text = Convert.ToString(r);
            }
            catch
            {
            }
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
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

            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {

                e.Handled = true;
                // Enviar el sonido de beep de windows
                System.Media.SystemSounds.Beep.Play();
                textBox2.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox4.Focus();
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
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



            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {

                e.Handled = true;
                // Enviar el sonido de beep de windows
                System.Media.SystemSounds.Beep.Play();
                textBox2.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox4.Focus();
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            reportes.BorrarTmpnvxfecha();
            string fecha;
            fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            reportes.nvxnumnotaventadia(Convert.ToString(txtid.Text));

            //FrVentaxdia newMDIChildForm = new FrVentaxdia();

            FrmNotaventapeq newMDIChildForm = new FrmNotaventapeq();

            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
        }

        private void dataGridView2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {

                    Int32 i;


                    for (i = 0; i < dataGridView2.Rows.Count; i++)
                    {


                        if (dataGridView2.Rows.Count == 2)
                        {
                            this.txtprod.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index - 1].Cells[1].Value.ToString();
                        }


                        if (dataGridView2.Rows.Count > 2)
                        {
                            cargartextodesdegrillavarios();
                        }
                    }


                }
            }
            catch { limpiar(); }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                decimal r;

                r = Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox4.Text);
                textBox1.Text = Convert.ToString(r);
            }
            catch
            {
            }
        }

        private void txtefectivo_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                Double cambio;
                cambio = Convert.ToDouble(txtefectivo.Text) - Convert.ToDouble(txttotalg.Text);
                txtcambio.Text = Convert.ToString(cambio);
            }
            catch
            { }
        }
    }
}
