using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
namespace RaposoFact.Clases
{
    class Clscompras:Clsconexion
    {

        public DataSet guardarFACTURA(string id_proveedor, DateTime fecha, string factura, string autorizacion, DateTime fechacaducidad, double iva0, double sub12, double iva, double total)
        {

            NpgsqlCommand com = new NpgsqlCommand("select insertar_facturacompras (@id_proveedor, @fecha, @factura, @autorizacion, @fechacaducidad, @iva0, @sub12, @iva,@total) ", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@id_proveedor", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = id_proveedor;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@factura", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = factura;
            com.Parameters.Add(new NpgsqlParameter("@autorizacion", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = autorizacion;
            com.Parameters.Add(new NpgsqlParameter("@fechacaducidad", NpgsqlTypes.NpgsqlDbType.Date)).Value = fechacaducidad;
            com.Parameters.Add(new NpgsqlParameter("@iva0", NpgsqlTypes.NpgsqlDbType.Double)).Value = iva0;
            com.Parameters.Add(new NpgsqlParameter("@sub12", NpgsqlTypes.NpgsqlDbType.Double)).Value = sub12;
            com.Parameters.Add(new NpgsqlParameter("@iva", NpgsqlTypes.NpgsqlDbType.Double)).Value = iva;

            com.Parameters.Add(new NpgsqlParameter("@total", NpgsqlTypes.NpgsqlDbType.Double)).Value = total;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet editarFACTURAcompra(string id, string id_proveedor, DateTime fecha, string factura, string autorizacion, DateTime fechacaducidad, double iva0, double sub12, double iva, double total)
        {

            NpgsqlCommand com = new NpgsqlCommand("update insertar_facturacompras set  id_proveedor=@id_proveedor,fecha= @fecha,factura= @factura,autorizacion= @autorizacion, fechacaducidad=@fechacaducidad,iva0= @iva0, sub12=@sub12,iva= @iva,total=@total) ", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id_proveedor", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = id_proveedor;
            com.Parameters.Add(new NpgsqlParameter("@id_proveedor", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = id_proveedor;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@factura", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = factura;
            com.Parameters.Add(new NpgsqlParameter("@autorizacion", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = autorizacion;
            com.Parameters.Add(new NpgsqlParameter("@fechacaducidad", NpgsqlTypes.NpgsqlDbType.Date)).Value = fechacaducidad;
            com.Parameters.Add(new NpgsqlParameter("@iva0", NpgsqlTypes.NpgsqlDbType.Double)).Value = iva0;
            com.Parameters.Add(new NpgsqlParameter("@sub12", NpgsqlTypes.NpgsqlDbType.Double)).Value = sub12;
            com.Parameters.Add(new NpgsqlParameter("@iva", NpgsqlTypes.NpgsqlDbType.Double)).Value = iva;

            com.Parameters.Add(new NpgsqlParameter("@total", NpgsqlTypes.NpgsqlDbType.Double)).Value = total;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

    }
}
