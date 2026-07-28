using System;
using System.Data;

namespace BRAMSELU.Ventas
{
    public class ReporteComprasDAL
    {
        private Conexion conexionDB = new Conexion();

        public DataTable ObtenerReporteCompras(DateTime fechaInicio, DateTime fechaFin)
        {
            string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaFinStr = fechaFin.ToString("yyyy-MM-dd HH:mm:ss");

            string query = @"SELECT 
                                co.IdCompra, 
                                co.Fecha, 
                                pr.NombreEmpresa, 
                                pr.Contacto, 
                                pr.Telefono, 
                                co.Total 
                             FROM Compras co 
                             INNER JOIN Proveedores pr ON co.IdProveedor = pr.IdProveedor 
                             WHERE co.Fecha BETWEEN '" + fechaInicioStr + "' AND '" + fechaFinStr + "'";

            return conexionDB.EjecutarConsultaDataTable(query);
        }
    }
}