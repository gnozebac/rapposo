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
    public partial class AperturaCaja : Form
    {
        public AperturaCaja()
        {
            InitializeComponent();
        }
        double res;
        Clases.ClsCaja caja = new Clases.ClsCaja();
        private void totalmonedas()
        {
            try
            {
                decimal totalm;
                decimal unctv;
                decimal cincoctv;
                decimal diezctv;
                decimal vctv;
                decimal ctactv;
                decimal undolar;
                //unctv = Convert.ToDecimal(0.01);
                unctv = (Convert.ToDecimal(txtm01.Text) * Convert.ToDecimal(0.01));
                cincoctv = (Convert.ToDecimal(txtm05.Text) * Convert.ToDecimal(0.05));
                diezctv = (Convert.ToDecimal(txtm10.Text) * Convert.ToDecimal(0.10));
                vctv = (Convert.ToDecimal(txtm25.Text) * Convert.ToDecimal(0.25));
                ctactv = (Convert.ToDecimal(txtm50.Text) * Convert.ToDecimal(0.50));
                undolar = (Convert.ToDecimal(txtm1.Text) * Convert.ToDecimal(1.0));

                totalm = unctv + cincoctv + diezctv + vctv + ctactv + undolar;
                txttotalm.Text = Convert.ToString(totalm);
            }
            catch
            { }
        }
        private void totalbilletes()
        {
            try
            {
                decimal totalb;
                decimal undolar;
                decimal cdolar;
                decimal ddolar;
                decimal vdolar;

                //unctv = Convert.ToDecimal(0.01);
                undolar = (Convert.ToDecimal(txtb1.Text) * Convert.ToDecimal(1));
                cdolar = (Convert.ToDecimal(txtb5.Text) * Convert.ToDecimal(5));
                ddolar = (Convert.ToDecimal(txtb10.Text) * Convert.ToDecimal(10));
                vdolar = (Convert.ToDecimal(txtb20.Text) * Convert.ToDecimal(20));

                totalb = undolar + cdolar + ddolar + vdolar;
                txttotalb.Text = Convert.ToString(totalb);
            }
            catch { }
        }
        private void btncalc_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet datos;
                datos = caja.cargarVerificarCajainicial(Convert.ToDateTime(label13.Text));
                int a = 0;
                a = Convert.ToInt16(datos.Tables[0].Rows[0].ItemArray[0].ToString());
                if (a == 0)
                {
                    totalmonedas();
                    totalbilletes();
                    decimal tm;
                    decimal tb;
                    decimal tg;
                    tm = Convert.ToDecimal(txttotalm.Text);
                    tb = Convert.ToDecimal(txttotalb.Text);
                    tg = tm + tb;
                    txttotalg.Text = Convert.ToString(tg);

                    caja.guardarCajaInicial(label16.Text, Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), "Saldo Inicial",Convert.ToDecimal(0));

                    Clases.ClsCaja a1 = new Clases.ClsCaja();
                    a1.trx_guay(Convert.ToDateTime(DateTime.Now.ToString()), "APERTURA CAJA",Convert.ToDouble(txttotalg.Text), 1);
                   

                    limpiar();
                }
                else
                {
                    MessageBox.Show("El Ingreso Está efectuado");
                
                }
            }
            catch { }

        }
        private void limpiar()
        {
            txtb1.Text = "0";
            txtb10.Text = "0";
            txtb20.Text = "0";
            txtb5.Text = "0";
            txtm01.Text = "0";
            txtm05.Text = "0";
            txtm1.Text = "0";
            txtm10.Text = "0";
            txtm25.Text = "0";
            txtm50.Text = "0";
            txttotalb.Text = "0";
            txttotalm.Text = "0";
            
        }
    private void cargarsaldoinicial()

        {
            try
            {
        label13.Text = DateTime.Now.ToString();
              
                DataSet datos;
                datos = caja.cargarCajaInicial(Convert.ToDateTime(label13.Text));
                txttotalg.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
           }
        catch
        { }
        }
    private void cargarsaldoinicialretiro()
    {try
            {
        string fecha;
        fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
        DataSet datos;
        datos = caja.cargarCajaInicial(Convert.ToDateTime(fecha));
        txtapertura.Text= datos.Tables[0].Rows[0].ItemArray[0].ToString();
            }
    catch
    { }
    }

    private void cargarcajacierre()
    {
        try
            {
        string fecha;
        fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
        DataSet datos;
        datos = caja.cargarCajaInicial(Convert.ToDateTime(fecha));
        txtapertura.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        catch
        { }
    }
        private void AperturaCaja_Load(object sender, EventArgs e)
        {
            try
            {
                cargarsaldoinicial();
                txtretiro.Text = "0";

                      DataSet datos;
                datos = caja.cargarVerificarCajafinal(Convert.ToDateTime(label13.Text));
                int a = 0;
                a = Convert.ToInt16(datos.Tables[0].Rows[0].ItemArray[0].ToString());
                if (a != 0)
                {
                    cargararq();
                }
            }
            catch
            { }
        }
        private void cajitas()

            {
             
             try
            {
            
            //para ver el total de ventas 
             label6.Text = System.DateTime.Now.ToString();
             label6.Visible = false;
                //DataSet datos;
                //datos = caja.cargarTotalConsumo(Convert.ToDateTime(label6.Text));
                //txtconsumo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                //caja.guardarvtotal(Convert.ToDateTime(label6.Text), Convert.ToDecimal(txtconsumo.Text));


                caja.cargarTotalCaja(Convert.ToDateTime(label6.Text));
                DataSet datos1;

                datos1 = caja.cargarTotalCaja(Convert.ToDateTime(label6.Text));

                this.txttotalventas.Text = datos1.Tables[0].Rows[0].ItemArray[4].ToString();

            }
             catch { }
            }
        private void faltantesobrante()
        {
            try

{
    Decimal faltante;
    Decimal sobrante = 0;
    faltante = Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(txtarqueo.Text);
    sobrante = Convert.ToDecimal(txtarqueo.Text) - Convert.ToDecimal(textBox1.Text);

    if (faltante >= 0)
    {
        if (sobrante <= 0)
        {
            txtfaltante.Text = Convert.ToString(faltante);

            txtsobrante.Text = "0";
        }
        else
        {
            txtfaltante.Text = Convert.ToString(faltante);
            txtsobrante.Text = Convert.ToString(sobrante);


        }
    }


    else
    {
        txtfaltante.Text = "0";
        txtsobrante.Text = Convert.ToString(sobrante);


    }

                }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
     

            try
            {
                DataSet datos;
                datos = caja.cargarVerificarCajafinal(Convert.ToDateTime(label13.Text));
                int a = 0;
                a = Convert.ToInt16(datos.Tables[0].Rows[0].ItemArray[0].ToString());
                if (a == 0)
                {
                    totalmonedas();
                    totalbilletes();
                    decimal tm;
                    decimal tb;
                    decimal tg;
                    tm = Convert.ToDecimal(txttotalm.Text);
                    tb = Convert.ToDecimal(txttotalb.Text);
                    tg = tm + tb;
                   this.txtgcierre.Text = Convert.ToString(tg);
                  
              
                   caja.guardarCajafinal(label16.Text, Convert.ToDateTime(label13.Text), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), "Saldo Final",Convert.ToDecimal(txtgcierre.Text));
                    cajitas();
                    faltantesobrante();

                     if

                           (MessageBox.Show("Retirar el dinero de caja?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                        DataSet dat;
                        dat = caja.verificararqueo(Convert.ToDateTime(label13.Text));
                        int ab = 0;
                        a = Convert.ToInt16(dat.Tables[0].Rows[0].ItemArray[0].ToString());
                        if (ab == 0)
                        {
                            audx();
                            caja.guardararqueo("00000", Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                            cargararq();
                            Clases.ClsCaja a1 = new Clases.ClsCaja();
                            a1.trx_guay(Convert.ToDateTime(DateTime.Now.ToString()), "TOTAL VENTAS", Convert.ToDouble(txttotalventas.Text), 1);


                        }
                        else
                        {
                            audx();
                           // caja.guardarCajafinal(label16.Text, Convert.ToDateTime(label13.Text), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), "Saldo Final", Convert.ToDecimal(txtgcierre.Text));
                            caja.actualizararqueo(Convert.ToString(txtcodigo.Text),Convert.ToString("00000"), Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(this.txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                            cargararq();
                        }
                        txtretiro.Focus();

                }
else
                {

                    DataSet dat;
                    dat = caja.verificararqueo(Convert.ToDateTime(label13.Text));
                    int ab = 0;
                    a = Convert.ToInt16(dat.Tables[0].Rows[0].ItemArray[0].ToString());
                    if (ab == 0)
                    {
                        audx();
                        caja.guardararqueo("00000", Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                        cargararq();
                    }
                    else
                    {
                        audx();
                        caja.actualizararqueo(Convert.ToString(txtcodigo.Text), Convert.ToString("00000"), Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(this.txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                        cargararq();
                    }
                }
                }
                else
                {
                    totalmonedas();
                    totalbilletes();
                    decimal tm;
                    decimal tb;
                    decimal tg;
                    tm = Convert.ToDecimal(txttotalm.Text);
                    tb = Convert.ToDecimal(txttotalb.Text);
                    tg = tm + tb;
                    this.txtgcierre.Text = Convert.ToString(tg);
                    txtarqueo.Text = Convert.ToString(tg);
                    caja.updatecierrecaja(Convert.ToDateTime(label13.Text),Convert.ToDecimal(this.txtgcierre.Text), "Saldo Final");
                    //limpiar();
                    cajitas();
                    //faltantesobrante();
                    if

              (MessageBox.Show("Retirar el dinero de caja?", "Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DataSet dat;
                        dat = caja.verificararqueo(Convert.ToDateTime(label13.Text));
                        int ab = 0;
                        a = Convert.ToInt16(dat.Tables[0].Rows[0].ItemArray[0].ToString());
                        if (ab == 0)
                        {
                            audx();
                            caja.guardararqueo("00000", Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                            cargararq();
                        }
                        else
                        {
                            audx();
                            caja.actualizararqueo(Convert.ToString(txtcodigo.Text), Convert.ToString("00000"), Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(this.txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                            cargararq();
                        }
                        button3.Focus();

                    }
                    else
                    {

                        DataSet dat;
                        dat = caja.verificararqueo(Convert.ToDateTime(label13.Text));
                        int ab = 0;
                        a = Convert.ToInt16(dat.Tables[0].Rows[0].ItemArray[0].ToString());
                        if (ab == 0)
                        {
                            audx();
                            caja.guardararqueo("00000", Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                            cargararq();
                        }
                        else
                        {
                            audx();
                            caja.actualizararqueo(Convert.ToString(txtcodigo.Text), Convert.ToString("00000"), Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(this.txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                            cargararq();
                        }
                    }
                }
            }
            catch {
            
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
          try
 {
            string fecha;
            fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            caja.borrarimprimirarqueo();
            caja.imprimirarqueo(Convert.ToDateTime(fecha));
            //FrmRepVentasDetalle newMDIChildForm = new FrmRepVentasDetalle();
              FrmCrystalReport2 newMDIChildForm = new FrmCrystalReport2();
              
            newMDIChildForm.MdiParent = this.MdiParent;

            newMDIChildForm.Show();
            this.Close();
 }
          catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caja.imprimirventa(Convert.ToDateTime(label13.Text));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void audx()
             {
              
            double saldo;


                        cargarsaldoinicialretiro();
                        depositosretiros();
                        sumaingresos();
                        cargartotalrecargas();
                        faltantesobrante();
                        txtarqueo.Text = Convert.ToString(txtgcierre.Text);
                        if (txtretiro.Text != "")
                        {
                            saldo = Convert.ToDouble(txtarqueo.Text) - Convert.ToDouble(txtretiro.Text);
                            txtsaldoencaja.Text = Convert.ToString(saldo);
                        }
                        else
                        {

                            saldo = Convert.ToDouble(txtarqueo.Text) - Convert.ToDouble(txtretiro.Text);
                            txtsaldoencaja.Text = Convert.ToString(saldo);

                        }
             }
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
 {
          
                            DataSet datos;
                datos = caja.verificararqueo(Convert.ToDateTime(label13.Text));
                int a = 0;
                a = Convert.ToInt16(datos.Tables[0].Rows[0].ItemArray[0].ToString());
                if (a == 0)
                {
                          audx();
                        caja.guardararqueo("00000", Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                        cargararq();


                }
                else
                {
                    audx();
                    caja.actualizararqueo(Convert.ToString(txtcodigo.Text), Convert.ToString("00000"), Convert.ToDateTime(label13.Text), Convert.ToDecimal(txttotalg.Text), Convert.ToDecimal(txtarqueo.Text), Convert.ToDecimal(txttotalventas.Text), Convert.ToDecimal(txtfaltante.Text), Convert.ToDecimal(txtsobrante.Text), Convert.ToDecimal(txtretiro.Text), Convert.ToDecimal(txtsaldoencaja.Text), Convert.ToDecimal(txtdepositos.Text), Convert.ToDecimal(this.txtretiroscaja.Text), Convert.ToDecimal(txttotalingresoss.Text), Convert.ToDecimal(textBox1.Text));
                    cargararq();
                }

 }
            catch
            { }
        
        }
        private void cargararq()
{
    DataSet datos;
string fecha;
            fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
    datos = caja.cargararqueo(Convert.ToDateTime(fecha));
    txtapertura.Text = datos.Tables[0].Rows[0].ItemArray[3].ToString();
    txtcodigo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
            txtarqueo.Text = datos.Tables[0].Rows[0].ItemArray[4].ToString();
    txtgcierre.Text = datos.Tables[0].Rows[0].ItemArray[4].ToString();
            txttotalventas.Text = datos.Tables[0].Rows[0].ItemArray[5].ToString();
            txtfaltante.Text = datos.Tables[0].Rows[0].ItemArray[6].ToString();
            txtsobrante.Text = datos.Tables[0].Rows[0].ItemArray[7].ToString();
            txtretiro.Text = datos.Tables[0].Rows[0].ItemArray[8].ToString();
            this.txtsaldoencaja.Text = datos.Tables[0].Rows[0].ItemArray[9].ToString();
            txtdepositos.Text = datos.Tables[0].Rows[0].ItemArray[10].ToString();
            txtretiroscaja.Text = datos.Tables[0].Rows[0].ItemArray[11].ToString();
            txttotalingresoss.Text = datos.Tables[0].Rows[0].ItemArray[12].ToString();
            txttotalingresos.Text = datos.Tables[0].Rows[0].ItemArray[12].ToString();
            textBox1.Text = datos.Tables[0].Rows[0].ItemArray[13].ToString();
}
        private void sumaingresos()

            {

                Decimal auxsuma,t;
                Decimal aux;
                Decimal auxtotal;
           
                auxsuma = Convert.ToDecimal(0) + Convert.ToDecimal(this.txttotalventas.Text);
                aux = auxsuma + Convert.ToDecimal(txtdepositos.Text);

                auxtotal = aux - Convert.ToDecimal(txtretiroscaja.Text);
          
                txttotalingresoss.Text = Convert.ToString(auxtotal);

                txttotalingresos.Text = txttotalingresoss.Text;
                txtarqueo.Text= txtgcierre.Text;
            

                t = Convert.ToDecimal(txttotalingresos.Text) + Convert.ToDecimal(txtapertura.Text);
                textBox1.Text = Convert.ToString(t);

      
            }
        private void button4_Click(object sender, EventArgs e)
        {
            cargararq();
            cargarsaldoinicialretiro();
            depositosretiros();
            sumaingresos();
            cargartotalrecargas();
        }
        private void cargartotalrecargas()
        {
            string fecha;
            fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");

            DataSet datos1;

            datos1 = caja.cargarTotalRecargas(Convert.ToDateTime(fecha));
            this.txtrecargas.Text = datos1.Tables[0].Rows[0].ItemArray[1].ToString();
            txtpines.Text = datos1.Tables[0].Rows[0].ItemArray[2].ToString();
         


        }
        private void cargardepositosPich()
        {
            try
            {
                label6.Text = System.DateTime.Now.ToString();

                DataSet datos1;

                datos1 = caja.DepVecino(Convert.ToDateTime(label6.Text));
                this.txtdepp.Text = datos1.Tables[0].Rows[0].ItemArray[0].ToString();
                DataSet datos2;
                datos2 = caja.Depguay(Convert.ToDateTime(label6.Text));
                txtretguay.Text = datos2.Tables[0].Rows[0].ItemArray[0].ToString();

                DataSet datos3;

                datos3 = caja.RetVecino(Convert.ToDateTime(label6.Text));
                this.txtretp.Text = datos3.Tables[0].Rows[0].ItemArray[0].ToString();
                DataSet datos4;
                datos4 = caja.Retguay(Convert.ToDateTime(label6.Text));
                this.txtdepguay.Text = datos4.Tables[0].Rows[0].ItemArray[0].ToString();

              


            }
            catch
            { }
        }
        private void depositosretiros()
        {

            try
            {
                label6.Text = System.DateTime.Now.ToString();

                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");




                DataSet datos;
                datos = caja.cargarTotalConsumo(Convert.ToDateTime(fecha));
                this.txttotalventas.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                caja.guardarvtotal(Convert.ToDateTime(fecha), Convert.ToDecimal(txttotalventas.Text));

                cargardepositosPich();
                caja.cargarTotalCaja(Convert.ToDateTime(fecha));
                DataSet datos1;

                datos1 = caja.cargarTotalCaja(Convert.ToDateTime(fecha));
                //txtcajainicial.Text = datos1.Tables[0].Rows[0].ItemArray[0].ToString();
                //txtconsumo.Text = datos1.Tables[0].Rows[0].ItemArray[1].ToString();

                auxdep.Text = datos1.Tables[0].Rows[0].ItemArray[2].ToString();
                Double d, r;

                if (txtdepguay.Text != ("") & txtretguay.Text != ("") & txtdepp.Text != ("") & txtretp.Text != (""))
                    {

                    d = (Convert.ToDouble(auxdep.Text) + Convert.ToDouble(this.txtdepp.Text) + Convert.ToDouble(txtretguay.Text));
                    txtdepositos.Text = Convert.ToString(d);

                    auxret.Text = datos1.Tables[0].Rows[0].ItemArray[3].ToString();

                    r = (Convert.ToDouble(auxret.Text) + Convert.ToDouble(this.txtretp.Text) + Convert.ToDouble(txtdepguay.Text));

                                        txtretiroscaja.Text = Convert.ToString(r);
                }
       
                else
                {



                    

                    MessageBox.Show("Revisar las transacciones pichincha y guayaquil y registrar en 0 de ser necesario ");

                }





                //this.txtretiroscaja.Text = datos1.Tables[0].Rows[0].ItemArray[3].ToString();
                //txtsaldocaja.Text = datos1.Tables[0].Rows[0].ItemArray[4].ToString();

                //cargartotalrecargas();
                //cargartotalrecargasIMPORTE();
            }
            catch
            {
                //DataSet datos1;
                //datos1 = caja.cargarTotalCaja(Convert.ToDateTime(label6.Text));
                //txtcajainicial.Text = datos1.Tables[0].Rows[0].ItemArray[0].ToString();
                //txtconsumo.Text = "0";
                //txtdepositos.Text = "0";
                //txtretiros.Text = "0";
                //txtsaldocaja.Text = "0";
                //txtbwise.Text = "0";
                //txtpclaro.Text = "0";
                //txtxy.Text = "0";
                //textBox3.Text = "0";
                //textBox2.Text = "0";
                //textBox1.Text = "0";


            }
           }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha;
                fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                caja.borrarimprimirarqueo();
                caja.imprimirarqueo(Convert.ToDateTime(fecha));
                FrmCrystalReport2 newMDIChildForm = new FrmCrystalReport2();
                newMDIChildForm.MdiParent = this.MdiParent;

                newMDIChildForm.Show();
                this.Close();
            }
            catch { }
        }

        private void txtm01_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtm10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtm50_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtm05_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtm25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtm1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtb10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtb5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtb20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtretiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44) // Si no es numerico y si no es espacio
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtb20_Leave(object sender, EventArgs e)
        {
            totalmonedas();
            totalbilletes();
            decimal tm;
            decimal tb;
            decimal tg;
            tm = Convert.ToDecimal(txttotalm.Text);
            tb = Convert.ToDecimal(txttotalb.Text);
            tg = tm + tb;
            this.txtgcierre.Text = Convert.ToString(tg);
            button1.Focus();
        }
    }
}
