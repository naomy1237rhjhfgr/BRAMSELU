using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BRAMSELU.Entidades;

namespace BRAMSELU.DAL
{
    public class InventarioDAL
    {
        private Conexion _conexion = new Conexion();

        public bool Guardar(Inventario inv)
        {
            string imagenSQL = ConvertirImagenSQL(inv.Imagen);

            string SQL = $"INSERT INTO Inventario" +
                $"(NombreProducto, Marca, Categoria, Precio, Stock, Imagen) " +
                $"VALUES('{inv.NombreProducto}', '{inv.Marca}', " +
                $"'{inv.Categoria}', {inv.Precio}, {inv.Stock}, {imagenSQL})";

            return _conexion.EjecutarSQL(SQL);
        }

        public bool Actualizar(Inventario inv)
        {
            string imagenSQL = ConvertirImagenSQL(inv.Imagen);

            string SQL = $"UPDATE Inventario SET " +
                $"NombreProducto='{inv.NombreProducto}', " +
                $"Marca='{inv.Marca}', " +
                $"Categoria='{inv.Categoria}', " +
                $"Precio={inv.Precio}, " +
                $"Stock={inv.Stock}, " +
                $"Imagen={imagenSQL} " +
                $"WHERE IdProducto={inv.IdProducto}";

            return _conexion.EjecutarSQL(SQL);
        }

        public bool Eliminar(int idProducto)
        {
            string SQL =
                $"DELETE FROM Inventario WHERE IdProducto={idProducto}";

            return _conexion.EjecutarSQL(SQL);
        }

        public List<Inventario> Listar()
        {
            List<Inventario> lista = new List<Inventario>();

            string SQL = "SELECT * FROM Inventario";

            SqlDataReader reader =
                _conexion.EjecutarConsulta(SQL);

            if (reader != null)
            {
                while (reader.Read())
                {
                    Inventario inv = new Inventario
                    {
                        IdProducto = reader.GetInt32(0),
                        NombreProducto = reader.GetString(1),
                        Marca = reader.GetString(2),
                        Categoria = reader.GetString(3),
                        Precio = reader.GetDecimal(4),
                        Stock = reader.GetInt32(5),
                        Imagen = reader.IsDBNull(6)
                            ? null
                            : (byte[])reader[6]
                    };

                    lista.Add(inv);
                }

                reader.Close();
            }

            return lista;
        }

        public DataTable Mostrar()
        {
            string SQL = "SELECT * FROM Inventario";

            return _conexion.EjecutarConsultaDataTable(SQL);
        }

        public List<Inventario> BuscarPorTexto(string criterio)
        {
            List<Inventario> lista = new List<Inventario>();

            string SQL =
                $"SELECT * FROM Inventario " +
                $"WHERE NombreProducto LIKE '%{criterio}%' " +
                $"OR Marca LIKE '%{criterio}%' " +
                $"OR Categoria LIKE '%{criterio}%'";

            SqlDataReader reader =
                _conexion.EjecutarConsulta(SQL);

            if (reader != null)
            {
                while (reader.Read())
                {
                    Inventario inv = new Inventario
                    {
                        IdProducto = reader.GetInt32(0),
                        NombreProducto = reader.GetString(1),
                        Marca = reader.GetString(2),
                        Categoria = reader.GetString(3),
                        Precio = reader.GetDecimal(4),
                        Stock = reader.GetInt32(5),
                        Imagen = reader.IsDBNull(6)
                            ? null
                            : (byte[])reader[6]
                    };

                    lista.Add(inv);
                }

                reader.Close();
            }

            return lista;
        }

        private string ConvertirImagenSQL(byte[] imagen)
        {
            if (imagen == null)
                return "NULL";

            return "0x" + BitConverter
                .ToString(imagen)
                .Replace("-", "");
        }
    }
}