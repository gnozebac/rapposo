using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaposoFact
{
    public partial class Factura : Form, IForm
    {
        public Factura()
        {
            InitializeComponent();
        }

        #region IForm Members

        public bool LoadDataGridView(DataTable dataTableParam)
        {
           
            //dgFac.DataSource = dataTableParam;
            //int rowIndex = dgFac.CurrentRow.Index;
            //MessageBox.Show (""+ dataTableParam.Rows[0].ItemArray[0].ToString());
            dgFac[0,numfilaact].Value = dataTableParam.Rows[0].ItemArray[0].ToString();
//            dgFac.EditingControlShowing = 0;
            
            
            return true;
        }

        #endregion

        public int numfilaact;
        public static string productos;
        public static string Textos;
        public static string nombres;
        public static string Texto;
        Clases.Clsfactura factura = new Clases.Clsfactura();
        Clases.Clsreportes reportes = new Clases.Clsreportes();
        Clases.Clscliente cliente = new Clases.Clscliente();
        public double subtotaliva;
        public double totaltotal;
        public double aux1 = 0;
        public int nFilaSel;
                    private List<Clases.Clsfactura> lst = new List<Clases.Clsfactura>();
        private void calcularTotalCobrar()
        {
            try
            {
                Int32 i;
                Double celda;
                Double aux;
                Double suma = 0;
                DataGridViewCell dgc;

                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dgc = dataGridView1.Rows[i].Cells[3];
                    celda = (Convert.ToDouble(dgc.Value));
                    //peliculas.actualizarstock(celda);
                    suma = suma + celda;
                }
                aux = suma;
                //txttotalg.Text =Convert.ToString (aux);

                string resultado = string.Format("{0:#,#0.00}", aux);

                txttotalg.Text = Convert.ToString(resultado);
                dataGridView1.ClearSelection();
            }

            catch { }

        }
        private void calcularTotalCobrarcodbarra()
        {
            try
            {
                Int32 i;
                Double celda;
                Double aux;
                Double suma = 0;
                DataGridViewCell dgc;

                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dgc = dataGridView1.Rows[i].Cells[4];
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
        private void cargarventalOAD()
        {
            try
            {
                dataGridView1.DataSource = factura.cargarTmpfactura().Tables[0];


                limpiar();
            }
            catch
            { }
        }
        private void limpiar()
        {
            this.txtproducto.Text = "";
            txtcodigo.Text = "";
            txtprecio.Text = "0";
            txtcantidad.Text = "1";
           // txttotal.Text = "0";
            txtcodigo.Focus();
            txtefectivo.Text = "";
           // txttotalg.Text = "";
            txtcambio.Text = "";
            txtstock.Text = "0";
            txtcsiva.Text = "";
        }
        private void limpiariva()
        {
            txtsubtotal.Text = "0";
            txtiva.Text = "0";
            txttotalg.Text = "0";
        }
        private void Factura_Load(object sender, EventArgs e)
        {
      
            try
            {
                label24.Text = DateTime.Now.ToString();
                this.txtproducto.Focus();

                button6.Enabled = true;
                cargarventalOAD();
                calcularTotalCobrar();
              limpiariva();
                //Invocamos al Evento
                //PonerTitulo es un método
                //formulario.MiEvento += new Form1.DelegadoTitulo(PonerTitulo);
            }
            catch { }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                // Invalidar la accion
                e.Handled = true;
                // Enviar el sonido de beep de windows
                System.Media.SystemSounds.Beep.Play();

            }
        }

       

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
           
             if (e.KeyChar == 13) // Si no es numerico y si no es espacio
        {
            try
            {
                BuscarClienteFac g = new BuscarClienteFac();
                Texto = this.txtbuscar.Text;
            
                g._FormPadres = this;
                if (g.ShowDialog() == DialogResult.OK)
                {

                    string nombre = g.Nombre; //lee la propiedad
                    string txtid = g.id;
                    string textruc = g.ruc;
                    string dir = g.direccion;
                    string email = g.Email;
                    string fono = g.fono;
                    this.txtidcliente.Text = txtid;
                    txtbuscar.Text = nombre;
                    //txtdir.Text = dir;
                    textBox8.Text = g.ruc;
                   this.txtdireccion.Text = dir;
                   txtfono.Text = fono;
                   txtcodigo.Focus();
                   


                    
               
                }
            }
            catch
            {
            }

        
            }

            
        }

    

        private void txtproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
        

            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                try
                {
                    ProdFac f = new ProdFac();
                    Textos = this.txtproducto.Text;
                    f._FormPadref = this;

                    if (f.ShowDialog() == DialogResult.OK)
                    {

                        string nombre = f.Nombres; //lee la propiedad
                        string txtid = f.ids;
                        string txtpvp = f.Pvps;
                        string textstock = f.Stocks;
                        string texttipoiva = f.Tiva;
                        txtproducto.Text = nombre;
                        
                        txtcodigo.Text = txtid;
                        txtprecio.Text = txtpvp;
                        Double precio = Convert.ToDouble(txtprecio.Text);
                        string resultado = string.Format("{0:#,#0.00}", precio);
                        txtprecio.Text = resultado;
                        txtstock.Text = textstock;
                        txtcsiva.Text = texttipoiva;
                        //txtstock.Text = textstock;
                        txtcantidad.Focus();
                    }
                }
                catch
                {
                }


            }
        }
        private void cargarTextosxcod()
        {
            try
            {
                DataSet datos;
                datos = factura.cargarProductosxcod(this.txtcodigo.Text);
                txtcodigo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                txtproducto.Text = datos.Tables[0].Rows[0].ItemArray[1].ToString();
                txtprecio.Text = datos.Tables[0].Rows[0].ItemArray[3].ToString();
                txtstock.Text = datos.Tables[0].Rows[0].ItemArray[4].ToString();
                txtcsiva.Text = datos.Tables[0].Rows[0].ItemArray[2].ToString();
            }

            catch { }
        }
        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {


            try
            {

                Clases.Clsfactura factura = new Clases.Clsfactura();

           dataGridView1.Visible = true;
               dataGridView2.DataSource = factura.cargarProductosxcod(txtproducto.Text).Tables[0];
               cargarTextosxcod();
        
            }
            catch { }
        }
        private void agregaralagrilla()
        {
           try
           {

               if (this.dgFac.Rows.Count <= 1212)
               {




                    double preSinIva = 0;
                       double sTotal = 0;
                    double Porcentaje = 0; Decimal SubTotal;
                        preSinIva = Convert.ToDouble((this.txtprecio.Text).Replace(".", ","));
                    Porcentaje = (Convert.ToDouble(txtcsiva.Text) / 100) + 1;
                    preSinIva = preSinIva / Porcentaje;
                       

                        string resultado = string.Format("{0:#,#0.000}", preSinIva);

                       sTotal = preSinIva * Convert.ToDouble(this.txtcantidad.Text);
                       string resultado1 = string.Format("{0:#,#0.000}", sTotal);

                       // this.dgFac.Rows.Add(txtcantidad.Text, this.txtproducto.Text, resultado, resultado1, txtcodigo.Text, txtcsiva.Text);
                       this.dgFac.Rows.Add(txtcodigo.Text, this.txtcantidad.Text, txtproducto.Text, resultado, resultado1, txtcsiva.Text);
                       string sResult = fnSumasingrilla();
                    dataGridView1.ClearSelection();


                    sumar();

                }
               

           }
              
            catch
           {
           }
        }
        private void cargarventa()
        {
            try
            {
                calculartot();

                DataSet datos;
                factura.guardarTmpnotaventa(Convert.ToString(txtcodigo.Text), Convert.ToDateTime(label24.Text), Convert.ToInt16(txtcantidad.Text), this.txtproducto.Text, Convert.ToDouble(txtprecio.Text), Convert.ToDouble(txttotal.Text));
                datos = factura.codmaxtaventa();
                txtcodigo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                dataGridView1.DataSource = factura.cargarTmpfactura().Tables[0];


                //limpiar();
                //txtid.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
            }

            catch { }
        }
        private string fnSumasingrilla()
        {

            double suma = 0;
            double sumaiva0 = 0;
            double aux = 0;

            for (int i = 0; i <= this.dgFac.Rows.Count - 2; i++)
            {
                if (Convert.ToDouble(dgFac.Rows[i].Cells[3].Value) + 0 != 0)
                {
                    aux = Convert.ToDouble(dgFac.Rows[i].Cells[5].Value.ToString());
                    if (aux == 0)
                    {
                        //txtaux.Text = Convert.ToString(aux);
                        sumaiva0 = sumaiva0 + Convert.ToDouble(dgFac.Rows[i].Cells[4].Value.ToString());
                    }
                    else
                    {
                        //txtaux.Text = Convert.ToString(aux);
                        suma = suma + Convert.ToDouble(dgFac.Rows[i].Cells[4].Value.ToString());
                    }
                }
            }
            



            if (txtcsiva.Text == "12")
            {

                string stSubtotal = "0";

                stSubtotal = string.Format("{0:#,#0.00}", suma);
                double auxdeaux = 0;

                auxdeaux = Convert.ToDouble(stSubtotal) + Convert.ToDouble(aux1);
                txtsubtotal.Text = Convert.ToString(auxdeaux);
                subtotaliva = Convert.ToDouble(txtsubtotal.Text);
                txtaux.Text = Convert.ToString(subtotaliva);

                string stIva = "0";

                stIva = string.Format("{0:#,#0.00}", (suma * 1.12) - suma);
                txtiva.Text = stIva;

                string stTotal = "0";

                stTotal = string.Format("{0:#,#0.00}", suma * 1.12);
                txttotalg.Text = stTotal;
                txtiva12.Text = Convert.ToString(suma);
                double totalito = 0;
                totalito = Convert.ToDouble(txtiva.Text) + Convert.ToDouble(txtsubtotal.Text);
                txttotalg.Text = Convert.ToString(totalito);
            }
            else
            {

                string stSubtotal = string.Format("{0:#,#0.00}", sumaiva0);
                aux1 = 0;
                aux1 = Convert.ToDouble(stSubtotal) + Convert.ToDouble(subtotaliva);
                txtsubtotal.Text = Convert.ToString(aux1);
                string stIva = string.Format("{0:#,#0.00}", (suma * 1.12) - suma);
                txtiva.Text = stIva;
                txtiva0.Text = Convert.ToString(sumaiva0);
                string stTotal = string.Format("{0:#,#0.00}", sumaiva0);
                txttotalg.Text = stTotal;
                double totalito = 0;
                totalito = Convert.ToDouble(txtiva.Text) + Convert.ToDouble(txtsubtotal.Text);
                txttotalg.Text = Convert.ToString(totalito);
            }

            string dosDecimales = "";

            return dosDecimales;

                   
        }
        private string fnSuma()
        {
           
                double suma = 0;
                double sumaiva0 = 0;
                double aux = 0;
                for (int i = 0; i <= this.dgFac.Rows.Count - 2; i++)
                {
                    if (Convert.ToDouble(dgFac.Rows[i].Cells[3].Value) + 0 != 0)
                    {
                        aux = Convert.ToDouble(dgFac.Rows[i].Cells[5].Value.ToString());
                        if (aux == 0)
                        {
                            //txtaux.Text = Convert.ToString(aux);
                            sumaiva0 = sumaiva0 + Convert.ToDouble(dgFac.Rows[i].Cells[3].Value.ToString());

                        }
                        else
                        {
                            //txtaux.Text = Convert.ToString(aux);
                            suma = suma + Convert.ToDouble(dgFac.Rows[i].Cells[3].Value.ToString());
                        }
                    }
                }








            if (txtcsiva.Text == "12")
                {

                    string stSubtotal = "0";
                
                    stSubtotal = string.Format("{0:#,#0.00}", suma);
                    double auxdeaux = 0;
                    auxdeaux = Convert.ToDouble(stSubtotal) + Convert.ToDouble(aux1);
                    txtsubtotal.Text = Convert.ToString(auxdeaux);
                    subtotaliva = Convert.ToDouble(txtsubtotal.Text);
                    txtaux.Text = Convert.ToString(subtotaliva);

                    string stIva = "0";

                    stIva = string.Format("{0:#,#0.00}", (suma * 1.12) - suma);
                    txtiva.Text = stIva;

                    string stTotal = "0";

                    stTotal = string.Format("{0:#,#0.00}", suma * 1.12);
                    txttotalg.Text = stTotal;
                    txtiva12.Text = Convert.ToString(suma);
                    double totalito = 0;
                    totalito = Convert.ToDouble(txtiva.Text) + Convert.ToDouble(txtsubtotal.Text);
                    txttotalg.Text = Convert.ToString(totalito);
                }
                else
                {

                    string stSubtotal = string.Format("{0:#,#0.00}", sumaiva0);
                    aux1 = 0;
                    aux1 = Convert.ToDouble(stSubtotal) + Convert.ToDouble(subtotaliva);
                    txtsubtotal.Text = Convert.ToString(aux1);
                    string stIva = string.Format("{0:#,#0.00}", (suma * 1.12) - suma);
                    txtiva.Text = stIva;
                    txtiva0.Text = Convert.ToString(sumaiva0);
                    string stTotal = string.Format("{0:#,#0.00}", sumaiva0);
                    txttotalg.Text = stTotal;
                    double totalito = 0;
                    totalito = Convert.ToDouble(txtiva.Text) + Convert.ToDouble(txtsubtotal.Text);
                    txttotalg.Text = Convert.ToString(totalito);
                }

                string dosDecimales = "";

                return dosDecimales;

           
        }
        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    if (this.dataGridView2.Rows.Count <= 10)
                    {
                        // Invalidar la accion
                        e.Handled = true;
                        // Enviar el sonido de beep de windows
                        System.Media.SystemSounds.Beep.Play();
                        agregaralagrilla();
                        //btnguardar.Focus();

                        dataGridView1.Visible = true;
                        txtcodigo.Focus();
                        limpiar();





                    }
                }
            }
            catch { }
        }
        private void calculartot()
        {
            try
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
            catch
            { }
        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {
           
            calculartot();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
               if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                   
                    if (this.dataGridView2.Rows.Count <= 12)
                    {
                        // Invalidar la accion
                        e.Handled = true;
                        // Enviar el sonido de beep de windows
                        System.Media.SystemSounds.Beep.Play();
                        agregaralagrilla();
                        //btnguardar.Focus();

                        dataGridView1.Visible = true;
                        this.txtcodigo.Focus();
                        limpiar();





                    }
                }
                
            }
            catch { }
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
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
            try
            {
                if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    if (this.dataGridView2.Rows.Count <= 12)
                    {
                        // Invalidar la accion
                        e.Handled = true;
                        // Enviar el sonido de beep de windows
                        System.Media.SystemSounds.Beep.Play();
                        agregaralagrilla();
                        //btnguardar.Focus();

                        dataGridView1.Visible = true;
                        this.txtcodigo.Focus();
                        limpiar();





                    }
                    
                }
            }
            catch { }
        }

        private void txtefectivo_TextChanged(object sender, EventArgs e)
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

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {

                calculartot();
            }
            catch
            { }
            
        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
            
                int f = dgFac.CurrentRow.Index;
                dgFac.Rows.RemoveAt(f);
                dataGridView1.ClearSelection();


                sumar();

                if (this.dgFac.Rows.Count <= 1)
                {

                    txtsubtotal.Text = "0";
                    txtiva.Text = "0";
                    txttotalg.Text = "0";
                    txtaux.Text = "0";
                    txtiva0.Text = "0";
                    txtiva12.Text = "0";

                }
            }



            catch
            {


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet datos;

                datos = cliente.cargarxcicliente(textBox8.Text);

                this.txtidcliente.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                txtbuscar.Text = datos.Tables[0].Rows[0].ItemArray[2].ToString();
                txtdireccion.Text = datos.Tables[0].Rows[0].ItemArray[3].ToString();
             txtfono.Text = datos.Tables[0].Rows[0].ItemArray[4].ToString();
            }

            catch { }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
        {
            try
            {
                BuscarClienteFac g = new BuscarClienteFac();
                Texto = this.textBox8.Text;
            
                g._FormPadres = this;
                if (g.ShowDialog() == DialogResult.OK)
                {

                    string nombre = g.Nombre; //lee la propiedad
                    string txtid = g.id;
                    string textruc = g.ruc;
                    string dir = g.direccion;
                    string email = g.Email;
                    string fono = g.fono;
                    this.txtidcliente.Text = txtid;
                    txtbuscar.Text = nombre;
                    //txtdir.Text = dir;
                    textBox8.Text = g.ruc;
                   this.txtdireccion.Text = dir;
                   txtfono.Text = fono;
                   txtcodigo.Focus();
                   


                    
               
                }
            }
            catch
            {
            }
        }

        }
        private void actualizarstock()
        {
        }
        private void GuardarFactura()
        {

            try
            {
                //select cantidad, descripcion, pvp, total, id, idproducto from tmpnotaventa
                Int32 i;
                String idproducto;
                //String id;
                Int32 cantidad;
                String descripcion;
                Double pvp;
                Double pvptotal;
                DataGridViewCell idprodD;
                
                DataGridViewCell cantidadD;
                DataGridViewCell descripcionD;
                DataGridViewCell pvpD;
                DataGridViewCell pvptotald;

                for (i = 0; i < dgFac.Rows.Count - 1; i++)
                {


                    cantidadD = dgFac.Rows[i].Cells[0];
                    descripcionD = dgFac.Rows[i].Cells[1];
                    pvpD = dgFac.Rows[i].Cells[2];
                    pvptotald = dgFac.Rows[i].Cells[3];         
                    idprodD = dgFac.Rows[i].Cells[4];
                     cantidad = (Convert.ToInt32(cantidadD.Value));
                    descripcion = (Convert.ToString(descripcionD.Value));
                    pvp = (Convert.ToDouble(pvpD.Value));
                    pvptotal = (Convert.ToDouble(pvptotald.Value));
                    idproducto = (Convert.ToString(idprodD.Value));
                    //idprodD = (Convert.ToString(idprodD.Value));

                    factura.insertarfactura(txtnumfac.Text, Convert.ToDateTime(label24.Text), txtidcliente.Text, Convert.ToDouble(txtsubtotal.Text), Convert.ToDouble(txtiva0.Text), Convert.ToDouble(txtiva12.Text),Convert.ToDouble(txtiva.Text), Convert.ToDouble(txttotalg.Text));
                    factura.insertardetallefactura(txtnumfac.Text, (idproducto), pvp,pvptotal, cantidad);


                }
                actualizarstock();
                this.txtcodigo.Focus();
            }

            catch { }

}
        private void GuardarFactura1()
        {

            try
            {
                //select cantidad, descripcion, pvp, total, id, idproducto from tmpnotaventa
                Int32 i;
                String idproducto;
                //String id;
                Int32 cantidad;
                String descripcion;
                Double pvp;
                Double pvptotal;
                DataGridViewCell idprodD;

                DataGridViewCell cantidadD;
                DataGridViewCell descripcionD;
                DataGridViewCell pvpD;
                DataGridViewCell pvptotald;

                for (i = 0; i < dgFac.Rows.Count - 1; i++)
                {


                    cantidadD = dgFac.Rows[i].Cells[1];
                    descripcionD = dgFac.Rows[i].Cells[2];
                    pvpD = dgFac.Rows[i].Cells[3];
                    pvptotald = dgFac.Rows[i].Cells[4];
                    idprodD = dgFac.Rows[i].Cells[0];
                    cantidad = (Convert.ToInt32(cantidadD.Value));
                    descripcion = (Convert.ToString(descripcionD.Value));
                    pvp = (Convert.ToDouble(pvpD.Value));
                    pvptotal = (Convert.ToDouble(pvptotald.Value));
                    idproducto = (Convert.ToString(idprodD.Value));
                    //idprodD = (Convert.ToString(idprodD.Value));
     

                    factura.insertarfactura(txtnumfac.Text, Convert.ToDateTime(label24.Text), txtidcliente.Text, Convert.ToDouble(txtsubtotal.Text), Convert.ToDouble(txtiva0.Text), Convert.ToDouble(txtiva12.Text), Convert.ToDouble(txtiva.Text), Convert.ToDouble(txttotalg.Text));
                    factura.insertardetallefactura(txtnumfac.Text, (idproducto), pvp, pvptotal, cantidad);


                }
                actualizarstock();
                this.txtcodigo.Focus();
            }

            catch { }

        }

        private void button6_Click(object sender, EventArgs e)
        {
           try
           {
                if (txtnumfac.Text != "")
                 {
                    if(MessageBox.Show("Guardar?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                    //factura.borrarTmpnotaventa();
                    GuardarFactura1();
                    button6.Enabled = false;
                    //factura.borrarTmpnotaventa();
                    cargarventalOAD();
                    limpiar();

                 if(MessageBox.Show("Imprimir?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            Clases.Clsreportes a = new Clases.Clsreportes();
                            DataSet dsImprimir = a.xnumfacturapeq(txtnumfac.Text);
                            //float stlinea = 110;
                            //MessageBox.Show(dsImprimir.Tables[0].Rows[0].ItemArray[7].ToString());


                            PrintDocument document = new PrintDocument();
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
                        catch(Exception ex)
                        {
                        MessageBox.Show("err1 "+ex.ToString());
                        }
                    }
                    }
                else
                {

                    //txtcambio.Text = "";
                    //txtefectivo.Text = "";
                    //txttotalg.Text = "";
                    txtcodigo.Focus();
                }


 }


                else
                {

                    //txtcambio.Text = "";
                    //txtefectivo.Text = "";
                    //txttotalg.Text = "";
                    MessageBox.Show("Falta el Número de factura");
                }



            }
           catch (Exception ex)
           {
               MessageBox.Show("err2 " + ex.ToString());

           }
            
            
          
        }

        private void dgFac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtnumfac.Text != "")
                {
                    if (MessageBox.Show("Guardar?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //factura.borrarTmpnotaventa();
                        GuardarFactura1();
                        button6.Enabled = false;
                        //factura.borrarTmpnotaventa();
                        cargarventalOAD();
                        limpiar();

                        if (MessageBox.Show("Imprimir?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {


                            reportes.borrartmpfactura();

                            reportes.xnumfactura(Convert.ToString(this.txtnumfac.Text));

                            Imprimirfactura newMDIChildForm = new Imprimirfactura();
                            newMDIChildForm.MdiParent = this.MdiParent;

                            newMDIChildForm.Show();
                            this.Close();

                        }


                    }
                }
            }
            catch
            { }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void txtcodigobarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == 13)) // Si no es numerico y si no es espacio
                {
                    if (this.dataGridView2.Rows.Count <= 10)
                    {
                        if (Convert.ToInt16(txtcantidad.Text) <= Convert.ToInt16(txtstock.Text))
                        {
                            // Invalidar la accion
                            e.Handled = true;
                            // Enviar el sonido de beep de windows
                            System.Media.SystemSounds.Beep.Play();
                            agregaralagrilla();
                            calcularTotalCobrarcodbarra();
                            //btnguardar.Focus();
                            dataGridView2.Visible = true;
                            dataGridView1.Visible = false;
                            this.txtcodigobarras.Focus();
                            txtcodigobarras.Text = "";
                            //limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No hay suficiente stock");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Guarde y/o imprima antes de continuar");
                        //btnguardar.Focus();
                        limpiar();
                    }
                }
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
               
                datos = factura.cargarProductosxcodbar(this.txtcodigobarras.Text);
                datos1 = factura.cargarProductosxcodbar(txtcodigobarras.Text);
                datos2 = factura.cargarProductosxcodbar(txtcodigobarras.Text);
                datos3 = factura.cargarProductosxcodbar(txtcodigobarras.Text);
                txtcodigo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                this.txtproducto.Text = datos.Tables[0].Rows[0].ItemArray[1].ToString();
                txtprecio.Text = datos.Tables[0].Rows[0].ItemArray[2].ToString();
                txtstock.Text = datos.Tables[0].Rows[0].ItemArray[3].ToString();
            }

            catch { }
        }
        private void txtcodigobarras_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtcodigobarras.Text != "")
                {
                  
                   Clases.Clsfactura factura = new Clases.Clsfactura();

                    dataGridView2.Visible = true;

                    dataGridView1.DataSource = factura.cargarProductosxcodbar(txtcodigobarras.Text).Tables[0];
                    cargarTextosxcodbar();
                    //cargarventa();


                }
            }
            catch { }
        }

        private void dgFac_KeyPress(object sender, KeyPressEventArgs e)
        {
              MessageBox.Show("y");
        }

        private void dgFac_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
         
        }

       

        private void dgFac_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dgFac_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
            
              
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                try
                {
                    BuscarClienteFac g = new BuscarClienteFac();
                    Texto = this.txtbuscar.Text;

                    g._FormPadres = this;
                    if (g.ShowDialog() == DialogResult.OK)
                    {

                        string nombre = g.Nombre; //lee la propiedad
                        string txtid = g.id;
                        string textruc = g.ruc;
                        string dir = g.direccion;
                        string email = g.Email;
                        string fono = g.fono;
                        this.txtidcliente.Text = txtid;
                        txtbuscar.Text = nombre;
                        //txtdir.Text = dir;
                        textBox8.Text = g.ruc;
                        this.txtdireccion.Text = dir;
                        txtfono.Text = fono;
                        txtcodigo.Focus();





                    }
                }
                catch
                {
                }


            }

        }

    



        /// <summary>
        /// Permite con escribir en la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        void text_KeyUp(object sender, KeyEventArgs e)
        {
            int rowIndex = ((System.Windows.Forms.DataGridViewTextBoxEditingControl)(sender)).EditingControlRowIndex;
            if (e.KeyCode == Keys.F3)
            {
                dgFac.Rows.Add();
                Form1no form2 = new Form1no();
                form2.MdiParent = this.MdiParent;
                form2.Opener = this;
                form2.Show();
                nFilaSel = rowIndex;
            }
            if (e.KeyCode == Keys.Enter)
            {
                int caseSwitch = dgFac.CurrentCell.ColumnIndex;
                switch (caseSwitch)
                {
                    case 0:
                        //MessageBox.Show(dgFac.CurrentCell.ColumnIndex.ToString());
                        Clases.Clsfactura factura = new Clases.Clsfactura();
                        //int valueEntered = Convert.ToInt32(dgFac.Rows[rowIndex - 1].Cells["cuenta"].Value);
                        string codigo = dgFac.Rows[rowIndex - 1].Cells["cuenta"].Value.ToString();
                        if (codigo == null)
                            break;
                        DataSet aa = factura.cargarProductosxcod(codigo);
                        if (aa.Tables[0].Rows.Count == 0)
                        {
                            dgFac.CurrentCell = dgFac.Rows[rowIndex - 1].Cells[0];
                            //MessageBox.Show("No existes el codigo");
                            break;
                        }
                        // dgFac.Rows[rowIndex - 1].Cells["descripcion"].Value = factura.cargarProductosxcod(codigo).Tables[0].Rows[0].ItemArray[1].ToString();
                        dgFac.Rows[rowIndex - 1].Cells["descripcion"].Value = aa.Tables[0].Rows[0].ItemArray[1].ToString();

                        dgFac.Rows[rowIndex - 1].Cells["iva"].Value = aa.Tables[0].Rows[0].ItemArray[2].ToString();
                        if (dgFac.Rows[rowIndex - 1].Cells["iva"].Value.ToString() == "12")
                        {
                            dgFac.Rows[rowIndex - 1].Cells["vu"].Value = String.Format("{0:f4}", Convert.ToDouble(aa.Tables[0].Rows[0].ItemArray[3]) / 1.12);
                        }
                        else
                        {
                            dgFac.Rows[rowIndex - 1].Cells["vu"].Value = aa.Tables[0].Rows[0].ItemArray[3].ToString();
                        }

                        //dgFac.Rows[rowIndex - 1].Cells["vu"].Value = aa.Tables[0].Rows[0].ItemArray[3].ToString();
                        //Console.WriteLine("Case 1");
                        dgFac.Rows[rowIndex - 1].Cells["cantidad"].Value = "1";
                        dgFac.CurrentCell = dgFac.Rows[rowIndex - 1].Cells[1];
                        dataGridView1.ClearSelection();
                        break;
                    case 1:
                        dgFac.Rows[rowIndex - 1].Cells["total"].Value = Convert.ToDouble(dgFac.Rows[rowIndex - 1].Cells["vu"].Value) * Convert.ToDouble(dgFac.Rows[rowIndex - 1].Cells["cantidad"].Value);
                        dgFac.CurrentCell = dgFac.Rows[rowIndex - 1].Cells[3];
                        sumar();
                        dataGridView1.ClearSelection();
                        //Console.WriteLine("Case 1");
                        break;
                    case 2:

                        //Console.WriteLine("Case 2");
                        break;

                    case 3:
                        dgFac.Rows[rowIndex - 1].Cells["total"].Value = Convert.ToDouble(dgFac.Rows[rowIndex - 1].Cells["vu"].Value) * Convert.ToDouble(dgFac.Rows[rowIndex - 1].Cells["cantidad"].Value);
                        dgFac.CurrentCell = dgFac.Rows[rowIndex].Cells[0];
                        sumar();
                        dataGridView1.ClearSelection();
                        //Console.WriteLine("Case 2");
                        break;

                    default:
                        //Console.WriteLine("Default case");
                        break;
                }




            }
        }

        //private void sumar()
        //{
        //    double subtotal = 0;
        //    double ivacero = 0;
        //    double iva12 = 0;
        //    double total = 0;

        //    for (int i = 0; i <= dgFac.Rows.Count - 2; i++)
        //    {
        //        // subtotal = subtotal + Convert.ToDouble(dgFac.Rows[i].Cells["total"].Value);
        //        if (dgFac.Rows[i].Cells["iva"].Value.ToString() == "12")
        //        {
        //            subtotal = subtotal + (Convert.ToDouble(dgFac.Rows[i].Cells["total"].Value) / 1.12);
        //        }
        //        else
        //        {
        //            ivacero = ivacero + Convert.ToDouble(dgFac.Rows[i].Cells["total"].Value);
        //        }

        //    }
        //    txtsubtotal.Text = String.Format("{0:f2}", subtotal);
        //    txtiva0.Text = ivacero.ToString();
        //    txtiva12.Text = String.Format("{0:f2}", (subtotal / 100) * 12);
        //    txttotalg.Text = ((subtotal * 1.12) + ivacero).ToString();
        //}


        private void sumar()
        {
            try
            {

                double subtotal = 0;
                double ivacero = 0;
                double iva12 = 0;
                double total = 0;


                for (int i = 0; i <= dgFac.Rows.Count - 2; i++)
                {
                    // subtotal = subtotal + Convert.ToDouble(dgFac.Rows[i].Cells["total"].Value);

                    if (dgFac.Rows[i].Cells["iva"].Value.ToString() == "12")
                    {
                        if (dgFac.Rows[i].Cells["total"].Value != null)
                            subtotal = subtotal + (Convert.ToDouble(dgFac.Rows[i].Cells["total"].Value));
                    }
                    else
                    {
                        if (dgFac.Rows[i].Cells["total"].Value != null)
                            ivacero = ivacero + Convert.ToDouble(dgFac.Rows[i].Cells["total"].Value);
                    }

                }
                txtsubtotal.Text = String.Format("{0:f2}", subtotal);
                txtiva0.Text = ivacero.ToString();
                txtiva12.Text = String.Format("{0:f2}", (subtotal / 100) * 12);

                txttotalg.Text = String.Format("{0:f2}", ((subtotal * 1.12) + ivacero).ToString());


              



            }
            catch (Exception ex)
            {
                MessageBox.Show("Valores Vacios" + ex.ToString());
            }
        }

        private void dgFac_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //MessageBox.Show("df");
            DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
            dText.KeyUp -= new KeyEventHandler(text_KeyUp);
            dText.KeyUp += new KeyEventHandler(text_KeyUp);

      
        }

        private void dgFac_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgFac.BeginEdit(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnumfac.Text != "")
                {
                    if (MessageBox.Show("Guardar?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //factura.borrarTmpnotaventa();
                        GuardarFactura1();
                        button6.Enabled = false;
                        //factura.borrarTmpnotaventa();
                        cargarventalOAD();
                        limpiar();

                        if (MessageBox.Show("Imprimir?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                reportes.borrartmpfactura();
                                string fecha;
                                reportes.xnumfactura(Convert.ToString(this.txtnumfac.Text));
                                facturapequ newMDIChildForm = new facturapequ();
                                newMDIChildForm.MdiParent = this.MdiParent;

                                newMDIChildForm.Show();
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("err1 " + ex.ToString());
                            }
                        }
                    }
                    else
                    {

                        //txtcambio.Text = "";
                        //txtefectivo.Text = "";
                        //txttotalg.Text = "";
                        txtcodigo.Focus();
                    }


                }


                else
                {

                    //txtcambio.Text = "";
                    //txtefectivo.Text = "";
                    //txttotalg.Text = "";
                    MessageBox.Show("Falta el Número de factura");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("err2 " + ex.ToString());

            }

        }

        private void btnselecccionar_Click(object sender, EventArgs e)
        {
            dgFac.CurrentCell = dgFac.Rows[numfilaact].Cells[0];
        }

        private void btncliente_Click(object sender, EventArgs e)
        {

        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgFac_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                reportes.borrartmpfactura();

                reportes.xnumfactura(Convert.ToString(this.txtnumfac.Text));

                facturapequ newMDIChildForm = new facturapequ();
                newMDIChildForm.MdiParent = this.MdiParent;

                newMDIChildForm.Show();
                this.Close();
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// ***********************************************************************************************************
        /// ***********************************************************************************************************
        /// IMPRIMIR ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {

            Clases.Clsreportes a = new Clases.Clsreportes();
            DataSet dsImprimir = a.xnumfacturapeq(txtnumfac.Text);
            //float stlinea = 110;
            //MessageBox.Show(dsImprimir.Tables[0].Rows[0].ItemArray[7].ToString());


            PrintDocument document = new PrintDocument();
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

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Clases.Clsreportes a = new Clases.Clsreportes();
                DataSet dsImprimir = a.xnumfacturapeq(txtnumfac.Text);

                e.Graphics.DrawString("FECHA: " + dsImprimir.Tables[0].Rows[0].ItemArray[16].ToString().Substring(0, 10), new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(6, 10));
                e.Graphics.DrawString("RUC: " + dsImprimir.Tables[0].Rows[0].ItemArray[3].ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(6, 30));
                e.Graphics.DrawString("CLIENTE: " + dsImprimir.Tables[0].Rows[0].ItemArray[2].ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(6, 50));
                e.Graphics.DrawString("DIR: " + dsImprimir.Tables[0].Rows[0].ItemArray[4].ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(6, 70));
                e.Graphics.DrawString("TELF.: " + dsImprimir.Tables[0].Rows[0].ItemArray[5].ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(6, 90));

                e.Graphics.DrawString("CANT   DESCRIPCION       VU       TOT" , new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(6, 110));

                /*e.Graphics.DrawString("6", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 110));
                e.Graphics.DrawString("7", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 130));
                e.Graphics.DrawString("8", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 150));
                e.Graphics.DrawString("9", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 170));
                */

                float stlinea = 130;
                for (int i = 0; i <= dsImprimir.Tables[0].Rows.Count - 1; i++)
                {
                    e.Graphics.DrawString(dsImprimir.Tables[0].Rows[i].ItemArray[7].ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(6, stlinea));
                    string des = dsImprimir.Tables[0].Rows[i].ItemArray[8].ToString();
                    if (des.Length >= 25) { e.Graphics.DrawString(des.Substring(0, 26), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(40, stlinea)); }
                    else { e.Graphics.DrawString(des, new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(40, stlinea)); }

                    e.Graphics.DrawString(dsImprimir.Tables[0].Rows[i].ItemArray[9].ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(310, stlinea));
                    e.Graphics.DrawString(dsImprimir.Tables[0].Rows[i].ItemArray[10].ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(375, stlinea));
                    stlinea = stlinea + 20;
                }

                e.Graphics.DrawString("--------------------------------------- ", new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(6, 350));

                e.Graphics.DrawString("IVA 0%: " + dsImprimir.Tables[0].Rows[0].ItemArray[11].ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(6, 370));
                e.Graphics.DrawString("SUBTOTAL: " + dsImprimir.Tables[0].Rows[0].ItemArray[13].ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(175, 370));
                e.Graphics.DrawString("IVA 12%: " + dsImprimir.Tables[0].Rows[0].ItemArray[14].ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(6, 390));
                e.Graphics.DrawString("TOTAL: " + dsImprimir.Tables[0].Rows[0].ItemArray[15].ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(175, 390));

            }
            catch { }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
             if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                   
                   
            double d;
            d = Convert.ToDouble(textBox2.Text) / 1.12;
            label6.Text = Convert.ToString(d);
                }
        }

        private void txttotalg_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtnumfac.Text != "")
                {
                    if (MessageBox.Show("Guardar?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //factura.borrarTmpnotaventa();
                        GuardarFactura1();
                        button6.Enabled = false;
                        //factura.borrarTmpnotaventa();
                        cargarventalOAD();
                        limpiar();

                        if (MessageBox.Show("Imprimir?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                reportes.borrartmpfactura();
                                string fecha;
                                reportes.xnumfactura(Convert.ToString(this.txtnumfac.Text));

                                Imprimirfactura newMDIChildForm = new Imprimirfactura();
                                newMDIChildForm.MdiParent = this.MdiParent;

                                newMDIChildForm.Show();
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("err1 " + ex.ToString());
                            }
                        }
                    }
                    else
                    {

                        //txtcambio.Text = "";
                        //txtefectivo.Text = "";
                        //txttotalg.Text = "";
                        txtcodigo.Focus();
                    }


                }


                else
                {

                    //txtcambio.Text = "";
                    //txtefectivo.Text = "";
                    //txttotalg.Text = "";
                    MessageBox.Show("Falta el Número de factura");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("err2 " + ex.ToString());

            }
            
            
          
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
                {

                    e.Handled = true;

                    System.Media.SystemSounds.Beep.Play();
                }
                if (e.KeyChar == 13)  // Si no es numerico y si no es espacio
                {
                    double a;
                    double b;
                    double c;
                    c = Convert.ToDouble(TXTDESC.Text) / 100;
                    a = Convert.ToDouble(txttotalg.Text) * Convert.ToDouble(c);
                    b = Convert.ToDouble(txttotalg.Text) - a;

                    string stTotal = string.Format("{0:#,#0.00}", b);

                    string resultado = string.Format("{0:#,#0.00}", b);
                    TXTTOTDESC.Text = Convert.ToString(resultado);





                }
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                reportes.borrartmpfactura();

                reportes.xnumfactura(Convert.ToString(this.txtnumfac.Text));

                facturapequ newMDIChildForm = new facturapequ();
                newMDIChildForm.MdiParent = this.MdiParent;

                newMDIChildForm.Show();
                this.Close();
            }
            catch
            { }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnumfac.Text != "")
                {



                    reportes.borrartmpfactura();

                    reportes.xnumfactura(Convert.ToString(this.txtnumfac.Text));

                    Imprimirfactura newMDIChildForm = new Imprimirfactura();
                    newMDIChildForm.MdiParent = this.MdiParent;

                    newMDIChildForm.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Ingrese el Número de factura");
                }


                    
                            }
            catch
            { }
        }
    }
}
