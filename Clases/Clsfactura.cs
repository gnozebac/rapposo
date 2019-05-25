using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
namespace RaposoFact.Clases
{
    class Clsfactura:Clsconexion
    {
        #region factura

        public DataSet insertarfactura(string numero, DateTime fecha, string idcliente, double subtotal, double iva0, double iva12,double impuesto, double total)
        {

            NpgsqlCommand com = new NpgsqlCommand("select insertar_factura (@numero, @fecha, @idcliente, @subtotal, @iva0, @iva12,@impuesto, @total)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@numero", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = numero;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@idcliente", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idcliente;
            com.Parameters.Add(new NpgsqlParameter("@subtotal", NpgsqlTypes.NpgsqlDbType.Double)).Value = subtotal;
            com.Parameters.Add(new NpgsqlParameter("@iva0", NpgsqlTypes.NpgsqlDbType.Double)).Value = iva0;
            com.Parameters.Add(new NpgsqlParameter("@iva12", NpgsqlTypes.NpgsqlDbType.Double)).Value = iva12;
            com.Parameters.Add(new NpgsqlParameter("@impuesto", NpgsqlTypes.NpgsqlDbType.Double)).Value = impuesto;
            com.Parameters.Add(new NpgsqlParameter("@total", NpgsqlTypes.NpgsqlDbType.Double)).Value = total;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);

            DataSet dd = new DataSet();
            cn.Close();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet insertardetallefactura(string ifactura, string idproducto, double precio, double ptotal,int cantidad)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into detalle values (@ifactura,@idproducto,@precio,@ptotal,@cantidad)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@ifactura", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = ifactura;
           com.Parameters.Add(new NpgsqlParameter("@idproducto", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idproducto;
            com.Parameters.Add(new NpgsqlParameter("@precio", NpgsqlTypes.NpgsqlDbType.Double)).Value = precio;
            com.Parameters.Add(new NpgsqlParameter("@ptotal", NpgsqlTypes.NpgsqlDbType.Double)).Value = ptotal;
            com.Parameters.Add(new NpgsqlParameter("@cantidad", NpgsqlTypes.NpgsqlDbType.Double)).Value = cantidad;
    
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet actualizarstock(string idproducto, int cant)
        {

            NpgsqlCommand com = new NpgsqlCommand("update productos set stock=stock - @cant where idproducto=@idproducto", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idproducto", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idproducto;
            com.Parameters.Add(new NpgsqlParameter("@cant", NpgsqlTypes.NpgsqlDbType.Integer)).Value = cant;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }
        public DataSet cargarProductos(string desc)
        {
            //por producto
            NpgsqlCommand com = new NpgsqlCommand("SELECT     idproducto, descripcion, tipoiva, pvp, stock  FROM  productos where descripcion like @desc ", cn);
            //NpgsqlCommand com = new NpgsqlCommand("SELECT     idproducto, descripcion, tipoiva, pvp, stock  FROM  productos where descripcion like @desc and stock >=1", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarProductosxcod(string id)
        {
            //por producto
            NpgsqlCommand com = new NpgsqlCommand("SELECT     idproducto, descripcion, tipoiva, pvp, stock  FROM  productos where idproducto=@id", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = id;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Close();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarProductosxcodbar(string desc)
        {
            //por producto

         

            NpgsqlCommand com = new NpgsqlCommand("select idproducto,descripcion,pvp,stock from familia,productos where  productos.idfamilia=  familia.idfamilia  and codbar =@desc", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", NpgsqlTypes.NpgsqlDbType.Varchar, 40)).Value = desc;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Close();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarProductoscod(string cod)
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("SELECT     idproducto, descripcion, tipoiva, pvp, stock  FROM  productos where idproducto = @cod", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@cod", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = cod;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion
        #region notaventa
        public DataSet guardarTmpnotaventa(string idproducto,DateTime fecha, int cantidad, string descripcion, double pvp,double total)
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("SELECT  insertar_notaventa (@idproducto , @fecha ,  @cantidad ,@descripcion   , @pvp ,@total)", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idproducto", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idproducto;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer)).Value = cantidad;
            com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
            com.Parameters.Add(new NpgsqlParameter("@pvp", NpgsqlTypes.NpgsqlDbType.Double)).Value = pvp;
            com.Parameters.Add(new NpgsqlParameter("@total", NpgsqlTypes.NpgsqlDbType.Double)).Value = total;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet codmaxtaventa()
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("select id from tmpnotaventa", cn);
            com.CommandType = CommandType.Text;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet guardarnotaventa(string id,string idproducto, DateTime fecha, int cantidad, string descripcion, double pvp, double total)
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("insert into notaventa values (@id,@idproducto , @fecha ,  @cantidad ,@descripcion   , @pvp ,@total)", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 9)).Value = id;
            com.Parameters.Add(new NpgsqlParameter("@idproducto", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idproducto;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer)).Value = cantidad;
            com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
            com.Parameters.Add(new NpgsqlParameter("@pvp", NpgsqlTypes.NpgsqlDbType.Double)).Value = pvp;
            com.Parameters.Add(new NpgsqlParameter("@total", NpgsqlTypes.NpgsqlDbType.Double)).Value = total;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrarTmpnotaventa()
        {
  
            NpgsqlCommand com = new NpgsqlCommand("delete from tmpnotaventa ", cn);
            com.CommandType = CommandType.Text;
            

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Close();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrarTmpnotaventaxcodigo(string id, string idproducto)
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("delete from tmpnotaventa where id=@id and idproducto=@idproducto ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 10)).Value = id;
            com.Parameters.Add(new NpgsqlParameter("@idproducto", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idproducto;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarTmpnotaventa()
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("select cantidad, descripcion, pvp, total, id, idproducto,fecha from tmpnotaventa", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion
        #region Factura
        //public DataSet guardarTmpfactura(string idproducto, DateTime fecha, int cantidad, string descripcion, double pvp, double total)
        //{
        //    //por codigo
        //    NpgsqlCommand com = new NpgsqlCommand("SELECT  insertar_notaventa (@idproducto , @fecha ,  @cantidad ,@descripcion   , @pvp ,@total)", cn);
        //    com.CommandType = CommandType.Text;
        //    com.Parameters.Add(new NpgsqlParameter("@idproducto", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idproducto;
        //    com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
        //    com.Parameters.Add(new NpgsqlParameter("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer)).Value = cantidad;
        //    com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
        //    com.Parameters.Add(new NpgsqlParameter("@pvp", NpgsqlTypes.NpgsqlDbType.Double)).Value = pvp;
        //    com.Parameters.Add(new NpgsqlParameter("@total", NpgsqlTypes.NpgsqlDbType.Double)).Value = total;
        //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
        //    DataSet dd = new DataSet();
        //    cn.Open();
        //    da.Fill(dd);
        //    cn.Close();
        //    return dd;
        //}
        public DataSet cargarTmpfactura()
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("select cantidad, descripcion, pvp, total, id, idproducto,fecha from tmpfactura", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet guardarfactura(string id, string idproducto, DateTime fecha, int cantidad, string descripcion, double pvp, double total)
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("insert into factura values (@id,@idproducto , @fecha ,  @cantidad ,@descripcion   , @pvp ,@total)", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = id;
            com.Parameters.Add(new NpgsqlParameter("@idproducto", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idproducto;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer)).Value = cantidad;
            com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
            com.Parameters.Add(new NpgsqlParameter("@pvp", NpgsqlTypes.NpgsqlDbType.Double)).Value = pvp;
            com.Parameters.Add(new NpgsqlParameter("@total", NpgsqlTypes.NpgsqlDbType.Double)).Value = total;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrarTmpfactura()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmpfactura ", cn);
            com.CommandType = CommandType.Text;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrarTmpfacturaxcodigo(string id, string idproducto)
        {
            //por codigo
            NpgsqlCommand com = new NpgsqlCommand("delete from tmpnfactura where id=@id and idproducto=@idproducto ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = id;
            com.Parameters.Add(new NpgsqlParameter("@idproducto", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idproducto;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
       
       
        #endregion
        #region cargarclientes
        public DataSet cargarclientesxnombre(string desc)
        {
            //por producto
            NpgsqlCommand com = new NpgsqlCommand("select * from cliente where clie_nombre like @desc", cn);
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
            NpgsqlCommand com = new NpgsqlCommand("select * from cliente where clie_nombre = @desc", cn);
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
    }
}
