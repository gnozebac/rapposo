using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
namespace RaposoFact.Clases
{
    class ClsProveedor:Clsconexion
    {
        #region cargarproveedores
        public DataSet cargarProveedorxcod(string id)
        {
            //por producto
            NpgsqlCommand com = new NpgsqlCommand("SELECT     * FROM  proveedor where pro_ruc=@id", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = id;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Close();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarclientesxnombre(string desc)
        {
            //por producto
            NpgsqlCommand com = new NpgsqlCommand("select * from proveedor  where pro_nombre like @desc", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet cargarclientesxnombreDeuda(string desc)
        {
            //por producto
            NpgsqlCommand com = new NpgsqlCommand("select * from proveedor where pro_nombre = @desc", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = desc;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion
        #region editar
        //public DataSet editarProductos(string idpadre,string id)
        public DataSet guardarproveedor(string p_clie_ruc, string p_clie_nombre, string p_clie_direccion, string p_clie_telefono, string pclie_email)
        {

            NpgsqlCommand com = new NpgsqlCommand("select insertar_proveedor (@p_clie_ruc,@p_clie_nombre,@p_clie_direccion ,@p_clie_telefono,@pclie_email) ", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@p_clie_ruc", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = p_clie_ruc;
            com.Parameters.Add(new NpgsqlParameter("@p_clie_nombre", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = p_clie_nombre;
            com.Parameters.Add(new NpgsqlParameter("@p_clie_direccion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = p_clie_direccion;
            com.Parameters.Add(new NpgsqlParameter("@p_clie_telefono", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = p_clie_telefono;
            com.Parameters.Add(new NpgsqlParameter("@pclie_email", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = pclie_email;




            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
       
        public DataSet EDITARcliente(string id, string p_clie_ruc, string p_clie_nombre, string p_clie_direccion, string p_clie_telefono, string pclie_email)
        {

            NpgsqlCommand com = new NpgsqlCommand("update proveedor set pro_ruc=@p_clie_ruc,pro_nombre=@p_clie_nombre,pro_direccion=@p_clie_direccion ,pro_telefono=@p_clie_telefono,pro_email=@pclie_email where pro_codigo=@id ", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@p_clie_ruc", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = p_clie_ruc;
            com.Parameters.Add(new NpgsqlParameter("@p_clie_nombre", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = p_clie_nombre;
            com.Parameters.Add(new NpgsqlParameter("@p_clie_direccion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = p_clie_direccion;
            com.Parameters.Add(new NpgsqlParameter("@p_clie_telefono", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = p_clie_telefono;
            com.Parameters.Add(new NpgsqlParameter("@pclie_email", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = pclie_email;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = id;



            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion
        public DataSet cargarxcicliente(string ruc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from proveedor where pro_ruc=@ruc ", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@ruc", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = ruc;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }


    }
}
