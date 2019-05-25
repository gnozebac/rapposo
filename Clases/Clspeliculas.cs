using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
namespace RaposoFact.Clases
{
    class Clspeliculas:Clsconexion
    {
        #region  mantenimiento peliculas
        #region Guardar
        public DataSet guardar(string ingles, string espanol, string actor, string actriz, string reparto, string genero, DateTime festreno, int stock)
        {

            NpgsqlCommand com = new NpgsqlCommand("select insertar_peliculas  (@ingles  , @espanol,@actor  , @actriz  , @reparto,@genero,@festreno,@stock)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@ingles", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = ingles;
            com.Parameters.Add(new NpgsqlParameter("@espanol", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = espanol;
            com.Parameters.Add(new NpgsqlParameter("@actor", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = actor;
            com.Parameters.Add(new NpgsqlParameter("@actriz", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = actriz;
            com.Parameters.Add(new NpgsqlParameter("@reparto", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = reparto;
            com.Parameters.Add(new NpgsqlParameter("@genero", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = genero;
            com.Parameters.Add(new NpgsqlParameter("@festreno", NpgsqlTypes.NpgsqlDbType.Date)).Value = festreno;
            com.Parameters.Add(new NpgsqlParameter("@stock", NpgsqlTypes.NpgsqlDbType.Integer, 6)).Value = stock;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }

        #endregion

        #region editar
        public DataSet editar(string ingles, string espanol, string actor, string actriz, string reparto, string genero, DateTime festreno, int stock, string id)
        {

            NpgsqlCommand com = new NpgsqlCommand("update peliculas set titingles= @ingles  , titespanol= @espanol,actor=@actor  ,actriz= @actriz  , reparto=@reparto,genero=@genero,festreno=@festreno,stock=@stock where id= @id ", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@ingles", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = ingles;
            com.Parameters.Add(new NpgsqlParameter("@espanol", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = espanol;
            com.Parameters.Add(new NpgsqlParameter("@actor", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = actor;
            com.Parameters.Add(new NpgsqlParameter("@actriz", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = actriz;
            com.Parameters.Add(new NpgsqlParameter("@reparto", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = reparto;
            com.Parameters.Add(new NpgsqlParameter("@genero", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = genero;
            com.Parameters.Add(new NpgsqlParameter("@festreno", NpgsqlTypes.NpgsqlDbType.Date)).Value = festreno;
            com.Parameters.Add(new NpgsqlParameter("@stock", NpgsqlTypes.NpgsqlDbType.Integer, 6)).Value = stock;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 6)).Value = id;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }

        #endregion
        #region cargarStock0

        public DataSet cargartitespanol0(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where titespanol like @desc ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarconcodigo(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where id=@desc and stock >=1 ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", NpgsqlTypes.NpgsqlDbType.Varchar, 6)).Value = desc;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarconcodigoeditar(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where id=@desc  ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", NpgsqlTypes.NpgsqlDbType.Varchar, 6)).Value = desc;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartiingles0(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where titingles like @desc ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartiactor0(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where actor like @desc ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartiactriz0(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where actriz like @desc ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartireparto0(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where reparto like @desc  ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet cargartigenero0(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where genero like @desc ", cn);
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
        #region eliminar
        public DataSet eliminar(string id)
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from peliculas where id= @id", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 6)).Value = id;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }

        #endregion

        #endregion
        #region ventaPeliculas
        #region select
        public DataSet cargartitespanol(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where titespanol like @desc and stock >=1", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartiingles(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where titingles like @desc and stock >=1", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartiactor(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where actor like @desc and stock >=1", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartiactriz(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where actriz like @desc and stock >=1", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartireparto(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where reparto like @desc and stock >=1", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartigenero(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where genero like @desc and stock >=1", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargartifecha(DateTime festreno)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from peliculas where festreno = @festreno and stock >=1", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@festreno", NpgsqlTypes.NpgsqlDbType.Date)).Value = festreno;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion

        #region guardar

        public DataSet cargarTMP()
        {

            NpgsqlCommand com = new NpgsqlCommand("select tmpventapeliculas.id, idpelicula, titespanol,stock from peliculas, tmpventapeliculas where peliculas.id= idpelicula", cn);

            com.CommandType = CommandType.Text;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet cargarParaAnular(DateTime fecha)
        {

            NpgsqlCommand com = new NpgsqlCommand("select ventapeliculas.id, idpelicula, titingles,titespanol,stock from peliculas, ventapeliculas where peliculas.id= idpelicula and fecha =@fecha", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet cargarParaAnularxTit(DateTime fecha, string nom)
        {

            NpgsqlCommand com = new NpgsqlCommand("select ventapeliculas.id, idpelicula, titingles,titespanol,stock from peliculas, ventapeliculas where peliculas.id= idpelicula and fecha =@fecha and titespanol like @nom", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@nom", "%" + nom + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet eliminarPelivendida(string id, string idpeli)
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from ventapeliculas where id =@id and idpelicula =@idpeli", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = id;
            com.Parameters.Add(new NpgsqlParameter("@idpeli", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpeli;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet actualizarstockPelianulada(string idpelicula)
        {

            NpgsqlCommand com = new NpgsqlCommand("update peliculas set stock=stock + 1 where id=@idpelicula", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idpelicula", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpelicula;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet actualizarstock(string idpelicula)
        {

            NpgsqlCommand com = new NpgsqlCommand("update peliculas set stock=stock - 1 where id=@idpelicula", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idpelicula", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpelicula;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet borrarTMP(string id, string idpelicula)
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from  tmpventapeliculas where id=@id and idpelicula=@idpelicula", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = id;
            com.Parameters.Add(new NpgsqlParameter("@idpelicula", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpelicula;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet borrarTMPtodo()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from  tmpventapeliculas ", cn);

            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet guardarTMP(string idpelicula, int cantidad, DateTime fecha)
        {

            NpgsqlCommand com = new NpgsqlCommand("select insertar_VPeli (@idpelicula , @cantidad , @fecha )", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idpelicula", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpelicula;
            com.Parameters.Add(new NpgsqlParameter("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = cantidad;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet cargarTMP(string idpelicula, int cantidad, DateTime fecha)
        {
            //cargar para eliminar
            NpgsqlCommand com = new NpgsqlCommand("select * from tmpventapeliculas", cn);

            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet guardarVentapeliculas()
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into ventapeliculas (select * from tmpventapeliculas )", cn);

            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet cargarTodoVentas()
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from tmpventapeliculas ", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet scarcantidadTMP(string idpelicula)
        {

            NpgsqlCommand com = new NpgsqlCommand("update VentaPeliculas set cantidad= cantidad + 1 where idpelicula=@pelicula  ", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idpelicula", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpelicula;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }

        #endregion
        #endregion
    }
}
