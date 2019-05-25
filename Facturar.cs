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
    public partial class Facturar : Form, IForm
    {
        public Facturar()
        {
            InitializeComponent();
        }
        Clases.Clsfactura factura = new Clases.Clsfactura();
        Clases.Clsreportes reportes = new Clases.Clsreportes();
        Clases.Clscliente cliente = new Clases.Clscliente();
        #region IForm Members

        public bool LoadDataGridView(DataTable dataTableParam)
        {
           // MessageBox.Show(""+ dataTableParam.Rows[0].ItemArray[0].ToString());
            dgFac[0,nFilaSel].Value=dataTableParam.Rows[0].ItemArray[0];

                        dgFac.CurrentCell = dgFac.Rows[nFilaSel].Cells[0];
            return true;
        }



        public bool LoadDataCli(DataTable dataTableParam)
        {
            // MessageBox.Show(""+ dataTableParam.Rows[0].ItemArray[0].ToString());
            //textBox1.Text = dataTableParam.Rows[0].ItemArray[0].ToString();
            textBox2.Text = dataTableParam.Rows[0].ItemArray[1].ToString();
            //textBox3.Text = dataTableParam.Rows[0].ItemArray[2].ToString();
            //textBox4.Text = dataTableParam.Rows[0].ItemArray[3].ToString();

            return true;
        }

        #endregion

        /////*****VARIABLES PUBLICAS

        public int nFilaSel;

        ///****************************************************************************************ESCRIBIR GRILLA
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

                        break;
                    case 1:
                        dgFac.Rows[rowIndex - 1].Cells["total"].Value = Convert.ToDouble(dgFac.Rows[rowIndex - 1].Cells["vu"].Value) * Convert.ToDouble(dgFac.Rows[rowIndex - 1].Cells["cantidad"].Value);
                        dgFac.CurrentCell = dgFac.Rows[rowIndex - 1].Cells[3];
                        sumar();
                        //Console.WriteLine("Case 1");
                        break;
                    case 2:

                        //Console.WriteLine("Case 2");
                        break;

                    case 3:
                        dgFac.Rows[rowIndex - 1].Cells["total"].Value = Convert.ToDouble(dgFac.Rows[rowIndex - 1].Cells["vu"].Value) * Convert.ToDouble(dgFac.Rows[rowIndex - 1].Cells["cantidad"].Value);
                        dgFac.CurrentCell = dgFac.Rows[rowIndex].Cells[0];
                        sumar();
                        //Console.WriteLine("Case 2");
                        break;

                    default:
                        //Console.WriteLine("Default case");
                        break;
                }




            }
        }

        /////*****************************************************************************SUMAR grilla


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
                        subtotal = subtotal + (Convert.ToDouble(dgFac.Rows[i].Cells["total"].Value) );
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
                txttotalg.Text = ((subtotal * 1.12) + ivacero).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valores Vacios" + ex.ToString());
            }
        }

        private void dgFac_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
            dText.KeyUp -= new KeyEventHandler(text_KeyUp);
            dText.KeyUp += new KeyEventHandler(text_KeyUp);
        }

        private void dgFac_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgFac.BeginEdit(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void dgFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("++");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FormCliFac form2 = new FormCliFac();
            //form2.MdiParent = this.MdiParent;
            //form2.Opener = this;
            //form2.Show();
        }

        private void Facturar_Load(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
          
        }
        private void limpiariva()
        {
            txtsubtotal.Text = "0";
            //txtiva.Text = "0";
            txttotalg.Text = "0";
        }
        private void dgFac_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                try
                {
                    BuscarClienteFac g = new BuscarClienteFac();
                    //Texto = this.txtbuscar.Text;

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
                        //txtcodigo.Focus();





                    }
                }
                catch
                {
                }


            }
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
                //this.txtcodigo.Focus();
            }

            catch { }

        }
        private void actualizarstock()
        {
        }
        private void button6_Click(object sender, EventArgs e)
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
                        //cargarventalOAD();
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                reportes.borrartmpfactura();

                reportes.xnumfactura(Convert.ToString(this.txtnumfac.Text));

                Imprimirfactura newMDIChildForm = new Imprimirfactura();
                newMDIChildForm.MdiParent = this.MdiParent;

                newMDIChildForm.Show();
                this.Close();
            }
            catch
            { }
        }

        private void button2_Click_1(object sender, EventArgs e)
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
                        //cargarventalOAD();
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

        private void button1_Click_1(object sender, EventArgs e)
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

   

    }
}
