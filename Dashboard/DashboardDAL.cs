using System;
using System.Data.SqlClient;

namespace BRAMSELU
{
    public class DashboardDAL
    {
        private readonly string cadenaConexion =
            "Server=localhost;Database=BRAMSELU;Integrated Security=True;TrustServerCertificate=True;";

        public int[] ObtenerEstadisticas()
        {
            int clientes = 0;
            int empleados = 0;
            int productos = 0;
            int stock = 0;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = @"
                    SELECT
                        (SELECT COUNT(*) FROM Clientes) AS TotalClientes,
                        (SELECT COUNT(*) FROM Empleados) AS TotalEmpleados,
                        (SELECT COUNT(*) FROM Productos) AS TotalProductos,
                        (SELECT ISNULL(SUM(Stock), 0) FROM Productos) AS StockTotal";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            clientes = Convert.ToInt32(reader["TotalClientes"]);
                            empleados = Convert.ToInt32(reader["TotalEmpleados"]);
                            productos = Convert.ToInt32(reader["TotalProductos"]);
                            stock = Convert.ToInt32(reader["StockTotal"]);
                        }
                    }
                }
            }

            return new int[]
            {
                clientes,
                empleados,
                productos,
                stock
            };
        }
    }
}