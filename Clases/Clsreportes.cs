using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
namespace RaposoFact.Clases
{
    class Clsreportes:Clsconexion
    {
        #region factura
        public DataSet insertstock0(string idpadre)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmprepstock0 select distinct familia,descripcion,stock from productos,familia where stock<=1 and familia.idpadre=@idpadre  and familia.idpadre=productos.idpadre order by stock , descripcion", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = idpadre;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrarstock0()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmprepstock0 ", cn);

            com.CommandType = CommandType.Text;
             NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet stock0(string idpadre)
        {

            NpgsqlCommand com = new NpgsqlCommand("select distinct descripcion,familia from productos,familia where stock<=1 and familia.idpadre=@idpadre  and familia.idpadre=productos.idpadre", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = idpadre;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrartmpfactura()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmpfactura", cn);

            com.CommandType = CommandType.Text;

            
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        //public DataSet xnumfactura(string id)
        //{

        //    NpgsqlCommand com = new NpgsqlCommand("insert into tmp_rep_notaventa ( select  distinct numero,idcliente,clie_nombre,clie_ruc,clie_direccion,clie_telefono, productos.idproducto,cantidad,productos.descripcion, round(cast(precio as numeric),2),round(cast(ptotal as numeric),2), iva0,iva12,subtotal,impuesto, round(cast(total as numeric),2) , factura.fecha  from factura, detalle ,productos,cliente where  factura.numero=@id and numero =detalle.idfactura  and productos.idproducto=detalle.idproducto  and clie_codigo=idcliente)", cn);

        //    com.CommandType = CommandType.Text;

        //    com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = id;


        //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
        //    DataSet dd = new DataSet();
        //    cn.Open();
        //    da.Fill(dd);
        //    cn.Close();
        //    return dd;
        //}
        public DataSet xnumfactura(string id)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmpfactura (select  distinct numero,idcliente,clie_nombre,clie_ruc,clie_direccion,clie_telefono, productos.idproducto,cantidad,productos.descripcion, precio,ptotal, iva0,iva12,subtotal,impuesto, total , factura.fecha  from factura, detalle ,productos,cliente where  factura.numero=@id and numero =detalle.idfactura  and productos.idproducto=detalle.idproducto  and clie_codigo=idcliente  )", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = id;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet xnumfacturapeq(string id)
        {
            //para imprimir la factura peq
            NpgsqlCommand com = new NpgsqlCommand("select  distinct numero,idcliente,clie_nombre,clie_ruc,clie_direccion,clie_telefono, productos.idproducto,cantidad,productos.descripcion, round(cast(precio as numeric),2),round(cast(ptotal as numeric),2), iva0,iva12,subtotal,impuesto, round(cast(total as numeric),2) , factura.fecha  from factura, detalle ,productos,cliente where  factura.numero=@id and numero =detalle.idfactura  and productos.idproducto=detalle.idproducto  and clie_codigo=idcliente", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = id;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet reportestock(string id)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_reportestock (select idproducto,descripcion,stock from productos where idpadre=@id order by descripcion)", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = id;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrarreportestock()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmp_reportestock ", cn);

            com.CommandType = CommandType.Text;

            


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet reportestockmin(string id)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_reportestock (select idproducto,descripcion,stock from productos where IDFAMILIA=@id order by stock)", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = id;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrarreportestockmin()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmp_reportestock ", cn);

            com.CommandType = CommandType.Text;




            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion
        # region deudas

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
        # region FacturasCompras
        public DataSet borrarFacturasCompras()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmp_factura_compras ", cn);

            com.CommandType = CommandType.Text;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet FacturasCompras(DateTime fecha,DateTime fecha1)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_factura_compras ( select p.pro_codigo,p.pro_nombre,pro_ruc,fecha,factura,autorizacion,fechacaducidad,iva0,sub12,iva,total from proveedor p , factura_compras  f where p.pro_codigo=f.id_proveedor and fecha between @fecha and @fecha1)", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@fecha1", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha1;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        #endregion
        # region NotaVenta
        public DataSet nvxfecha(DateTime fecha)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_rep_notaventa ( select id, idproducto,fecha,cantidad,descripcion, pvp, total from notaventa where fecha=@fecha and idproducto<>'00415')", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet nvxnumnotaventadia(string id)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_rep_notaventa ( select * from tmpnotaventa)", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = id;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet nvxnumnotaventa(string id)
        {
            //reporte de todo el día de venta
            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_rep_notaventa ( select id, idproducto,fecha,cantidad,descripcion, pvp, total from notaventa where id=@id)", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = id;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet nvxnumero(DateTime fecha)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_rep_notaventa ( select id, idproducto,fecha,cantidad,descripcion, pvp, total from notaventa where fecha=@fecha)", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet BorrarTmpnvxfecha()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmp_rep_notaventa", cn);

            com.CommandType = CommandType.Text;
           NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
       //sacar reporte por categoria
        public DataSet notaventaxcat(string idpadre,DateTime fecha)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_rep_notaventa ( select productos.idpadre,productos.idpadre, notaventa.fecha ,productos.idpadre,productos.idpadre,productos.idpadre, sum(notaventa.total) from notaventa, productos  where notaventa.idproducto= productos.idproducto and notaventa.idproducto<>'00415' and productos.idpadre=@idpadre and notaventa.fecha between '01-01-2015' and '31-01-2015'  group by productos.idpadre,productos.idpadre, notaventa.fecha ,productos.idpadre,productos.idpadre,productos.idpadre order by notaventa.fecha)", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@idpadre", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = idpadre;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;


            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        //sacar reporte por mes
        public DataSet repxmes( DateTime fecha, DateTime fecha1)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into reportemes(Select sum(total) cabina " +
",(select sum(total)  from notaventa,productos  where  notaventa.fecha between @fecha and @fecha1   and productos.idpadre='0001' and notaventa.idproducto= productos.idproducto )bazar " +
",(select sum(total)  from notaventa,productos  where notaventa.fecha between @fecha and @fecha1  and productos.idpadre='0002' and notaventa.idproducto= productos.idproducto )bisuteria " +
",(select sum(total)  from notaventa,productos  where notaventa.fecha between @fecha and @fecha1  and productos.idpadre='0003' and notaventa.idproducto= productos.idproducto )cosmeticos " +
",(select sum(total)  from notaventa,productos  where notaventa.fecha between @fecha and @fecha1   and productos.idpadre='0006' and notaventa.idproducto= productos.idproducto )papeleria " +
",(select sum(total)  from notaventa,productos  where notaventa.fecha between @fecha and @fecha1   and productos.idpadre='0051' and notaventa.idproducto= productos.idproducto and idfamilia='0062')copias " +
",(select sum(total)  from notaventa,productos  where notaventa.fecha between @fecha and @fecha1   and productos.idpadre='0022' and notaventa.idproducto= productos.idproducto and productos.idproducto <>'00001' and productos.idproducto <>'00002' )tecnologia " +
",(select sum(total)  from notaventa,productos  where notaventa.fecha between @fecha and @fecha1   and productos.idpadre='0051' and notaventa.idproducto= productos.idproducto and productos.idproducto <>'00003' and idfamilia='0053' )servicios " +
",(select sum(total)  from notaventa,productos  where notaventa.fecha between @fecha and @fecha1   and productos.idpadre='0058' and notaventa.idproducto= productos.idproducto )golosinas " +
",(select sum(total)  from notaventa  where fecha between @fecha and @fecha1   AND idproducto='00001')movistar,(select sum(total)   " +
"from notaventa  where fecha between @fecha and @fecha1  AND idproducto='00002')claro  from notaventa where fecha between @fecha and @fecha1  and idproducto='00003'  )", cn);

            com.CommandType = CommandType.Text;

            
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;

            com.Parameters.Add(new NpgsqlParameter("@fecha1", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha1;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        //borrar
        public DataSet borrarrepxmes()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from reportemes ", cn);

            com.CommandType = CommandType.Text;
               
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet borrartmp_ventasxcant()
        {

            NpgsqlCommand com = new NpgsqlCommand("delete from tmp_ventasxcant ", cn);

            com.CommandType = CommandType.Text;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet insert_tmp_ventasxcant(DateTime fecha1, DateTime fecha2)
        {

            NpgsqlCommand com = new NpgsqlCommand("insert into tmp_ventasxcant (SELECT IDPRODUCTO, sum(cantidad) as cantidad, descripcion FROM  NOTAVENTA WHERE    FECHA  BETWEEN @fecha1   AND @fecha2 gROUP BY IDPRODUCTO, descripcion order by cantidad desc)", cn);

            com.CommandType = CommandType.Text;


            com.Parameters.Add(new NpgsqlParameter("@fecha1", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha1;

            com.Parameters.Add(new NpgsqlParameter("@fecha2", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha2;
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
