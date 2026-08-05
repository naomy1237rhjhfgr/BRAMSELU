using System.Data;

namespace BRAMSELU.llamadoinventario.DAL
{
    public class llamadoinventarioDAL
    {
        public DataTable Listar()
        {
            Conexion conexionBD = new Conexion();

            string query = @"SELECT
                        P.IdProducto,
                        P.NombreProducto,
                        P.Marca,
                        C.NombreCategoria AS Categoria,
                        P.Precio,
                        P.Stock,
                        P.FechaRegistro,
                        P.Imagen,
                        P.IdCategoria
                    FROM Productos P
                    INNER JOIN Categorias C
                        ON P.IdCategoria = C.IdCategoria";

            return conexionBD.EjecutarConsultaDataTable(query);
        }

        public DataTable Buscar(string texto)
        {
            Conexion conexionBD = new Conexion();

            string query = @"SELECT
                        P.IdProducto,
                        P.NombreProducto,
                        P.Marca,
                        C.NombreCategoria AS Categoria,
                        P.Precio,
                        P.Stock,
                        P.FechaRegistro,
                        P.Imagen,
                        P.IdCategoria
                    FROM Productos P
                    INNER JOIN Categorias C
                        ON P.IdCategoria = C.IdCategoria
                    WHERE CAST(P.IdProducto AS VARCHAR) LIKE '%" + texto + @"%'
                       OR P.NombreProducto LIKE '%" + texto + @"%'
                       OR P.Marca LIKE '%" + texto + @"%'
                       OR C.NombreCategoria LIKE '%" + texto + @"%'";

            return conexionBD.EjecutarConsultaDataTable(query);
        }
    }
}