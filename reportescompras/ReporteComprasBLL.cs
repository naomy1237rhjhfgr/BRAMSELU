using System;
using System.Data;

namespace BRAMSELU.Ventas
{
    public class ReporteComprasBLL
    {
        private ReporteComprasDAL objDAL = new ReporteComprasDAL();

        public DataTable ObtenerReporteCompras(DateTime fechaInicio, DateTime fechaFin)
        {
            return objDAL.ObtenerReporteCompras(fechaInicio, fechaFin);
        }
    }
}