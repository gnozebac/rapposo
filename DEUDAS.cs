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
    public partial class DEUDAS : Form
    {
        Clases.ClsCaja caja = new Clases.ClsCaja();
        public DEUDAS()
        {
            InitializeComponent();
        }
        Clases.deudas deuda = new Clases.deudas();
        Clases.Clsfactura factura = new Clases.Clsfactura();
      private void sacarvalordeuda()
 {
          try{
          DataSet datos;
            datos = deuda.sacardeuda(txtidcliente.Text);
          this.txtdebe.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
          this.txtpaga.Text = datos.Tables[0].Rows[0].ItemArray[1].ToString();
          if ( txtpaga.Text!= "")
               {
          decimal a;
            a  = Convert.ToDecimal(txtdebe.Text) - Convert.ToDecimal(txtpaga.Text);
            textBox1.Text = Convert.ToString(a);
               }
          else
          {

              decimal a;
              txtpaga.Text = "0";
              a = Convert.ToDecimal(txtdebe.Text) - Convert.ToDecimal(txtpaga.Text);
              textBox1.Text = Convert.ToString(a);
          }
          }
          catch

          { }

 }
        private void DEUDAS_Load(object sender, EventArgs e)
        {

            //Clases.deudas c = new Clases.deudas();
            //c.autocompletar(txtcliente);
            
            dataGridView1.Visible = false;
            linkLabel1.Visible = false;
            label3.Text = DateTime.Now.ToString();
            dataGridView1.DataSource = deuda.CARGARdeudas(txtcliente.Text).Tables[0];
            dataGridView2.DataSource = factura.cargarclientesxnombre(txtcliente.Text).Tables[0];
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try { 

            if (txtidcliente.Text != "")
            {
                if (comboBox1.SelectedItem == "DEBE")
                {
                    deuda.guardardeduda(Convert.ToDateTime(label3.Text), txtidcliente.Text, Convert.ToDecimal(txtvalor.Text), txtdetalle.Text, Convert.ToString(comboBox1.SelectedItem));
                    dataGridView1.DataSource = deuda.CARGARdeudas(txtidcliente.Text).Tables[0];
                    sacarvalordeuda();
                    MessageBox.Show("Guardado");

                    limpiar();
                }
                if (comboBox1.SelectedItem == "PAGA")
                {
                    deuda.guardardeduda(Convert.ToDateTime(label3.Text), txtidcliente.Text, Convert.ToDecimal(txtvalor.Text), txtdetalle.Text, Convert.ToString(comboBox1.SelectedItem));
                    dataGridView1.DataSource = deuda.CARGARdeudas(txtidcliente.Text).Tables[0];
                    sacarvalordeuda();
                        ingresardineroacaja();
                    MessageBox.Show("Guardado");

                    limpiar();
                }
            }
            else
            {
                MessageBox.Show("Cliente no existe");
            }
        }
       catch { }
        }
        private void ingresardineroacaja()
        {

            //cuando pagan las deudas va directo al ingreso de caja
            try
            {
                DataSet datos;
                datos = caja.cargarVerificarCajainicial(Convert.ToDateTime(label3.Text));
                int a = 0;
                a = Convert.ToInt16(datos.Tables[0].Rows[0].ItemArray[0].ToString());

                caja.guardardepositos("00001", Convert.ToDateTime(label3.Text), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDouble(this.txtvalor.Text), Convert.ToDecimal(0), comboBox1.Text, Convert.ToDecimal(0));

                txtvalor.Text = "";

                this.Close();

            }
            catch { }



        }
        private void limpiar()
        {
            txtdetalle.Text = "";
            txtdetalle.Text = "";
            txtvalor.Text = "";
            
        }
        private void cargarTextosxcod()
        {
            try
            {
                //DataSet datos;

                //datos = deuda.CARGARCLIENTERUC(this.txtruc.Text);

                ////txtruc.Text = datos.Tables[0].Rows[0].ItemArray[1].ToString();
                //this.txtcliente.Text = datos.Tables[0].Rows[0].ItemArray[2].ToString();
                //this.txtidcliente.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                //txtvalor.Focus();
            }

            catch { }
        }
        private void txtruc_TextChanged(object sender, EventArgs e)
        {
            cargarTextosxcod();
        }

        private void txtcliente_TextChanged(object sender, EventArgs e)
        {
         
    dataGridView2.Visible = true;
    dataGridView2.DataSource = deuda.CARGARCLIENTENOMBRE(txtcliente.Text).Tables[0];
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == 13) // Si no es numerico y si no es espacio
                {
                    dataGridView1.Focus();
                }
        }

        private void txtvalor_KeyPress(object sender, KeyPressEventArgs e)
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
            catch
 {}
    }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            linkLabel1.Visible = true;
            dataGridView1.Visible = true;
            dataGridView1.DataSource = deuda.CARGARdeudas(txtidcliente.Text).Tables[0];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataGridView1.Visible = false;
            linkLabel1.Visible = false;
            dataGridView2.Visible = true;
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            txtidcliente.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
            txtcliente.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
            txtvalor.Focus();
            sacarvalordeuda();
            dataGridView2.Visible = false;
        }

        private void txtcliente_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void txtcliente_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtcliente_Click(object sender, EventArgs e)
        {
          
        }

        private void txtcliente_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show(this.txtcliente.Text);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtvalor_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            deuda.tmpcobrosdelete();
            deuda.tmpcobrosdebe();
            deuda.tmpcobrospaga();
       

            crtcobrosa newMDIChildForm = new crtcobrosa();
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
        }

     
    }
}
