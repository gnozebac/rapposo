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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        Clases.Clsfactura factura = new Clases.Clsfactura();
        public static string Texto;
        public static string textid;
        public static string txtpvps;
        private int ik; //pasar keydown currentrow
        public static string textstock;
        public string Nombre { get; set; }
        public string id { get; set; }
        public string Pvp { get; set; }
        public string Stock { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            cerrar();

        }
        private Form FormPadre;


        public Form _FormPadre
        {
            get { return FormPadre; }
            set { FormPadre = value; }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                dataGridView1.Focus();
                dataGridView1.DataSource = factura.cargarProductos(textBox1.Text).Tables[0];

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           Nombre = textBox1.Text;
            dataGridView1.DataSource = factura.cargarProductos(textBox1.Text).Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = NotadeVenta.Texto;
        dataGridView1.DataSource = factura.cargarProductos(textBox1.Text).Tables[0];
        dataGridView1.Columns[0].Name = "Recipe";
        }

       

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //cargarid();

          
        }



        private void txtid_TextChanged(object sender, EventArgs e)
        {
            id = textBox2.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            id = textBox2.Text;
        }
        private void cerrar()
        {
            DialogResult = DialogResult.OK;

           this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            cargarid(dataGridView1.CurrentRow.Index);
            cerrar();
        }

       

      
        private void cargarid(int i)
        {
            
            /*textBox1.Text= */Nombre = dataGridView1.Rows[i].Cells[1].Value.ToString();
            /*textBox2.Text= */id  = dataGridView1.Rows[i].Cells[0].Value.ToString();
            /*txtpvp.Text=*/Pvp  = dataGridView1.Rows[i].Cells[3].Value.ToString();
            /*txtstock.Text=*/Stock=dataGridView1.Rows[i].Cells[4].Value.ToString();
            
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            

           if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
               // MessageBox.Show(dataGridView1 .CurrentCell.ToString());

                    cargarid(ik);
                    cerrar();
             

            }
        }

        private void txtpvp_TextChanged(object sender, EventArgs e)
        {
            Pvp = txtpvp.Text;
        }

        private void txtstock_TextChanged(object sender, EventArgs e)
        {
            Stock = txtstock.Text;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
            
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           ik = dataGridView1.CurrentRow.Index;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     
    }
}
