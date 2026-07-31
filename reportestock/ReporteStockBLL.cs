using System;
using System.Data;

namespace BRAMSELU.reportestock
{
    public class ReporteStockBLL
    {
        private ReporteStockDAL objDAL = new ReporteStockDAL();

        public DataTable ObtenerProductosStockBajo(int stockLimite)
        {
           
            if (stockLimite < 0)
            {
                stockLimite = 0;
            }

            return objDAL.ObtenerProductosStockBajo(stockLimite);
        }
    }
}