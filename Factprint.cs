using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Text;
using System.Windows.Forms;  


namespace RaposoFact
{
    public partial class Factprint : Form
    {
        public Factprint()
        {
            InitializeComponent();
        }

        private void Factprint_Load(object sender, EventArgs e)
        {

        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            /* e.Graphics.DrawString("m", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 10));
             e.Graphics.DrawString("2", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(30, 10));
             e.Graphics.DrawString("3", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(50, 10));
             e.Graphics.DrawString("4", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(70, 10));
             e.Graphics.DrawString("5", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(90, 10));
             e.Graphics.DrawString("6", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(110, 10));
             e.Graphics.DrawString("7", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(130, 10));
             e.Graphics.DrawString("8", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(150, 10));
             e.Graphics.DrawString("9", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(170, 10));
             e.Graphics.DrawString("0", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(190, 10));*/

            
            Clases.Clsreportes a = new Clases.Clsreportes();
            //a.xnumfactura("652").Tables[0].Rows[0].ItemArray[];


            e.Graphics.DrawString("RUC", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 10));
            e.Graphics.DrawString("CLIENTE", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 30));
            e.Graphics.DrawString("TELF", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 50));
            e.Graphics.DrawString("CIUDA", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 70));
            e.Graphics.DrawString("TOTAL", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 90));
            e.Graphics.DrawString("6", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 110));
            e.Graphics.DrawString("7", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 130));
            e.Graphics.DrawString("8", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 150));
            e.Graphics.DrawString("9", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 170));
            e.Graphics.DrawString("0", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 190));

            //  e.Graphics.DrawString("Clientess", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(100, 120));
            // e.Graphics.DrawString("RUC", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(100, 140));
        }

        private void button1_Click(object sender, EventArgs e)
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

    }
}
