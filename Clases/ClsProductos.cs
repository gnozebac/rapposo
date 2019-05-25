using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
namespace RaposoFact.Clases
{
    class ClsProductos:Clsconexion
    {
        #region editar
        //public DataSet editarProductos(string idpadre,string id)
        public DataSet editarProductos(string descripcion, double pvp, double gasto, int ganancia, int stock, string familia, string idpadre,int unidades,decimal costo, string id, string iva,string compra,string codbar )
        {

            NpgsqlCommand com = new NpgsqlCommand("update productos set descripcion=@descripcion  ,  pvp=@pvp , gastostransporte= @gasto,ganancia=@ganancia, stock=@stock, idfamilia=@familia,idpadre =@idpadre,unidades=@unidades , costo=@costo ,tipoiva =@iva ,tipocompra=@compra,codbar=@codbar where idproducto=@id", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
            com.Parameters.Add(new NpgsqlParameter("@pvp", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = pvp;
            com.Parameters.Add(new NpgsqlParameter("@gasto", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = gasto;
            com.Parameters.Add(new NpgsqlParameter("@ganancia", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = ganancia;

            com.Parameters.Add(new NpgsqlParameter("@stock", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = stock;
            com.Parameters.Add(new NpgsqlParameter("@familia", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = familia;
            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpadre;
            com.Parameters.Add(new NpgsqlParameter("@unidades", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = unidades;
            com.Parameters.Add(new NpgsqlParameter("@costo", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = costo;
            com.Parameters.Add(new NpgsqlParameter("@iva", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = iva;
            com.Parameters.Add(new NpgsqlParameter("@compra", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = compra;
            com.Parameters.Add(new NpgsqlParameter("@codbar", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = codbar;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = id;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion
        #region Guardar
        public DataSet guardar(string p_idfamilia, string descripcion, decimal costo, int unidades, decimal gastostransporte, int ganancia, string tipoiva, string tipocompra, decimal pvp, int stock, string idpadre,string codbar)
        {
            NpgsqlCommand com = new NpgsqlCommand("select insertar_producto  (@idfamilia  , @descripcion  , @costo  , @unidades , @gastostransporte  , @ganancia  , @tipoiva  ,@tipocompra  ,@pvp  , @stock ,@idpadre,@codbar)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idfamilia", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = p_idfamilia;
            com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
            com.Parameters.Add(new NpgsqlParameter("@costo", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = costo;
            com.Parameters.Add(new NpgsqlParameter("@unidades", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = unidades;
            com.Parameters.Add(new NpgsqlParameter("@gastostransporte", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = gastostransporte;
            com.Parameters.Add(new NpgsqlParameter("@ganancia", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = ganancia;
            com.Parameters.Add(new NpgsqlParameter("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = descripcion;
            com.Parameters.Add(new NpgsqlParameter("@tipoiva", NpgsqlTypes.NpgsqlDbType.Varchar, 12)).Value = tipoiva;
            com.Parameters.Add(new NpgsqlParameter("@tipocompra", NpgsqlTypes.NpgsqlDbType.Varchar, 12)).Value = tipocompra;
            com.Parameters.Add(new NpgsqlParameter("@pvp", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = pvp;
            com.Parameters.Add(new NpgsqlParameter("@stock", NpgsqlTypes.NpgsqlDbType.Integer, 5)).Value = stock;
            com.Parameters.Add(new NpgsqlParameter("@codbar", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = codbar;
            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpadre;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }


        #endregion
        #region cargar productos
        public DataSet borrarlistaprecioscategoria()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from listaprecios ", cn);
            com.CommandType = CommandType.Text;
            
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet listaprecioscategoria(string idpadre)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into listaprecios select idproducto,descripcion,pvp from productos where idpadre=@idpadre order by descripcion ", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpadre;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet listapreciostodox()
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into listaprecios select idproducto,descripcion,pvp from productos   order by idproducto ", cn);
            com.CommandType = CommandType.Text;
  
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet listaproductos()
        {
            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_listaprecios SELECT idproducto,familia, subfamilia , descripcion,pvp, CASE WHEN ganancia=25 THEN pvp WHEN ganancia =30  THEN pvp  WHEN ganancia =31  " +
  "THEN (costo*1.12)*(1.25)   WHEN ganancia =32  THEN  (costo*1.12)*(1.30)     WHEN ganancia =33  THEN (costo*1.12)*(1.30)     " +
  "WHEN ganancia =34  THEN (costo*1.12)*(1.30)     WHEN ganancia =35  THEN (costo*1.12)*(1.30)     WHEN ganancia =36  THEN (costo*1.12)*(1.30) " +
   "WHEN ganancia =37  THEN (costo*1.12)*(1.30)     WHEN ganancia =38  THEN (costo*1.12)*(1.30)     WHEN ganancia =39  THEN (costo*1.12)*(1.30)  " +
     "WHEN ganancia =40  THEN (costo*1.12)*(1.30)     WHEN ganancia =41  THEN (costo*1.12)*(1.30) " +
      "WHEN ganancia =42  THEN (costo*1.12)*(1.30)   WHEN ganancia =43  THEN (costo*1.12)*(1.30) " +
      "WHEN ganancia =44  THEN (costo*1.12)*(1.34) WHEN ganancia =45  THEN (costo*1.12)*(1.34)     WHEN ganancia =46  THEN (costo*1.12)*(1.34)  " +
       "WHEN ganancia =47  THEN (costo*1.12)*(1.34)     WHEN ganancia =48  THEN (costo*1.12)*(1.34)  WHEN ganancia =49  THEN (costo*1.12)*(1.34)    " +
  "      WHEN ganancia =50  THEN (costo*1.12)*(1.34)" +
    "          WHEN ganancia =40  THEN (costo*1.12)*(1.34)    END ,stock   FROM productos,familia    where stock >=1 and familia.idfamilia=productos.idfamilia order by familia  ,subfamilia,descripcion  ", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet listaproductosoRDENCODIGO()
        {


            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_listaprecios SELECT idproducto,familia, subfamilia , descripcion,pvp, CASE WHEN ganancia=25 THEN pvp WHEN ganancia =30  THEN pvp  WHEN ganancia =31  " +
"THEN (costo*1.12)*(1.25)   WHEN ganancia =32  THEN  (costo*1.12)*(1.30)     WHEN ganancia =33  THEN (costo*1.12)*(1.30)     " +
"WHEN ganancia =34  THEN (costo*1.12)*(1.30)     WHEN ganancia =35  THEN (costo*1.12)*(1.30)     WHEN ganancia =36  THEN (costo*1.12)*(1.30) " +
 "WHEN ganancia =37  THEN (costo*1.12)*(1.30)     WHEN ganancia =38  THEN (costo*1.12)*(1.30)     WHEN ganancia =39  THEN (costo*1.12)*(1.30)  " +
   "WHEN ganancia =40  THEN (costo*1.12)*(1.30)     WHEN ganancia =41  THEN (costo*1.12)*(1.30) " +
    "WHEN ganancia =42  THEN (costo*1.12)*(1.30)   WHEN ganancia =43  THEN (costo*1.12)*(1.30) " +
    "WHEN ganancia =44  THEN (costo*1.12)*(1.34) WHEN ganancia =45  THEN (costo*1.12)*(1.34)     WHEN ganancia =46  THEN (costo*1.12)*(1.34)  " +
     "WHEN ganancia =47  THEN (costo*1.12)*(1.34)     WHEN ganancia =48  THEN (costo*1.12)*(1.34)  WHEN ganancia =49  THEN (costo*1.12)*(1.34)    " +
"      WHEN ganancia =50  THEN (costo*1.12)*(1.34)" +
  "          WHEN ganancia =40  THEN (costo*1.12)*(1.34)    END ,stock   FROM productos,familia    where stock >=1 and familia.idfamilia=productos.idfamilia order by idproducto;", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet Borrarlistaproductos()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmp_listaprecios ", cn);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet
            cargarsuProd_parastock(string desc)
        {



            //NpgsqlCommand com = new NpgsqlCommand("select descripcion,pvp from productos where descripcion like @desc", cn);
            NpgsqlCommand com = new NpgsqlCommand("select idproducto,subfamilia,descripcion,pvp,stock,costo, ganancia,familia.idfamilia,familia.idpadre,codbar from familia,productos where  productos.idfamilia=  familia.idfamilia  and descripcion like @desc", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;

        }

        public DataSet 
            cargarsuProductosTodo(string desc)
        {


            //NpgsqlCommand com = new NpgsqlCommand("select descripcion,pvp from productos where descripcion like @desc", cn);
            NpgsqlCommand com = new NpgsqlCommand("select idproducto,subfamilia,descripcion,pvp,stock,costo, ganancia,unidades,gastostransporte,tipoiva,tipocompra ,familia.idfamilia,familia.idpadre,codbar from familia,productos where  productos.idfamilia=  familia.idfamilia  and descripcion like @desc", cn);
            //NpgsqlCommand com = new NpgsqlCommand("select idproducto,descripcion,pvp,stock,codbar from familia,productos where  productos.idfamilia=  familia.idfamilia  and descripcion =@desc", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        
        }
         
        public DataSet cargarsuProductosTodocodbar(string desc)
        {

           
                NpgsqlCommand com = new NpgsqlCommand("select idproducto,subfamilia,descripcion,pvp,stock,costo, ganancia,unidades,gastostransporte,tipoiva,tipocompra ,familia.idfamilia,familia.idpadre,codbar from familia,productos where  productos.idfamilia=  familia.idfamilia  and codbar =@desc", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", NpgsqlTypes.NpgsqlDbType.Varchar, 40)).Value = desc;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarsuProductosTodoxcodstock(string producto)
        {

            NpgsqlCommand com = new NpgsqlCommand("select idproducto,subfamilia,descripcion,pvp,stock,costo, ganancia,unidades,gastostransporte,tipoiva,tipocompra ,familia.idfamilia,familia.idpadre,codbar from familia,productos where  productos.idfamilia=  familia.idfamilia  and idproducto =@producto", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@producto", NpgsqlTypes.NpgsqlDbType.Varchar, 40)).Value = producto;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarsuProductosTodoxcod(string desc)
        {
            //búsqueda para en 
            NpgsqlCommand com = new NpgsqlCommand("select idproducto,subfamilia,descripcion,pvp,stock,costo, ganancia,unidades,gastostransporte,tipoiva,tipocompra ,familia.idfamilia,familia.idpadre,codbar from familia,productos where  productos.idfamilia=  familia.idfamilia  and idproducto like @desc", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarsuProductosNotaventa(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select idproducto,descripcion, ganancia,tipoiva,pvp,stock from familia,productos where  productos.idfamilia=  familia.idfamilia  and descripcion like @desc", cn);
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

            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,familia,esultima from familia where esultima = False order by familia", cn);
            com.CommandType = CommandType.Text;
            //com.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar, 20)).Value = titulo;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet usuario1(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,subfamilia from familia where familia=@desc order by subfamilia", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", NpgsqlTypes.NpgsqlDbType.Varchar, 50)).Value = desc;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarsubfamilia(string idpadre)
        {

            NpgsqlCommand com = new NpgsqlCommand("select idfamilia,idpadre,subfamilia,esultima from familia where esultima = true and idpadre = @idpadre order by subfamilia", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = idpadre;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet famProd()
        {
            //cargar Familia para la tabla productos
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
        #region CARGAR PRODUCTOS
        public DataSet cargarsuProductosg(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from productos where descripcion like @desc", cn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@desc", "%" + desc + "%"));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargar(string desc)
        {

            NpgsqlCommand com = new NpgsqlCommand("select * from productos where descripcion like @desc", cn);
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
        public DataSet eliminarProductos(string id)
        {

            NpgsqlCommand com = new NpgsqlCommand("delete  from productos where idproducto=@id", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 100)).Value = id;
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
