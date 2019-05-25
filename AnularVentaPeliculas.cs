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
    public partial class AnularVentaPeliculas : Form
    {
        public AnularVentaPeliculas()
        {
            InitializeComponent();
        }
        Clases.Clspeliculas peliculas = new Clases.Clspeliculas();
        private void buscar()
        {
            string busca;
            busca = Convert.ToString(comboBox1.SelectedItem);

            dataGridView1.DataSource = peliculas.cargartitespanol(txtbuscar.Text).Tables[0];
            switch (busca)
            {
                case "T.Inglés":
                    dateTimePicker1.Visible = false;
                    dataGridView1.DataSource = peliculas.cargartiingles(txtbuscar.Text).Tables[0];
                    break;
                case "T.Español":
                    dateTimePicker1.Visible = false;
                    dataGridView1.DataSource = peliculas.cargartitespanol(txtbuscar.Text).Tables[0];
                    break;
                case "Actor":
                    dateTimePicker1.Visible = false;
                    dataGridView1.DataSource = peliculas.cargartiactor(txtbuscar.Text).Tables[0];
                    break;
                case "Actriz":
                    dateTimePicker1.Visible = false;
                    dataGridView1.DataSource = peliculas.cargartiactriz(txtbuscar.Text).Tables[0];
                    break;
                case "Reparto":
                    dateTimePicker1.Visible = false;
                    dataGridView1.DataSource = peliculas.cargartireparto(txtbuscar.Text).Tables[0];
                    break;
                case "Género":
                    dateTimePicker1.Visible = false;
                    dataGridView1.DataSource = peliculas.cargartigenero(txtbuscar.Text).Tables[0];
                    break;
                case "F.Estreno":

                    dateTimePicker1.Visible = true;
                    //dataGridView1.DataSource = peliculas.cargartifecha(Convert.ToDateTime(dateTimePicker1.Value.ToString())).Tables[0];
                    break;
            }

        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {

                if

                        (MessageBox.Show("Seguro que desea eliminar?", "Anular Peli vendida", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    peliculas.eliminarPelivendida(txtid.Text, textBox1.Text);
                    peliculas.actualizarstockPelianulada(textBox1.Text);
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            dataGridView1.DataSource = peliculas.cargarParaAnular(Convert.ToDateTime(dateTimePicker1.Value.ToString())).Tables[0];
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = peliculas.cargarParaAnularxTit(Convert.ToDateTime(dateTimePicker1.Value.ToString()), txtbuscar.Text).Tables[0];
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtid.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txtbuscar.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void AnularVentaPeliculas_Load(object sender, EventArgs e)
        {

        }
    }
}
