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
    public partial class Familia : Form
    {
        Clases.Familia familia = new Clases.Familia();
        public Familia()
        {
            InitializeComponent();
        }

        private void Familia_Load(object sender, EventArgs e)
        {

        }
        private void cargarPadre()
        {
            Clases.ClsProductos nuevo = new Clases.ClsProductos();
            DataSet da = new DataSet();
            da = nuevo.usuario();
            comboBox1.DataSource = da.Tables[0];
            comboBox1.DisplayMember = "familia";
            comboBox1.ValueMember = "idfamilia";


        }
        private void guardar()
        {
            try
            {
                switch (radioButton1.Checked)
                {
                    case true:
                        //...   
                        familia.guardar("", txtdesc.Text, "", false, true);
                        break;
                    case false:
                        familia.guardar(Convert.ToString(comboBox1.SelectedValue), (comboBox1.Text), txtdesc.Text, true, false);
                        break;

                }
            }
            catch
            { }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            guardar();

            MessageBox.Show("Guardado exitosamente");
            txtcodigofam.Text = "";
            txtdesc.Text = "";
        }
        private void Buscar()
        {
            string esraiz;
            esraiz = Convert.ToString(comboBox2.SelectedItem);
            switch (esraiz)
            {
                case "Familia":


                    dataGridView1.DataSource = familia.cargarFamilia(txtbuscar.Text).Tables[0];

                    break;
                case "Subfamilia":
                    dataGridView1.DataSource = familia.cargarsubFamilia(txtbuscar.Text).Tables[0];
                    break;

            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            cargarPadre();
            string esraiz;
            esraiz = Convert.ToString(comboBox2.SelectedItem);
            switch (esraiz)
            {
                case "Familia":
                    txtcodigofam.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    comboBox1.SelectedValue = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    txtdesc.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    radioButton2.Checked = Convert.ToBoolean(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
                    radioButton1.Checked = Convert.ToBoolean(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString());



                    break;
                case "Subfamilia":
                    txtcodigofam.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    comboBox1.SelectedValue = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    comboBox1.SelectedItem = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    txtdesc.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    radioButton2.Checked = Convert.ToBoolean(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString());
                    radioButton1.Checked = Convert.ToBoolean(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString());
                    break;

            }

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            cargarPadre();
            txtdesc.Text = "";
        }
    }
}
