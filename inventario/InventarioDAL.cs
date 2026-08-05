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

            string SQL = $"INSERT INTO Productos (NombreProducto, Marca, IdCategoria, Precio, Stock, FechaRegistro, Imagen) VALUES('{inv.NombreProducto}', '{inv.Marca}', '{inv.IdCategoria}', {inv.Precio}, {inv.Stock}, GETDATE(), {imagenSQL})";

            return _conexion.EjecutarSQL(SQL);
        }

        public bool Actualizar(Inventario inv)
        {
            string imagenSQL = ConvertirImagenSQL(inv.Imagen);

            string SQL = $"UPDATE Productos SET NombreProducto='{inv.NombreProducto}', Marca='{inv.Marca}', IdCategoria='{inv.IdCategoria}', Precio={inv.Precio}, Stock={inv.Stock}, Imagen={imagenSQL} WHERE IdProducto={inv.IdProducto}";

            return _conexion.EjecutarSQL(SQL);
        }

        public bool Eliminar(int idProducto)
        {
            string SQL = $"DELETE FROM Productos WHERE IdProducto={idProducto}";

            return _conexion.EjecutarSQL(SQL);
        }

        public List<Inventario> Listar()
        {
            List<Inventario> lista = new List<Inventario>();

            string SQL = @"SELECT
                p.IdProducto,
                p.NombreProducto,
                p.Marca,
                c.NombreCategoria,
                p.Precio,
                p.Stock,
                p.Imagen
               FROM Productos p
               INNER JOIN Categorias c
                    ON p.IdCategoria = c.IdCategoria";

            SqlDataReader reader = _conexion.EjecutarConsulta(SQL);

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
            string SQL = "SELECT * FROM Productos";

            return _conexion.EjecutarConsultaDataTable(SQL);
        }

        public List<Inventario> BuscarPorTexto(string criterio)
        {
            List<Inventario> lista = new List<Inventario>();

            string SQL = $@"
                        SELECT
                        p.IdProducto,
                        p.NombreProducto,
                        p.Marca,
                        c.NombreCategoria,
                        p.Precio,
                        p.Stock,
                        p.Imagen
                        FROM Productos p
                        INNER JOIN Categorias c
                        ON p.IdCategoria = c.IdCategoria
                        WHERE
                        CAST(p.IdProducto AS VARCHAR) LIKE '%{criterio}%'
                        OR p.NombreProducto LIKE '%{criterio}%'
                        OR p.Marca LIKE '%{criterio}%'
                        OR c.NombreCategoria LIKE '%{criterio}%'";

            SqlDataReader reader = _conexion.EjecutarConsulta(SQL);

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
                        Imagen = reader.IsDBNull(6) ? null : (byte[])reader[6]
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

            return $"0x{BitConverter.ToString(imagen).Replace("-", "")}";
        }
    }
}