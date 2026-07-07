using System;
using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU
{
    internal class Inventario
    {
        Conexion conexion = new Conexion();

        public DataTable MostrarProductos()
        {
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM Productos";

            SqlDataAdapter da = new SqlDataAdapter(sql, conexion.Abrir());
            da.Fill(dt);

            conexion.Cerrar();

            return dt;
        }

        public DataTable BuscarPorId(int id)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM Productos WHERE IdProducto=@Id";

            SqlCommand cmd = new SqlCommand(sql, conexion.Abrir());
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            conexion.Cerrar();

            return dt;
        }

        public void InsertarProducto(string nombre, string marca,
            string categoria, decimal precio, int stock, byte[] imagen)
        {
            string sql = @"INSERT INTO Productos
                          (NombreProducto,Marca,Categoria,Precio,Stock,Imagen)
                          VALUES
                          (@Nombre,@Marca,@Categoria,@Precio,@Stock,@Imagen)";

            SqlCommand cmd = new SqlCommand(sql, conexion.Abrir());

            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Marca", marca);
            cmd.Parameters.AddWithValue("@Categoria", categoria);
            cmd.Parameters.AddWithValue("@Precio", precio);
            cmd.Parameters.AddWithValue("@Stock", stock);
            cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = (object)imagen ?? DBNull.Value;

            cmd.ExecuteNonQuery();

            conexion.Cerrar();
        }

        public void EditarProducto(int id, string nombre, string marca,
            string categoria, decimal precio, int stock, byte[] imagen)
        {
            string sql = @"UPDATE Productos
                           SET NombreProducto=@Nombre,
                               Marca=@Marca,
                               Categoria=@Categoria,
                               Precio=@Precio,
                               Stock=@Stock,
                               Imagen=@Imagen
                           WHERE IdProducto=@Id";

            SqlCommand cmd = new SqlCommand(sql, conexion.Abrir());

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Marca", marca);
            cmd.Parameters.AddWithValue("@Categoria", categoria);
            cmd.Parameters.AddWithValue("@Precio", precio);
            cmd.Parameters.AddWithValue("@Stock", stock);
            cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = (object)imagen ?? DBNull.Value;

            cmd.ExecuteNonQuery();

            conexion.Cerrar();
        }

        public void EliminarProducto(int id)
        {
            string sql = "DELETE FROM Productos WHERE IdProducto=@Id";

            SqlCommand cmd = new SqlCommand(sql, conexion.Abrir());

            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            conexion.Cerrar();
        }
    }
}