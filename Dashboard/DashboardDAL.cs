using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BRAMSELU
{
    public class DashboardDAL
    {
        private readonly string cadenaConexion =
            "Server=localhost;Database=BRAMSELU;Integrated Security=True;TrustServerCertificate=True;";

        public DashboardModel ObtenerEstadisticas()
        {
            DashboardModel datos = new DashboardModel();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = @"
                    SELECT
                        (SELECT COUNT(*) FROM Clientes) AS TotalClientes,
                        (SELECT COUNT(*) FROM Empleados WHERE Estado = 1) AS EmpleadosActivos,
                        (SELECT ISNULL(SUM(Stock), 0) FROM Productos) AS ProductosInventario,
                        (SELECT COUNT(*) FROM Categorias) AS CategoriasActivas,
                        (SELECT COUNT(*) FROM Ventas WHERE CAST(FechaVenta AS DATE) = CAST(GETDATE() AS DATE)) AS VentasDelDia,
                        (SELECT ISNULL(SUM(Total), 0) FROM Ventas WHERE CAST(FechaVenta AS DATE) = CAST(GETDATE() AS DATE)) AS IngresosDelDia,
                        (SELECT COUNT(*) FROM Citas WHERE Fecha = CAST(GETDATE() AS DATE) AND Estado != 'Cancelada') AS CitasDelDia;";
                        

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            datos.TotalClientes = Convert.ToInt32(reader["TotalClientes"]);
                            datos.EmpleadosActivos = Convert.ToInt32(reader["EmpleadosActivos"]);
                            datos.ProductosInventario = Convert.ToInt32(reader["ProductosInventario"]);
                            datos.CategoriasActivas = Convert.ToInt32(reader["CategoriasActivas"]);
                            datos.VentasDelDia = Convert.ToInt32(reader["VentasDelDia"]);
                            datos.IngresosDelDia = Convert.ToDecimal(reader["IngresosDelDia"]);
                            datos.CitasDelDia = Convert.ToInt32(reader["CitasDelDia"]);

                       
                            datos.ReportesDisponibles = 6;
                        }
                    }
                }
            }

            return datos;
        }
        public DataTable ObtenerProductosStockBajo(int limiteStock = 5)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {

                string query = @"
                    SELECT 
                        NombreProducto AS [Producto], 
                        Marca AS [Marca],
                        ISNULL(Categoria, 'Sin Cat.') AS [Categoría], 
                        Stock AS [Stock]
                    FROM Productos 
                    WHERE Stock <= @Limite 
                    ORDER BY Stock ASC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Limite", limiteStock);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
        public DataTable ObtenerUltimasVentas(int limite = 10)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Muestra las últimas 'N' ventas del día ordenadas de la más reciente a la más antigua
                string query = @"
                    SELECT TOP (@Limite)
                        IdVenta AS [N° Venta],
                        FORMAT(FechaVenta, 'hh:mm tt') AS [Hora],
                        Total AS [Total]
                    FROM Ventas
                    WHERE CAST(FechaVenta AS DATE) = CAST(GETDATE() AS DATE)
                    ORDER BY FechaVenta DESC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Limite", limite);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
  
    }
}