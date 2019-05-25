using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
namespace RaposoFact.Clases
{
    class Clscliente:Clsconexion
    {
        #region editar
        //public DataSet editarProductos(string idpadre,string id)
        public DataSet guardarcliente(string p_clie_ruc,string p_clie_nombre,string p_clie_direccion ,string p_clie_telefono,string pclie_email)
        {

            NpgsqlCommand com = new NpgsqlCommand("select insertar_cliente (@p_clie_ruc,@p_clie_nombre,@p_clie_direccion ,@p_clie_telefono,@pclie_email) ", cn);

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
        public DataSet EDITARcliente(string id,string p_clie_ruc, string p_clie_nombre, string p_clie_direccion, string p_clie_telefono, string pclie_email)
        {

            NpgsqlCommand com = new NpgsqlCommand("update cliente set clie_ruc=@p_clie_ruc,clie_nombre=@p_clie_nombre,clie_direccion=@p_clie_direccion ,clie_telefono=@p_clie_telefono,clie_email=@pclie_email where clie_codigo=@id ", cn);

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

            NpgsqlCommand com = new NpgsqlCommand("select * from cliente where clie_ruc=@ruc ", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@ruc", NpgsqlTypes.NpgsqlDbType.Varchar, 13)).Value = ruc;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
//        #region Guardar
//        public DataSet guardar(string p_idfamilia, string descripcion, decimal costo, int unidades, decimal gastostransporte, int ganancia, string tipoiva, string tipocompra, decimal pvp, int stock, string idpadre)
//        {
//            NpgsqlCommand com = new NpgsqlCommand("select insertar_cliente  (@idfamilia  , @descripcion  , @costo  , @unidades , @gastostransporte  , @ganancia  , @tipoiva  ,@tipocompra  ,@pvp  , @stock ,@idpadre)", cn);

//            com.CommandType = CommandType.Text;
//            com.Parameters.Add(new NpgsqlParameter("@idfamilia", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = p_idfamilia;
//            com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
//            com.Parameters.Add(new NpgsqlParameter("@costo", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = costo;
//            com.Parameters.Add(new NpgsqlParameter("@unidades", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = unidades;
//            com.Parameters.Add(new NpgsqlParameter("@gastostransporte", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = gastostransporte;
//            com.Parameters.Add(new NpgsqlParameter("@ganancia", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = ganancia;
//            com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
//            com.Parameters.Add(new NpgsqlParameter("@tipoiva", NpgsqlTypes.NpgsqlDbType.Varchar, 12)).Value = tipoiva;
//            com.Parameters.Add(new NpgsqlParameter("@tipocompra", NpgsqlTypes.NpgsqlDbType.Varchar, 12)).Value = tipocompra;
//            com.Parameters.Add(new NpgsqlParameter("@pvp", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = pvp;
//            com.Parameters.Add(new NpgsqlParameter("@stock", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = stock;
//            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpadre;
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }


//        #endregion
//        #region cargar productos
//        public DataSet listaproductos()
//        {
//            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_listaprecios SELECT idproducto,familia, subfamilia , descripcion,pvp, CASE WHEN ganancia=25 THEN pvp WHEN ganancia =30  THEN pvp  WHEN ganancia =31  " +
//  "THEN (costo*1.12)*(1.25)   WHEN ganancia =32  THEN  (costo*1.12)*(1.30)     WHEN ganancia =33  THEN (costo*1.12)*(1.30)     " +
//  "WHEN ganancia =34  THEN (costo*1.12)*(1.30)     WHEN ganancia =35  THEN (costo*1.12)*(1.30)     WHEN ganancia =36  THEN (costo*1.12)*(1.30) " +
//   "WHEN ganancia =37  THEN (costo*1.12)*(1.30)     WHEN ganancia =38  THEN (costo*1.12)*(1.30)     WHEN ganancia =39  THEN (costo*1.12)*(1.30)  " +
//     "WHEN ganancia =40  THEN (costo*1.12)*(1.30)     WHEN ganancia =41  THEN (costo*1.12)*(1.30) " +
//      "WHEN ganancia =42  THEN (costo*1.12)*(1.30)   WHEN ganancia =43  THEN (costo*1.12)*(1.30) " +
//      "WHEN ganancia =44  THEN (costo*1.12)*(1.34) WHEN ganancia =45  THEN (costo*1.12)*(1.34)     WHEN ganancia =46  THEN (costo*1.12)*(1.34)  " +
//       "WHEN ganancia =47  THEN (costo*1.12)*(1.34)     WHEN ganancia =48  THEN (costo*1.12)*(1.34)  WHEN ganancia =49  THEN (costo*1.12)*(1.34)    " +
//  "      WHEN ganancia =50  THEN (costo*1.12)*(1.34)" +
//    "          WHEN ganancia =40  THEN (costo*1.12)*(1.34)    END ,stock   FROM productos,familia    where stock >=1 and familia.idfamilia=productos.idfamilia order by familia  ,subfamilia,descripcion  ", cn);
//            com.CommandType = CommandType.Text;
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        public DataSet listaproductosoRDENCODIGO()
//        {


//            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_listaprecios SELECT idproducto,familia, subfamilia , descripcion,pvp, CASE WHEN ganancia=25 THEN pvp WHEN ganancia =30  THEN pvp  WHEN ganancia =31  " +
//"THEN (costo*1.12)*(1.25)   WHEN ganancia =32  THEN  (costo*1.12)*(1.30)     WHEN ganancia =33  THEN (costo*1.12)*(1.30)     " +
//"WHEN ganancia =34  THEN (costo*1.12)*(1.30)     WHEN ganancia =35  THEN (costo*1.12)*(1.30)     WHEN ganancia =36  THEN (costo*1.12)*(1.30) " +
// "WHEN ganancia =37  THEN (costo*1.12)*(1.30)     WHEN ganancia =38  THEN (costo*1.12)*(1.30)     WHEN ganancia =39  THEN (costo*1.12)*(1.30)  " +
//   "WHEN ganancia =40  THEN (costo*1.12)*(1.30)     WHEN ganancia =41  THEN (costo*1.12)*(1.30) " +
//    "WHEN ganancia =42  THEN (costo*1.12)*(1.30)   WHEN ganancia =43  THEN (costo*1.12)*(1.30) " +
//    "WHEN ganancia =44  THEN (costo*1.12)*(1.34) WHEN ganancia =45  THEN (costo*1.12)*(1.34)     WHEN ganancia =46  THEN (costo*1.12)*(1.34)  " +
//     "WHEN ganancia =47  THEN (costo*1.12)*(1.34)     WHEN ganancia =48  THEN (costo*1.12)*(1.34)  WHEN ganancia =49  THEN (costo*1.12)*(1.34)    " +
//"      WHEN ganancia =50  THEN (costo*1.12)*(1.34)" +
//  "          WHEN ganancia =40  THEN (costo*1.12)*(1.34)    END ,stock   FROM productos,familia    where stock >=1 and familia.idfamilia=productos.idfamilia order by idproducto;", cn);
//            com.CommandType = CommandType.Text;
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        public DataSet Borrarlistaproductos()
//        {

//            NpgsqlCommand com = new NpgsqlCommand("delete from tmp_listaprecios ", cn);
//            com.CommandType = CommandType.Text;
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }

//        public DataSet cargarsuProductosTodo(string desc)
//        {

//            NpgsqlCommand com = new NpgsqlCommand("select idproducto,familia.idfamilia,familia.idpadre,subfamilia,descripcion,costo,unidades,gastostransporte, ganancia,tipoiva,tipocompra,pvp,stock from familia,productos where  productos.idfamilia=  familia.idfamilia and descripcion like @desc", cn);
//            com.CommandType = CommandType.Text;
//            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        public DataSet cargarsuProductosNotaventa(string desc)
//        {

//            NpgsqlCommand com = new NpgsqlCommand("select idproducto,descripcion, ganancia,tipoiva,pvp,stock from familia,productos where  productos.idfamilia=  familia.idfamilia  and descripcion like @desc", cn);
//            com.CommandType = CommandType.Text;
//            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        #endregion
//        #region familia

//        public DataSet usuario()
//        {

//            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,familia,esultima from familia where esultima = False order by familia", cn);
//            com.CommandType = CommandType.Text;
//            //com.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar, 20)).Value = titulo;
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        public DataSet cargarsubfamilia(string idpadre)
//        {

//            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,subfamilia,esultima from familia where esultima = true and idpadre = @idpadre order by subfamilia", cn);
//            com.CommandType = CommandType.Text;
//            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpadre;
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        public DataSet famProd()
//        {
//            //cargar Familia para la tabla productos
//            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,descripcion,esultima from familia where esultima = False", cn);
//            com.CommandType = CommandType.Text;
//            //com.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar, 20)).Value = titulo;
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        #endregion
//        #region CARGAR PRODUCTOS
//        public DataSet cargarsuProductosg(string desc)
//        {

//            NpgsqlCommand com = new NpgsqlCommand("select * from productos where descripcion like @desc", cn);
//            com.CommandType = CommandType.Text;
//            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        public DataSet cargar(string desc)
//        {

//            NpgsqlCommand com = new NpgsqlCommand("select * from productos where descripcion like @desc", cn);
//            com.CommandType = CommandType.Text;
//            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        #endregion

//        #region eliminar
//        public DataSet eliminarProductos(string id)
//        {

//            NpgsqlCommand com = new NpgsqlCommand("delete  from productos where idproducto=@id", cn);

//            com.CommandType = CommandType.Text;
//            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = id;
//            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
//            DataSet dd = new DataSet();
//            cn.Open();
//            da.Fill(dd);
//            cn.Close();
//            return dd;
//        }
//        #endregion
   }
}
