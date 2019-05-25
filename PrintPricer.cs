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
    public partial class PrintPricer : Form
    {
        public PrintPricer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
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
            int x = 50;
            int y = 50;
            for (int i = 1; i <= 22; i++)
            {
                x = 50;
                for (int j = 1; j <= 6; j++)
                {
                    //MessageBox.Show("" + dataGridView1[0, 0].Value+ dataGridView1[0, 1].Value+ dataGridView1[0, 2].Value);
                    Rectangle r1 = new Rectangle(x, y, 120, 25);
                    e.Graphics.DrawString(dataGridView1[1,0+g].Value.ToString(), font3, solidBrush, r1, stringFormatCenter);
                    e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(r1));

                    Rectangle r2 = new Rectangle(x, y + 25, 50, 25);
                    e.Graphics.DrawString(dataGridView1[0, 0+g].Value.ToString(), font1, solidBrush, r2, stringFormat3);
                    e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(r2));

                    Rectangle r3 = new Rectangle(x + 50, y + 25, 70, 25);
                    e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(r3));
                    SolidBrush blueBrush = new SolidBrush(Color.Yellow);
                    e.Graphics.FillRectangle(blueBrush, r3);
                    e.Graphics.DrawString(dataGridView1[2, 0+g].Value.ToString(), font2, solidBrush, r3, stringFormat3);

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

        }//fin while

        private void button1_Click(object sender, EventArgs e)
        {
            Clases.Clsfactura factura = new Clases.Clsfactura();
            
           String codigo= factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[0].ToString();
            String descripcion = factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[1].ToString();
            //String precio  = factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[3].ToString();
            //MessageBox.Show( String.Format("{0:f2}", factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[3]));
            if (this.dataGridView1.Rows.Count <= 132)
            {
                for (int i=0;i<=Convert.ToInt32(textBox2.Text)-1;i++)
            {
                
                    dataGridView1.Rows.Add(codigo, descripcion, String.Format("{0:f2}", factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[3]));
                    
            }
                limpiar();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Imprimir");
                button2.Focus();
                limpiar();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + dataGridView1[0, 1].Value);
            MessageBox.Show("" + dataGridView1[1, 1].Value);
            MessageBox.Show("" + dataGridView1[2, 1].Value);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                button1.Focus();
            }
        }


        private void limpiar()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";

        }
        private void car()
        {
            try
            {
                //CARGA AUTOMATICASMENTE para imprimir e
                Clases.Clsfactura factura = new Clases.Clsfactura();

            String codigo = factura.cargarProductosxcodbar(textBox3.Text).Tables[0].Rows[0].ItemArray[0].ToString();
            String descripcion = factura.cargarProductosxcodbar(textBox3.Text).Tables[0].Rows[0].ItemArray[1].ToString();

            //String precio  = factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[3].ToString();
            //MessageBox.Show( String.Format("{0:f2}", factura.cargarProductosxcod(textBox1.Text).Tables[0].Rows[0].ItemArray[3]));
            if (this.dataGridView1.Rows.Count <= 126)
            {
                for (int i = 0; i <= Convert.ToInt32(textBox4.Text) - 1; i++)
                {
                    dataGridView1.Rows.Add(codigo, descripcion, String.Format("{0:f2}", factura.cargarProductosxcod(codigo).Tables[0].Rows[0].ItemArray[3]));
                    textBox4.Focus();

                }
                limpiar();
                textBox4.Focus();
            }
            else
            {
                MessageBox.Show("Imprimir");
                button2.Focus();
                limpiar();
            }
            }
            catch { }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {

            car();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                button4.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            try
            {

                if (textBox3.Text != "")
                {
                    car();

                }
            }
            catch { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
