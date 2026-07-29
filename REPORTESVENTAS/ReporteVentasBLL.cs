using System;
using System.Data;

namespace BRAMSELU.Ventas
{
    public class ReporteVentasBLL
    {
        private ReporteVentasDAL objDAL = new ReporteVentasDAL();

        public DataTable ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            return objDAL.ObtenerReporteVentas(fechaInicio, fechaFin);
        }
    }
}