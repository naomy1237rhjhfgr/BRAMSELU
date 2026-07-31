using System;
using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU.reportestock
{
    public class ReporteStockDAL
    {
        private Conexion conexionObj = new Conexion();

        public DataTable ObtenerProductosStockBajo(int stockLimite)
        {
            string query = $"SELECT IdProducto, NombreProducto, Marca, Categoria, Precio, Stock " +
                           $"FROM Productos " +
                           $"WHERE Stock <= {stockLimite} " +
                           $"ORDER BY Stock ASC";

            return conexionObj.EjecutarConsultaDataTable(query);
        }
    }
}