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
    public partial class Form1no : Form
    {
        public Form1no()
        {
            InitializeComponent();
        }
        public IForm Opener { get; set; }
        Clases.ClsCaja a = new Clases.ClsCaja();
        private void Form1no_FormClosing(object sender, FormClosingEventArgs e)
        {
   
        }


      

        private void Form1no_Load(object sender, EventArgs e)
        {
      textBox1.Text = DateTime.Now.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = a.c.CARGARdeudas(txtidcliente.Text).Tables[0];
     
        }
    }
}
