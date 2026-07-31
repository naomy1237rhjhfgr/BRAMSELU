using System;
using System.Data;

namespace BRAMSELU.reporteproductos
{
    public class ReporteProductosVendidosBLL
    {
        private ReporteProductosVendidosDAL objDAL = new ReporteProductosVendidosDAL();

        public DataTable ObtenerProductosMasVendidos(int topCantidad)
        {
           
            if (topCantidad <= 0)
            {
                topCantidad = 10;
            }

            return objDAL.ObtenerProductosMasVendidos(topCantidad);
        }
    }
}