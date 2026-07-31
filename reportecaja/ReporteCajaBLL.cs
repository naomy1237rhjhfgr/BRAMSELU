using System;
using System.Data;

namespace BRAMSELU.reportecaja
{
    public class ReporteCajaBLL
    {
        private ReporteCajaDAL objDAL = new ReporteCajaDAL();

        public DataTable ObtenerArqueoCajaPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                throw new Exception("La fecha de inicio no puede ser mayor que la fecha final.");
            }

            return objDAL.ObtenerArqueoCajaPorFecha(fechaInicio, fechaFin);
        }
    }
}