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
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }
      
    
        void text_KeyUp(object sender, KeyEventArgs e)
        {
        int rowIndex = ((System.Windows.Forms.DataGridViewTextBoxEditingControl)(sender)).EditingControlRowIndex;
            if (e.KeyCode == Keys.Enter)
            {
            int valueEntered = Convert.ToInt32(dataGridView1.Rows[rowIndex - 1].Cells["cuenta"].Value);
            dataGridView1.Rows[rowIndex - 1].Cells["descripcion"].Value = this.Search(valueEntered);
            }
        }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("cuenta");
            dt.Columns.Add("descripcion");


            DataRow row = dt.NewRow();
            row["cuenta"] = "1001";
            row["descripcion"] = "cuenta 1001";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["cuenta"] = "1002";
            row["descripcion"] = "cuenta 1002";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["cuenta"] = "1003";
            row["descripcion"] = "cuenta 1003";
            dt.Rows.Add(row);

            return dt;


        }

        private string Search(int cuenta)
        {
            string descripcion = (from item in this.GetDataTable().AsEnumerable()
                                  where Convert.ToInt32(item["cuenta"]) == cuenta
                                  select item["descripcion"].ToString()).FirstOrDefault<string>();

            return descripcion;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
            dText.KeyUp -= new KeyEventHandler(text_KeyUp);
            dText.KeyUp += new KeyEventHandler(text_KeyUp);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.BeginEdit(false);
        }

   

    }
}
