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
    public partial class peliculas : Form
    {
        public peliculas()
        {
            InitializeComponent();
        }
        Clases.Clspeliculas pelicula = new Clases.Clspeliculas();
        private void limpiar()
        {
            txtid.Text = "";
            txtingles.Text = "";
            txtespanol.Text = "";
            txtactriz.Text = "";
            txtactor.Text = "";
            txtstock.Text = "1";
            txtreparto.Text = "";
            txtfestreno.Text = "";
            txtfestreno.Text = "2/3/2013";
            txtespanol.Focus();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            btnguardar.Enabled = false;
                btneditar.Enabled = true;
                txtid.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                this.txtingles.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtespanol.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                txtactor.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                txtactriz.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                this.txtreparto.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
                cmbgenero.SelectedItem = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
                txtfestreno.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
                this.txtstock.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
            
           
        }

        private void peliculas_Load(object sender, EventArgs e)
        {
            btnguardar.Enabled = false;
            btneditar.Enabled = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
              if (txtespanol.Text != "")
                   {
                       pelicula.guardar(txtingles.Text, txtespanol.Text, txtactor.Text, txtactriz.Text, txtreparto.Text, Convert.ToString(cmbgenero.SelectedItem), Convert.ToDateTime(txtfestreno.Text), Convert.ToInt16(txtstock.Text));
                       dataGridView1.DataSource = pelicula.cargartitespanol0(txtespanol.Text).Tables[0];
                       MessageBox.Show("Guardado exitosamente");

                       limpiar();
                       txtespanol.Focus();
                       btnguardar.Enabled = true;
                       btneditar.Enabled = false;
                   }
              else

                   {
                       MessageBox.Show("No hay datos");
                       txtespanol.Focus();
                   }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pelicula.cargartitespanol0(txtbuscar.Text).Tables[0];
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                pelicula.editar(txtingles.Text, txtespanol.Text, txtactor.Text, txtactriz.Text, txtreparto.Text, Convert.ToString(cmbgenero.SelectedItem), Convert.ToDateTime(txtfestreno.Text), Convert.ToInt16(txtstock.Text), Convert.ToString(txtid.Text));
                MessageBox.Show("Guardado exitosamente");
                limpiar();
                btnguardar.Enabled = true;
                btneditar.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btgnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            txtfestreno.Text = DateTime.Now.ToString();
            btnguardar.Enabled = true;
            btneditar.Enabled = false;
        }

        private void btndescartar_Click(object sender, EventArgs e)
        {
            try
            {

                if

                        (MessageBox.Show("Seguro que dese salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pelicula.eliminar(txtid.Text);
                    limpiar();

                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void txtespanol_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pelicula.cargartitespanol0(txtespanol.Text).Tables[0];
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Clases.Clspeliculas peliculas = new Clases.Clspeliculas();


                dataGridView1.DataSource = peliculas.cargarconcodigoeditar(txtid.Text).Tables[0];

            }
            catch { }
        }
    }
}
