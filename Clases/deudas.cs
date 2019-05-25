using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace RaposoFact.Clases
{
    class deudas:Clsconexion
    {
        # region deudas
        public DataSet tmpcobrosdelete()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmpcobros ", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet tmpcobrosdebe()
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmpcobros (select deudas.CLIENTE,CLIE_NOMBRE,sum(cantidad)DEBE,'0' from deudas, cliente where cliente.clie_codigo =deudas.cliente and estado='DEBE' group by cliente.clie_nombre,deudas.CLIENTE order by cliente.clie_nombre)", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet tmpcobrospaga()
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmpcobros (select deudas.CLIENTE,CLIE_NOMBRE,'0',sum(cantidad)PAGA from deudas, cliente where cliente.clie_codigo =deudas.cliente and estado='PAGA' group by cliente.clie_nombre,deudas.CLIENTE order by cliente.clie_nombre)", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion


        public DataSet sacardeuda(string cliente)
        {

            NpgsqlCommand com = new NpgsqlCommand("SELECT SUM (CANTIDAD) AS DEBE,(SELECT SUM (CANTIDAD) AS  PAGA FROM DEUDAS WHERE ESTADO='PAGA'AND cliente =@cliente ) AS PAGA FROM DEUDAS WHERE ESTADO='DEBE' AND cliente =@cliente", cn);

            com.CommandType = CommandType.Text;
               
            com.Parameters.Add(new NpgsqlParameter("@cliente", NpgsqlTypes.NpgsqlDbType.Varchar, 6)).Value = cliente;
             NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet guardardeduda(DateTime fecha, string cliente, decimal cantidad, string detalle, string estado)
        {

            NpgsqlCommand com = new NpgsqlCommand(" select insertar_deuda  (@fecha, @cliente,@cantidad,@detalle,@estado) ", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cliente", NpgsqlTypes.NpgsqlDbType.Varchar, 6)).Value = cliente;
            com.Parameters.Add(new NpgsqlParameter("@cantidad", NpgsqlTypes.NpgsqlDbType.Double, 100)).Value = cantidad;
            com.Parameters.Add(new NpgsqlParameter("@detalle", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = detalle;
            com.Parameters.Add(new NpgsqlParameter("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, 15)).Value = estado;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet CARGARdeudas(string NOMBRE)
        {

            NpgsqlCommand com = new NpgsqlCommand(" select id , fecha,cantidad,detalle,estado from deudas where cliente =@NOMBRE", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@NOMBRE", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = NOMBRE;

            

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet CARGARCLIENTERUC(string ruc)
        {

            NpgsqlCommand com = new NpgsqlCommand(" SELECT CLIE_CODIGO,CLIE_RUC,CLIE_NOMBRE FROM CLIENTE where clie_ruc = @ruc ", cn);

            com.CommandType = CommandType.Text;



            com.Parameters.Add(new NpgsqlParameter("@ruc", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = ruc;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet CARGARCLIENTENOMBRE(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand(" SELECT CLIE_CODIGO,CLIE_NOMBRE FROM CLIENTE where CLIE_NOMBRE LIKE @desc ", cn);

            com.CommandType = CommandType.Text;



            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public void autocompletar(TextBox CajaTexto)
        {
            NpgsqlDataReader dr;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select CLIE_NOMBRE from cliente", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CajaTexto.AutoCompleteCustomSource.Add(dr["clie_nombre"].ToString());

                }
                dr.Close();
                cn.Close();
             

            }
            catch (Exception ex)
            {
                MessageBox.Show("Auncomplete error deudas.cs " + ex.ToString());
            }
        }
        
    }
}
