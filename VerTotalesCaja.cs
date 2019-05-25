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
    public partial class VerTotalesCaja : Form
    {
        Clases.ClsCaja caja = new Clases.ClsCaja();
        public VerTotalesCaja()
        {
            InitializeComponent();
        }
        private void cargartotalrecargas()
  {
         
    

  }
        private void cargartotalrecargasIMPORTE()
        {
              try
            {
                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
       

            DataSet datos1;

            datos1 = caja.cargarTotalRecargasIMPORTEs(Convert.ToDateTime(fecha));
            this.textBox3.Text = datos1.Tables[0].Rows[0].ItemArray[0].ToString();
            textBox2.Text = datos1.Tables[0].Rows[0].ItemArray[1].ToString();
            textBox1.Text = datos1.Tables[0].Rows[0].ItemArray[2].ToString();

            }
             catch
              { }
        }


        private void cargardepositosPich()
        {
            try
            {
                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                DataSet datos1;

                datos1 = caja.DepVecino(Convert.ToDateTime(fecha));
                this.txtdepp.Text = datos1.Tables[0].Rows[0].ItemArray[0].ToString();
                DataSet datos2;
                datos2 = caja.Depguay(Convert.ToDateTime(fecha));
                txtretguay.Text = datos2.Tables[0].Rows[0].ItemArray[0].ToString();

                DataSet datos3;

                datos3 = caja.RetVecino(Convert.ToDateTime(fecha));
                this.txtretp.Text = datos3.Tables[0].Rows[0].ItemArray[0].ToString();
                DataSet datos4;
                datos4 = caja.Retguay(Convert.ToDateTime(fecha));
                this.txtdepguay.Text = datos4.Tables[0].Rows[0].ItemArray[0].ToString();
                


            }
            catch
            { }
        }
        private void llamar()

        {

            try
            {
                //label6.Text = System.DateTime.Now.ToString();

                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");

                DataSet datos;
                datos = caja.cargarTotalConsumo(Convert.ToDateTime(fecha));
                txtconsumo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                caja.guardarvtotal(Convert.ToDateTime(fecha), Convert.ToDecimal(txtconsumo.Text));
                cargardepositosPich();

                caja.cargarTotalCaja(Convert.ToDateTime(fecha));
                DataSet datos1;

                datos1 = caja.cargarTotalCaja(Convert.ToDateTime(fecha));
                txtcajainicial.Text = datos1.Tables[0].Rows[0].ItemArray[0].ToString();
                txtconsumo.Text = datos1.Tables[0].Rows[0].ItemArray[1].ToString();
                auxdep.Text = datos1.Tables[0].Rows[0].ItemArray[2].ToString();

                Double d, r, s;


                d = (Convert.ToDouble(auxdep.Text) + Convert.ToDouble(this.txtdepp.Text) + Convert.ToDouble(txtretguay.Text));
                txtdepositos.Text = Convert.ToString(d);

                auxret.Text = datos1.Tables[0].Rows[0].ItemArray[3].ToString();

                r = (Convert.ToDouble(auxret.Text) + Convert.ToDouble(this.txtretp.Text) + Convert.ToDouble(txtdepguay.Text));
                txtretiros.Text = Convert.ToString(r);
                String saldocaja = datos1.Tables[0].Rows[0].ItemArray[4].ToString();


                s = Convert.ToDouble(txtcajainicial.Text) + Convert.ToDouble(txtconsumo.Text) + Convert.ToDouble(txtdepositos.Text) - Convert.ToDouble(txtretiros.Text);
                txtsaldocaja.Text = Convert.ToString(s);
                cargartotalrecargas();
                cargartotalrecargasIMPORTE();
            }
            catch
            {
                DataSet datos1;
                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                datos1 = caja.cargarTotalCaja(Convert.ToDateTime(fecha));
                txtcajainicial.Text = datos1.Tables[0].Rows[0].ItemArray[0].ToString();
                txtconsumo.Text = "0";
                txtdepositos.Text = "0";
                txtretiros.Text = "0";
                txtsaldocaja.Text = "0";
                txtbwise.Text = "0";
                txtpclaro.Text = "0";
                txtxy.Text = "0";
                textBox3.Text = "0";
                textBox2.Text = "0";
                textBox1.Text = "0";


            }
        
    }
        private void VerTotalesCaja_Load(object sender, EventArgs e)
        {
            //string fecha;
            //fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            llamar();
            //txttotalg.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
        }

    private void button1_Click(object sender, EventArgs e)
    {

            string fecha;
            fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            llamar();
    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
