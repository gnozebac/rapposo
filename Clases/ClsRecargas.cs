using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
namespace RaposoFact.Clases
{
    class ClsRecargas:Clsconexion
    {

        public DataSet HechasXy()
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select sum(total) as Venta, (select sum(valor)  as Saldo from recargas where detalle ='XY' and valor <>0 and nota='Acreditaciones Recibidas' )as Saldo from notaventa where  idproducto='00416'", cn);

            com.CommandType = CommandType.Text;
    
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet Hechaspines()
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select sum(total) as Venta, (select sum(valor)  as Saldo from recargas where detalle ='Pines Claro' and valor <>0 and nota='Acreditaciones Recibidas' )as Saldo from notaventa where  idproducto='00417'", cn);

            com.CommandType = CommandType.Text;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet Hechasbwise()
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select sum(total) as Venta, (select sum(valor)  as Saldo from recargas where detalle ='Sistema Bwise' and valor <>0 and nota='Acreditaciones Recibidas' )as Saldo from notaventa where  idproducto='00001' AND FECHA='18-06-2018' ", cn);

            com.CommandType = CommandType.Text;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet guardarrecargas(string usuario,  decimal valor, string detalle , DateTime fecha,  string nota)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select insertar_recargas  (@usuario,@valor  , @detalle  , @fecha  , @nota)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
            com.Parameters.Add(new NpgsqlParameter("@valor", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = valor;
            com.Parameters.Add(new NpgsqlParameter("@detalle", NpgsqlTypes.NpgsqlDbType.Varchar,100)).Value = detalle;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@nota", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = nota;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarBwise()
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select valor,detalle, fecha , (select sum(valor) from recargas where detalle ='Sistema Bwise') as sum  from recargas where detalle ='Sistema Bwise' and valor <>0 and nota='Acreditaciones Recibidas'", cn);

            com.CommandType = CommandType.Text;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarXY()
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select valor,detalle, fecha , (select sum(valor) from recargas where detalle ='XY') as sum  from recargas where detalle ='XY' and valor <>0 and nota='Acreditaciones Recibidas'", cn);

            com.CommandType = CommandType.Text;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarPines()
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select valor,detalle, fecha , (select sum(valor) from recargas where detalle ='Pines Claro') as sum   from recargas where detalle ='Pines Claro'  and nota='Acreditaciones Recibidas'", cn);

            com.CommandType = CommandType.Text;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet RecargasHoy(DateTime fecha)
        {
            //valor recaudado en ventas
            NpgsqlCommand com = new NpgsqlCommand("select total, descripcion from notaventa where fecha=@fecha and idproducto='00416' ", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
    }
}
