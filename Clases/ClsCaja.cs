using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
namespace RaposoFact.Clases
{
    class ClsCaja:Clsconexion
    {

        public DataSet DepVecino(DateTime fecha)
        {
            NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from trx where fecha = @fecha and dor =-1  ", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet Depguay(DateTime fecha)
        {
            NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from trx_bus where fecha = @fecha and dor =-1  ", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet Retguay(DateTime fecha)
        {
            NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from trx_bus where fecha = @fecha and dor =1   ", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet RetVecino(DateTime fecha)
        {
            NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from trx where fecha = @fecha and dor =1   ", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet kxMiVecino(DateTime fecha)
        {
            NpgsqlCommand com = new NpgsqlCommand("Select T1.id,T1.dor,T1.fecha,T1.detalle,T1.valor, Sum(T2.valor*T2.dor) as Acumulado from trx T1 join trx T2 on (T1.id >= T2.id) where T1.fecha=@fecha Group By T1.id,T1.valor,T1.detalle,T1.dor,T1.fecha Order by id desc", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        //para trx_bus
        //*****************************************************

        public DataSet kxbus(DateTime fecha)
        {
            NpgsqlCommand com = new NpgsqlCommand("Select T1.id,T1.dor,T1.fecha,T1.detalle,T1.valor, Sum(T2.valor*T2.dor) as Acumulado from trx_bus T1 join trx_bus T2 on (T1.id >= T2.id) where T1.fecha=@fecha Group By T1.id,T1.valor,T1.detalle,T1.dor,T1.fecha Order by id desc", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        //para trx_pichincha
        //para trx_pichincha
        //*****************************************************

        public DataSet kxMiguay(DateTime fecha)
        {
            NpgsqlCommand com = new NpgsqlCommand("Select T1.id,T1.dor,T1.fecha,T1.detalle,T1.valor, Sum(T2.valor*T2.dor) as Acumulado from trx_guay T1 join trx_guay T2 on (T1.id >= T2.id) where T1.fecha=@fecha Group By T1.id,T1.valor,T1.detalle,T1.dor,T1.fecha Order by id desc", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
       
        //para trx_pichincha
        //*****************************************************//
        public DataSet verificararqueo(DateTime fecha)
        {
            NpgsqlCommand com = new NpgsqlCommand("select count(retiro)  from arqueo where fecha=@fecha ", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet borrarimprimirarqueo()
        {
            //recargas ingresadas por el usuario
            NpgsqlCommand com = new NpgsqlCommand("delete from imparqueo", cn);
            com.CommandType = CommandType.Text;

       
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet trx(DateTime fecha,string detalle, double valor, decimal deporet)
        {
            //recargas ingresadas por el usuario
            NpgsqlCommand com = new NpgsqlCommand("insert into trx(fecha, detalle, valor, dor)VALUES(@fecha1,@detalle1,@valor1,@deporet1)", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha1", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@detalle1", NpgsqlTypes.NpgsqlDbType.Varchar )).Value = detalle;
            com.Parameters.Add(new NpgsqlParameter("@valor1", NpgsqlTypes.NpgsqlDbType.Double)).Value = valor;
            com.Parameters.Add(new NpgsqlParameter("@deporet1", NpgsqlTypes.NpgsqlDbType.Double)).Value = deporet;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet trx_guay(DateTime fecha, string detalle, double valor, decimal deporet)
        {
            //BANCO GUAYAQUIL
            //recargas ingresadas por el usuario
            NpgsqlCommand com = new NpgsqlCommand("insert into trx_guay(fecha, detalle, valor, dor)VALUES(@fecha1,@detalle1,@valor1,@deporet1)", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha1", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@detalle1", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = detalle;
            com.Parameters.Add(new NpgsqlParameter("@valor1", NpgsqlTypes.NpgsqlDbType.Double)).Value = valor;
            com.Parameters.Add(new NpgsqlParameter("@deporet1", NpgsqlTypes.NpgsqlDbType.Double)).Value = deporet;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet trx_bus(DateTime fecha, string detalle, double valor, decimal deporet)
        {
            //BANCO GUAYAQUIL
            //recargas ingresadas por el usuario
            NpgsqlCommand com = new NpgsqlCommand("insert into trx_bus(fecha, detalle, valor, dor)VALUES(@fecha1,@detalle1,@valor1,@deporet1)", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha1", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@detalle1", NpgsqlTypes.NpgsqlDbType.Varchar)).Value = detalle;
            com.Parameters.Add(new NpgsqlParameter("@valor1", NpgsqlTypes.NpgsqlDbType.Double)).Value = valor;
            com.Parameters.Add(new NpgsqlParameter("@deporet1", NpgsqlTypes.NpgsqlDbType.Double)).Value = deporet;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet imprimirarqueo(DateTime fecha)
        {
            //recargas ingresadas por el usuario
            NpgsqlCommand com = new NpgsqlCommand("insert into imparqueo(Select * from arqueo where fecha=@fecha)", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargararqueo(DateTime fecha)
        {
            //recargas ingresadas por el usuario
            NpgsqlCommand com = new NpgsqlCommand("Select * from arqueo where fecha=@fecha", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet guardararqueo(string usuario, DateTime fecha, decimal cajainicial, decimal arqueo, decimal totalventas, decimal faltante, decimal sobrante, decimal retiro, decimal saldocaja, decimal depositos, decimal extracciones, decimal totaldia, decimal totaldiasum)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select insertar_arqueocaja(@usuario,@fecha  , @cajainicial  , @cajacierre  , @totalventas , @faltante  , @sobrante,@retiro,@saldocaja,@depositos ,  @extracciones ,  @totaldia,  @totaldiasum  )", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cajainicial", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajainicial;
            com.Parameters.Add(new NpgsqlParameter("@cajacierre", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = arqueo;
            com.Parameters.Add(new NpgsqlParameter("@totalventas", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = totalventas;
            com.Parameters.Add(new NpgsqlParameter("@faltante", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = faltante;
            com.Parameters.Add(new NpgsqlParameter("@sobrante", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = sobrante;
            com.Parameters.Add(new NpgsqlParameter("@retiro", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = retiro;
            com.Parameters.Add(new NpgsqlParameter("@saldocaja", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = saldocaja;
            com.Parameters.Add(new NpgsqlParameter("@depositos", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = depositos;
            com.Parameters.Add(new NpgsqlParameter("@extracciones", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = extracciones;
            com.Parameters.Add(new NpgsqlParameter("@totaldia", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = totaldia;
            com.Parameters.Add(new NpgsqlParameter("@totaldiasum", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = totaldiasum;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet actualizararqueo(string id, string usuario, DateTime fecha, decimal cajainicial, decimal arqueo, decimal totalventas, decimal faltante, decimal sobrante, decimal retiro, decimal saldocaja, decimal depositos, decimal extracciones, decimal totaldia, decimal totaldiasum)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("update  arqueo set usuario=@usuario  , cajainicial=@cajainicial  , cajacierre=@cajacierre  ,totalventas= @totalventas , faltante=@faltante  ,sobrante= @sobrante,retiro=@retiro,saldocaja=@saldocaja,depositos=@depositos , extracciones= @extracciones , totaldia= @totaldia, totaldiasum= @totaldiasum  where fecha=@fecha  ", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = id;
            com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cajainicial", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajainicial;
            com.Parameters.Add(new NpgsqlParameter("@cajacierre", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = arqueo;
            com.Parameters.Add(new NpgsqlParameter("@totalventas", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = totalventas;
            com.Parameters.Add(new NpgsqlParameter("@faltante", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = faltante;
            com.Parameters.Add(new NpgsqlParameter("@sobrante", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = sobrante;
            com.Parameters.Add(new NpgsqlParameter("@retiro", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = retiro;
            com.Parameters.Add(new NpgsqlParameter("@saldocaja", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = saldocaja;
            com.Parameters.Add(new NpgsqlParameter("@depositos", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = depositos;
            com.Parameters.Add(new NpgsqlParameter("@extracciones", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = extracciones;
            com.Parameters.Add(new NpgsqlParameter("@totaldia", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = totaldia;
            com.Parameters.Add(new NpgsqlParameter("@totaldiasum", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = totaldiasum;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        #region cargar
        public DataSet cargarTotalRecargas(DateTime fecha)
        {
            //recargas ingresadas por el usuario
            NpgsqlCommand com = new NpgsqlCommand("Select sum(total) ,(select sum(total)  from notaventa  where fecha=@fecha  AND idproducto='00001'),(select sum(total)  from notaventa  where fecha=@fecha AND idproducto='00002')  from notaventa where fecha=@fecha and idproducto='00003'  ", cn);            //NpgsqlCommand com = new NpgsqlCommand("select sum(total) from notaventa where fecha=@fecha AND idproducto<>'00031' and idproducto <>'00029' and idproducto <>'00030'", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarTotalRecargasIMPORTEs(DateTime fecha)
        {
            //recargas sacadas del reporte del sistema de regarcas respectivamente
            NpgsqlCommand com = new NpgsqlCommand("Select sum(total) ,(select sum(total)  from notaventa  where fecha=@fecha  AND idproducto='00415'),(select sum(total)  from notaventa  where fecha=@fecha AND idproducto='00416')  from notaventa where fecha=@fecha and idproducto='00417'  ", cn);            //NpgsqlCommand com = new NpgsqlCommand("select sum(total) from notaventa where fecha=@fecha AND idproducto<>'00031' and idproducto <>'00029' and idproducto <>'00030'", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }

        public DataSet borrarimprimirventa()
        {
            //imprimirventa diaria  por detalle 
            NpgsqlCommand com = new NpgsqlCommand("delete from tmprepdiariovenas ", cn);
            //NpgsqlCommand com = new NpgsqlCommand("insert into tmprepdiariovenas (select sum(total)as Ventas ,(select total from  notaventa where fecha='09/09/2012' and idproducto='00415')+(select total from  notaventa where fecha='09/09/2012' and idproducto='00416') +(select total from  notaventa where fecha='09/09/2012' and idproducto='00417')as recargas, (select total from notaventa where fecha='09/09/2012' and idproducto='00400') as Internet,(select sum(total) from notaventa where fecha='09/09/2012' and idproducto<>'00415' and idproducto<>'00416' and idproducto<>'00417' and idproducto<>'00400')as Ventas from  notaventa where fecha='09/09/2012')", cn);
            com.CommandType = CommandType.Text;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet imprimirventa(DateTime fecha)
        {
            //imprimirventa diaria  por detalle 
            NpgsqlCommand com = new NpgsqlCommand("insert into tmprepdiariovenas (select sum(total)as Ventas ,(select total from  notaventa where fecha=@fecha and idproducto='00415')+(select total from  notaventa where fecha=@fecha and idproducto='00416') +(select total from  notaventa where fecha=@fecha and idproducto='00417'), (select total from notaventa where fecha=@fecha and idproducto='00400'),(select sum(total) from notaventa where fecha=@fecha and idproducto<>'00415' and idproducto<>'00416' and idproducto<>'00417' and idproducto<>'00400' AND idproducto<>'00031' and idproducto <>'00029' and idproducto <>'00030') from  notaventa where fecha=@fecha AND idproducto<>'00031' and idproducto <>'00029' and idproducto <>'00030')", cn);
            //NpgsqlCommand com = new NpgsqlCommand("insert into tmprepdiariovenas (select sum(total)as Ventas ,(select total from  notaventa where fecha='09/09/2012' and idproducto='00415')+(select total from  notaventa where fecha='09/09/2012' and idproducto='00416') +(select total from  notaventa where fecha='09/09/2012' and idproducto='00417')as recargas, (select total from notaventa where fecha='09/09/2012' and idproducto='00400') as Internet,(select sum(total) from notaventa where fecha='09/09/2012' and idproducto<>'00415' and idproducto<>'00416' and idproducto<>'00417' and idproducto<>'00400')as Ventas from  notaventa where fecha='09/09/2012')", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarDetalleRetiros(DateTime fecha)
        {
            //detalle de retisos 
            NpgsqlCommand com = new NpgsqlCommand("select retiro, nota from caja where fecha =@fecha and retiro<>0", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarDetalleingresos(DateTime fecha)
        {
            //detalle de retisos 
            NpgsqlCommand com = new NpgsqlCommand("select deposito, nota from caja where fecha =@fecha and deposito<>0", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarCajaInicial(DateTime fecha)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select sum(cajainicial) from caja where fecha=@fecha and nota='Saldo Inicial'", cn);

            com.CommandType = CommandType.Text;
            
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarTotalVentas(DateTime fecha)
        {
            //valor recaudado en ventas
            NpgsqlCommand com = new NpgsqlCommand("select sum (pvp) from notaventa where fecha=@fecha", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarTotalCaja(DateTime fecha)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("SELECT sum(cajainicial) ,  sum(vrecaudado)as totalventas,sum(deposito)as deposito, sum (retiro)as retiro,(sum(cajainicial)+ sum (deposito) +sum(vrecaudado)) - sum (retiro)as SaldoEncaja FROM CAJA WHERE fecha=@fecha", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Close();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarTotalConsumo(DateTime fecha)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select sum(total) from notaventa where fecha=@fecha  and idproducto<>'00415' and idproducto<>'00416'and idproducto<>'00417'", cn);
            //NpgsqlCommand com = new NpgsqlCommand("select sum(total) from notaventa where fecha=@fecha AND idproducto<>'00031' and idproducto <>'00029' and idproducto <>'00030'", cn);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarVerificarCajainicial(DateTime fecha)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select count(cajainicial)  from caja where cajainicial<>0 and fecha=@fecha AND nota='Saldo Inicial'", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet cargarVerificarCajafinal(DateTime fecha)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select count(cajafinal)  from caja where cajafinal<>0 and fecha=@fecha AND nota='Saldo Final'", cn);

            com.CommandType = CommandType.Text;

            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
#endregion
        #region Guardar
        public DataSet guardarCajaInicial(string usuario, DateTime fecha, decimal cajainicial, decimal retiro, decimal deposito, decimal vrecaudado, string nota, decimal cajafinal)
        {
         //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select insertar_caja  (@usuario,@fecha  , @cajainicial  , @retiro  , @deposito , @vrecaudado  , @nota,@cajafinal)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cajainicial", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajainicial;
            com.Parameters.Add(new NpgsqlParameter("@retiro", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = retiro;
            com.Parameters.Add(new NpgsqlParameter("@deposito", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = deposito;
            com.Parameters.Add(new NpgsqlParameter("@vrecaudado", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = vrecaudado;
            com.Parameters.Add(new NpgsqlParameter("@nota", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = nota;
            com.Parameters.Add(new NpgsqlParameter("@cajafinal", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajafinal;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet guardarCajafinal(string usuario, DateTime fecha, decimal cajainicial, decimal retiro, decimal deposito, decimal vrecaudado, string nota,decimal cajafinal)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("select insertar_caja  (@usuario,@fecha  , @cajainicial  , @retiro  , @deposito , @vrecaudado  , @nota,@cajafinal)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cajainicial", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajainicial;
            com.Parameters.Add(new NpgsqlParameter("@retiro", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = retiro;
            com.Parameters.Add(new NpgsqlParameter("@deposito", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = deposito;
            com.Parameters.Add(new NpgsqlParameter("@vrecaudado", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = vrecaudado;
            com.Parameters.Add(new NpgsqlParameter("@nota", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = nota;
            com.Parameters.Add(new NpgsqlParameter("@cajafinal", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajafinal;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet updatecierrecaja(DateTime fecha, decimal cajafinal, string nota)
        {
            //saldo inicial
            NpgsqlCommand com = new NpgsqlCommand("update caja set cajafinal= @cajafinal  where fecha=@fecha and   nota='Saldo Final' ", cn);

            com.CommandType = CommandType.Text;
                        com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
                        com.Parameters.Add(new NpgsqlParameter("@cajafinal", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajafinal;
            com.Parameters.Add(new NpgsqlParameter("@nota", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = nota;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet guardarRetiros(string usuario, DateTime fecha, decimal cajainicial, decimal retiro, decimal deposito, decimal vrecaudado, string nota,decimal cajafinal)
        {
            //registrar los retiros
            NpgsqlCommand com = new NpgsqlCommand("select insertar_caja  (@usuario,@fecha  , @cajainicial  , @retiro  , @deposito , @vrecaudado  , @nota,@cajafinal)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cajainicial", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajainicial;
            com.Parameters.Add(new NpgsqlParameter("@retiro", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = retiro;
            com.Parameters.Add(new NpgsqlParameter("@deposito", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = deposito;
            com.Parameters.Add(new NpgsqlParameter("@vrecaudado", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = vrecaudado;
            com.Parameters.Add(new NpgsqlParameter("@nota", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = nota;
            com.Parameters.Add(new NpgsqlParameter("@cajafinal", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajafinal;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet guardarBwise(string usuario, DateTime fecha, decimal cajainicial, decimal retiro, decimal deposito, decimal vrecaudado, string nota, decimal cajafinal,decimal bwise,decimal pclaro,decimal xy)
        {
            //registrar los retiros
            NpgsqlCommand com = new NpgsqlCommand("select insertar_caja  (@usuario,@fecha  , @cajainicial  , @retiro  , @deposito , @vrecaudado  , @nota,@cajafinal,@bwise,@pclaro,@xy)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cajainicial", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajainicial;
            com.Parameters.Add(new NpgsqlParameter("@retiro", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = retiro;
            com.Parameters.Add(new NpgsqlParameter("@deposito", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = deposito;
            com.Parameters.Add(new NpgsqlParameter("@vrecaudado", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = vrecaudado;
            com.Parameters.Add(new NpgsqlParameter("@nota", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = nota;
            com.Parameters.Add(new NpgsqlParameter("@cajafinal", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajafinal;
            com.Parameters.Add(new NpgsqlParameter("@bwise", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = bwise;
            com.Parameters.Add(new NpgsqlParameter("@pclaro", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = pclaro;
            com.Parameters.Add(new NpgsqlParameter("@xy", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = xy;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        //public DataSet guardarCajafinal(string usuario, DateTime fecha, decimal cajainicial, decimal retiro, decimal deposito, decimal vrecaudado, string nota,decimal cajafinal)
        //{
        //    //registrar los retiros
        //    NpgsqlCommand com = new NpgsqlCommand("select insertar_caja  (@usuario,@fecha  , @cajainicial  , @retiro  , @deposito , @vrecaudado  , @nota,@cajafinal)", cn);

        //    com.CommandType = CommandType.Text;
        //    com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
        //    com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
        //    com.Parameters.Add(new NpgsqlParameter("@cajainicial", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajainicial;
        //    com.Parameters.Add(new NpgsqlParameter("@retiro", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = retiro;
        //    com.Parameters.Add(new NpgsqlParameter("@deposito", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = deposito;
        //    com.Parameters.Add(new NpgsqlParameter("@vrecaudado", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = vrecaudado;
        //    com.Parameters.Add(new NpgsqlParameter("@nota", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = nota;
        //    com.Parameters.Add(new NpgsqlParameter("@cajafinal", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajafinal;
        //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
        //    DataSet dd = new DataSet();
        //    cn.Open();
        //    da.Fill(dd);
        //    cn.Close();
        //    return dd;
        //}
        public DataSet guardardepositos(string usuario, DateTime fecha, decimal cajainicial, decimal retiro, double deposito, decimal vrecaudado, string nota,decimal cajafinal)
        {
            //registrar los depositos o ingresos a caja
            NpgsqlCommand com = new NpgsqlCommand("select insertar_caja  (@usuario,@fecha  , @cajainicial  , @retiro  , @deposito , @vrecaudado  , @nota,@cajafinal)", cn);

            com.CommandType = CommandType.Text;
            com.Parameters.Add(new NpgsqlParameter("@usuario", NpgsqlTypes.NpgsqlDbType.Varchar, 5)).Value = usuario;
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@cajainicial", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajainicial;
            com.Parameters.Add(new NpgsqlParameter("@retiro", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = retiro;
     
            com.Parameters.Add(new NpgsqlParameter("@deposito", NpgsqlTypes.NpgsqlDbType.Double)).Value = deposito;
            com.Parameters.Add(new NpgsqlParameter("@vrecaudado", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = vrecaudado;
            com.Parameters.Add(new NpgsqlParameter("@nota", NpgsqlTypes.NpgsqlDbType.Varchar, 75)).Value = nota;
            com.Parameters.Add(new NpgsqlParameter("@cajafinal", NpgsqlTypes.NpgsqlDbType.Double, 6)).Value = cajafinal;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataSet dd = new DataSet();
            cn.Open();
            da.Fill(dd);
            cn.Close();
            return dd;
        }
        public DataSet guardarvtotal(DateTime fecha, decimal valor)
        {
            //registrar los depositos o ingresos a caja
            NpgsqlCommand com = new NpgsqlCommand("UPDATE CAJA SET VRECAUDADO=@valor WHERE fecha=@fecha AND nota='Saldo Inicial'", cn);

            com.CommandType = CommandType.Text;
            
            com.Parameters.Add(new NpgsqlParameter("@fecha", NpgsqlTypes.NpgsqlDbType.Date)).Value = fecha;
            com.Parameters.Add(new NpgsqlParameter("@valor", NpgsqlTypes.NpgsqlDbType.Double)).Value = valor;
 

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
