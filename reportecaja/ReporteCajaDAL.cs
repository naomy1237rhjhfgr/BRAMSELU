using System;
using System.Data;

namespace BRAMSELU.reportecaja
{
    public class ReporteCajaDAL
    {
        private Conexion conexionObj = new Conexion();

        public DataTable ObtenerArqueoCajaPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            string query = $"SELECT IdCaja, FechaApertura, FechaCierre, MontoInicial, TotalVentasEfectivo, MontoFinal, Estado, UsuarioApertura, TotalCompras " +
                           $"FROM Cajas " +
                           $"WHERE FechaApertura >= '{fechaInicio:yyyy-MM-dd 00:00:00}' AND FechaApertura <= '{fechaFin:yyyy-MM-dd 23:59:59}' " +
                           $"ORDER BY FechaApertura DESC";

            return conexionObj.EjecutarConsultaDataTable(query);
        }
    }
}