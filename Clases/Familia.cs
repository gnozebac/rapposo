using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
namespace RaposoFact.Clases
{
    class Familia:Clsconexion
    {
        #region Guardar
        public DataSet guardar(string idpadre, string familia, string subfamilia, Boolean esultima, Boolean esraiz)
        {

            NpgsqlCommand com = new NpgsqlCommand("select insertar_familia  (@idpadre  , @familia,@subfamilia  , @esultima  , @esraiz)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpadre;
            com.Parameters.Add(new NpgsqlParameter("@familia", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = familia;
            com.Parameters.Add(new NpgsqlParameter("@subfamilia", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = subfamilia;
            com.Parameters.Add(new NpgsqlParameter("@esultima", NpgsqlTypes.NpgsqlDbType.Boolean, 8)).Value = esultima;
            com.Parameters.Add(new NpgsqlParameter("@esraiz", NpgsqlTypes.NpgsqlDbType.Boolean, 8)).Value = esraiz;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        #endregion
        #region CargarDatos
        public DataSet cargarFamilia(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,familia,esultima,esraiz from familia where esraiz = true and familia like @desc order by familia", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet cargarsubFamilia(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,familia,subfamilia,esultima,esraiz from familia where esultima = true and subfamilia like @desc order by subfamilia", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        #endregion

        #region familia

        public DataSet usuario()
        {

            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,descripcion,esultima from familia where esultima = False", cn);
            com.CommandType = CommandType.Text;
            //com.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar, 20)).Value = titulo;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion
    }
}
