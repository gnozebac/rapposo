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
    public partial class ResumenRecargas : Form
    {
        public ResumenRecargas()
        {
            InitializeComponent();
        }
        Clases.ClsRecargas recargas = new Clases.ClsRecargas();
        private void suma()
            {
               try
                     {
                    Int32 i;
                //string valor;
                Decimal ventab=0;
                Decimal cantidad=0;
                //Decimal venta=0;
                Decimal a=0;
                DataGridViewCell cantidadD;
                //DataGridViewCell ventas;
                DataGridViewCell ventabwise;
                for (i = 0; i < dataGridView6.Rows.Count; i++)
                {
                    cantidadD = (dataGridView6.Rows[i].Cells[1]);
                       cantidad = (Convert.ToDecimal(cantidadD.Value));
                       ventabwise = (dataGridView6.Rows[i].Cells[0]);
           
                    ventab = (Convert.ToDecimal(ventabwise.Value));
     
                    a = cantidad - ventab;

                    txtbwise.Text = Convert.ToString(a);
                 
               

                }
                for (i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    cantidadD = (dataGridView5.Rows[i].Cells[1]);
                    cantidad = (Convert.ToDecimal(cantidadD.Value));
                    ventabwise = (dataGridView5.Rows[i].Cells[0]);
                    ventab = (Convert.ToDecimal(ventabwise.Value));
                    a = cantidad - ventab;
                    this.txtxy.Text = Convert.ToString(a);



                }
                for (i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    cantidadD = (dataGridView4.Rows[i].Cells[1]);
                    cantidad = (Convert.ToDecimal(cantidadD.Value));
                    ventabwise = (dataGridView4.Rows[i].Cells[0]);
                    ventab = (Convert.ToDecimal(ventabwise.Value));
                    a = cantidad - ventab;
                    this.txtpin.Text = Convert.ToString(a);



                }
             
 }
            catch
               {  
               
               }
               
            }
        private void ResumenRecargas_Load(object sender, EventArgs e)
        {
         try
             {
              DataSet datos, datos1 ;
              datos = recargas.cargarBwise();

              datos1 = recargas.cargarXY();
            txtsib.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
            txtsixy.Text = datos1.Tables[0].Rows[0].ItemArray[0].ToString();
            dataGridView1.DataSource = recargas.cargarBwise().Tables[0];
            dataGridView2.DataSource = recargas.cargarXY().Tables[0];
            dataGridView3.DataSource = recargas.cargarPines().Tables[0];
            dataGridView5.DataSource = recargas.HechasXy().Tables[0];
            dataGridView6.DataSource = recargas.Hechasbwise().Tables[0];
            dataGridView4.DataSource = recargas.Hechaspines().Tables[0];
            //txtsipc.Text = datos.Tables[0].Rows[0].ItemArray[2].ToString();
            suma();
        }
        
        catch
         {
             }
         }

        private void button1_Click(object sender, EventArgs e)
        {
            suma();
        }
         
     }
    }

