using System.Data;

namespace BRAMSELU.llamadoinventario.DAL
{
    public class llamadoinventarioDAL
    {
        public DataTable Listar()
        {
            Conexion conexionBD = new Conexion();

            string query = "SELECT IdProducto, NombreProducto, Marca, Categoria, Precio, Stock, FechaRegistro, Imagen, IdCategoria FROM Productos";

            return conexionBD.EjecutarConsultaDataTable(query);
        }

        public DataTable Buscar(string texto)
        {
            Conexion conexionBD = new Conexion();

           
            string query = "SELECT IdProducto, NombreProducto, Marca, Categoria, Precio, Stock, FechaRegistro, Imagen, IdCategoria " +
                           "FROM Productos " +
                           "WHERE CAST(IdProducto AS VARCHAR) LIKE '%" + texto + "%' " +
                           "OR NombreProducto LIKE '%" + texto + "%' " +
                           "OR Marca LIKE '%" + texto + "%'";

            return conexionBD.EjecutarConsultaDataTable(query);
        }
    }
}