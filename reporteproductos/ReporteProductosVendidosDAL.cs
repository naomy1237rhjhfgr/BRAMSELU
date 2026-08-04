using System;
using System.Data;

namespace BRAMSELU.reporteproductos
{
    public class ReporteProductosVendidosDAL
    {
        private Conexion conexionObj = new Conexion();

        public DataTable ObtenerProductosMasVendidos(int topCantidad)
        {
            string query = $"SELECT TOP ({topCantidad}) " +
                           $"p.IdProducto, " +
                           $"p.NombreProducto, " +
                           $"p.Marca, " +
                           $"p.Categoria, " +
                           $"SUM(dv.Cantidad) AS CantidadVendidaTotal, " +
                           $"SUM(dv.Subtotal) AS TotalIngresos " +
                           $"FROM DetalleVenta dv " +
                           $"INNER JOIN Productos p ON dv.IdProducto = p.IdProducto " +
                           $"GROUP BY p.IdProducto, p.NombreProducto, p.Marca, p.Categoria " +
                           $"ORDER BY CantidadVendidaTotal DESC";

            return conexionObj.EjecutarConsultaDataTable(query);
        }
    }
}