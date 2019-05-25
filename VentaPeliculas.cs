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
    public partial class VentaPeliculas : Form
    {
        Clases.Clspeliculas peliculas = new Clases.Clspeliculas();
        public VentaPeliculas()
        {
            InitializeComponent();
        }
        private void buscar()
        {
            string busca;
            busca = Convert.ToString(comboBox1.SelectedItem);
            dateTimePicker1.Visible = false;
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
            peliculas.guardarVentapeliculas();
            actualizarstock();
            peliculas.borrarTMP(txtid.Text, textBox1.Text);
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            txtbuscar.Focus();
            txtbuscar.Text = "";
            txtid.Text = "";
            textBox1.Text = "";
            MessageBox.Show("Guardado exitosamente");
            peliculas.borrarTMPtodo();
            cargarTmp();

        }
        private void cargarTmp()
        {
            dataGridView2.DataSource = peliculas.cargarTMP().Tables[0];
        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            buscar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string busca;
            busca = Convert.ToString(comboBox1.SelectedItem);
            txtbuscar.Focus();
            switch (busca)
            {
                case "T.Inglés":
                    dateTimePicker1.Visible = false;
                    txtbuscar.Text = "";
                    txtbuscar.Focus();
                    break;
                case "T.Español":
                    dateTimePicker1.Visible = false;
                    txtbuscar.Text = "";
                    txtbuscar.Focus();
                    break;
                case "Actor":
                    dateTimePicker1.Visible = false;
                    txtbuscar.Text = "";
                    txtbuscar.Focus();
                    break;
                case "Actriz":
                    dateTimePicker1.Visible = false;
                    txtbuscar.Text = "";
                    txtbuscar.Focus();
                    break;
                case "Reparto":
                    dateTimePicker1.Visible = false;
                    txtbuscar.Text = "";
                    txtbuscar.Focus();
                    break;
                case "Género":
                    dateTimePicker1.Visible = false;
                    txtbuscar.Text = "";
                    txtbuscar.Focus();
                    break;
                case "F.Estreno":
                    dateTimePicker1.Visible = true;
                    txtbuscar.Text = "";
                    dateTimePicker1.Focus();

                    break;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = peliculas.cargartifecha(Convert.ToDateTime(dateTimePicker1.Value.ToString())).Tables[0];
        }
        private void cargarVendidas()
        {
            peliculas.guardarTMP(Convert.ToString(txtid.Text), Convert.ToInt16("1"), Convert.ToDateTime(label3.Text)); ;
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView2.DataSource = peliculas.cargarTMP().Tables[0];
        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
                // Invalidar la accion
                e.Handled = true;
                // Enviar el sonido de beep de windows
                System.Media.SystemSounds.Beep.Play();
                cargarVendidas();
                limpiar();
            }
        }

        private void VentaPeliculas_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            label3.Text = DateTime.Now.ToString();
            cargarTmp();
        }

        private void btndescartar_Click(object sender, EventArgs e)
        {
            try
            {

                if

                        (MessageBox.Show("Seguro que desea eliminar?", "Anular Peli vendida", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    peliculas.borrarTMP(txtid.Text, textBox1.Text);
                    cargarTmp();
                    limpiar();
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if

                        (MessageBox.Show("Seguro que desea eliminar?", "Anular Todo?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    peliculas.borrarTMPtodo();
                    cargarTmp();
                    limpiar();
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }
        private void actualizarstock()
        {
            Int32 i;
            String celda;
            DataGridViewCell dgc;
            for (i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dgc = dataGridView2.Rows[i].Cells[1];
                celda = ((String)dgc.Value);
                peliculas.actualizarstock(celda);
            }
        }
        private void limpiar()
        {
            txtbuscar.Text = "";
            textBox1.Text = "";
            txtid.Text = "";
            
            txtid.Focus();

        }

        private void btgnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            peliculas.borrarTMP(txtid.Text, textBox1.Text);
            txtbuscar.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtid.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txtbuscar.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            dataGridView1.Visible = true;
            txtbuscar.Focus();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {

                txtid.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
                textBox1.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
                txtbuscar.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {

    
                dataGridView1.DataSource =peliculas.cargarconcodigo(txtid.Text).Tables[0];
                cargarTextosxcod();
            }
            catch { }
        }
        private void cargarTextosxcod()
        {
            try
            {
                DataSet datos;
                DataSet datos1;
                DataSet datos2;
                DataSet datos3;
                datos = peliculas.cargarconcodigo(this.txtid.Text);
                datos1 = peliculas.cargarconcodigo(this.txtid.Text);
                datos2 = peliculas.cargarconcodigo(this.txtid.Text);
                datos3 = peliculas.cargarconcodigo(this.txtid.Text);
                //txtcodigo.Text = datos.Tables[0].Rows[0].ItemArray[0].ToString();
                this.txtbuscar.Text = datos.Tables[0].Rows[0].ItemArray[2].ToString();
                this.txtstock.Text = datos.Tables[0].Rows[0].ItemArray[8].ToString();
                //txtstocks.Text = datos.Tables[0].Rows[0].ItemArray[4].ToString();
            }

            catch {
               
            }
        }

        private void txtstock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si no es numerico y si no es espacio
            {
               if ((this.txtbuscar.Text!="")&& (this.txtstock.Text!=""))
                   {
                // Invalidar la accion
                e.Handled = true;
                // Enviar el sonido de beep de windows
                System.Media.SystemSounds.Beep.Play();
                cargarVendidas();
                limpiar();
                   }
               else

                   {
                       MessageBox.Show("Stock insuficiente");
                   }
            }
        }

    }
}
