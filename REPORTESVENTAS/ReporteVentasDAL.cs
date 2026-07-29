using System;
using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU.Ventas
{
    public class ReporteVentasDAL
    {
        private Conexion conexionDB = new Conexion();

        public DataTable ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaFinStr = fechaFin.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "SELECT v.IdVenta, v.FechaVenta, v.Total, v.EfectivoRecibido, v.Cambio, c.IdCaja FROM Ventas v INNER JOIN Cajas c ON v.IdCaja = c.IdCaja WHERE v.FechaVenta BETWEEN '" + fechaInicioStr + "' AND '" + fechaFinStr + "'";

            return conexionDB.EjecutarConsultaDataTable(query);
        }
    }
}