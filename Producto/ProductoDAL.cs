using System;
using System.Data;
using System.Data.SqlClient;
using BRAMSELU.Productos.Modelos;

namespace BRAMSELU.Productos.DAL
{
    public class ProductoDAL
    {
        private Conexion conexionDB = new Conexion();

        public DataTable Listar()
        {
            string query = "SELECT IdProducto, NombreProducto, Marca, Categoria, Precio, Stock, FechaRegistro, Imagen, IdCategoria FROM Productos";
            return conexionDB.EjecutarConsultaDataTable(query);
        }

        public bool Insertar(Producto prod)
        {
            string query = "INSERT INTO Productos (NombreProducto, Marca, Categoria, Precio, Stock, FechaRegistro, Imagen, IdCategoria) " +
                           "VALUES (@Nombre, @Marca, @Categoria, @Precio, @Stock, @Fecha, @Imagen, @IdCat)";

            using (SqlConnection cn = conexionDB.Abrir())
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", prod.NombreProducto);
                    cmd.Parameters.AddWithValue("@Marca", prod.Marca);
                    cmd.Parameters.AddWithValue("@Categoria", prod.Categoria);
                    cmd.Parameters.AddWithValue("@Precio", prod.Precio);
                    cmd.Parameters.AddWithValue("@Stock", prod.Stock);
                    cmd.Parameters.AddWithValue("@Fecha", prod.FechaRegistro);
                    cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = (object)prod.Imagen ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@IdCat", (object)prod.IdCategoria ?? DBNull.Value);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    conexionDB.Cerrar();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool Actualizar(Producto prod)
        {
            string query = "UPDATE Productos SET NombreProducto = @Nombre, Marca = @Marca, Categoria = @Categoria, " +
                           "Precio = @Precio, Stock = @Stock, Imagen = @Imagen, IdCategoria = @IdCat WHERE IdProducto = @Id";

            using (SqlConnection cn = conexionDB.Abrir())
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", prod.IdProducto);
                    cmd.Parameters.AddWithValue("@Nombre", prod.NombreProducto);
                    cmd.Parameters.AddWithValue("@Marca", prod.Marca);
                    cmd.Parameters.AddWithValue("@Categoria", prod.Categoria);
                    cmd.Parameters.AddWithValue("@Precio", prod.Precio);
                    cmd.Parameters.AddWithValue("@Stock", prod.Stock);
                    cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = (object)prod.Imagen ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@IdCat", (object)prod.IdCategoria ?? DBNull.Value);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    conexionDB.Cerrar();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool Eliminar(int idProducto)
        {
            string query = "DELETE FROM Productos WHERE IdProducto = @Id";

            using (SqlConnection cn = conexionDB.Abrir())
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", idProducto);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    conexionDB.Cerrar();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}