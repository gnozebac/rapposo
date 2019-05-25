using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Npgsql;
namespace RaposoFact.Clases
{
    class ClscodCNB: Clsconexion 
    {
        public DataSet cargarcodigo(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from cnbcod WHERE descripcion like @desc ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
    }
}
