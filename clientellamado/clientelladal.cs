using System;
using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU.Ventas
{
    public class clientelladal
    {
        private Conexion conexionDB = new Conexion();

        public DataTable ListarClientes()
        {
            string query = "SELECT IdCliente, Nombre, Telefono, Correo, Direccion FROM Clientes";
          
            return conexionDB.EjecutarConsultaDataTable(query);
        }

        public DataTable BuscarClientes(string filtro)
        {
            DataTable tabla = new DataTable();

            
            try
            {
                SqlConnection conexion = conexionDB.Abrir();
                string query = "SELECT IdCliente, Nombre, Telefono, Correo, Direccion FROM Clientes WHERE Nombre LIKE '%' + @filtro + '%' OR IdCliente LIKE '%' + @filtro + '%'";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@filtro", filtro);
                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar clientes: ", ex);
            }
            finally
            {
                conexionDB.Cerrar();
            }

            return tabla;
        }
    }
}